﻿using FontAwesome.Sharp;
using Khayaal_SAHM.Main_Form_and_Children_Forms.Home_Form_and_Mdi_Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Khayaal_SAHM.Main_Form_and_Children_Forms
{
    public partial class Main_Form : Form
    {
        private IconButton Current_Button;
        private Panel Left_Border_Btn;
        private Form Current_Child_Form;
        public Main_Form()
        {

            InitializeComponent();
            Left_Border_Btn = new Panel();
            Left_Border_Btn.Size = new Size(7, 52);
            Panel_Menu.Controls.Add(Left_Border_Btn);
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void Open_Child_form(Form Child_Form)
        {
            if (Current_Child_Form != null)
            {
                Current_Child_Form.Close();
            }
            Current_Child_Form = Child_Form;
            Child_Form.TopLevel = false;
            Child_Form.FormBorderStyle = FormBorderStyle.None;
            Child_Form.Dock = DockStyle.Fill;
            Panel_Child.Controls.Add(Child_Form);
            Child_Form.BringToFront();
            Child_Form.Show();
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(241, 102, 103);

        }
        //Methods
        private void Activate_Btn(object Sender_Btn, Color color)
        {
            if (Sender_Btn != null)
            {
                Disable_Btn();
                Current_Button = (IconButton)Sender_Btn;
                Current_Button.BackColor = Color.FromArgb(235, 86, 104);
                Current_Button.ForeColor = Color.FromArgb(255, 255, 255);
                Current_Button.TextAlign = ContentAlignment.BottomCenter;
                Current_Button.IconColor = Color.FromArgb(255, 255, 255);
                Current_Button.TextImageRelation = TextImageRelation.ImageAboveText;
                Current_Button.ImageAlign = ContentAlignment.TopCenter;
                Left_Border_Btn.BackColor = color;
                Left_Border_Btn.Location = new Point(0, Current_Button.Location.Y);
                Left_Border_Btn.Visible = true;
                Left_Border_Btn.BringToFront();


            }
        }
        private void Disable_Btn()
        {
            if (Current_Button != null)
            {
                Current_Button.BackColor = Color.FromArgb(23, 24, 31);
                Current_Button.ForeColor = Color.FromArgb(108, 110, 123);
                Current_Button.TextAlign = ContentAlignment.BottomCenter;
                Current_Button.IconColor = Color.FromArgb(108, 110, 123);
                Current_Button.TextImageRelation = TextImageRelation.ImageAboveText;
                Current_Button.ImageAlign = ContentAlignment.TopCenter;
            }
        }



        private void Btn_Exit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void BtnHome_Click(object sender, System.EventArgs e)
        {
            Activate_Btn(sender, RGBColors.color1);
            Open_Child_form(new Home_Form());
        }

        private void Btn_Booking_Click(object sender, EventArgs e)
        {
            Activate_Btn(sender, RGBColors.color1);
            Open_Child_form(new Booking_Form());

        }

        private void Btn_Raw_Material_Click(object sender, EventArgs e)
        {
            Activate_Btn(sender, RGBColors.color1);
            Open_Child_form(new Raw_Materials_Form());
        }

        private void Btn_Relations_Click(object sender, EventArgs e)
        {
            Activate_Btn(sender, RGBColors.color1);
            Open_Child_form(new Relations_Form());
        }

        private void Btn_Bills_Click(object sender, EventArgs e)
        {
            Activate_Btn(sender, RGBColors.color1);
            Open_Child_form(new Bills_Form());
        }

        private void Btn_Purchases_Click(object sender, EventArgs e)
        {
            Activate_Btn(sender, RGBColors.color1);
            Open_Child_form(new Purchase_Form());
        }

        private void Btn_Maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }



        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }

        }

        private void Btn_Items_Click(object sender, EventArgs e)
        {
            Open_Child_form(new Items_Form());
        }
    }
}
