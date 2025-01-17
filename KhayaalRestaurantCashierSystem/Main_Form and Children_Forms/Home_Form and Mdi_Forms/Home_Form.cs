﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Khayaal.Main_Form_and_Children_Forms.Home_Form_and_Mdi_Forms
{
    public partial class Home_Form : Form
    {
        static System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString.Value); public EventHandler On_Select = null;
        bool Cashier = false;
        public Home_Form(bool cashier = false)
        {
            InitializeComponent();
            Cashier = cashier;
            Reload();

            Date_Time_Timer.Interval = 1000;
            Date_Time_Timer.Tick += new EventHandler(Refreash_Time);
            Date_Time_Timer.Enabled = true;

        }
        void Reload()
        {

            Fill_Item_Panel();
            Fill_Combo_Box();
            if (Cashier)
                Add_Item_Button.Enabled = false;
        }

        private void Refreash_Time(object sender, EventArgs e)
        {
            Date_Label.Text = DateTime.Now.ToString("ddd , dd MMM yyyy , hh:mm:ss tt");
        }

        public void Fill_Combo_Box()
        {
            Category_Combo_Box.DataSource = null;
            Formatter.CheckConnection(conn);
            conn.Open();
            string sql = "SELECT Category FROM CR.Items GROUP BY Category";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            DataRow row = dt.NewRow();
            dt.Rows.InsertAt(row, 0);
            row["Category"] = "All";
            Category_Combo_Box.DataSource = dt;
            Category_Combo_Box.DisplayMember = "Category";

        }



        private void Search_Text_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '"' || e.KeyChar == '=' || e.KeyChar == '\'' || e.KeyChar == ';') || (Search_Text_Box.Text.Length >= 50 && e.KeyChar != 8)
         || (e.KeyChar == ' ' && Search_Text_Box.Text.Length == 0))

            {
                e.Handled = true;
            }
        }

        public void Fill_Item_Panel()
        {
            Items_Nested_Flow_Layout_Panel.Controls.Clear();
            Formatter.CheckConnection(conn);

            SqlDataAdapter da = new SqlDataAdapter("SELECT Id,[Name],Category,Unit_Price,[Image],[Description] FROM CR.Items ORDER BY Category,[Name] ;", conn);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);

            conn.Close();
            Items_Nested_Flow_Layout_Panel.Controls.Clear();
            foreach (DataRow row in dt.Rows)
            {
                Item_User_Control Item = new Item_User_Control();
                Item.Id = (int)row[0];
                Item.Name = (string)row[1];
                Item.Category = (string)row[2];
                Item.Price = (double)row[3];
                Item.Image = Image.FromStream(new MemoryStream((byte[])row[4]));
                Item.Description = (string)row[5];
                Tool_Tip.SetToolTip(Item.Controls["Information_Button"], Item.ToString());

                Items_Nested_Flow_Layout_Panel.Controls.Add(Item);
                if (!Cashier)
                {
                    Item.Remove_Event += (obj, e) =>
                    {
                        if (Order_Nested_Flow_Layout_Panel.Controls.Count == 0)
                        {
                            DialogResult r = System.Windows.Forms.MessageBox.Show("Are You Sure?", "Warning", MessageBoxButtons.YesNo);
                            if (DialogResult.Yes == r)
                            {
                                Formatter.CheckConnection(conn);

                                Item_User_Control item = (Item_User_Control)obj;
                                SqlCommand Delete = new SqlCommand($"DELETE CR.Items_Relations WHERE Item_Id={item.Id};\nDELETE CR.Items Where Id ={item.Id};\nUpdate CR.Bills_Details Set Category=N'Deleted' Where Item_Id={item.Id};", conn);

                                conn.Open();
                                Delete.ExecuteNonQuery();
                                conn.Close();
                                ((Item_User_Control)obj).Dispose();
                                System.Windows.Forms.MessageBox.Show("Successfully Done!!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Finish Your Bill First!!");
                        }

                    };
                    Item.Edit_Event += (obj, e) =>
                    {
                        if (Order_Nested_Flow_Layout_Panel.Controls.Count == 0)
                        {
                            Item_User_Control i = (Item_User_Control)obj;
                            Add_Edit_HF_Mdi_Form form = new Add_Edit_HF_Mdi_Form(i.Name, $"{i.Price}", $"{i.Description}", $"{i.Category}", i.Image, i.Id);
                            form.MdiParent = this.Owner;
                            form.Referesh_Current_Form += (obj2, ef) =>
                            {
                                this.Reload();
                            };
                            form.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Finish Your Bill First!!");
                        }

                    };
                }


                Item.Add_Event += (obj, e) =>
                {
                    foreach (var item in Order_Nested_Flow_Layout_Panel.Controls.OfType<Order_User_Control>())
                    {
                        if (((Item_User_Control)obj).Id == item.Id)
                        {

                            ((Order_User_Control)item).Qty += 1;
                            ((Order_User_Control)item).Sub_Total = ((Order_User_Control)item).Qty * ((Order_User_Control)item).Price;
                            if (!Check_Negative_Qty())
                            {
                                ((Order_User_Control)item).Qty -= 1;
                                ((Order_User_Control)item).Sub_Total = ((Order_User_Control)item).Qty * ((Order_User_Control)item).Price;
                            }
                            Calculate_Total();
                            return;
                        }
                    }
                    Order_User_Control item2 = new Order_User_Control();
                    item2.Id = ((Item_User_Control)obj).Id;
                    item2.Name = ((Item_User_Control)obj).Name;
                    item2.Price = ((Item_User_Control)obj).Price;
                    item2.Qty = 1;
                    item2.Image = ((Item_User_Control)obj).Image;
                    item2.Sub_Total = item2.Price;
                    Order_Nested_Flow_Layout_Panel.Controls.Add(item2);
                    if (!Check_Negative_Qty())
                        item2.Dispose();
                    Calculate_Total();
                    item2.Increase_Event += (obj2, e2) =>
                    {
                        ((Order_User_Control)obj2).Qty += 1;
                        ((Order_User_Control)obj2).Sub_Total = ((Order_User_Control)obj2).Qty * ((Order_User_Control)obj2).Price;
                        if (!Check_Negative_Qty())
                        {
                            ((Order_User_Control)obj2).Qty -= 1;
                            ((Order_User_Control)obj2).Sub_Total = ((Order_User_Control)obj2).Qty * ((Order_User_Control)obj2).Price;
                        }
                        Calculate_Total();
                    };
                    item2.Decrease_Event += (obj3, e2) =>
                    {
                        if (((Order_User_Control)obj3).Qty == 1)
                        {
                            ((Order_User_Control)obj3).Dispose();
                        }
                        else
                        {
                            ((Order_User_Control)obj3).Qty -= 1;
                            ((Order_User_Control)obj3).Sub_Total = ((Order_User_Control)obj3).Qty * ((Order_User_Control)obj3).Price;
                        }
                        Calculate_Total();
                    };
                    item2.Remove_Event += (obj3, e2) =>
                    {
                        ((Order_User_Control)obj3).Dispose();
                        Calculate_Total();
                    };
                };


            }
        }
        void Choose_Query()
        {
            string Search = Formatter.SpecialFormatting(Search_Text_Box.Text);
            string Caetgory = Category_Combo_Box.Text;
            foreach (var item in Items_Nested_Flow_Layout_Panel.Controls.OfType<Item_User_Control>())
            {
                if (Caetgory == "All" && Search == "")
                    item.Visible = true;
                else if (Caetgory == "All" && Search != "")
                    item.Visible = item.Name.Contains(Search);
                else if (Caetgory != "All" && Search == "")
                    item.Visible = item.Category == Caetgory;
                else if (Caetgory != "All" && Search != "")
                    item.Visible = item.Name.Contains(Search) && item.Category == Caetgory;
            }
        }
        private void Search_Text_Box_TextChanged(object sender, EventArgs e)
        {
            Choose_Query();
        }

        private void Category_Combo_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Choose_Query();
        }

        private void Clear_All_Button_Click(object sender, EventArgs e)
        {

            Clear_Order_Nested_Flow_Layout_Panel();
            Calculate_Total();
        }
        void Clear_Order_Nested_Flow_Layout_Panel()
        {
            Total_Value_Label.Text = "0";
            With_Tax_Label.Text = "0";
            Order_Nested_Flow_Layout_Panel.Controls.Clear();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (Order_Nested_Flow_Layout_Panel.Controls.Count != 0)
            {
                Create_a_Bill();
                MessageBox.Show("Successfully Saved");
            }

            else
                MessageBox.Show("Insert Items To Your Bill First!!");
        }

        private void Print_and_Save_Button_Click(object sender, EventArgs e)
        {
            if (Order_Nested_Flow_Layout_Panel.Controls.Count != 0)
            {
                Create_a_Bill();

                Bills_Form_and_Mdi_Forms.Print_Form.Print_Form Form = new Bills_Form_and_Mdi_Forms.Print_Form.Print_Form();
                Form.Show();

            }
            else
                MessageBox.Show("Insert Items To Your Bill First!!");
        }
        void Create_a_Bill()
        {

            if (Order_Nested_Flow_Layout_Panel.Controls.Count != 0)
            {
                Copy_Data_From_Orig_To_Test();
                Formatter.CheckConnection(conn);
                string Query = "";
                foreach (var item in Order_Nested_Flow_Layout_Panel.Controls.OfType<Order_User_Control>())
                {
                    Query += $"EXEC CR.Decrease_Raw_Materials_Qty @Item_Id={item.Id},@Qty={item.Qty};\r\n";
                }
                SqlCommand Decrease_From_Orig = new SqlCommand(Query, conn);
                Formatter.CheckConnection(conn);

                conn.Open();
                Decrease_From_Orig.ExecuteNonQuery();
                conn.Close();
                Copy_Data_From_Orig_To_Test();

                string Current_Date = Formatter.DateFormating(DateTime.Now);
                SqlCommand Create_a_Bill = new SqlCommand($" INSERT INTO CR.Bills VALUES('{Current_Date}',CR.Get_Last_User_Name_Logged(),CR.Get_Last_User_Id_Logged());\r\n", conn);
                Formatter.CheckConnection(conn);
                conn.Open();
                Create_a_Bill.ExecuteNonQuery();
                conn.Close();
                string Insert_Bills_Details_Query = "";
                foreach (var item in Order_Nested_Flow_Layout_Panel.Controls.OfType<Order_User_Control>())
                {
                    Insert_Bills_Details_Query += $"INSERT INTO CR.Bills_Details VALUES(CR.GET_Last_Bill_Serial(),{item.Id},{item.Qty},{item.Price},N'{item.Name}','{Current_Date}',CR.Get_Item_Category(N'{item.Name}'));\r\n";
                }
                Clear_Order_Nested_Flow_Layout_Panel();
                Formatter.CheckConnection(conn);
                SqlCommand Insert_Bills_Details_Query_Command = new SqlCommand(Insert_Bills_Details_Query, conn);
                conn.Open();

                Insert_Bills_Details_Query_Command.ExecuteNonQuery();
                conn.Close();
            }
            else
                MessageBox.Show("Insert Items To Your Bill First!!");

        }
        bool Check_Negative_Qty()
        {

            Copy_Data_From_Orig_To_Test();
            Formatter.CheckConnection(conn);
            string Query = "";
            string Items_Ids_With_Relation = "";
            string Raw_Ids_With_Relation = "";
            foreach (var item in Order_Nested_Flow_Layout_Panel.Controls.OfType<Order_User_Control>())
            {
                Query += $"EXEC CR.Decrease_Raw_Materials_Qty_Test @Item_Id={item.Id},@Qty={item.Qty};\r\n";
                Items_Ids_With_Relation += $" OR Item_Id={item.Id}";
            }
            Items_Ids_With_Relation = Items_Ids_With_Relation.Remove(0, 3);



            SqlDataAdapter Select_Raw_Relation_Ids = new SqlDataAdapter($"Select Raw_Id From CR.Items_Relations WHERE {Items_Ids_With_Relation} Group By Raw_Id; \r\n", conn);
            DataTable Table_Raw_Relation_Ids = new DataTable();
            Formatter.CheckConnection(conn);

            conn.Open();
            Select_Raw_Relation_Ids.Fill(Table_Raw_Relation_Ids);
            conn.Close();

            if (Table_Raw_Relation_Ids.Rows.Count > 0)
            {
                Formatter.CheckConnection(conn);
                SqlCommand Decrease_From_Test = new SqlCommand(Query, conn);
                conn.Open();
                Decrease_From_Test.ExecuteNonQuery();
                conn.Close();

                Raw_Ids_With_Relation = "AND (";
                foreach (DataRow row in Table_Raw_Relation_Ids.Rows)
                {
                    Raw_Ids_With_Relation += $" OR Id={(int)row[0]}";
                }
                Raw_Ids_With_Relation = Raw_Ids_With_Relation.Remove(5, 3) + ")";
                SqlDataAdapter Check_Negative_Qty = new SqlDataAdapter($"SELECT [Name],Qty FROM CR.Raw_Materials_Test Where Qty<0 {Raw_Ids_With_Relation} ; \r\n", conn);
                DataTable Negative_Qty = new DataTable();

                Formatter.CheckConnection(conn);
                conn.Open();
                Check_Negative_Qty.Fill(Negative_Qty);
                conn.Close();


                Copy_Data_From_Orig_To_Test();

                if (Negative_Qty.Rows.Count > 0)
                {
                    string Warning_Message = "You Need : ";
                    foreach (DataRow row in Negative_Qty.Rows)
                    {
                        Warning_Message += $"{(-1 * (double)row[1])} Units more from {(string)row[0]}\n";
                    }
                    MessageBox.Show(Warning_Message + "\n To Create The Order");

                    //Start of Removable Area
                    if (!Cashier)
                    {
                        DialogResult r = System.Windows.Forms.MessageBox.Show("Do you want to add though ?", "Warning", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == r)
                            return true;
                    }
                    //End of Removable Area

                    return false;//never remove this line !!

                }

            }
            return true;

        }
        void Calculate_Total()
        {
            if (Order_Nested_Flow_Layout_Panel.Controls.Count != 0)
            {
                double Total = 0;
                foreach (var item in Order_Nested_Flow_Layout_Panel.Controls.OfType<Order_User_Control>())
                {
                    Total += item.Sub_Total;

                }
                Total_Value_Label.Text = $"{Total}";
                With_Tax_Label.Text = $"{Total + ((Total / 100) * 14)}";
            }
            else
            {
                Total_Value_Label.Text = "0";
                With_Tax_Label.Text = "0";
            }
        }
        void Copy_Data_From_Orig_To_Test()
        {
            Formatter.CheckConnection(conn);
            SqlCommand Query = new SqlCommand("TRUNCATE TABLE CR.Raw_Materials_Test\r\nINSERT INTO CR.Raw_Materials_Test (Id,Category,Name,Qty) \r\nSELECT Id,Category,Name,Qty FROM CR.Raw_Materials;\r\n", conn);
            conn.Open();
            Query.ExecuteNonQuery();
            conn.Close();
        }

        private void Add_Item_Button_Click(object sender, EventArgs e)
        {
            if (Order_Nested_Flow_Layout_Panel.Controls.Count == 0)
            {
                Add_Edit_HF_Mdi_Form form = new Add_Edit_HF_Mdi_Form();
                form.MdiParent = this.Owner;
                form.Referesh_Current_Form += (obj, ef) =>
                {
                    this.Reload();
                };
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Finish Your Bill First!!");
            }

        }



    }



}


