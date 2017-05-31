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
    public partial class Sales_Order : Form
    {
        connection mc = new connection();
        public Sales_Order()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }

        string[] prds = new string[50];
        int[] qty = new int[50];
        int[] tot = new int[50];
        int counter = 0;

        //My_connection mc = new My_connection();
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Sales_Order_Load(object sender, EventArgs e)
        {
            try
            {

                {
                    mc.conn.Open();


                    OleDbCommand cmd = new OleDbCommand("SELECT CID From Customer  where CStatus='" + "Approved" + "'", mc.conn);

                    OleDbDataReader Dr = cmd.ExecuteReader();

                    while (Dr.Read())
                    {

                        comboBox1.Items.Add(Dr["CID"]);
                    }


                    OleDbCommand cmd1 = new OleDbCommand("Select PModel from Products", mc.conn);
                    OleDbDataReader Dr1 = cmd1.ExecuteReader();
                    while (Dr1.Read())
                    {
                        comboBox2.Items.Add(Dr1["PModel"]);
                    }

                    int c = 0;
                    OleDbCommand cmd2 = new OleDbCommand("select count (SOID) from SO", mc.conn);
                    OleDbDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        c = Convert.ToInt32(dr2[0]); c++;

                    }

                    textBox9.Text = "SO-" + c.ToString() + "-" + System.DateTime.Today.Year;
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT *  From Customer  where CID='" + comboBox1.SelectedItem + "'", mc.conn);
                OleDbDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {


                    textBox1.Text = Dr["CName"].ToString();
                    textBox4.Text = Dr["CPPH"].ToString();
                    textBox3.Text = Dr["ContectPerson"].ToString();
                    textBox2.Text = Dr["CGroup"].ToString();


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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
                    textBox5.Text = dr["PName"].ToString();
                    textBox6.Text = dr["BasePrice"].ToString();


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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "0";

            }

            else
            {
                int mul = Convert.ToInt32(textBox6.Text) * Convert.ToInt32(textBox7.Text);

                textBox8.Text = mul.ToString();
                textBox10.Text = mul.ToString();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox11.Text += comboBox2.SelectedItem + Environment.NewLine;
            textBox12.Text += textBox7.Text + Environment.NewLine;
            textBox13.Text += textBox10.Text + Environment.NewLine;

            prds[counter] = comboBox2.SelectedItem.ToString();
            qty[counter] = Convert.ToInt32(textBox7.Text);
            tot[counter] = Convert.ToInt32(textBox10.Text);
            counter++;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {

                mc.conn.Open();
                {

                    OleDbCommand cmd = new OleDbCommand("insert into SO(SOID,DDate,Status,Approve,CDept,CName,CID,CContectPerson,CPPH,DCDate,TotalAmount)" +
                    "values(@SOID,@DDate,@Status,@Approve,@CDept,@CName,@CID,@CContectPerson,@CPPH,,@DCDate,@TotalAmount);", mc.conn);
                    cmd.Parameters.AddWithValue("@SOID", textBox9.Text);
                    cmd.Parameters.AddWithValue("@DDate", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Status", "Open");
                    cmd.Parameters.AddWithValue("@Approve", "UnApproved");
                    cmd.Parameters.AddWithValue("@CDept", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CId", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@CContectPerson", textBox3.Text);
                    cmd.Parameters.AddWithValue("@CPPH", textBox4.Text);
                    DateTime thisDay = DateTime.Today;
                    cmd.Parameters.AddWithValue("@DCDate", thisDay);
                    cmd.Parameters.AddWithValue("@TotalAmount", textBox10.Text);
                    cmd.ExecuteNonQuery();
                }
                
                {
                    OleDbCommand cmd = new OleDbCommand("insert into SOProducts(SOID,PModel,PQty)values(@SOID,@PModel,@PQty);", mc.conn);
                    cmd.Parameters.AddWithValue("@SOID", textBox9.Text);
                    cmd.Parameters.AddWithValue("@PModel", textBox11.Text);
                    cmd.Parameters.AddWithValue("@PQty", textBox12.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Order successfully added....");
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
    }
}
