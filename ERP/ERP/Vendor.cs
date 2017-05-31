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
    public partial class Vendor : Form
    {
        connection mc = new connection();
        public Vendor()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }
        //My_connection mc = new My_connection();


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Vendor_Load(object sender, EventArgs e)
        {
            mc.conn.Open();
            int c = 0;

            OleDbCommand cmd = new OleDbCommand("select count (VID) from Vendor", mc.conn);

            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;

            }

            textBox11.Text = c.ToString();
            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || comboBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("All Field Required Must Be Filled");
            }
            else
            {
                try
                {
                    mc.conn.Open();

                    OleDbCommand cmd = new OleDbCommand("insert into Vendor([VID],[VName],[VCode],[VCity],[PH1],[PH2],[VAddress],[CPName],[CPPH],[VEmail],[VFax],[VGroup],[VStatus]) values (@VID,@VName,@VCode,@VCity,@PH1,@PH2,@VAddress,@CPName,@CPPH,@VEmail,@VFax,@VGroup,@VStatus)", mc.conn);

                    cmd.Parameters.AddWithValue("@VID", textBox11.Text);
                    cmd.Parameters.AddWithValue("@VName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@VCode", textBox2.Text);
                    cmd.Parameters.AddWithValue("@VCity", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@PH1", Convert.ToInt32(textBox4.Text));
                    cmd.Parameters.AddWithValue("@PH2", Convert.ToInt32(textBox5.Text));
                    cmd.Parameters.AddWithValue("@VAddress", textBox6.Text);
                    cmd.Parameters.AddWithValue("@CPName", textBox7.Text);
                    cmd.Parameters.AddWithValue("@CPPH", Convert.ToInt32(textBox8.Text));
                    cmd.Parameters.AddWithValue("@VEmail", textBox9.Text);
                    cmd.Parameters.AddWithValue("@VFax", textBox10.Text);
                    cmd.Parameters.AddWithValue("@VGroup", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@VStatus", textBox3.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Inserted Successfully!");
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

                textBox11.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                comboBox2.Text = "";
                textBox3.Text = "";
            }

        }
    }
}

