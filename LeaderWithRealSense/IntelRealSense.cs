using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using Intel.RealSense;
using System.Windows;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV;
using System.IO;
using System.Runtime.InteropServices;
using HalconDotNet;

namespace LeaderWithRealSense
{
    public class IntelRealSense
    {
        Pipeline Camera = new Pipeline();
        PipelineProfile PipelineProfile;
        StreamProfile sp;
        VideoStreamProfile vsp;
        AdvancedDevice adev;

        Colorizer colorizer = new Colorizer();
        Config cfg = new Config();
        //Align align = new Align(Stream.Color);  // 深度影像MAP彩色影像D415所使用
        VideoFrame depColor = null;
        VideoFrame filteredColor = null;   

        public Intrinsics intrinsics;
        Extrinsics extrinsics;

        DecimationFilter dec_Filter = new DecimationFilter();
        SpatialFilter Spa_Filter = new SpatialFilter();
        TemporalFilter Temp_Filter = new TemporalFilter();
        HoleFillingFilter HoleFill_Filter = new HoleFillingFilter();
        ThresholdFilter Thres_Filter = new ThresholdFilter();

        /// <summary>
        /// 相機連結狀態
        /// </summary>
        enum CameraState
        {
            Disconnected = 0,
            Connected = 1,
            Opened = 2
        }
        CameraState CamState = CameraState.Disconnected;  // 初始狀態設為斷線

        /// <summary>
        /// 初始化設定並連接RealSense相機
        /// </summary>
        internal void Connect()
        {
            DeviceList DeviceList = new Context().QueryDevices(); // Get a snapshot of currently connected devices
            if (DeviceList.Count == 0)
                throw new Exception("No device detected. Is it plugged in?");
            else if (CamState == CameraState.Disconnected)
            {
                for(int i = 0; i < DeviceList.Count; i++)
                {
                    adev = AdvancedDevice.FromDevice(DeviceList[i]);
                    cfg.EnableStream(Intel.RealSense.Stream.Depth, 1280, 720, Format.Z16, 30);
                    cfg.EnableStream(Intel.RealSense.Stream.Color, 1280, 720, Format.Bgr8);
                    Console.WriteLine("相機型號為：" + adev.Info[CameraInfo.Name] + "\n目前傳輸介面：" + adev.Info[CameraInfo.UsbTypeDescriptor], "相機連接成功！");
                    CamState = CameraState.Connected;
                    using (StreamReader sr = new StreamReader(@"D:\project\C#\LeaderWithRealSense\LeaderWithRealSense\setting.json"))
                    ////using (StreamReader sr = new StreamReader(@"C:\Users\EL404\Desktop\LabData\Realsense物件3D重建與模型訓練\Pre-Processing.json"))
                    ////using (StreamReader sr = new StreamReader(@"C:\Users\EL404\Desktop\LabData\Realsense物件3D重建與模型訓練\NewPreProcessing.json"))
                    {
                        string line = sr.ReadToEnd();
                        adev.JsonConfiguration = line;
                    }
                }
            }
        }
        
