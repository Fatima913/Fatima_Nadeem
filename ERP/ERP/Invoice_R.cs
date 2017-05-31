using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ERP
{
    public partial class Invoice_R : Form
    {
        connection mc = new connection();
        public Invoice_R()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }

        //My_connection mc = new My_connection();

        private void Invoice_R_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();


                OleDbCommand cmd = new OleDbCommand("SELECT DCID From DeliveryChalan where GoodRecieved='" + "Open" + "'", mc.conn);

                OleDbDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    comboBox1.Items.Add(Dr["DCID"]);
                }

                int c = 0;

                OleDbCommand cmd1 = new OleDbCommand("select count (InvoiceNo) from InvoiceRecievable", mc.conn);

                OleDbDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    c = Convert.ToInt32(dr1[0]);
                    c++;

                }

                textBox11.Text = c.ToString();

                mc.conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                mc.conn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                {
                    OleDbCommand cmd = new OleDbCommand("select * from DeliveryChalan where DCID='" + comboBox1.SelectedItem + "'", mc.conn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        textBox2.Text = dr["SOID"].ToString();
                        textBox1.Text = dr["CName"].ToString();
                        textBox10.Text = dr["DDate"].ToString();
                        textBox15.Text = dr["RDate"].ToString();
                    }


                    {

                        OleDbCommand cmd1 = new OleDbCommand("Select * from Customer where Cname= '" + textBox1.Text + "'", mc.conn);
                        OleDbDataReader dr1 = cmd1.ExecuteReader();

                        while (dr1.Read())
                        {
                            textBox4.Text = dr1["CID"].ToString();
                            textBox3.Text = dr1["CGroup"].ToString();
                            textBox12.Text = dr1["PH1"].ToString();
                        }
                    }

                    {


                        OleDbCommand cmd2 = new OleDbCommand("Select * from SOProducts where SOID='" + textBox2.Text + "'", mc.conn);
                        OleDbDataReader dr2 = cmd2.ExecuteReader();

                        while (dr2.Read())
                        {
                            textBox6.Text = dr2["PModel"].ToString();
                            textBox8.Text = dr2["PQty"].ToString();

                        }
                    }

                    {
                        OleDbCommand cmd3 = new OleDbCommand("Select * from Products where PModel = '" + textBox6.Text + "'", mc.conn);
                        OleDbDataReader dr3 = cmd3.ExecuteReader();

                        while (dr3.Read())
                        {
                            textBox7.Text = dr3["PName"].ToString();
                        }

                    }
                    {

                        OleDbCommand cmd4 = new OleDbCommand("select * from SO where SOID = '" + textBox2.Text + "'", mc.conn);
                        OleDbDataReader dr4 = cmd4.ExecuteReader();

                        while (dr4.Read())
                        {
                            textBox9.Text = dr4["TotalAmount"].ToString();
                        }
                    }

                    mc.conn.Close();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                mc.conn.Close();
            }
            }



        int t = 0;
        int a = 0;
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            t = Convert.ToInt32(textBox9.Text) * 17 / 100;

            textBox14.Text = t.ToString();

            a= Convert.ToInt32(textBox14.Text) + Convert.ToInt32(textBox9.Text);
            textBox13.Text = a.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("insert into InvoiceRecievable([InvoiceNo],[CustomerID],[CustomerName],[Phone_No],[DDate],[RDate],[AmountRecievable],[DCID]) Values (@InvoiceNo,@CustomerID,@CustomerName,@Phone_No,@DDate,@RDate,@AmountRecievable,@DCID)", mc.conn);

                cmd.Parameters.AddWithValue("@InvoiceNo", textBox11.Text);
                cmd.Parameters.AddWithValue("@CustomerID", textBox4.Text);
                cmd.Parameters.AddWithValue("@CustomerName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Phone_No", Convert.ToInt32(textBox12.Text));
                cmd.Parameters.AddWithValue("@DDate", textBox10.Text);
                cmd.Parameters.AddWithValue("@RDate", textBox15.Text);
                cmd.Parameters.AddWithValue("@AmountRecievable", Convert.ToInt32(textBox13.Text));
                cmd.Parameters.AddWithValue("@DCID", comboBox1.SelectedItem);
                cmd.ExecuteNonQuery();

                OleDbCommand cmd1 = new OleDbCommand("UPDATE DeliveryChalan set GoodRecieved ='Close' where DCID ='" + comboBox1.SelectedItem + "'", mc.conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Invoice Has Been Created!");
                mc.conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                mc.conn.Close();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        }
        
    }

