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
    public partial class GRN : Form
    {
        connection mc = new connection();
        public GRN()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }

        //My_connection mc = new My_connection();
        private void GRN_Load(object sender, EventArgs e)
        {
            try
            {

                mc.conn.Open();


                //// SNO
                {
                    int c = 0;

                    OleDbCommand cmd = new OleDbCommand("select count (SNO) from GRN", mc.conn);

                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c = Convert.ToInt32(dr[0]);
                        c++;

                    }

                    textBox11.Text = c.ToString();
                }

                ////POID

                {
                    OleDbCommand cmd = new OleDbCommand("SELECT POID From PO  where Approve='" + "Approved" + "'", mc.conn);

                    OleDbDataReader Dr = cmd.ExecuteReader();

                    while (Dr.Read())
                    {

                        comboBox1.Items.Add(Dr["POID"]);
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
            
                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("Select * From POProducts where POID='" + comboBox1.SelectedItem + "'", mc.conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox1.Text = dr["PModel"].ToString();
                    textBox4.Text = dr["PQty"].ToString();
                }

                OleDbCommand cmd1 = new OleDbCommand("Select * From PO where POID = '" + comboBox1.SelectedItem + "'", mc.conn);
                OleDbDataReader dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {
                    textBox5.Text = dr1["VID"].ToString();
                    textBox6.Text = dr1["VName"].ToString();
                    textBox7.Text = dr1["VDept"].ToString();
                    textBox8.Text = dr1["DDate"].ToString();
                    textBox10.Text = dr1["TotalAmount"].ToString();

                }

                {

                    string[] stringArray = comboBox1.Text.Split(new char[] { '-' }, StringSplitOptions.None);
                    textBox9.Text = "GRN_" + stringArray[1] + "_" + System.DateTime.Today.Year;

                }

                mc.conn.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                mc.conn.Open();

                string status = "Open";
                OleDbCommand cmd = new OleDbCommand("Insert into GRN([GRNID],[BaseDocument],[Status],[DDate],[VName],[GRDate],[SNO]) Values (@GRNID,@BaseDocument,@Status,@DDate,@VName,@GRDate,@SNO)", mc.conn);

                cmd.Parameters.AddWithValue("@GRNID", textBox9.Text);
                cmd.Parameters.AddWithValue("@BaseDocument", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@DDate", textBox8.Text);
                cmd.Parameters.AddWithValue("@VName", textBox6.Text);
                cmd.Parameters.AddWithValue("@GRDate", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@SNO", textBox11.Text);
                cmd.ExecuteNonQuery();

                OleDbCommand cmd1 = new OleDbCommand("update PO set Status = 'Close' where POID ='" + comboBox1.Text + "'", mc.conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("GRN Created");
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
            textBox10.Text = "";
            textBox11.Text = "";
            textBox4.Text="";
            textBox5.Text="";
            textBox6.Text = "";
            textBox7.Text="";
            textBox8.Text="";
            textBox9.Text = "";
            comboBox1.Text = "";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
