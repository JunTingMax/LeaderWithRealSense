using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Intel.RealSense;
using System.Drawing;
using Emgu.CV.CvEnum;
using System.IO;

namespace LeaderWithRealSense
{
    public partial class Form1 : Form
    {
        IntelRealSense rs = new IntelRealSense();
        Image<Bgr, byte> ColorImg;
        Image<Rgb, byte> DepthImg;
        Image<Rgb, byte> FilteredImg;
        Image<Gray, byte> GrayImg;
        Image<Gray, byte> ThresholdImg;

        VideoFrame colorFrame;
        DepthFrame depthFrame;
        Intel.RealSense.Frame filtered;
        readonly int PICBOX_SCALE = 2;

        List<string> pointList;
        
        Thread CamGrab;
        Thread thread;
        Thread Cam;

        private void btn_CameraConnect_Click(object sender, EventArgs e)
        {
            thread = new Thread(CamConnect);
            thread.IsBackground = true;
            thread.Start();

                
            btn_CamStreaming.Enabled = true;
            btn_saveImg.Enabled = true;
            btn_CameraConnect.Enabled = false;
            
        }
        private void CamConnect()
        {
            rs.Connect();
        }
        private void btn_CamStreaming_Click(object sender, EventArgs e)
        {

            //btn_CamStreaming.Enabled = false;
            //btn_StopStreaming.Enabled = true;


            CamGrab = new Thread(Grab);
            CamGrab.IsBackground = true;
            CamGrab.Start();
            //Cam = new Thread(Streaming);
            //Cam.IsBackground = true;
            //Cam.Start();
        }

        private void Grab()
        {
            for (int i = 0; i < 3; i++)
            {
                rs.Open(out ColorImg, out DepthImg, out FilteredImg, out colorFrame, out depthFrame, out filtered);
            }
            Invoke((Action)(() =>
            {
                tBx_fx.Text = rs.intrinsics.fx.ToString();
                tBx_fy.Text = rs.intrinsics.fy.ToString();
                tBx_ppx.Text = rs.intrinsics.ppx.ToString();
                tBx_ppy.Text = rs.intrinsics.ppy.ToString();
                if (ColorImg != null && DepthImg != null && FilteredImg != null)
                {
                    picBox_color.Image = ColorImg.Bitmap;
                    picBox_depth.Image = DepthImg.Bitmap;
                    GC.Collect();
                    ImgProcess();
                }
            }));
            
        }
        private void ImgProcess()
        {
            GrayImg = new Image<Gray, byte>(ColorImg.Bitmap);
            ThresholdImg = GrayImg.ThresholdBinaryInv(new Gray(75), new Gray(255));
            
            ThresholdImg.Save("ThresholdImg.bmp");
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            
                // 在這版本請使用FindContours，早期版本有cvFindContours等等，在這版都無法使用，
                // 由於這邊是要取得最外層的輪廓，所以第三個參數給 null，第四個參數則用 RetrType.External。
            CvInvoke.FindContours(ThresholdImg, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            pointList = new List<string>();

            int count = contours.Size;
            PointF deltaDepth = new PointF();
            int ID = 0;
            for (int i = 0; i < count; i++)
            {
                VectorOfPoint contour = contours[i];
                if (contour.Size　> 50)
                {
                    ID++;
                    Rectangle BoundingBox = CvInvoke.BoundingRectangle(contour);
                    double z = rs.get_distance(depthFrame, BoundingBox.X + BoundingBox.Width / 2, BoundingBox.Y + BoundingBox.Height / 2) * 1000;
                    deltaDepth.X = Convert.ToSingle(z * ((BoundingBox.X + BoundingBox.Width / 2) - rs.intrinsics.ppx) / (rs.intrinsics.fx));
                    deltaDepth.Y = Convert.ToSingle(z * ((BoundingBox.Y + BoundingBox.Height / 2) - rs.intrinsics.ppy) / (rs.intrinsics.fy));


                    double X = 1.2741447 + deltaDepth.X;
                    double Y = 541.050512 - deltaDepth.Y;
                    double Z = 400 - z + 40;

                    string str = ID.ToString() + "," + X.ToString("0.000") + "," + Y.ToString("0.000") + "," + Z.ToString("0.000") + ",180,0,90";
                    pointList.Add(str);
                    Console.WriteLine("x:" + X.ToString("0.0000") + " y:" + Y.ToString("0.0000") + " z:" + Z.ToString("0.0000"));
                    CircleF circlef = new CircleF(new PointF((BoundingBox.X + BoundingBox.Width / 2), BoundingBox.Y + BoundingBox.Height / 2), 10);

                    ColorImg.Draw(circlef, new Bgr(0, 0, 255), 5);
                    ColorImg.Draw(BoundingBox, new Bgr(0, 255, 0), 3);
                    
                    // 使用 BoundingRectangle 取得框選矩形
                }


            }


            string path = @"route.txt";
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);

            for (int i = 0; i < pointList.Count; i++)
            {
                sw.WriteLine(pointList[i]);
            } 
            sw.Close(); // 關閉檔案    

            routeLoad(path);

            
            ColorImg.Save("ColorImg.bmp");

        }
        private void btn_saveImg_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "";
            saveFileDialog1.Filter = "All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorImg.ToBitmap().Save(saveFileDialog1.FileName + ".bmp");
            }
        }

        private void Streaming()
        {
            try
            {
                while (!btn_CameraConnect.Enabled && !btn_CamStreaming.Enabled)
                {
                    rs.Open(out ColorImg, out DepthImg, out FilteredImg, out colorFrame, out depthFrame, out filtered);

                    Invoke((Action)(() =>
                    {
                        tBx_fx.Text = rs.intrinsics.fx.ToString();
                        tBx_fy.Text = rs.intrinsics.fy.ToString();
                        tBx_ppx.Text = rs.intrinsics.ppx.ToString();
                        tBx_ppy.Text = rs.intrinsics.ppy.ToString();
                        CircleF circlef = new CircleF(new PointF(rs.intrinsics.ppx, rs.intrinsics.ppy), 10);
                        if (ColorImg != null && DepthImg != null && FilteredImg != null)
                        {
                            ColorImg.Draw(circlef, new Bgr(0, 0, 255), 5);
                            picBox_color.Image = ColorImg.Bitmap;
                            picBox_depth.Image = DepthImg.Bitmap;
                            GC.Collect();
                        }
                    }));
                }
                Console.WriteLine("跳脫");
            }
            catch (Exception ex)
            {
            }
        }

    }
}