        /// <summary>
        /// 開啟RealSense相機並進行取像
        /// </summary>
        internal void Open(out Image<Bgr, byte> ColorImg,
                           out Image<Rgb, byte> DepthImg, 
                           out Image<Rgb, byte> FilteredImg, 
                           out VideoFrame color, 
                           out DepthFrame depth, 
                           out Frame filtered)
        {
            DepthImg = null; ColorImg = null; FilteredImg = null; color = null; depth = null; filtered = null;
            if (CamState != CameraState.Opened)
            {
                PipelineProfile = Camera.Start(cfg);  // 以cfg設定並開始串流
                vsp = PipelineProfile.GetStream<VideoStreamProfile>(Intel.RealSense.Stream.Depth);  // 取得內部參數
                intrinsics = vsp.GetIntrinsics();
                sp = PipelineProfile.GetStream(Intel.RealSense.Stream.Color);  // 取得外部參數
                extrinsics = vsp.GetExtrinsicsTo(sp);
                CamState = CameraState.Opened;  // 更新相機狀態
            }
            else
            {
                try
                {
                    FrameSet frames = Camera.WaitForFrames();
                    depth = frames.DepthFrame.DisposeWith(frames);
                    color = frames.ColorFrame.DisposeWith(frames);
                    filtered = depth;
                    if (depth != null)
                    {
                        //Thres_Filter.Options[Option.MinDistance].Value = float.Parse(form1.textBox2.Text);
                        //Thres_Filter.Options[Option.MaxDistance].Value = float.Parse(form1.textBox1.Text);
                        //filtered = Thres_Filter.Process(filtered);

                        //Spa_Filter.Options[Option.FilterMagnitude].Value = 1;
                        //Spa_Filter.Options[Option.FilterSmoothAlpha].Value = 0.6f;
                        //Spa_Filter.Options[Option.FilterSmoothDelta].Value = 8;
                        //filtered = Spa_Filter.Process(filtered);

                        Temp_Filter.Options[Option.FilterSmoothAlpha].Value = 0.5f;
                        Temp_Filter.Options[Option.FilterSmoothDelta].Value = 20;
                        Temp_Filter.Options[Option.HolesFill].Value = 2;
                        filtered = Temp_Filter.Process(filtered);
                        
                        depColor = colorizer.Colorize(depth);
                        filteredColor = colorizer.Colorize(filtered);

                        ColorImg = new Image<Bgr, byte>(color.Width, color.Height, color.Stride, color.Data);
                        DepthImg = new Image<Rgb, byte>(depColor.Width, depColor.Height, depColor.Stride, depColor.Data);
                        FilteredImg = new Image<Rgb, byte>(filteredColor.Width, filteredColor.Height, filteredColor.Stride, filteredColor.Data);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 停止取像並關閉相機
        /// </summary>
        internal void Close()
        {
            Camera.Stop();
            CamState = CameraState.Connected;
        }

        internal int GetCameraState()
        {
            return (int)CamState;
        }

        /// <summary>
        /// 將深度與彩色影像直接轉換成點雲並輸出.ply檔
        /// </summary>
        internal void DepthToPLY(VideoFrame color, DepthFrame depth)
        {
            using (PointCloud pc = new PointCloud())
            {
                pc.MapTexture(color);  // Tell pointcloud object to map to this color frame
                using (Points points = pc.Calculate(depth))  // Generate the pointcloud and texture mappings
                    points.ExportToPLY("C:/Users/EL125/Desktop/testest.ply", color);
            }
        }

        /// <summary>
        /// 將1D-Depth Value陣列轉換為3D世界座標陣列
        /// </summary>
        /// <param name="DepVal">1D-ushort深度值陣列</param>
        /// <returns></returns>
        internal float[,,] DepthValueToXYZ(ushort[] DepVal)
        {
            if (DepVal == null) return null;
            int w = vsp.Width;  // 1280
            int h = vsp.Height;  // 720
            float scale = Camera.ActiveProfile.Device.Sensors[0].DepthScale;
            float dist;
            float[] pixel = new float[2];  // 當前深度影像座標暫存
            float[] pointset = new float[3];  // 世界座標暫存
            float[,,] WorldCoor = new float[h, w, 3];  // 3維世界座標陣列
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    pixel[0] = j;
                    pixel[1] = i;
                    dist = DepVal[i * w + j] * scale;  // 單位：m
                    pointset = rs2_deproject_pixel_to_point(intrinsics, pixel, dist);
                    WorldCoor[i, j, 0] = pointset[0];
                    WorldCoor[i, j, 1] = pointset[1];
                    WorldCoor[i, j, 2] = pointset[2];
                }
            }
            return WorldCoor;
        }

        /// <summary>
        /// 將2D-Depth Value陣列轉換為3D世界座標陣列
        /// </summary>
        /// <param name="DepVal">2D-ushort深度值陣列</param>
        /// <returns></returns>
        internal float[,,] DepthValueToXYZ(ushort[,] DepVal)
        {
            if (DepVal == null) return null;
            int w = vsp.Width;  // 1280
            int h = vsp.Height;  // 720
            float scale = Camera.ActiveProfile.Device.Sensors[0].DepthScale;
            float dist;
            float[] pixel = new float[2];  // 當前深度影像座標暫存
            float[] pointset = new float[3];  // 世界座標暫存
            float[,,] WorldCoor = new float[h, w, 3];  // 3維世界座標陣列
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    pixel[0] = j;
                    pixel[1] = i;
                    dist = DepVal[i, j] * scale;  // 單位：m
                    pointset = rs2_deproject_pixel_to_point(intrinsics, pixel, dist);
                    WorldCoor[i, j, 0] = pointset[0];
                    WorldCoor[i, j, 1] = pointset[1];
                    WorldCoor[i, j, 2] = pointset[2];
                }
            }
            return WorldCoor;
        }

