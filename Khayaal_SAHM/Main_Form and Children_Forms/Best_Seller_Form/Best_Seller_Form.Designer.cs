﻿namespace Khayaal_SAHM.Main_Form_and_Children_Forms.Best_Seller_Form
{
    partial class Best_Seller_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Category_Combo_Box = new Guna.UI2.WinForms.Guna2ComboBox();
            this.From_Date_Picker = new System.Windows.Forms.DateTimePicker();
            this.To_Date_Picker = new System.Windows.Forms.DateTimePicker();
            this.Search_Text_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Category_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.From_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.To_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Count_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Count_Value_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Best_Seller_Table = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Best_Seller_Table)).BeginInit();
            this.SuspendLayout();
            // 
            // Category_Combo_Box
            // 
            this.Category_Combo_Box.BackColor = System.Drawing.Color.Transparent;
            this.Category_Combo_Box.BorderRadius = 10;
            this.Category_Combo_Box.BorderThickness = 0;
            this.Category_Combo_Box.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Category_Combo_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Category_Combo_Box.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(67)))));
            this.Category_Combo_Box.FocusedColor = System.Drawing.Color.Empty;
            this.Category_Combo_Box.FocusedState.Parent = this.Category_Combo_Box;
            this.Category_Combo_Box.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Category_Combo_Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Category_Combo_Box.FormattingEnabled = true;
            this.Category_Combo_Box.HoverState.Parent = this.Category_Combo_Box;
            this.Category_Combo_Box.ItemHeight = 30;
            this.Category_Combo_Box.ItemsAppearance.Parent = this.Category_Combo_Box;
            this.Category_Combo_Box.Location = new System.Drawing.Point(469, 53);
            this.Category_Combo_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Category_Combo_Box.Name = "Category_Combo_Box";
            this.Category_Combo_Box.ShadowDecoration.Parent = this.Category_Combo_Box;
            this.Category_Combo_Box.Size = new System.Drawing.Size(212, 36);
            this.Category_Combo_Box.TabIndex = 5;
            this.Category_Combo_Box.SelectedIndexChanged += new System.EventHandler(this.Category_Combo_Box_SelectedIndexChanged);
            // 
            // From_Date_Picker
            // 
            this.From_Date_Picker.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.From_Date_Picker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(67)))));
            this.From_Date_Picker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(67)))));
            this.From_Date_Picker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(67)))));
            this.From_Date_Picker.CustomFormat = "";
            this.From_Date_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.From_Date_Picker.Location = new System.Drawing.Point(751, 73);
            this.From_Date_Picker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.From_Date_Picker.Name = "From_Date_Picker";
            this.From_Date_Picker.Size = new System.Drawing.Size(160, 22);
            this.From_Date_Picker.TabIndex = 7;
            this.From_Date_Picker.ValueChanged += new System.EventHandler(this.From_Date_Picker_ValueChanged);
            // 
            // To_Date_Picker
            // 
            this.To_Date_Picker.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.To_Date_Picker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(67)))));
            this.To_Date_Picker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(67)))));
            this.To_Date_Picker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(67)))));
            this.To_Date_Picker.CustomFormat = "";
            this.To_Date_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.To_Date_Picker.Location = new System.Drawing.Point(1027, 73);
            this.To_Date_Picker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.To_Date_Picker.Name = "To_Date_Picker";
            this.To_Date_Picker.Size = new System.Drawing.Size(160, 22);
            this.To_Date_Picker.TabIndex = 8;
            this.To_Date_Picker.ValueChanged += new System.EventHandler(this.To_Date_Picker_ValueChanged);
            // 
            // Search_Text_Box
            // 
            this.Search_Text_Box.BorderRadius = 10;
            this.Search_Text_Box.BorderThickness = 0;
            this.Search_Text_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Search_Text_Box.DefaultText = "";
            this.Search_Text_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Search_Text_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Search_Text_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search_Text_Box.DisabledState.Parent = this.Search_Text_Box;
            this.Search_Text_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search_Text_Box.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(67)))));
            this.Search_Text_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Search_Text_Box.FocusedState.Parent = this.Search_Text_Box;
            this.Search_Text_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Search_Text_Box.HoverState.Parent = this.Search_Text_Box;
            this.Search_Text_Box.Location = new System.Drawing.Point(69, 53);
            this.Search_Text_Box.Margin = new System.Windows.Forms.Padding(5);
            this.Search_Text_Box.Name = "Search_Text_Box";
            this.Search_Text_Box.PasswordChar = '\0';
            this.Search_Text_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Search_Text_Box.PlaceholderText = "Search";
            this.Search_Text_Box.SelectedText = "";
            this.Search_Text_Box.ShadowDecoration.Parent = this.Search_Text_Box;
            this.Search_Text_Box.Size = new System.Drawing.Size(352, 44);
            this.Search_Text_Box.TabIndex = 9;
            this.Search_Text_Box.TextChanged += new System.EventHandler(this.Search_Text_Box_TextChanged);
            this.Search_Text_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Search_Text_Box_KeyPress);
            // 
            // Category_Label
            // 
            this.Category_Label.BackColor = System.Drawing.Color.Transparent;
            this.Category_Label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(158)))), ((int)(((byte)(163)))));
            this.Category_Label.Location = new System.Drawing.Point(469, 14);
            this.Category_Label.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Category_Label.Name = "Category_Label";
            this.Category_Label.Size = new System.Drawing.Size(80, 27);
            this.Category_Label.TabIndex = 11;
            this.Category_Label.Text = "Category";
            // 
            // From_Label
            // 
            this.From_Label.BackColor = System.Drawing.Color.Transparent;
            this.From_Label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.From_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(158)))), ((int)(((byte)(163)))));
            this.From_Label.Location = new System.Drawing.Point(751, 14);
            this.From_Label.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.From_Label.Name = "From_Label";
            this.From_Label.Size = new System.Drawing.Size(46, 27);
            this.From_Label.TabIndex = 12;
            this.From_Label.Text = "From";
            // 
            // To_Label
            // 
            this.To_Label.BackColor = System.Drawing.Color.Transparent;
            this.To_Label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.To_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(158)))), ((int)(((byte)(163)))));
            this.To_Label.Location = new System.Drawing.Point(1027, 14);
            this.To_Label.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.To_Label.Name = "To_Label";
            this.To_Label.Size = new System.Drawing.Size(25, 27);
            this.To_Label.TabIndex = 13;
            this.To_Label.Text = "To";
            // 
            // Count_Label
            // 
            this.Count_Label.BackColor = System.Drawing.Color.Transparent;
            this.Count_Label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Count_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(158)))), ((int)(((byte)(163)))));
            this.Count_Label.Location = new System.Drawing.Point(65, 668);
            this.Count_Label.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Count_Label.Name = "Count_Label";
            this.Count_Label.Size = new System.Drawing.Size(64, 27);
            this.Count_Label.TabIndex = 14;
            this.Count_Label.Text = "Count : ";
            // 
            // Count_Value_Label
            // 
            this.Count_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.Count_Value_Label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Count_Value_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(158)))), ((int)(((byte)(163)))));
            this.Count_Value_Label.Location = new System.Drawing.Point(128, 668);
            this.Count_Value_Label.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Count_Value_Label.Name = "Count_Value_Label";
            this.Count_Value_Label.Size = new System.Drawing.Size(3, 2);
            this.Count_Value_Label.TabIndex = 15;
            this.Count_Value_Label.Text = null;
            // 
            // Best_Seller_Table
            // 
            this.Best_Seller_Table.AllowUserToAddRows = false;
            this.Best_Seller_Table.AllowUserToDeleteRows = false;
            this.Best_Seller_Table.AllowUserToResizeColumns = false;
            this.Best_Seller_Table.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(104)))));
            this.Best_Seller_Table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Best_Seller_Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Best_Seller_Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Best_Seller_Table.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(123)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Best_Seller_Table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Best_Seller_Table.ColumnHeadersHeight = 48;
            this.Best_Seller_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Best_Seller_Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Best_Seller_Table.DefaultCellStyle = dataGridViewCellStyle4;
            this.Best_Seller_Table.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.Best_Seller_Table.Location = new System.Drawing.Point(93, 123);
            this.Best_Seller_Table.Name = "Best_Seller_Table";
            this.Best_Seller_Table.ReadOnly = true;
            this.Best_Seller_Table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.Best_Seller_Table.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Best_Seller_Table.RowTemplate.Height = 24;
            this.Best_Seller_Table.Size = new System.Drawing.Size(1167, 540);
            this.Best_Seller_Table.TabIndex = 16;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Category";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Quntity";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Total";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Best_Seller_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1299, 715);
            this.Controls.Add(this.Best_Seller_Table);
            this.Controls.Add(this.Count_Value_Label);
            this.Controls.Add(this.Count_Label);
            this.Controls.Add(this.To_Label);
            this.Controls.Add(this.From_Label);
            this.Controls.Add(this.Category_Label);
            this.Controls.Add(this.Search_Text_Box);
            this.Controls.Add(this.To_Date_Picker);
            this.Controls.Add(this.From_Date_Picker);
            this.Controls.Add(this.Category_Combo_Box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Best_Seller_Form";
            this.Text = "Best_Seller_Form";
            ((System.ComponentModel.ISupportInitialize)(this.Best_Seller_Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox Category_Combo_Box;
        private System.Windows.Forms.DateTimePicker From_Date_Picker;
        private System.Windows.Forms.DateTimePicker To_Date_Picker;
        private Guna.UI2.WinForms.Guna2TextBox Search_Text_Box;
        private Guna.UI2.WinForms.Guna2HtmlLabel Category_Label;
        private Guna.UI2.WinForms.Guna2HtmlLabel From_Label;
        private Guna.UI2.WinForms.Guna2HtmlLabel To_Label;
        private Guna.UI2.WinForms.Guna2HtmlLabel Count_Label;
        private Guna.UI2.WinForms.Guna2HtmlLabel Count_Value_Label;
        private System.Windows.Forms.DataGridView Best_Seller_Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}