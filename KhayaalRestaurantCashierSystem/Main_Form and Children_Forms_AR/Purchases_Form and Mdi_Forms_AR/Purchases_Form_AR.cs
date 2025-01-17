﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Khayaal.Main_Form_and_Children_Forms_AR.Purchases_Form_and_Mdi_Forms_AR
{
    public partial class Purchases_Form_AR : Form
    {
        static SqlConnection conn = new SqlConnection(ConnectionString.Value);


        private void Search_Text_Box_TextChanged(object sender, EventArgs e)
        {
            Choose_Query();
        }

        public Purchases_Form_AR()
        {
            Formatter.CheckConnection(conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Name From CR.Raw_Materials;", conn);
            conn.Open();
            da.Fill(dt);
            conn.Close();
            InitializeComponent();
            Reload();
            if (dt.Rows.Count == 0)
                Add_Purchase_Button.Enabled = false;
            else
                Add_Purchase_Button.Enabled = true;
        }
        void Reload()
        {

            Fill_Combo_Box();
            Fill_Table($"select Id,Name,Category,[Cashier_User_Name],[Cashier_User_Id],Qty,Unit_Price,Sub_Total,[Date],Notes FROM CR.Purchases ORDER BY [Date];");
            if (Purchases_Table.Rows.Count == 0)
            {
                From_Date_Picker.Value = To_Date_Picker.Value = DateTime.Now;
                From_Time_Picker.Value = To_Time_Picker.Value = DateTime.Now;
            }
            else
            {
                From_Date_Picker.Value = Convert.ToDateTime(Purchases_Table.Rows[0].Cells[8].Value);

                From_Time_Picker.Value = new DateTime(2023, 1, 12, 0, 0, 0);
                To_Time_Picker.Value = new DateTime(2023, 1, 12, 23, 59, 59);

                To_Date_Picker.Value = Convert.ToDateTime(Purchases_Table.Rows[Purchases_Table.Rows.Count - 1].Cells[8].Value);
            }


        }
        public void Fill_Combo_Box()
        {
            Category_Combo_Box.DataSource = null;
            Formatter.CheckConnection(conn);

            conn.Open();
            string sql = "SELECT Category FROM CR.Raw_Materials GROUP BY Category ORDER BY Category;";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            DataRow row = dt.NewRow();
            dt.Rows.InsertAt(row, 0);
            row["Category"] = "الجميع";
            row = dt.NewRow();
            dt.Rows.InsertAt(row, 1);
            row["Category"] = "المحذوف";
            Category_Combo_Box.DataSource = dt;
            Category_Combo_Box.DisplayMember = "Category";

        }

        void Fill_Table(string Query)
        {
            Formatter.CheckConnection(conn);

            SqlCommand Command = new SqlCommand(Query, conn);
            SqlDataAdapter da = new SqlDataAdapter(Command);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);


            conn.Close();
            Purchases_Table.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {

                Purchases_Table.Rows.Add((int)row[0], (string)row[1], (((string)row[2] == "Deleted") ? "محذوف" : (string)row[2]), (string)row[3], (int)row[4], (double)row[5], (double)row[6], (double)row[7], (DateTime)row[8], (string)row[9]);
            }
            try
            {
                Table_Croll_Bar.Maximum = Purchases_Table.Rows.Count - 1;
            }
            catch { }
            Count_Value_Label.Text = $"{Purchases_Table.Rows.Count}";
            string Sum_Qty = Formatter.Float($"{Purchases_Table.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[5].Value))}");
            string Sum_Total = Formatter.Float($"{Purchases_Table.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[7].Value))}") + " $";

            Sum_Qty_Value_Label.Text = Sum_Qty;

            Sum_Sub_Total_Value_Label.Text = Sum_Total;
        }
        void Choose_Query()
        {
            string From = Formatter.DateFormating(From_Date_Picker.Value, "Normal", From_Time_Picker.Value);
            string To = Formatter.DateFormating(To_Date_Picker.Value, "Normal", To_Time_Picker.Value);

            if (DateTime.Parse(From) > DateTime.Parse(To))
            {
                From_Time_Picker.Value = To_Time_Picker.Value;
                From_Date_Picker.Value = To_Date_Picker.Value;

                MessageBox.Show("!! خطأ في المدي الزمني , قم بتغييره ", "!! خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string Name = Formatter.SpecialFormatting(Search_Text_Box.Text);
                string Category = Category_Combo_Box.Text == "المحذوف" ? "Deleted" : Category_Combo_Box.Text;
                if (Name == "" && Category == "الجميع")
                    Fill_Table($"select Id,Name,Category,[Cashier_User_Name],[Cashier_User_Id],Qty,Unit_Price,Sub_Total,[Date],Notes FROM CR.Purchases WHERE [Date] BETWEEN '{From}' AND '{To}' ORDER BY [Date];");
                else if (Name == "" && Category != "الجميع")
                    Fill_Table($"select Id,Name,Category,[Cashier_User_Name],[Cashier_User_Id],Qty,Unit_Price,Sub_Total,[Date],Notes FROM CR.Purchases WHERE  Category=N'{Category}' AND [Date] BETWEEN '{From}' AND '{To}' ORDER BY [Date];\n");
                else if (Name != "" && Category == "الجميع")
                    Fill_Table($"select Id,Name,Category,[Cashier_User_Name],[Cashier_User_Id],Qty,Unit_Price,Sub_Total,[Date],Notes FROM CR.Purchases WHERE NAME LIKE N'%{Name}%' AND [Date] BETWEEN '{From}' AND '{To}'  ORDER BY [Date];\n");
                else
                    Fill_Table($"select Id,Name,Category,[Cashier_User_Name],[Cashier_User_Id],Qty,Unit_Price,Sub_Total,[Date],Notes FROM CR.Purchases WHERE NAME LIKE N'%{Name}%' AND [Date] BETWEEN '{From}' AND '{To}' AND Category=N'{Category}' ORDER BY [Date];\n");
            }
        }








        private void Category_Combo_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Choose_Query();
        }

        private void From_Date_Picker_ValueChanged(object sender, EventArgs e)
        {
            Choose_Query();
        }

        private void To_Date_Picker_ValueChanged(object sender, EventArgs e)
        {
            Choose_Query();
        }



        private void Table_Croll_Bar_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                Table_Croll_Bar.Maximum = Purchases_Table.Rows.Count - 1;

                Purchases_Table.FirstDisplayedScrollingRowIndex = Purchases_Table.Rows[e.NewValue].Index;
            }
            catch { }

        }

        private void Best_Seller_Table_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                Table_Croll_Bar.Maximum = Purchases_Table.Rows.Count - 1;
            }
            catch { }
        }

        private void Best_Seller_Table_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                Table_Croll_Bar.Maximum = Purchases_Table.Rows.Count - 1;
            }
            catch { }
        }

        private void Sort_By_Combo_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Choose_Query();
        }

        private void Add_Purchase_Button_Click(object sender, EventArgs e)
        {
            Add_BG_Mdi_Form_AR form = new Add_BG_Mdi_Form_AR();
            form.MdiParent = this.Owner;
            form.Referesh_Current_Form += (obj, ef) =>
            {
                this.Reload();
            };
            form.ShowDialog();
        }

        private void Purchases_Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = Purchases_Table.Rows[e.RowIndex];

                int id = (int)row.Cells[0].Value;

                if (Purchases_Table.Columns[e.ColumnIndex].Index == 10)
                {
                    if ((string)row.Cells[2].Value != "محذوف")
                    {
                        try
                        {
                            DialogResult r = System.Windows.Forms.MessageBox.Show("هل انت متأكد ؟", "تحذير", MessageBoxButtons.YesNo);
                            if (DialogResult.Yes == r)
                            {
                                string Name = (string)row.Cells[1].Value;
                                string Qty = $"{(double)row.Cells[5].Value}";
                                string Query = $"DELETE CR.Purchases WHERE Id={id};\nUpdate CR.Raw_Materials Set Qty=Qty-{Qty} Where Name=N'{Name}';";
                                Formatter.CheckConnection(conn);
                                SqlCommand Delete = new SqlCommand(Query, conn);
                                conn.Open();
                                Delete.ExecuteNonQuery();
                                conn.Close();
                                Choose_Query();
                                MessageBox.Show(" ! تم بنجاح");
                            }

                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                    else
                    {
                        MessageBox.Show("! هذة المادة الخام غير موجودة,قد حذفت من النظام مسبقا ", "خطأ ");
                    }

                }
                else if (Purchases_Table.Columns[e.ColumnIndex].Index == 11)
                {

                    try
                    {
                        DialogResult r = System.Windows.Forms.MessageBox.Show("هل انت متأكد ؟", "تحذير", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == r)
                        {
                            string Query = $"DELETE CR.Purchases WHERE Id={id};";
                            Formatter.CheckConnection(conn);
                            SqlCommand Delete = new SqlCommand(Query, conn);
                            conn.Open();
                            Delete.ExecuteNonQuery();
                            conn.Close();
                            Choose_Query();
                            MessageBox.Show(" ! تم بنجاح");
                        }

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            catch { }
        }

        private void To_Time_Picker_ValueChanged(object sender, EventArgs e)
        {
            Choose_Query();
        }

        private void From_Time_Picker_ValueChanged(object sender, EventArgs e)
        {
            Choose_Query();
        }

        private void Edit_Buttton_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook Work_Book = app.Workbooks.Add();
            Excel.Worksheet Work_Sheet = null;
            app.Visible = true;
            Work_Sheet = Work_Book.Sheets["Sheet1"];
            Work_Sheet = Work_Book.ActiveSheet;

            for (int i = 0, k = 0; i < Purchases_Table.ColumnCount - 2; i++, k++)
            {
                if (i == 0)
                {
                    k--;
                    continue;
                }
                Work_Sheet.Cells[1, k + 1] = Purchases_Table.Columns[i].HeaderText;




            }


            for (int j = 0; j < Purchases_Table.Rows.Count; j++)
            {
                for (int i = 0, m = 0; i < Purchases_Table.Columns.Count - 2; i++, m++)
                {
                    if (i == 0)
                    {
                        m--;
                        continue;
                    }
                    Work_Sheet.Cells[j + 2, m + 1] = Purchases_Table.Rows[j].Cells[i].Value.ToString();

                }

            }
            Work_Sheet.Columns.AutoFit();
        }

        private void Search_Text_Box_TextChanged_1(object sender, EventArgs e)
        {
            Choose_Query();
        }

        private void Search_Text_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '"' || e.KeyChar == '=' || e.KeyChar == '\'' || e.KeyChar == ';') || (Search_Text_Box.Text.Length >= 50 && e.KeyChar != 8)
          || (e.KeyChar == ' ' && Search_Text_Box.Text.Length == 0))

            {
                e.Handled = true;
            }
        }
    }
}