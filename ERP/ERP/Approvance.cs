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
    public partial class Approvance : Form
    {
        connection mc = new connection();
        public Approvance()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }

        //My_connection mc = new My_connection();



        private void Approvance_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();


                OleDbCommand cmd = new OleDbCommand("SELECT CID From Customer  where CStatus='" + "UnApproved" + "'", mc.conn);

                OleDbDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    comboBox1.Items.Add(Dr["CID"]);
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

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                mc.conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT *  From Customer  where CID='" + comboBox1.SelectedItem + "'", mc.conn);
                OleDbDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {


                    textBox11.Text = Dr["CID"].ToString();
                    textBox1.Text = Dr["CName"].ToString();
                    textBox2.Text = Dr["CAddress"].ToString();
                    textBox4.Text = Dr["City"].ToString();
                    textBox5.Text = Dr["PH1"].ToString();
                    textBox6.Text = Dr["PH2"].ToString();
                    textBox7.Text = Dr["ContectPerson"].ToString();
                    textBox8.Text = Dr["CPPH"].ToString();
                    textBox9.Text = Dr["CEmail"].ToString();
                    textBox10.Text = Dr["CreditLimit"].ToString();
                    textBox12.Text = Dr["CGroup"].ToString();


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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Select Approvence..");
            }
            else
            {
                try
                {
                    mc.conn.Open();
                    OleDbCommand cmd = new OleDbCommand("update Customer set CStatus ='" + comboBox2.Text + "' where CID ='" + textBox11.Text + "'", mc.conn);
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
            textBox11.Text ="";
            textBox1.Text ="";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text ="";
            textBox10.Text = "";
            textBox12.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
