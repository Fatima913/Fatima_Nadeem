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
    public partial class PO_Approvance : Form
    {
        connection mc = new connection();
        public PO_Approvance()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }

        //My_connection mc = new My_connection();
        private void PO_Approvance_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();


                OleDbCommand cmd = new OleDbCommand("SELECT POID From PO where Approve='" + "UnApproved" + "'", mc.conn);

                OleDbDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    comboBox1.Items.Add(Dr["POID"]);
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
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Select Approve..");
            }
            else
            {
                try
                {
                    mc.conn.Open();


                    OleDbCommand cmd = new OleDbCommand("update PO set Approve ='" + comboBox2.Text + "' where POID ='" + textBox11.Text + "'", mc.conn);

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

                textBox1.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";

               
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * From PO where POID='" + comboBox1.SelectedItem + "'", mc.conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox11.Text = dr["POID"].ToString();
                    textBox1.Text = dr["Status"].ToString();
                    textBox4.Text = dr["VID"].ToString();
                    textBox5.Text = dr["VName"].ToString();
                    textBox6.Text = dr["VDept"].ToString();
                    textBox7.Text = dr["VContectPerson"].ToString();
                    textBox8.Text = dr["VCPPH"].ToString();
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
    }
}
