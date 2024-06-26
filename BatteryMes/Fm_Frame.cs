﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryMes
{
    public partial class Fm_Frame : Form
    {
        private bool isFullScreen = false;
        private FormBorderStyle originalFormBorderStyle;
        private FormWindowState originalWindowState;

        public Fm_Frame()
        {
            InitializeComponent();
            Load_Form(new Fm_Main());
        }
        public void Load_Form(object Form)
        {
            if (this.Pn_Main.Controls.Count > 0)
            {
                this.Pn_Main.Controls.RemoveAt(0);
            }
                Form fm = Form as Form;
                fm.TopLevel = false;
            fm.Dock = DockStyle.Fill;
            this.Pn_Main.Controls.Add(fm);
            this.WindowState = FormWindowState.Maximized;
            this.Pn_Main.Tag = fm;
                fm.Show();

            
        }
        private void Bt_Main_Click(object sender, EventArgs e)
        {
            Load_Form(new Fm_Main());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bt_Control_Click(object sender, EventArgs e)
        {
            Load_Form(new Fm_Control());
        }

        private void Bt_Test_Click(object sender, EventArgs e)
        {
            Load_Form(new Fm_Test());
        }

        private void Bt_Static_Click(object sender, EventArgs e)
        {
            Load_Form(new Fm_statistics());
        }

        private void Bt_User_Click(object sender, EventArgs e)
        {
            Load_Form(new Fm_User());
        }

        private void Bt_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Bt_Zoom_Click(object sender, EventArgs e)
        {
            if (isFullScreen)
            {
                this.FormBorderStyle = originalFormBorderStyle;
                this.WindowState = originalWindowState;
                this.KeyPreview = false;
                isFullScreen = false;
            }
            else
            {
                originalFormBorderStyle = this.FormBorderStyle;
                originalWindowState = this.WindowState;

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.KeyPreview = true;
                isFullScreen = true;
            }
        }


        private void Pn_Side_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bt_Mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Bt_Main_MouseHover(object sender, EventArgs e)
        {
            Bt_Main.BackColor = Color.FromArgb(255, 255, 255);
            Bt_Main.ForeColor = Color.MidnightBlue;
        }

        private void Bt_Main_MouseLeave(object sender, EventArgs e)
        {
            Bt_Main.BackColor = Color.MidnightBlue;
            Bt_Main.ForeColor = Color.White;
        }

        private void Bt_Control_MouseHover(object sender, EventArgs e)
        {
            Bt_Control.BackColor = Color.White;
            Bt_Control.ForeColor = Color.MidnightBlue;
        }

        private void Bt_Control_MouseLeave(object sender, EventArgs e)
        {
            Bt_Control.BackColor = Color.MidnightBlue;
            Bt_Control.ForeColor = Color.White;
        }

        private void Bt_Test_MouseHover(object sender, EventArgs e)
        {
            Bt_Test.BackColor = Color.FromArgb(255, 255, 255);
            Bt_Test.ForeColor = Color.MidnightBlue;
        }

        private void Bt_Test_MouseLeave(object sender, EventArgs e)
        {
            Bt_Test.BackColor = Color.MidnightBlue;
            Bt_Test.ForeColor = Color.White;
        }

        private void Bt_Static_MouseHover(object sender, EventArgs e)
        {
            Bt_Static.BackColor = Color.FromArgb(255, 255, 255);
            Bt_Static.ForeColor = Color.MidnightBlue;
        }

        private void Bt_Static_MouseLeave(object sender, EventArgs e)
        {
            Bt_Static.BackColor = Color.MidnightBlue;
            Bt_Static.ForeColor = Color.White;
        }

        private void Bt_User_MouseHover(object sender, EventArgs e)
        {
            Bt_User.BackColor = Color.FromArgb(255, 255, 255);
            Bt_User.ForeColor = Color.MidnightBlue;
        }

        private void Bt_User_MouseLeave(object sender, EventArgs e)
        {
            Bt_User.BackColor = Color.MidnightBlue;
            Bt_User.ForeColor = Color.White;
        }
    }
}
