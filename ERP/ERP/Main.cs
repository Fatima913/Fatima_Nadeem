using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void arpprovanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       

        private void verificationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            customer data = new customer();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void approvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvance data = new Approvance();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        
        private void entryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendor data = new Vendor();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void approvanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VApprovance data = new VApprovance();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void pOCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_Order data = new Purchase_Order();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void pOApprovanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO_Approvance data = new PO_Approvance();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void gRNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createGRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GRN data = new GRN();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void generateInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invoice data = new invoice();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
            
        }
    }
}
