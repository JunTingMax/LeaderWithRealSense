﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaderWithRealSense
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connectFlag)
            {
                connectFlag = false;
                read.Abort();
                read = null;
            }
            if (!btn_connect.Enabled)
            {
                //Cam.Abort();
                //Cam = null;
            }

        }


    }
}
