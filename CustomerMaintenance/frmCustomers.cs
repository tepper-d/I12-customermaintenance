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
* 9a. Load event handler that uses GetCustomers() of the
*     CustomerDB class, adds customers to listbox.
* 9b. Use GDT() to format custoemr data
* 10. Add btnAdd_Click event handler that creates a new
*     instance of GNC().
*     If data != null => add new customer obj, call
*     SaveCustomers() of CustomersDB class to save list,
*     refresh Customer listbox.
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

    }
}