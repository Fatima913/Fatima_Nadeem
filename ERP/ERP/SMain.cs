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
    public partial class SMain : Form
    {
        public SMain()
        {
            InitializeComponent();
        }

        private void verificationToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void approvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void addOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales_Order data = new Sales_Order();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void approvedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales_Approvance data = new Sales_Approvance();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            D_Chalan data = new D_Chalan();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void generateInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice_R data = new Invoice_R();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }
    }
}