        private HImage dataToHimage(float[] data, int imageWidth, int imageHeight)
        {
            unsafe
            {
                fixed (float* p = data)
                {
                    HImage img = new HImage("real", imageWidth, imageHeight, new IntPtr(p));
                    //img.GenImage1("ushort", imageWidth, imageHeight, new IntPtr(p));
                    return img;
                }
            }
        }

        /// <summary>
        /// 將3D世界座標陣列轉存為TIFF
        /// </summary>
        /// <param name="WorldCoor">3D世界座標陣列[h, w, 3]</param>
        /// <param name="filename">檔案名稱</param>
        internal void saveTIFF(float[,,] WorldCoor, string filename)
        {
            int h = WorldCoor.GetLength(0);
            int w = WorldCoor.GetLength(1);
            float[] tempX = new float[w * h];
            float[] tempY = new float[w * h];
            float[] tempZ = new float[w * h];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    tempX[i * w + j] = WorldCoor[i, j, 0];
                    tempY[i * w + j] = WorldCoor[i, j, 1];
                    tempZ[i * w + j] = WorldCoor[i, j, 2];
                }
            }
            HImage himgX = dataToHimage(tempX, w, h);
            HImage himgY = dataToHimage(tempY, w, h);
            HImage himgZ = dataToHimage(tempZ, w, h);
            HImage hhh = himgX.Compose3(himgY, himgZ);
            if (filename.Contains(".ply"))
                filename = filename.Replace(".ply", ".tiff");
            hhh.WriteImage("tiff", 0, filename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DepVal"></param>
        internal void ushortToPLY(ushort[,] DepVal, string filename)
        {
            if (DepVal != null)
            {
                float[,,] WorldCoor = DepthValueToXYZ(DepVal);  // 深度ushort轉XYZ
                int h = vsp.Height;
                int w = vsp.Width;
                //string[] coorStr = new string[w * h * 3];  // XYZ座標值string陣列
                List<string> coorStr = new List<string>();
                for (int i = 0; i < h; i++)
                    for (int j = 0; j < w; j++)
                    {
                        if (WorldCoor[i, j, 0] == 0 || WorldCoor[i, j, 1] == 0 || WorldCoor[i, j, 2] == 0)  // 去除x,y,z為0的元素
                            continue;
                        for (int k = 0; k < 3; k++)
                            //coorStr[i * w * 3 + j * 3 + k] = WorldCoor[j, i, k].ToString();
                            coorStr.Add(WorldCoor[i, j, k].ToString());
                    }
                saveTIFF(WorldCoor, filename);
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    string[] header = {
                    "ply\n",
                    "format ascii 1.0\n",
                    "element vertex " + coorStr.Count/3 + "\n",
                    "property float32 x\n",
                    "property float32 y\n",
                    "property float32 z\n",
                    "end_header\n"
                    };
                    for (int i = 0; i < header.Length; i++)
                        sw.Write(header[i]);
                    for (int i = 1; i <coorStr.Count + 1; i++)
                    {
                        sw.Write(coorStr[i - 1] + " ");
                        if (i % 3 == 0) sw.WriteLine();
                    }
                    sw.Close();
                }
            }
        }

