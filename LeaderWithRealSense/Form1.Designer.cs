namespace LeaderWithRealSense
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage_Camera = new System.Windows.Forms.TabPage();
            this.btn_playRoute = new System.Windows.Forms.Button();
            this.tBx_ppy = new System.Windows.Forms.TextBox();
            this.tBx_ppx = new System.Windows.Forms.TextBox();
            this.tBx_fy = new System.Windows.Forms.TextBox();
            this.tBx_fx = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_saveImg = new System.Windows.Forms.Button();
            this.btn_CamStreaming = new System.Windows.Forms.Button();
            this.btn_CameraConnect = new System.Windows.Forms.Button();
            this.picBox_color = new System.Windows.Forms.PictureBox();
            this.picBox_depth = new System.Windows.Forms.PictureBox();
            this.tabPage_Leader = new System.Windows.Forms.TabPage();
            this.lbl_state = new System.Windows.Forms.Label();
            this.tBx_RZ = new System.Windows.Forms.TextBox();
            this.tBx_J6 = new System.Windows.Forms.TextBox();
            this.tBx_RY = new System.Windows.Forms.TextBox();
            this.tBx_J5 = new System.Windows.Forms.TextBox();
            this.tBx_RX = new System.Windows.Forms.TextBox();
            this.tBx_J4 = new System.Windows.Forms.TextBox();
            this.tBx_Z = new System.Windows.Forms.TextBox();
            this.tBx_J3 = new System.Windows.Forms.TextBox();
            this.tBx_Y = new System.Windows.Forms.TextBox();
            this.tBx_J2 = new System.Windows.Forms.TextBox();
            this.tBx_speed = new System.Windows.Forms.TextBox();
            this.tBx_X = new System.Windows.Forms.TextBox();
            this.tBx_J1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_XYZ = new System.Windows.Forms.Label();
            this.lbl_Joint = new System.Windows.Forms.Label();
            this.btn_moveL = new System.Windows.Forms.Button();
            this.btn_moveJ = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Camera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_depth)).BeginInit();
            this.tabPage_Leader.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage_Camera
            // 
            this.tabPage_Camera.Controls.Add(this.btn_playRoute);
            this.tabPage_Camera.Controls.Add(this.tBx_ppy);
            this.tabPage_Camera.Controls.Add(this.tBx_ppx);
            this.tabPage_Camera.Controls.Add(this.tBx_fy);
            this.tabPage_Camera.Controls.Add(this.tBx_fx);
            this.tabPage_Camera.Controls.Add(this.label17);
            this.tabPage_Camera.Controls.Add(this.label16);
            this.tabPage_Camera.Controls.Add(this.label15);
            this.tabPage_Camera.Controls.Add(this.label14);
            this.tabPage_Camera.Controls.Add(this.btn_saveImg);
            this.tabPage_Camera.Controls.Add(this.btn_CamStreaming);
            this.tabPage_Camera.Controls.Add(this.btn_CameraConnect);
            this.tabPage_Camera.Controls.Add(this.picBox_color);
            this.tabPage_Camera.Controls.Add(this.picBox_depth);
            this.tabPage_Camera.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage_Camera.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Camera.Name = "tabPage_Camera";
            this.tabPage_Camera.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Camera.Size = new System.Drawing.Size(1109, 536);
            this.tabPage_Camera.TabIndex = 1;
            this.tabPage_Camera.Text = "Camera";
            this.tabPage_Camera.UseVisualStyleBackColor = true;
            // 
            // btn_playRoute
            // 
            this.btn_playRoute.Font = new System.Drawing.Font("標楷體", 12F);
            this.btn_playRoute.Location = new System.Drawing.Point(819, 100);
            this.btn_playRoute.Margin = new System.Windows.Forms.Padding(2);
            this.btn_playRoute.Name = "btn_playRoute";
            this.btn_playRoute.Size = new System.Drawing.Size(273, 34);
            this.btn_playRoute.TabIndex = 4;
            this.btn_playRoute.Text = "執行";
            this.btn_playRoute.UseVisualStyleBackColor = true;
            this.btn_playRoute.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // tBx_ppy
            // 
            this.tBx_ppy.Location = new System.Drawing.Point(956, 485);
            this.tBx_ppy.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_ppy.Name = "tBx_ppy";
            this.tBx_ppy.Size = new System.Drawing.Size(54, 22);
            this.tBx_ppy.TabIndex = 3;
            // 
            // tBx_ppx
            // 
            this.tBx_ppx.Location = new System.Drawing.Point(853, 485);
            this.tBx_ppx.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_ppx.Name = "tBx_ppx";
            this.tBx_ppx.Size = new System.Drawing.Size(54, 22);
            this.tBx_ppx.TabIndex = 3;
            // 
            // tBx_fy
            // 
            this.tBx_fy.Location = new System.Drawing.Point(956, 433);
            this.tBx_fy.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_fy.Name = "tBx_fy";
            this.tBx_fy.Size = new System.Drawing.Size(54, 22);
            this.tBx_fy.TabIndex = 3;
            // 
            // tBx_fx
            // 
            this.tBx_fx.Location = new System.Drawing.Point(853, 433);
            this.tBx_fx.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_fx.Name = "tBx_fx";
            this.tBx_fx.Size = new System.Drawing.Size(54, 22);
            this.tBx_fx.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("標楷體", 13F);
            this.label17.Location = new System.Drawing.Point(910, 487);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 18);
            this.label17.TabIndex = 2;
            this.label17.Text = "ppy:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("標楷體", 13F);
            this.label16.Location = new System.Drawing.Point(816, 487);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 18);
            this.label16.TabIndex = 2;
            this.label16.Text = "ppx:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("標楷體", 13F);
            this.label15.Location = new System.Drawing.Point(910, 435);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 18);
            this.label15.TabIndex = 2;
            this.label15.Text = "fy:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("標楷體", 13F);
            this.label14.Location = new System.Drawing.Point(816, 435);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 18);
            this.label14.TabIndex = 2;
            this.label14.Text = "fx:";
            // 
            // btn_saveImg
            // 
            this.btn_saveImg.Enabled = false;
            this.btn_saveImg.Font = new System.Drawing.Font("標楷體", 12F);
            this.btn_saveImg.Location = new System.Drawing.Point(1005, 11);
            this.btn_saveImg.Name = "btn_saveImg";
            this.btn_saveImg.Size = new System.Drawing.Size(87, 52);
            this.btn_saveImg.TabIndex = 1;
            this.btn_saveImg.Text = "儲存影像";
            this.btn_saveImg.UseVisualStyleBackColor = true;
            this.btn_saveImg.Click += new System.EventHandler(this.btn_saveImg_Click);
            // 
            // btn_CamStreaming
            // 
            this.btn_CamStreaming.Enabled = false;
            this.btn_CamStreaming.Font = new System.Drawing.Font("標楷體", 12F);
            this.btn_CamStreaming.Location = new System.Drawing.Point(912, 10);
            this.btn_CamStreaming.Name = "btn_CamStreaming";
            this.btn_CamStreaming.Size = new System.Drawing.Size(87, 52);
            this.btn_CamStreaming.TabIndex = 1;
            this.btn_CamStreaming.Text = "開始取像";
            this.btn_CamStreaming.UseVisualStyleBackColor = true;
            this.btn_CamStreaming.Click += new System.EventHandler(this.btn_CamStreaming_Click);
            // 
            // btn_CameraConnect
            // 
            this.btn_CameraConnect.Font = new System.Drawing.Font("標楷體", 12F);
            this.btn_CameraConnect.Location = new System.Drawing.Point(819, 10);
            this.btn_CameraConnect.Name = "btn_CameraConnect";
            this.btn_CameraConnect.Size = new System.Drawing.Size(87, 52);
            this.btn_CameraConnect.TabIndex = 1;
            this.btn_CameraConnect.Text = "相機連接";
            this.btn_CameraConnect.UseVisualStyleBackColor = true;
            this.btn_CameraConnect.Click += new System.EventHandler(this.btn_CameraConnect_Click);
            // 
            // picBox_color
            // 
            this.picBox_color.Location = new System.Drawing.Point(11, 10);
            this.picBox_color.Name = "picBox_color";
            this.picBox_color.Size = new System.Drawing.Size(791, 255);
            this.picBox_color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_color.TabIndex = 0;
            this.picBox_color.TabStop = false;
            // 
            // picBox_depth
            // 
            this.picBox_depth.Location = new System.Drawing.Point(11, 276);
            this.picBox_depth.Name = "picBox_depth";
            this.picBox_depth.Size = new System.Drawing.Size(791, 255);
            this.picBox_depth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_depth.TabIndex = 0;
            this.picBox_depth.TabStop = false;
            // 
            // tabPage_Leader
            // 
            this.tabPage_Leader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage_Leader.Controls.Add(this.lbl_state);
            this.tabPage_Leader.Controls.Add(this.tBx_RZ);
            this.tabPage_Leader.Controls.Add(this.tBx_J6);
            this.tabPage_Leader.Controls.Add(this.tBx_RY);
            this.tabPage_Leader.Controls.Add(this.tBx_J5);
            this.tabPage_Leader.Controls.Add(this.tBx_RX);
            this.tabPage_Leader.Controls.Add(this.tBx_J4);
            this.tabPage_Leader.Controls.Add(this.tBx_Z);
            this.tabPage_Leader.Controls.Add(this.tBx_J3);
            this.tabPage_Leader.Controls.Add(this.tBx_Y);
            this.tabPage_Leader.Controls.Add(this.tBx_J2);
            this.tabPage_Leader.Controls.Add(this.tBx_speed);
            this.tabPage_Leader.Controls.Add(this.tBx_X);
            this.tabPage_Leader.Controls.Add(this.tBx_J1);
            this.tabPage_Leader.Controls.Add(this.label12);
            this.tabPage_Leader.Controls.Add(this.label6);
            this.tabPage_Leader.Controls.Add(this.label11);
            this.tabPage_Leader.Controls.Add(this.label5);
            this.tabPage_Leader.Controls.Add(this.label10);
            this.tabPage_Leader.Controls.Add(this.label4);
            this.tabPage_Leader.Controls.Add(this.label9);
            this.tabPage_Leader.Controls.Add(this.label3);
            this.tabPage_Leader.Controls.Add(this.label8);
            this.tabPage_Leader.Controls.Add(this.label13);
            this.tabPage_Leader.Controls.Add(this.label2);
            this.tabPage_Leader.Controls.Add(this.label7);
            this.tabPage_Leader.Controls.Add(this.label1);
            this.tabPage_Leader.Controls.Add(this.lbl_XYZ);
            this.tabPage_Leader.Controls.Add(this.lbl_Joint);
            this.tabPage_Leader.Controls.Add(this.btn_moveL);
            this.tabPage_Leader.Controls.Add(this.btn_moveJ);
            this.tabPage_Leader.Controls.Add(this.btn_connect);
            this.tabPage_Leader.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage_Leader.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Leader.Name = "tabPage_Leader";
            this.tabPage_Leader.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Leader.Size = new System.Drawing.Size(1109, 536);
            this.tabPage_Leader.TabIndex = 0;
            this.tabPage_Leader.Text = "Leader";
            this.tabPage_Leader.UseVisualStyleBackColor = true;
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl_state.Location = new System.Drawing.Point(26, 261);
            this.lbl_state.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(109, 19);
            this.lbl_state.TabIndex = 38;
            this.lbl_state.Text = "動作狀態: ";
            // 
            // tBx_RZ
            // 
            this.tBx_RZ.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_RZ.Location = new System.Drawing.Point(704, 155);
            this.tBx_RZ.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_RZ.Name = "tBx_RZ";
            this.tBx_RZ.Size = new System.Drawing.Size(72, 28);
            this.tBx_RZ.TabIndex = 36;
            this.tBx_RZ.Text = "0";
            // 
            // tBx_J6
            // 
            this.tBx_J6.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_J6.Location = new System.Drawing.Point(704, 110);
            this.tBx_J6.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_J6.Name = "tBx_J6";
            this.tBx_J6.Size = new System.Drawing.Size(72, 28);
            this.tBx_J6.TabIndex = 35;
            this.tBx_J6.Text = "0";
            // 
            // tBx_RY
            // 
            this.tBx_RY.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_RY.Location = new System.Drawing.Point(577, 155);
            this.tBx_RY.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_RY.Name = "tBx_RY";
            this.tBx_RY.Size = new System.Drawing.Size(72, 28);
            this.tBx_RY.TabIndex = 34;
            this.tBx_RY.Text = "0";
            // 
            // tBx_J5
            // 
            this.tBx_J5.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_J5.Location = new System.Drawing.Point(577, 110);
            this.tBx_J5.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_J5.Name = "tBx_J5";
            this.tBx_J5.Size = new System.Drawing.Size(72, 28);
            this.tBx_J5.TabIndex = 33;
            this.tBx_J5.Text = "0";
            // 
            // tBx_RX
            // 
            this.tBx_RX.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_RX.Location = new System.Drawing.Point(450, 155);
            this.tBx_RX.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_RX.Name = "tBx_RX";
            this.tBx_RX.Size = new System.Drawing.Size(72, 28);
            this.tBx_RX.TabIndex = 32;
            this.tBx_RX.Text = "0";
            // 
            // tBx_J4
            // 
            this.tBx_J4.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_J4.Location = new System.Drawing.Point(450, 110);
            this.tBx_J4.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_J4.Name = "tBx_J4";
            this.tBx_J4.Size = new System.Drawing.Size(72, 28);
            this.tBx_J4.TabIndex = 31;
            this.tBx_J4.Text = "0";
            // 
            // tBx_Z
            // 
            this.tBx_Z.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_Z.Location = new System.Drawing.Point(322, 155);
            this.tBx_Z.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_Z.Name = "tBx_Z";
            this.tBx_Z.Size = new System.Drawing.Size(72, 28);
            this.tBx_Z.TabIndex = 30;
            this.tBx_Z.Text = "0";
            // 
            // tBx_J3
            // 
            this.tBx_J3.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_J3.Location = new System.Drawing.Point(322, 110);
            this.tBx_J3.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_J3.Name = "tBx_J3";
            this.tBx_J3.Size = new System.Drawing.Size(72, 28);
            this.tBx_J3.TabIndex = 28;
            this.tBx_J3.Text = "0";
            // 
            // tBx_Y
            // 
            this.tBx_Y.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_Y.Location = new System.Drawing.Point(194, 155);
            this.tBx_Y.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_Y.Name = "tBx_Y";
            this.tBx_Y.Size = new System.Drawing.Size(72, 28);
            this.tBx_Y.TabIndex = 29;
            this.tBx_Y.Text = "0";
            // 
            // tBx_J2
            // 
            this.tBx_J2.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_J2.Location = new System.Drawing.Point(194, 110);
            this.tBx_J2.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_J2.Name = "tBx_J2";
            this.tBx_J2.Size = new System.Drawing.Size(72, 28);
            this.tBx_J2.TabIndex = 37;
            this.tBx_J2.Text = "0";
            // 
            // tBx_speed
            // 
            this.tBx_speed.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_speed.Location = new System.Drawing.Point(90, 207);
            this.tBx_speed.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_speed.Name = "tBx_speed";
            this.tBx_speed.Size = new System.Drawing.Size(72, 28);
            this.tBx_speed.TabIndex = 27;
            this.tBx_speed.Text = "10";
            // 
            // tBx_X
            // 
            this.tBx_X.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_X.Location = new System.Drawing.Point(67, 155);
            this.tBx_X.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_X.Name = "tBx_X";
            this.tBx_X.Size = new System.Drawing.Size(72, 28);
            this.tBx_X.TabIndex = 26;
            this.tBx_X.Text = "0";
            // 
            // tBx_J1
            // 
            this.tBx_J1.Font = new System.Drawing.Font("新細明體", 13F);
            this.tBx_J1.Location = new System.Drawing.Point(67, 110);
            this.tBx_J1.Margin = new System.Windows.Forms.Padding(2);
            this.tBx_J1.Name = "tBx_J1";
            this.tBx_J1.Size = new System.Drawing.Size(72, 28);
            this.tBx_J1.TabIndex = 25;
            this.tBx_J1.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 13F);
            this.label12.Location = new System.Drawing.Point(662, 161);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 18);
            this.label12.TabIndex = 23;
            this.label12.Text = "RZ : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 13F);
            this.label6.Location = new System.Drawing.Point(667, 116);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "J6 : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 13F);
            this.label11.Location = new System.Drawing.Point(533, 161);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 18);
            this.label11.TabIndex = 20;
            this.label11.Text = "RY : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 13F);
            this.label5.Location = new System.Drawing.Point(540, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "J5 : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 13F);
            this.label10.Location = new System.Drawing.Point(405, 161);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "RX : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 13F);
            this.label4.Location = new System.Drawing.Point(412, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "J4 : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 13F);
            this.label9.Location = new System.Drawing.Point(284, 161);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 18);
            this.label9.TabIndex = 13;
            this.label9.Text = "Z : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 13F);
            this.label3.Location = new System.Drawing.Point(284, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "J3 : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 13F);
            this.label8.Location = new System.Drawing.Point(157, 161);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = "Y : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 13F);
            this.label13.Location = new System.Drawing.Point(30, 213);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 18);
            this.label13.TabIndex = 15;
            this.label13.Text = "Speed : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 13F);
            this.label2.Location = new System.Drawing.Point(157, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "J2 : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 13F);
            this.label7.Location = new System.Drawing.Point(30, 161);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "X : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 13F);
            this.label1.Location = new System.Drawing.Point(30, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "J1 : ";
            // 
            // lbl_XYZ
            // 
            this.lbl_XYZ.AutoSize = true;
            this.lbl_XYZ.Font = new System.Drawing.Font("標楷體", 15F);
            this.lbl_XYZ.Location = new System.Drawing.Point(26, 382);
            this.lbl_XYZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_XYZ.Name = "lbl_XYZ";
            this.lbl_XYZ.Size = new System.Drawing.Size(79, 20);
            this.lbl_XYZ.TabIndex = 11;
            this.lbl_XYZ.Text = "XYZ座標";
            // 
            // lbl_Joint
            // 
            this.lbl_Joint.AutoSize = true;
            this.lbl_Joint.Font = new System.Drawing.Font("標楷體", 15F);
            this.lbl_Joint.Location = new System.Drawing.Point(26, 318);
            this.lbl_Joint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Joint.Name = "lbl_Joint";
            this.lbl_Joint.Size = new System.Drawing.Size(89, 20);
            this.lbl_Joint.TabIndex = 10;
            this.lbl_Joint.Text = "關節座標";
            // 
            // btn_moveL
            // 
            this.btn_moveL.Location = new System.Drawing.Point(991, 157);
            this.btn_moveL.Name = "btn_moveL";
            this.btn_moveL.Size = new System.Drawing.Size(79, 26);
            this.btn_moveL.TabIndex = 8;
            this.btn_moveL.Text = "MoveL";
            this.btn_moveL.UseVisualStyleBackColor = true;
            this.btn_moveL.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_moveJ
            // 
            this.btn_moveJ.Location = new System.Drawing.Point(991, 109);
            this.btn_moveJ.Name = "btn_moveJ";
            this.btn_moveJ.Size = new System.Drawing.Size(79, 25);
            this.btn_moveJ.TabIndex = 9;
            this.btn_moveJ.Text = "MoveJ";
            this.btn_moveJ.UseVisualStyleBackColor = true;
            this.btn_moveJ.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Font = new System.Drawing.Font("標楷體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_connect.Location = new System.Drawing.Point(30, 17);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(79, 49);
            this.btn_connect.TabIndex = 7;
            this.btn_connect.Text = "連線";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Leader);
            this.tabControl1.Controls.Add(this.tabPage_Camera);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1117, 562);
            this.tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 580);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Leader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabPage_Camera.ResumeLayout(false);
            this.tabPage_Camera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_depth)).EndInit();
            this.tabPage_Leader.ResumeLayout(false);
            this.tabPage_Leader.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage_Camera;
        private System.Windows.Forms.Button btn_playRoute;
        private System.Windows.Forms.TextBox tBx_ppy;
        private System.Windows.Forms.TextBox tBx_ppx;
        private System.Windows.Forms.TextBox tBx_fy;
        private System.Windows.Forms.TextBox tBx_fx;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_saveImg;
        private System.Windows.Forms.Button btn_CamStreaming;
        private System.Windows.Forms.Button btn_CameraConnect;
        private System.Windows.Forms.PictureBox picBox_color;
        private System.Windows.Forms.PictureBox picBox_depth;
        private System.Windows.Forms.TabPage tabPage_Leader;
        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.TextBox tBx_RZ;
        private System.Windows.Forms.TextBox tBx_J6;
        private System.Windows.Forms.TextBox tBx_RY;
        private System.Windows.Forms.TextBox tBx_J5;
        private System.Windows.Forms.TextBox tBx_RX;
        private System.Windows.Forms.TextBox tBx_J4;
        private System.Windows.Forms.TextBox tBx_Z;
        private System.Windows.Forms.TextBox tBx_J3;
        private System.Windows.Forms.TextBox tBx_Y;
        private System.Windows.Forms.TextBox tBx_J2;
        private System.Windows.Forms.TextBox tBx_speed;
        private System.Windows.Forms.TextBox tBx_X;
        private System.Windows.Forms.TextBox tBx_J1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_XYZ;
        private System.Windows.Forms.Label lbl_Joint;
        private System.Windows.Forms.Button btn_moveL;
        private System.Windows.Forms.Button btn_moveJ;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

