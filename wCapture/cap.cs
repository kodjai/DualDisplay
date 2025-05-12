using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PvDotNet;
using PvGUIDotNet;

namespace wCapture
{
    public partial class cap : Form
    {
        public cap()
        {
            InitializeComponent();
        }

        private const UInt16 cBufferCount = 16;

        private PvDevice mDevice0 = null;            
        private PvDevice mDevice1 = null;           


        private PvStream mStream0 = null;
        private PvStream mStream1 = null;

        private PvPipeline mPipeline0 = null;
        private PvPipeline mPipeline1 = null;

        private Thread mThread0 = null;
        private Thread mThread1 = null;

        private bool mIsStopping0 = false;
        private bool mIsStopping1 = false;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            PvDeviceFinderForm ConnectForm = new PvDeviceFinderForm();          
            if ((ConnectForm.ShowDialog() == DialogResult.OK) && (ConnectForm.Selected != null))
            {
                try
                {
                    PvDeviceInfo lDeviceInfo = ConnectForm.Selected as PvDeviceInfo;            

                    // Create and connect device.
                    mDevice0 = PvDevice.CreateAndConnect(lDeviceInfo);                           

                    // Create and Open stream.
                    mStream0 = PvStream.CreateAndOpen(lDeviceInfo);                              

                    // Create pipeline.
                    mPipeline0 = new PvPipeline(mStream0);                                        
                }
                catch (PvException ex)
                {

                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            
            btnConfigure.Enabled = true;
        }


        private void btnConfigure_Click(object sender, EventArgs e)
        {
            btnConfigure.Enabled = false;
            try
            {
                // Perform GigE Vision only configuration
                PvDeviceGEV lDGEV = mDevice0 as PvDeviceGEV;
                if (lDGEV != null)
                {
                    // Negotiate packet size    
                    lDGEV.NegotiatePacketSize();

                    // Set stream destination.  
                    PvStreamGEV lSGEV = mStream0 as PvStreamGEV;
                    lDGEV.SetStreamDestination(lSGEV.LocalIPAddress, lSGEV.LocalPort);
                }

                // Perform GigE Vision only configuration  
                // Read payload size, set buffer size the pipeline will use to allocate buffers. 
                mPipeline0.BufferSize = mDevice0.PayloadSize;

                // Set buffer count. Use more buffers (at expense of using more memory) to eliminate missing block IDs.
                mPipeline0.BufferCount = cBufferCount;

            }
            catch (PvException ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            btnStartstream.Enabled = true;
        }


        private void btnStartstream_Click(object sender, EventArgs e)
        {
            btnStartstream.Enabled = false;
            mIsStopping0 = false;
            //mDevice0.Parameters.SetIntegerValue("TLParamsLocked", 1);  

            mPipeline0.Start();

            // Start display thread.                                
            mThread0 = new Thread(new ParameterizedThreadStart(ThreadProc));
            cap lP1 = this;
            object[] lParameters = new object[] { lP1 };
         
            mThread0.Start(lParameters);

            // Enables streaming before sending the AcquisitionStart command.
            mDevice0.StreamEnable();

            // Start acquisition on the device.
            mDevice0.Parameters.ExecuteCommand("AcquisitionStart");

            //refreshTimer.Start();
            btnStopstream.Enabled = true;
        }

        private static void ThreadProc(object aParameters)
        {
            object[] lParameters = (object[])aParameters;
            cap lThis = (cap)lParameters[0];

            PvBuffer lBuffer = null;



            for (; ;)
            {

                if (lThis.mIsStopping0)
                {
                    // Signaled to terminate thread, return.
                    return;
                }
                // Retrieve next buffer from acquisition pipeline.
                PvResult lResult = lThis.mPipeline0.RetrieveNextBuffer(ref lBuffer);
                if (lResult.IsOK)
                {
                    // Operation result of buffer is OK, display.
                    if (lBuffer.OperationResult.IsOK)
                    {
                        lThis.displayControl.Display(lBuffer);
                    }

                    // We got a buffer (good or not) we must release it back.
                    lThis.mPipeline0.ReleaseBuffer(lBuffer);
                }
            }
        }

        private static void ThreadProc1(object aParameters)
        {
            object[] lParameters = (object[])aParameters;
            cap lThis = (cap)lParameters[0];

            PvBuffer lBuffer = null;



            for (; ; )
            {

                if (lThis.mIsStopping1)
                {
                    // Signaled to terminate thread, return.
                    return;
                }
                // Retrieve next buffer from acquisition pipeline.
                PvResult lResult = lThis.mPipeline1.RetrieveNextBuffer(ref lBuffer);
                if (lResult.IsOK)
                {
                    // Operation result of buffer is OK, display.
                    if (lBuffer.OperationResult.IsOK)
                    {
                        lThis.displayControl1.Display(lBuffer);
                    }

                    // We got a buffer (good or not) we must release it back.
                    lThis.mPipeline1.ReleaseBuffer(lBuffer);
                }
            }
        }

        private void btnStopstream_Click(object sender, EventArgs e)
        {
            //mDevice0.Parameters.SetIntegerValue("TLParamsLocked", 0);
            //refreshTimer.Stop();
            btnStopstream.Enabled = false;
            mIsStopping0 = false;
            // Stop acquisition. 
            mDevice0.Parameters.ExecuteCommand("AcquisitionStop"); //ExecuteCommand("AcquisitionStop");
            // Disable streaming after sending the AcquisitionStop command. 
            mDevice0.StreamDisable();

            // Stop the pipeline.
            mPipeline0.Stop();

            // Stop display thread.
            mIsStopping0 = true;
            mThread0.Join();
            mThread0 = null;
            btnDisconnect.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            if (mStream0 != null)
            {
                // Close and release stream
                mStream0.Close();
                mStream0 = null;
            }

            if (mDevice0 != null)
            {
                // Disconnect and release device
                mDevice0.Disconnect();
                mDevice0 = null;
            }
            btnConnect.Enabled = true;
        }

        private void refresh_timer_Tick(object sender, EventArgs e)
        {
            PvGenParameterArray lStreamParams = mStream0.Parameters;
            PvGenParameterArray lStreamParams1 = mStream1.Parameters;
            lStreamParams.InvalidateCache();
            lStreamParams1.InvalidateCache();
        }

        private void btnConnect1_Click(object sender, EventArgs e)
        {
            btnConnect1.Enabled = false;
            PvDeviceFinderForm ConnectForm = new PvDeviceFinderForm();          
            if ((ConnectForm.ShowDialog() == DialogResult.OK) && (ConnectForm.Selected != null))
            {
                try
                {
                     //获得所选设备参数
                    PvDeviceInfo lDeviceInfo1 = ConnectForm.Selected as PvDeviceInfo;

                    // Create and connect device.                         
                    mDevice1 = PvDevice.CreateAndConnect(lDeviceInfo1);

                    // Create and Open stream.                        
                    mStream1 = PvStream.CreateAndOpen(lDeviceInfo1);

                    // Create pipeline.                               
                    mPipeline1 = new PvPipeline(mStream1);
                }
                catch (PvException ex)
                {

                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

            btnConfigure1.Enabled = true;
        }



        private void btnConfigure1_Click(object sender, EventArgs e)
        {
            btnConfigure1.Enabled = false;
            try
            {

                // Perform GigE Vision only configuration   
                PvDeviceGEV lDGEV1 = mDevice1 as PvDeviceGEV;
                if (lDGEV1 != null)
                {
                    // Negotiate packet size    
                    lDGEV1.NegotiatePacketSize();

                    // Set stream destination.  
                    PvStreamGEV lSGEV = mStream1 as PvStreamGEV;
                    lDGEV1.SetStreamDestination(lSGEV.LocalIPAddress, lSGEV.LocalPort);
                }

                // Read payload size, set buffer size the pipeline will use to allocate buffers. 

                mPipeline1.BufferSize = mDevice1.PayloadSize;

                // Set buffer count. Use more buffers (at expense of using more memory) to eliminate missing block IDs.

                mPipeline1.BufferCount = cBufferCount;
            }
            catch (PvException ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            btnStartstream1.Enabled = true;
        }

        private void btnStartstream1_Click(object sender, EventArgs e)
        {
            btnStartstream1.Enabled = false;
            mIsStopping1 = false;
            //mDevice0.Parameters.SetIntegerValue("TLParamsLocked", 1);  

            mPipeline1.Start();

            // Start display thread.                                
            mThread1 = new Thread(new ParameterizedThreadStart(ThreadProc1));
            cap lP1 = this;
            object[] lParameters = new object[] { lP1 };

            mThread1.Start(lParameters);

            // Enables streaming before sending the AcquisitionStart command.
            mDevice1.StreamEnable();

            // Start acquisition on the device.
            mDevice1.Parameters.ExecuteCommand("AcquisitionStart");

            //refreshTimer.Start();
            btnStopstream1.Enabled = true;
        }

        private void btnStopstream1_Click(object sender, EventArgs e)
        {
            //mDevice0.Parameters.SetIntegerValue("TLParamsLocked", 0);
            //refreshTimer.Stop();
            btnStopstream1.Enabled = false;
            mIsStopping1 = false;
            // Stop acquisition. 
             //ExecuteCommand("AcquisitionStop");
            mDevice1.Parameters.ExecuteCommand("AcquisitionStop");
            // Disable streaming after sending the AcquisitionStop command. 
            mDevice1.StreamDisable();

            // Stop the pipeline.
            mPipeline1.Stop();

            // Stop display thread.
            mIsStopping1 = true;
            mThread1.Join();
            mThread1 = null;
            btnDisconnect1.Enabled = true;
        }

        private void btnDisconnect1_Click(object sender, EventArgs e)
        {
            btnDisconnect1.Enabled = false;
            if (mStream1 != null)
            {
                // Close and release stream
                mStream1.Close();
                mStream1 = null;
            }

            if (mDevice1 != null)
            {
                // Disconnect and release device
                mDevice1.Disconnect();
                mDevice1 = null;
            }
            btnConnect1.Enabled = true;
        }


    }
}