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
    public partial class Sales_Approvance : Form
    {
        connection mc = new connection();
        public Sales_Approvance()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }

        //My_connection mc = new My_connection();

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * From SO where SOID='" + comboBox1.SelectedItem + "'", mc.conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox11.Text = dr["SOID"].ToString();
                    textBox1.Text = dr["Status"].ToString();
                    textBox4.Text = dr["CID"].ToString();
                    textBox5.Text = dr["CName"].ToString();
                    textBox6.Text = dr["CDept"].ToString();
                    textBox7.Text = dr["CContectPerson"].ToString();
                    textBox8.Text = dr["CPPH"].ToString();
                    textBox9.Text = dr["DDate"].ToString();
                    textBox10.Text = dr["TotalAmount"].ToString();

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

        private void Sales_Approvance_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();


                OleDbCommand cmd = new OleDbCommand("SELECT SOID From SO where Approve='" + "UnApproved" + "'", mc.conn);

                OleDbDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    comboBox1.Items.Add(Dr["SOID"]);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Select Approve....");
            }
            else
            {
                try
                {
                    mc.conn.Open();


                    OleDbCommand cmd = new OleDbCommand("update SO set Approve ='" + comboBox2.Text + "' where SOID ='" + textBox11.Text + "'", mc.conn);

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
