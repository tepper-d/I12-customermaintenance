using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* *******************************************************
* CIS123: Intro to Object-oriented Programming
* Murach C#, 7th ed., pp. 425-426
* Chapter 12. How to create & use classes
* Dominique Tepper, 18JUN2022
* 
* 8.  Declare customers class var, list tyoe, null
* 9.  Load event handler that uses GetCustomers() of the
*     CustomerDB class, adds customers to listbox. Use 
*     GDT() to format custoemr data
* 10. Add btnAdd_Click event handler that creates a new
*     instance of GNC().
*     If data != null => (a) add new customer obj, (b) call
*     SaveCustomers() of CustomersDB class to save list,
*     (c) refresh Customer listbox.
* 11. btnDelete_Click event handler
*     a. removes selected custoemr
*     b. calls SaveCustomers()
*     c. refreshes list box
* 12. btnExit_Click event handler
* ******************************************************/

namespace CustomerMaintenance
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        //8. var customer, list, null
        private List<Customer> customers = null;

        //9. Load event handler
        //Tepper, 18JUN2022
        private void frmCustomers_Load(object sender, EventArgs e)
        {
            customers = CustomerDB.GetCustomers();
            FillCustomerListBox(); 
        }

        //9. fills list box with customers from DB
        //uses GDT() to format data
        //Tepper, 18JUN2022
        private void FillCustomerListBox()
        {
            lstCustomers.Items.Clear();
            foreach (Customer c in customers)
            {
                lstCustomers.Items.Add(c.GetDisplayText());
            }
        }

        //10. btnAdd event handler that instantiates
        // GetNewCustomer()
        // Tepper, 18JUN2022
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer addCustomerForm = new frmAddCustomer();
            Customer customer = addCustomerForm.GetNewCustomer();
            if (customer != null)
            {
                customers.Add(customer); //10a
                CustomerDB.SaveCustomers(customers); //10b
                FillCustomerListBox(); //10c
            }
        }

        //11. btnDelete event handler
        //Tepper, 18JUN2022
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstCustomers.SelectedIndex;
            if (i != -1)
            {
                Customer customer = customers[i];
                string message = "Are you sure you want to delete "
                    + customer.FirstName + " " + customer.LastName + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    customers.Remove(customer); //1a
                    CustomerDB.SaveCustomers(customers); //11b
                    FillCustomerListBox();   //11c
                }
            }
        }

        //btnExit event handler
        //Tepper, 18JUN2022
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}