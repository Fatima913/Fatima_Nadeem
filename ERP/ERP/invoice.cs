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
    public partial class invoice : Form
    {
        connection mc = new connection();
        public invoice()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }

        //My_connection mc = new My_connection();

        private void invoice_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();


                OleDbCommand cmd = new OleDbCommand("SELECT GRNID From GRN where Status='" + "Open" + "'", mc.conn);

                OleDbDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    comboBox1.Items.Add(Dr["GRNID"]);
                }

                int c = 0;

                OleDbCommand cmd1 = new OleDbCommand("select count (InvoiceNo) from Invoice", mc.conn);

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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();


                OleDbCommand cmd = new OleDbCommand("select * from GRN where GRNID='" + comboBox1.SelectedItem + "'", mc.conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox2.Text = dr["BaseDocument"].ToString();
                    textBox1.Text = dr["VName"].ToString();
                    textBox10.Text = dr["DDate"].ToString();
                }




                OleDbCommand cmd1 = new OleDbCommand("Select * from Vendor where VName= '" + textBox1.Text + "'", mc.conn);
                OleDbDataReader dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {
                    textBox4.Text = dr1["VID"].ToString();
                    textBox3.Text = dr1["VGroup"].ToString();
                    textBox5.Text = dr1["VCode"].ToString();
                    textBox12.Text = dr1["PH1"].ToString();
                }



                OleDbCommand cmd2 = new OleDbCommand("Select * from POProducts where POID='" + textBox2.Text + "'", mc.conn);
                OleDbDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    textBox6.Text = dr2["PModel"].ToString();
                    textBox8.Text = dr2["PQty"].ToString();

                }


                OleDbCommand cmd3 = new OleDbCommand("Select * from Products where PModel = '" + textBox6.Text + "'", mc.conn);
                OleDbDataReader dr3 = cmd3.ExecuteReader();

                while (dr3.Read())
                {
                    textBox7.Text = dr3["PName"].ToString();
                }





                OleDbCommand cmd4 = new OleDbCommand("select * from PO where POID = '" + textBox2.Text + "'", mc.conn);
                OleDbDataReader dr4 = cmd4.ExecuteReader();

                while (dr4.Read())
                {
                    textBox9.Text = dr4["TotalAmount"].ToString();
                }

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


        int adtax = 0;
        int tamount = 0;
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

            adtax = Convert.ToInt32(textBox9.Text) * 17 / 100;

            textBox14.Text = adtax.ToString();

            tamount =Convert.ToInt32(textBox14.Text) + Convert.ToInt32(textBox9.Text);
            textBox13.Text = tamount.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("insert into Invoice([InvoiceNo],[VendorID],[VendorName],[Phone_No],[DDate],[RDate],[AmountPayable],[GRNID]) Values (@InvoiceNo,@VendorID,@VendorName,@Phone_No,@DDate,@RDate,@AmountPayable,@GRNID)", mc.conn);

                cmd.Parameters.AddWithValue("@InvoiceNo", textBox11.Text);
                cmd.Parameters.AddWithValue("@VendorID", textBox4.Text);
                cmd.Parameters.AddWithValue("@VendorName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Phone_No", Convert.ToInt32(textBox12.Text));
                cmd.Parameters.AddWithValue("@DDate", textBox10.Text);
                cmd.Parameters.AddWithValue("@RDate", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@AmountPayable", Convert.ToInt32(textBox13.Text));
                cmd.Parameters.AddWithValue("@GRNID", comboBox1.SelectedItem);
                cmd.ExecuteNonQuery();

                OleDbCommand cmd1 = new OleDbCommand("UPDATE GRN set Status='Close' where GRNID ='" + comboBox1.SelectedItem + "'", mc.conn);
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

            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
            //textBox5.Text = "";
            //textBox6.Text = "";
            //textBox7.Text = "";
            //textBox8.Text = "";
            //textBox9.Text = "";
            //textBox10.Text = "";
            //textBox11.Text = "";
            //textBox12.Text = "";
            //textBox13.Text = "";
            //textBox14.Text = "";
            //comboBox1.Text = "";
       


            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
