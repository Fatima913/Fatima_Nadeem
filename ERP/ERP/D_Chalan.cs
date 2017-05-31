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
    public partial class D_Chalan : Form
    {
        connection mc = new connection();
        public D_Chalan()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }

        //My_connection mc = new My_connection();

        private void D_Chalan_Load(object sender, EventArgs e)
        {
            try
            {

                mc.conn.Open();


                // SNO
                {
                    int c = 0;

                    OleDbCommand cmd = new OleDbCommand("select count (SNO) from DeliveryChalan", mc.conn);

                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c = Convert.ToInt32(dr[0]);
                        c++;

                    }

                    textBox11.Text = c.ToString();
                }
                ////SOID

                {
                    OleDbCommand cmd = new OleDbCommand("SELECT SOID From SO  where Approve='" + "Approved" + "'", mc.conn);

                    OleDbDataReader Dr = cmd.ExecuteReader();

                    while (Dr.Read())
                    {

                        comboBox1.Items.Add(Dr["SOID"]);
                    }

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                

                    OleDbCommand cmd = new OleDbCommand("Select * From SOProducts where SOID='" + comboBox1.SelectedItem + "'", mc.conn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        textBox1.Text = dr["PModel"].ToString();
                        textBox4.Text = dr["PQty"].ToString();
                    }


                    OleDbCommand cmd1 = new OleDbCommand("Select * From SO where SOID = '" + comboBox1.SelectedItem + "'", mc.conn);
                    OleDbDataReader dr1 = cmd1.ExecuteReader();

                    while (dr1.Read())
                    {
                        textBox5.Text = dr1["CID"].ToString();
                        textBox6.Text = dr1["CName"].ToString();
                        textBox7.Text = dr1["CDept"].ToString();
                        textBox8.Text = dr1["DDate"].ToString();

                    }
                    

                        string[] stringArray = comboBox1.Text.Split(new char[] { '_' }, StringSplitOptions.None);
                        textBox9.Text = "DC_" + stringArray[1] + "_" + System.DateTime.Today.Year;


                    mc.conn.Close();
                }
                catch(Exception er)
            {
                    MessageBox.Show(er.Message);
                }
            finally
            {
               mc.conn.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                string status = "Open";
                OleDbCommand cmd = new OleDbCommand("Insert into DeliveryChalan([DCID],[SOID],[GoodRecieved],[DDate],[CName],[RDate],[SNO]) Values (@BCID,@SOID,@GoodRecieved,@DDate,@CName,@RDate,@SNO)", mc.conn);

                cmd.Parameters.AddWithValue("@DCID", textBox9.Text);
                cmd.Parameters.AddWithValue("@SOID", comboBox1.Text);
                cmd.Parameters.AddWithValue("@GoodRecieved", status);
                cmd.Parameters.AddWithValue("@DDate", textBox8.Text);
                cmd.Parameters.AddWithValue("@CName", textBox6.Text);
                DateTime thisDay = DateTime.Today;
                cmd.Parameters.AddWithValue("@RDate", thisDay);
                cmd.Parameters.AddWithValue("@SNO", textBox11.Text);
                cmd.ExecuteNonQuery();

                OleDbCommand cmd1 = new OleDbCommand("update SO set Status = 'Close' where SOID ='" + comboBox1.Text + "'", mc.conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Delivery Chalan Inserted...");
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

            textBox1.Text = "";
            textBox11.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
