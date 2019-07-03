using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting
{
    public partial class frm_Customers : Form
    {
       
        public frm_Customers()
        {
            InitializeComponent();
        }

        private void frm_Customers_Load(object sender, EventArgs e)
        {
            dgvcustomers.AutoGenerateColumns = false;
            DataBinding();
        }

        private void DataBinding()
        {
            using (Business.Customers customers = new  Business.Customers())
            {
                dgvcustomers.DataSource = customers.Get();// customers.Get();
            }
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using (Business.Customers customers = new Business.Customers())
            {
                dgvcustomers.DataSource = customers.Get(w => w.FullName.Contains(txtFilter.Text.Trim()) || w.Address.Contains(txtFilter.Text.Trim()) || w.Email.Contains(txtFilter.Text.Trim()));
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvcustomers.CurrentRow != null)
            {
                using (Business.Customers customers = new Business.Customers())
                {
                    int customerid = int.Parse(dgvcustomers.CurrentRow.Cells[0].Value.ToString());
                    customers.DeleteByID(customerid);
                    customers.Save();
                }
                
            }
            else
            {
                MessageBox.Show("یک خط انتخاب کنید");
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            frm_AddCustomer frm_AddCustomer = new frm_AddCustomer();
            if (frm_AddCustomer.ShowDialog() == DialogResult.OK)
            {
                DataBinding();
            }
            
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvcustomers.CurrentRow != null)
            {
                int customerid = int.Parse(dgvcustomers.CurrentRow.Cells[0].Value.ToString());
                frm_AddCustomer frm_AddCustome = new frm_AddCustomer();
                frm_AddCustome.CustomerID = customerid;
                if(frm_AddCustome.ShowDialog() == DialogResult.OK)
                {
                    DataBinding();
                }
            }
            else
            {
                MessageBox.Show("یک نفر رو انتخاب کن");
            }
        }
    }
}
