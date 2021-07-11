//#define USE_CALL_BACK

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HalconDotNet;
using MVSDK;
using CameraHandle = System.Int32;
using MvApi = MVSDK.MvApi;



namespace _20191114A_CameraSDK
{
    public partial class FormMindVision : Form
    {
        protected CameraHandle m_hCamera = 0;             // 句柄
        protected IntPtr m_ImageBuffer;             // 预览通道RGB图像缓存
        protected IntPtr m_ImageBufferSnapshot;     // 抓拍通道RGB图像缓存
        protected tSdkCameraCapbility tCameraCapability;  // 相机特性描述
        protected int m_iDisplayedFrames = 0;    //已经显示的总帧数
        protected CAMERA_SNAP_PROC m_CaptureCallback;
        protected IntPtr m_iCaptureCallbackCtx;     //图像回调函数的上下文参数
        protected Thread m_tCaptureThread;          //图像抓取线程
        protected bool m_bExitCaptureThread = false;//采用线程采集时，让线程退出的标志
        protected IntPtr m_iSettingPageMsgCallbackCtx; //相机配置界面消息回调函数的上下文参数   
        protected tSdkFrameHead m_tFrameHead;
        //protected SnapshotDlg m_DlgSnapshot = new SnapshotDlg();               //显示抓拍图像的窗口
        protected bool m_bEraseBk = false;
        protected bool m_bSaveImage = false;//保存一张图的flag
        string savePath = null; //保存图片的路径 
        bool bCamOpen = false;  //相机开启状态

        //Halcon Value
        HTuple hv_WindowHandle = null;
        HObject ho_Image = null, ho_ImageRotate=null;



        public FormMindVision()
        {
            InitializeComponent();
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            if (bCamOpen==false)
            {
                if (InitCamera() == true)
                {
                    MvApi.CameraPlay(m_hCamera);  //播放
                    bOpen.Text = "关闭相机";
                    bCamOpen = true;

                }
            }
            else
            {
                MvApi.CameraPause(m_hCamera);
                bOpen.Text = "打开相机";
                bCamOpen = false;
            }
            

        }

 



        private void FormMindVision_Load(object sender, EventArgs e)
        {
            //设置Halcon窗口
            HOperatorSet.OpenWindow(0, 0, pictureBox2.Width, pictureBox2.Height,
                pictureBox2.Handle, "visible", "", out hv_WindowHandle);
            HDevWindowStack.Push(hv_WindowHandle); //窗口放到堆栈    
        }

