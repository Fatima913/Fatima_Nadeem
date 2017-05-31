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
    public partial class VApprovance : Form
    {
        connection mc = new connection();
        public VApprovance()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }
        //My_connection mc = new My_connection();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VApprovance_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT VID From Vendor  where VStatus='" + "UnApproved" + "'", mc.conn);
                OleDbDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    comboBox1.Items.Add(Dr["VID"]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Select Approvence..");
            }
            else
            {
                try
                {
                    mc.conn.Open();


                    OleDbCommand cmd = new OleDbCommand("update Vendor set VStatus ='" + comboBox3.Text + "' where VID ='" + textBox11.Text + "'", mc.conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Verification Approved");
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT *  From Vendor  where VID='" + comboBox1.SelectedItem + "'", mc.conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    textBox11.Text = dr["VID"].ToString();
                    textBox1.Text = dr["VName"].ToString();
                    textBox6.Text = dr["VAddress"].ToString();
                    textBox2.Text = dr["VCode"].ToString();
                    textBox4.Text = dr["VCity"].ToString();
                    textBox7.Text = dr["PH1"].ToString();
                    textBox5.Text = dr["PH2"].ToString();
                    textBox8.Text = dr["CPName"].ToString();
                    textBox9.Text = dr["CPPH"].ToString();
                    textBox10.Text = dr["VEmail"].ToString();
                    textBox3.Text = dr["VFax"].ToString();
                    textBox12.Text = dr["VGroup"].ToString();

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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
