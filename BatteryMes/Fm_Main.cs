﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACTMULTILib;

namespace BatteryMes
{
    public partial class Fm_Main : Form
    {
        //객체 선언
        ActEasyIF PLC1 = new ActEasyIF();

        public Fm_Main()
        {
            InitializeComponent();
            this.Load += new EventHandler(Fm_Main_Load);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fm_Main_Load(object sender, EventArgs e)
        {
            case_cylamp.SizeMode = PictureBoxSizeMode.StretchImage;
            battery_cylamp.SizeMode = PictureBoxSizeMode.StretchImage;
            cvlamp1.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_xlamp.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_ylamp.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_zlamp.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_rotatelamp.SizeMode = PictureBoxSizeMode.StretchImage;
            cvlamp2.SizeMode = PictureBoxSizeMode.StretchImage;
            vision_check.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SetPanelRegionToCircle(Panel panel)
        {
            if (panel != null)
            {
                // 원형 경로 생성
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, panel.Width, panel.Height);

                // 클리핑 영역 설정
                panel.Region = new Region(path);
            }
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            SetPanelRegionToCircle(panel);
        }
        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            PLC1.ActLogicalStationNumber = 1; //로지컬 스테이션 넘버 넣기
            int conErr = 0;
            conErr = PLC1.Open();

            if (conErr == 0)
            {
                lblStatus.Text = "Connected";
            }
            else lblStatus.Text = "Connection error : " + conErr;
        }

        private void btnDiscon_Click(object sender, EventArgs e)
        {
            PLC1.Close();
            lblStatus.Text = "Disconnected";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // PLC에서 Y20과 Y21 상태 읽기
                int y20 = 0; int y21 = 0; int y22 = 0; int y23 = 0; int y24 = 0; int y25 = 0; 
                int y26 = 0; int y27 = 0; int y28 = 0; int y29 = 0; int y30 = 0; int y31 = 0;
                int y32 = 0; int y33 = 0; int y34 = 0; int y35 = 0; int y36 = 0; int y37 = 0;
                int y50 = 0, y51 = 0;
                PLC1.GetDevice("Y20", out y20); PLC1.GetDevice("Y21", out y21); PLC1.GetDevice("Y22", out y22);
                PLC1.GetDevice("Y23", out y23); PLC1.GetDevice("Y24", out y24); PLC1.GetDevice("Y25", out y25);
                PLC1.GetDevice("Y26", out y26); PLC1.GetDevice("Y27", out y27); PLC1.GetDevice("Y28", out y28);
                PLC1.GetDevice("Y29", out y29); PLC1.GetDevice("Y30", out y30); PLC1.GetDevice("Y31", out y31);
                PLC1.GetDevice("Y32", out y32); PLC1.GetDevice("Y33", out y33); PLC1.GetDevice("Y34", out y34);
                PLC1.GetDevice("Y35", out y35); PLC1.GetDevice("Y36", out y36); PLC1.GetDevice("Y37", out y37);
                PLC1.GetDevice("Y50", out y50); PLC1.GetDevice("Y51", out y51);


                // PictureBox 이미지 변경
                case_cylamp.Image = (y20 == 1) ? Properties.Resources.green : (y21 == 1) ? Properties.Resources.red : null;
                battery_cylamp.Image = (y22 == 1) ? Properties.Resources.green : (y23 == 1) ? Properties.Resources.red : null;
                cvlamp1.Image = (y24 == 1) ? Properties.Resources.green : (y25 == 1) ? Properties.Resources.red : null;
                fork_xlamp.Image = (y26 == 1) ? Properties.Resources.green : (y27 == 1) ? Properties.Resources.red : null;
                fork_ylamp.Image = (y28 == 1) ? Properties.Resources.green : (y29 == 1) ? Properties.Resources.red : null;
                fork_zlamp.Image = (y30 == 1) ? Properties.Resources.green : (y31 == 1) ? Properties.Resources.red : null;
                fork_rotatelamp.Image = (y32 == 1) ? Properties.Resources.green : (y33 == 1) ? Properties.Resources.red : null;
                cvlamp2.Image = (y34 == 1) ? Properties.Resources.green : (y35 == 1) ? Properties.Resources.red : null;
                vision_check.Image = (y36 == 1) ? Properties.Resources.green : (y37 == 1) ? Properties.Resources.red : null;
                if (y50 == 1)
                {
                    mentbox.Text = "vision 과정에서 양품으로 판단하였습니다.";
                }
                else if (y51 == 1)
                {
                    mentbox.Text = "vision 과정에서 불량품으로 판단하였습니다.";
                }
                else
                {
                    mentbox.Text = ""; // y50, y51 외의 번호가 켜질 때 mentbox를 비웁니다.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PLC 통신 오류: " + ex.Message);
            }
        }

        private void mentbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
