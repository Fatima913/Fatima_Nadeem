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
    public partial class Purchase_Order : Form
    {
        connection mc = new connection();
        public Purchase_Order()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }

        string[] prds = new string[50];
        int[] qty = new int[50];
        int[] tot = new int[50];
        int counter = 0; 

        //My_connection mc = new My_connection();

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * from Vendor where VID = '" + comboBox3.SelectedItem + "'", mc.conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox3.Text = dr["VName"].ToString();
                    textBox4.Text = dr["VCode"].ToString();
                    textBox5.Text = dr["VGroup"].ToString();
                    textBox6.Text = dr["VAddress"].ToString();
                    textBox7.Text = dr["VEmail"].ToString();
                    textBox14.Text = dr["CPName"].ToString();
                    textBox15.Text = dr["CPPH"].ToString();
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

        private void Purchase_Order_Load(object sender, EventArgs e)
        {
           try
            {
                mc.conn.Open();

                //POID Populate

                int c = 0;



                OleDbCommand cmd = new OleDbCommand("select count (POID) from PO", mc.conn);

                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]); c++;

                }

                textBox2.Text = "PO-" + c.ToString() + "-" + System.DateTime.Today.Year;




                    //Vender ID Populate

                    OleDbCommand cmd1 = new OleDbCommand("SELECT VID from Vendor", mc.conn);
                    OleDbDataReader Dr1 = cmd1.ExecuteReader();

                    while (Dr1.Read())
                    {

                        comboBox3.Items.Add(Dr1["VID"]);

                    }


                    //Product ID Populate

                    OleDbCommand cmd2 = new OleDbCommand("SELECT PModel from Products", mc.conn);
                    OleDbDataReader Dr2 = cmd2.ExecuteReader();

                    while (Dr2.Read())
                    {

                        comboBox2.Items.Add(Dr2["PModel"]);

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * from Products where PModel = '" + comboBox2.SelectedItem + "'", mc.conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox9.Text = dr["BasePrice"].ToString();
                    textBox8.Text = dr["PName"].ToString();

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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "0";

            }

            else
            { 
             int mul = Convert.ToInt32(textBox9.Text) * Convert.ToInt32(textBox10.Text);

             textBox11.Text = mul.ToString();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                textBox1.Text += comboBox2.SelectedItem + Environment.NewLine;
                textBox12.Text += textBox10.Text + Environment.NewLine;
                textBox13.Text += textBox11.Text + Environment.NewLine;

                prds[counter] = comboBox2.SelectedItem.ToString();
                qty[counter] = Convert.ToInt32(textBox10.Text);
                tot[counter] = Convert.ToInt32(textBox11.Text);
                counter++;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                {

                    {
                        string status = "Open";
                        string app = "UnApproved";
                        OleDbCommand cmd = new OleDbCommand("insert into PO ([POID],[DDate],[Status],[Approve],[VDept],[VName],[VID],[VContectPerson],[VCPPH],[TotalAmount]) values (@POID,@DDate,@Status,@Approve,@VDept,@VName,@VID,@VContectPerson,@VCPPH,@TotalAmount)", mc.conn);
                        cmd.Parameters.AddWithValue("@POID", textBox2.Text);
                        cmd.Parameters.AddWithValue("@DDate", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Approve", app);
                        cmd.Parameters.AddWithValue("@VDept", textBox5.Text);
                        cmd.Parameters.AddWithValue("@VName", textBox3.Text);
                        cmd.Parameters.AddWithValue("@VID", comboBox3.Text);
                        cmd.Parameters.AddWithValue("@VContectPerson", textBox14.Text);
                        cmd.Parameters.AddWithValue("@VCPPH", Convert.ToInt32(textBox15.Text));
                        cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToInt32(textBox11.Text));
                        cmd.ExecuteNonQuery();
                    }


                    {
                        OleDbCommand cmd = new OleDbCommand("insert into POProducts ([POID],[PModel],[PQty]) values (@POID,@PModel,@PQty)", mc.conn);
                        cmd.Parameters.AddWithValue("@POID", textBox2.Text);
                        cmd.Parameters.AddWithValue("@PModel", textBox1.Text);
                        cmd.Parameters.AddWithValue("@PQty", textBox12.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                mc.conn.Close();
                MessageBox.Show("Transaction done!!");
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
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
                
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