        internal void xyzToPLY(float[,,] xyzmap, string filename)
        {
            if (xyzmap != null)
            {
                int h = xyzmap.GetLength(0);
                int w = xyzmap.GetLength(1);
                List<string> coorStr = new List<string>();

                for (int i = 0; i < h; i++)
                    for (int j = 0; j < w; j++)
                        if (xyzmap[i, j, 0] != 0 && xyzmap[i, j, 1] != 0 && xyzmap[i, j, 2] != 0)  // 移除座標全為0的元素
                            for (int k = 0; k < 3; k++)
                                coorStr.Add(xyzmap[i, j, k].ToString());
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    string[] header = {
                    "ply\n",
                    "format ascii 1.0\n",
                    "element vertex " + coorStr.Count/3 + "\n",
                    "property float32 x\n",
                    "property float32 y\n",
                    "property float32 z\n",
                    "end_header\n"
                    };
                    for (int i = 0; i < header.Length; i++)
                        sw.Write(header[i]);
                    for (int i = 1; i < coorStr.Count + 1; i++)
                    {
                        sw.Write(coorStr[i - 1] + " ");
                        if (i % 3 == 0) sw.WriteLine();
                    }
                    sw.Close();
                }
            }
        }

        internal void MatToPLY(Mat mat)
        {
            if (!mat.IsEmpty)
            {
                ushort[] DepthMap = new ushort[mat.Width * mat.Height];
                mat.CopyTo(DepthMap);
                float[,,] WorldCoor = DepthValueToXYZ(DepthMap);  // 深度ushort轉XYZ
                int h = vsp.Height;
                int w = vsp.Width;
                string[] coorStr = new string[w * h * 3];  // XYZ座標值string陣列
                for (int i = 0; i < h; i++)
                    for (int j = 0; j < w; j++)
                        for (int k = 0; k < 3; k++)
                            coorStr[i * w * 3 + j * 3 + k] = WorldCoor[j, i, k].ToString();
                using (StreamWriter sw = new StreamWriter(@"C:\Users\EL125\Desktop\888888888.ply"))
                {
                    string[] header = {
                    "ply\n",
                    "format ascii 1.0\n",
                    "element vertex " + w * h + "\n",
                    "property float32 x\n",
                    "property float32 y\n",
                    "property float32 z\n",
                    "end_header\n"
                    };
                    for (int i = 0; i < header.Length; i++)
                        sw.Write(header[i]);
                    for (int i = 1; i < w * h * 3 + 1; i++)
                    {
                        sw.Write(coorStr[i - 1] + " ");
                        if (i % 3 == 0) sw.WriteLine();
                    }
                    sw.Close();
                }
            }
        }

        ///<summary>
        ///DepthFrame深度值切割
        ///</summary>
        internal ushort[,] depth_segmantation(DepthFrame dep, float low, float up)
        {
            ushort[] dep_1Darray = FrameTo_1D_ushort(dep);
            int len = dep_1Darray.Length;
            int h = dep.Height;
            int w = dep.Width;
            int stride = dep.Stride;
            float scale = Camera.ActiveProfile.Device.Sensors[0].DepthScale;
            float lowerBound = low*0.01f;  // 深度下限設置
            float upperBound = up*0.01f;  // 深度上限設置
            ushort[,] seg = new ushort[w, h];
            for (int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    seg[j, i] = 0;
                    float value = dep_1Darray[i * w + j] * scale;  // 深度值(單位：m）
                    if (value > lowerBound && value < upperBound)
                        seg[j, i] = dep_1Darray[i * w + j];
                }
            }
            return seg;
        }

        ///<summary>
        ///Frame深度值切割
        ///</summary>
        internal ushort[,] depth_segmantation(Frame dep, float low, float up)
        {
            ushort[] dep_1Darray = FrameTo_1D_ushort(dep);
            int len = dep_1Darray.Length;
            int h = 720;
            int w = 1280;
            float scale = Camera.ActiveProfile.Device.Sensors[0].DepthScale;
            float lowerBound = low * scale;  // 深度下限設置
            float upperBound = up * scale;  // 深度上限設置
            ushort[,] seg = new ushort[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    seg[i, j] = 0;
                    float value = dep_1Darray[i * w + j] * scale;  // 深度值(單位：m）
                    if (value > lowerBound && value < upperBound)
                        seg[i, j] = dep_1Darray[i * w + j];
                }
            }
            return seg;
        }

        /// <summary>
        /// 計算該像素點座標之深度值(單位：m)
        /// </summary>
        internal float get_distance(DepthFrame depth ,int x, int y)
        {
            float dist = depth.GetDistance(x, y);
            return dist;
        }

        /// <summary>
        /// 將DepthFrame格式轉換為2維 ushort 陣列 [height, width, 1]
        /// </summary>
        internal ushort[,] FrameTo_2D_ushort(DepthFrame depFrame)
        {
            if (depFrame.Width == 0) return null;
            ushort[] data = new ushort[depFrame.Width * depFrame.Height];
            depFrame.CopyTo(data);
            ushort[,] bmp = new ushort[depFrame.Height, depFrame.Width];
            for (int x = 0; x < depFrame.Height; x++)
            {
                for (int y = 0; y < depFrame.Width; y++)
                {
                    bmp[x, y] = (ushort)(data[x * depFrame.Width + y]); // data是一維的，bmp二維
                }
            }
            return bmp;
        }

        /// <summary>
        /// 將DepthFrame格式轉換為1維 ushort 陣列 [height*width]
        /// </summary>
        internal ushort[] FrameTo_1D_ushort(DepthFrame depFrame)
        {
            if (depFrame.Width == 0) return null;
            ushort[] data = new ushort[depFrame.Width * depFrame.Height];
            depFrame.CopyTo(data);
            return data;
        }

        /// <summary>
        /// 將VideoFrame格式轉換為1維 ushort 陣列 [height*width]
        /// </summary>
        internal ushort[] FrameTo_1D_ushort(VideoFrame depFrame)
        {
            if (depFrame.Width == 0) return null;
            ushort[] data = new ushort[depFrame.Width * depFrame.Height];
            depFrame.CopyTo(data);
            return data;
        }

        /// <summary>
        /// 將Frame格式轉換為1維 ushort 陣列 [height*width]
        /// </summary>
        internal ushort[] FrameTo_1D_ushort(Frame depFrame)//測試中，目前轉換不正確
        {
            ushort[] data = new ushort[1280 * 720];
            unsafe
            {
                ushort* p = (ushort*)depFrame.Data;

                for (int j = 0; j < 720; j++)
                {
                    for (int i = 0; i < 1280; i++)
                    {
                        data[j * 1280 + i] = p[0];
                        p++;
                    }
                }
            }
            return data;
        }
        #region 坐標系轉換
        /// <summary>
        /// 深度2D座標 -> 3D世界座標，即depth轉point cloud
        /// </summary>
        /// <param name="intrin">相機的內部參數</param>
        /// <param name="pixel">DepthFrame的座標值，pixel[0], pixel[1] = x, y</param>
        /// <param name="depth">DepthFrame在座標(x,y)的深度值(單位：m)</param>
        static internal float[] rs2_deproject_pixel_to_point(Intrinsics intrin, float[] pixel, float depth)
        {
            //assert(intrin.model != Distortion.ModifiedBrownConrady); // Cannot deproject from a forward-distorted image
            //assert(intrin.model != Distortion.Ftheta); // Cannot deproject to an ftheta image
            //assert(intrin->model != RS2_DISTORTION_BROWN_CONRADY); // Cannot deproject to an brown conrady model
            float[] point = new float[3];
            float x = (pixel[0] - intrin.ppx) / intrin.fx;
            float y = (pixel[1] - intrin.ppy) / intrin.fy;
            if (intrin.model == Distortion.ModifiedBrownConrady)
            {
                float r2 = x * x + y * y;
                float f = 1 + intrin.coeffs[0] * r2 + intrin.coeffs[1] * r2 * r2 + intrin.coeffs[4] * r2 * r2 * r2;
                float ux = x * f + 2 * intrin.coeffs[2] * x * y + intrin.coeffs[3] * (r2 + 2 * x * x);
                float uy = y * f + 2 * intrin.coeffs[3] * x * y + intrin.coeffs[2] * (r2 + 2 * y * y);
                x = ux;
                y = uy;
            }
            point[0] = depth * x;  // X
            point[1] = depth * y;  // Y
            point[2] = depth;      // Z
            return point;  // 世界座標
        }
        /// <summary>
        /// 3D世界座標 -> 深度2D座標，即point cloud轉depth
        /// </summary>
        static internal float[] rs2_project_point_to_pixel(Intrinsics intrin, float[] point)
        {
            //assert(intrin->model != RS2_DISTORTION_INVERSE_BROWN_CONRADY); // Cannot project to an inverse-distorted image
            float[] pixel = new float[2];
            float x = point[0] / point[2], y = point[1] / point[2];
            if (intrin.model == Distortion.ModifiedBrownConrady)
            {
                float r2 = x * x + y * y;
                float f = 1 + intrin.coeffs[0] * r2 + intrin.coeffs[1] * r2 * r2 + intrin.coeffs[4] * r2 * r2 * r2;
                x *= f;
                y *= f;
                float dx = x + 2 * intrin.coeffs[2] * x * y + intrin.coeffs[3] * (r2 + 2 * x * x);
                float dy = y + 2 * intrin.coeffs[3] * x * y + intrin.coeffs[2] * (r2 + 2 * y * y);
                x = dx;
                y = dy;
            }
            if (intrin.model == Distortion.Ftheta)
            {
                float r = (float)Math.Sqrt(x * x + y * y);
                float rd = (float)(1.0f / intrin.coeffs[0] * Math.Atan(2 * r * Math.Tan(intrin.coeffs[0] / 2.0f)));
                x *= rd / r;
                y *= rd / r;
            }
            pixel[0] = x * intrin.fx + intrin.ppx;
            pixel[1] = y * intrin.fy + intrin.ppy;
            return pixel;
        }
        #endregion
    }
}
