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
    public partial class customer : Form
    {
        connection mc = new connection();
        public customer()
        {
            InitializeComponent();
            mc.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "//PC_DB.accdb";
        }
        //My_connection mc = new My_connection();
        
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox3.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("All Field Required Must Be Filled");
            }
            else
            {
                try
                {
                    mc.conn.Open();

                    OleDbCommand cmd = new OleDbCommand("insert into Customer([CID],[Cname],[CAddress],[City],[PH1],[PH2],[ContectPerson],[CPPH],[CEmail],[CreditLimit],[CStatus],[CGroup]) values (@CID,@Cname,@CAddress,@City,@PH1,@PH2,@Contectperson,@CPPH,@CEmail,@CreditLimit,@CStatus,@CGroup)", mc.conn);

                    cmd.Parameters.AddWithValue("@CID", textBox11.Text);
                    cmd.Parameters.AddWithValue("@Cname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CAddress", textBox2.Text);
                    cmd.Parameters.AddWithValue("@City", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@PH1", Convert.ToInt32(textBox4.Text));
                    cmd.Parameters.AddWithValue("@PH2", Convert.ToInt32(textBox5.Text));
                    cmd.Parameters.AddWithValue("@Contectperson", textBox6.Text);
                    cmd.Parameters.AddWithValue("@CPPH", Convert.ToInt32(textBox7.Text));
                    cmd.Parameters.AddWithValue("@CEmail", textBox8.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", Convert.ToInt32(textBox9.Text));
                    cmd.Parameters.AddWithValue("@CStatus", textBox3.Text);
                    cmd.Parameters.AddWithValue("@CGroup", comboBox2.SelectedItem);
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
                    textBox3.Text = "";
                    comboBox2.Text = "";


            }
            }

        private void customer_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                int c = 0;



                OleDbCommand cmd = new OleDbCommand("select count (CID) from Customer", mc.conn);

                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        }

       
    }