        private bool InitCamera()
        {
            CameraSdkStatus status;
            tSdkCameraDevInfo[] tCameraDevInfoList;
            IntPtr ptr;
            int i;
            if (m_hCamera > 0)
            {
                //已经初始化过，直接返回 true

                return true;
            }

            status = MvApi.CameraEnumerateDevice(out tCameraDevInfoList);
            if (status == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
            {
                if (tCameraDevInfoList != null)//此时iCameraCounts返回了实际连接的相机个数。如果大于1，则初始化第一个相机
                {
                    status = MvApi.CameraInit(ref tCameraDevInfoList[0], -1, -1, ref m_hCamera);
                    if (status == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
                    {
                        //获得相机特性描述
                        MvApi.CameraGetCapability(m_hCamera, out tCameraCapability);
                        m_ImageBuffer = Marshal.AllocHGlobal(tCameraCapability.sResolutionRange.iWidthMax * tCameraCapability.sResolutionRange.iHeightMax * 3 + 1024);
                        m_ImageBufferSnapshot = Marshal.AllocHGlobal(tCameraCapability.sResolutionRange.iWidthMax * tCameraCapability.sResolutionRange.iHeightMax * 3 + 1024);

                        if (tCameraCapability.sIspCapacity.bMonoSensor != 0)
                        {
                            // 黑白相机输出8位灰度数据
                            MvApi.CameraSetIspOutFormat(m_hCamera, (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);
                        }

                       // MvApi.CameraSetIspOutFormat(m_hCamera, (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);

                        //初始化显示模块，使用SDK内部封装好的显示接口
                        MvApi.CameraDisplayInit(m_hCamera, pictureBox1.Handle);
                        MvApi.CameraSetDisplaySize(m_hCamera, pictureBox1.Width, pictureBox1.Height);

                        ////设置抓拍通道的分辨率。
                        //tSdkImageResolution tResolution;
                        //tResolution.uSkipMode = 0;
                        //tResolution.uBinAverageMode = 0;
                        //tResolution.uBinSumMode = 0;
                        //tResolution.uResampleMask = 0;
                        //tResolution.iVOffsetFOV = 0;
                        //tResolution.iHOffsetFOV = 0;
                        //tResolution.iWidthFOV = tCameraCapability.sResolutionRange.iWidthMax;
                        //tResolution.iHeightFOV = tCameraCapability.sResolutionRange.iHeightMax;
                        //tResolution.iWidth = tResolution.iWidthFOV;
                        //tResolution.iHeight = tResolution.iHeightFOV;
                        //tResolution.iIndex = 0xff;表示自定义分辨率,如果tResolution.iWidth和tResolution.iHeight
                        //定义为0，则表示跟随预览通道的分辨率进行抓拍。抓拍通道的分辨率可以动态更改。
                        //本例中将抓拍分辨率固定为最大分辨率。
                        //tResolution.iIndex = 0xff;
                        //tResolution.acDescription = new byte[32];//描述信息可以不设置
                        //tResolution.iWidthZoomHd = 0;
                        //tResolution.iHeightZoomHd = 0;
                        //tResolution.iWidthZoomSw = 0;
                        //tResolution.iHeightZoomSw = 0;

                        //MvApi.CameraSetResolutionForSnap(m_hCamera, ref tResolution);

                        //让SDK来根据相机的型号动态创建该相机的配置窗口。
                        //MvApi.CameraCreateSettingPage(m_hCamera, this.Handle, tCameraDevInfoList[0].acFriendlyName,/*SettingPageMsgCalBack*/null,/*m_iSettingPageMsgCallbackCtx*/(IntPtr)null, 0);

                        //两种方式来获得预览图像，设置回调函数或者使用定时器或者独立线程的方式，
                        //主动调用CameraGetImageBuffer接口来抓图。
                        //本例中仅演示了两种的方式,注意，两种方式也可以同时使用，但是在回调函数中，
                        //不要使用CameraGetImageBuffer，否则会造成死锁现象。
                        //如果需要采用多线程，使用下面的方式
                        m_bExitCaptureThread = false;
                        m_tCaptureThread = new Thread(new ThreadStart(CaptureThreadProc));
                        //m_tCaptureThread.IsBackground = true;
                        m_tCaptureThread.Start();


                        //MvApi.CameraReadSN 和 MvApi.CameraWriteSN 用于从相机中读写用户自定义的序列号或者其他数据，32个字节
                        //MvApi.CameraSaveUserData 和 MvApi.CameraLoadUserData用于从相机中读取自定义数据，512个字节
                        return true;

                    }
                    else
                    {
                        m_hCamera = 0;
                        //StateLabel.Text = "Camera init error";
                        String errstr = string.Format("相机初始化错误，错误码{0},错误原因是", status);
                        String errstring = MvApi.CameraGetErrorString(status);
                        // string str1 
                        MessageBox.Show(errstr + errstring, "ERROR");
                        Environment.Exit(0);
                        return false;
                    }


                }
            }
            else
            {
                MessageBox.Show("没有找到相机，如果已经接上相机，可能是权限不够，请尝试使用管理员权限运行程序。");
                Environment.Exit(0);
            }

            return false;

        }

     
        private void Convert2HalconImageImage3()
        {

        }

        public void CaptureThreadProc()
        {
            CameraSdkStatus eStatus;
            tSdkFrameHead FrameHead;
            IntPtr uRawBuffer;//rawbuffer由SDK内部申请。应用层不要调用delete之类的释放函数

            while (m_bExitCaptureThread == false)
            {
                //500毫秒超时,图像没捕获到前，线程会被挂起,释放CPU，所以该线程中无需调用sleep
                eStatus = MvApi.CameraGetImageBuffer(m_hCamera, out FrameHead, out uRawBuffer, 500);

                if (eStatus == CameraSdkStatus.CAMERA_STATUS_SUCCESS)//如果是触发模式，则有可能超时
                {
                    //图像处理，将原始输出转换为RGB格式的位图数据，同时叠加白平衡、饱和度、LUT等ISP处理。
                    MvApi.CameraImageProcess(m_hCamera, uRawBuffer, m_ImageBuffer, ref FrameHead); 
                    //这里转成的m_ImageBuffer可以用imageInterleave转Halcon
// [in] hCamera 相机的句柄。  
//[in] pbyIn 输入图像数据的缓冲区地址，不能为NULL。  
//[out] pbyOut 处理后图像输出的缓冲区地址，不能为NULL。  
//[in,out] pFrInfo 输入图像的帧头信息，处理完成后，帧头信息中的图像格式uiMediaType会随之改变。  

                    //叠加十字线、自动曝光窗口、白平衡窗口信息(仅叠加设置为可见状态的)。    
                    //MvApi.CameraImageOverlay(m_hCamera, m_ImageBuffer, ref FrameHead);
                    //调用SDK封装好的接口，显示预览图像
                    MvApi.CameraDisplayRGB24(m_hCamera, m_ImageBuffer, ref FrameHead); //只是显示
                    
                    
                    //转成Halcon Image,Convert2HalconImageImageInterleave

                    try
                    {
                        HOperatorSet.GenImageInterleaved(out ho_Image, m_ImageBuffer, "bgr", FrameHead.iWidth, FrameHead.iHeight,
                       -1, "byte", FrameHead.iWidth, FrameHead.iHeight,
                       0, 0, -1, 0);
                        //HOperatorSet.GenImage1(out ho_Image, "byte", FrameHead.iWidth, FrameHead.iHeight, m_ImageBuffer);
                        //HOperatorSet.GenImage1(out Image, "byte", w, h, pFrameBuffer);

                        //显示
                        HOperatorSet.SetPart(hv_WindowHandle, 0, 0, FrameHead.iHeight, FrameHead.iWidth);
                        // HOperatorSet.RotateImage(ho_Image,out ho_ImageRotate, 180, "constant");
                        HOperatorSet.MirrorImage(ho_Image, out ho_ImageRotate, "row");
                        HOperatorSet.DispObj(ho_ImageRotate, hv_WindowHandle);
                        ho_Image.Dispose();
                        ho_ImageRotate.Dispose();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                   
                    //---------------------------------------



                    //成功调用CameraGetImageBuffer后必须释放，下次才能继续调用CameraGetImageBuffer捕获图像。
                    MvApi.CameraReleaseImageBuffer(m_hCamera, uRawBuffer);

                    if (FrameHead.iWidth != m_tFrameHead.iWidth || FrameHead.iHeight != m_tFrameHead.iHeight)
                    {
                        m_bEraseBk = true;
                        m_tFrameHead = FrameHead;
                    }

                    //m_iDisplayedFrames++;


                    //保存图片
                    if (m_bSaveImage)  
                    {
                        MvApi.CameraSaveImage(m_hCamera, savePath, m_ImageBuffer, ref FrameHead, emSdkFileType.FILE_BMP, 100);
                       // MvApi.CameraSaveImage(m_hCamera, "c:\\test.bmp", m_ImageBuffer, ref FrameHead, emSdkFileType.FILE_BMP, 100);
                        m_bSaveImage = false;
                    }


                   // Marshal.FreeHGlobal(m_ImageBuffer); //释放内存,这句不能加，加了会报错！下面再来访问这个内存就不行了，要重新分配。
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
        }

        private void bSaveImage_Click(object sender, EventArgs e)
        {
            //保存截图
            SaveFileDialog sFD = new SaveFileDialog();
            if (sFD.ShowDialog()==DialogResult.OK)
            {
                savePath = sFD.FileName;
                m_bSaveImage = true;
            }

        }

        private void FormMindVision_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Environment.Exit(0);  //会把整个窗口都关了，不能这么用
            //m_bExitCaptureThread = true;
            //  m_tCaptureThread.Interrupt(); //用interrupt不会报错，用abort会报错！
            //m_tCaptureThread.Join(); //会停止住不动！！

            //等待m_tCaptureThread运行完再关闭线程
            //if (m_hCamera>0)
            //{
            //    m_bExitCaptureThread = true;
            //    while (m_tCaptureThread.IsAlive)
            //    {
            //        Thread.Sleep(10); //这一帧完全运行完，主程序才退出！
            //    }
            //}

            //----------------------------------------------


            //相机1反初始化
            //if (m_tCaptureThread != null)
            //{
            //    m_bExitCaptureThread = true;
            //    Thread.Sleep(100); //等完全运行完！
            //  // m_tCaptureThread.Interrupt();
            //    m_tCaptureThread = null;
            //}

            //if (m_ImageBuffer != IntPtr.Zero)
            //{
            //    Marshal.FreeHGlobal(m_ImageBuffer);
            //    m_ImageBuffer = IntPtr.Zero;
            //}

            m_bExitCaptureThread = true;
            Thread.Sleep(50); //等运行完！！！
            MvApi.CameraPause(m_hCamera);
            if (m_hCamera != 0)
            {
                MvApi.CameraUnInit(m_hCamera);
                m_hCamera = 0;
            }

        }
    }
}
