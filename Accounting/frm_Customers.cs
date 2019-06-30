using Accounting.DataLayer.Context;
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
            using (UnitOfWork UOF = new UnitOfWork())
            {
                dgvcustomers.DataSource = UOF.Customers.GetAll();
            }
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork UOF = new UnitOfWork())
            {
                dgvcustomers.DataSource = UOF.Customers.GetCustomersByFilter(txtFilter.Text.Trim());
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvcustomers.CurrentRow != null)
            {
                using (UnitOfWork UOW = new UnitOfWork())
                {
                    int customerid = int.Parse(dgvcustomers.CurrentRow.Cells[0].Value.ToString());
                    UOW.Customers.DeleteByID(customerid);
                    UOW.Save();
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
    }
}
