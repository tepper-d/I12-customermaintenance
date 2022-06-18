using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/* *******************************************************
* CIS123: Intro to Object-oriented Programming
* Murach C#, 7th ed., pp. 425-426
* Chapter 12. How to create & use classes
* Dominique Tepper, 18JUN2022
* 
* 4. Declare a class variable named customer with an
*    initial value of null.
* 5. Add public GetNewCustomer() that displays form as
*    a (a) dialog box and (b) returns a Customer obj.
* 6. btnSave_Click() event handler that (a) validates
*    data using Validator class methods, (b) creates new
*    Customer obj, and (c) closes for if data is valid.
* 7. Add btnExit_Click event handler
* ******************************************************/

namespace CustomerMaintenance
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        //4. var customer = null
        private Customer customer = null;

        //5. GetNewCustomer()
        public Customer GetNewCustomer()
        {
            this.ShowDialog(); //5a. dialog box
            return customer; //5b. returns obj
        }

        //6. Save button event handler
        //Tepper, 18JUN2022
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData()) //6b, 6c
            {
                customer = new Customer(txtFirstName.Text, txtLastName.Text,
                    txtEmail.Text); //6b creates new obj
                this.Close(); //6c
            }
        }

        //6a. uses Validator class methods
        //Tepper, 18JUN2022
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtFirstName.Text, txtFirstName.Tag.ToString());
            errorMessage += Validator.IsPresent(txtLastName.Text, txtLastName.Tag.ToString());
            errorMessage += Validator.IsValidEmail(txtEmail.Text, txtEmail.Tag.ToString());

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        //7. Cancel click event handler
        //Tepper, 18JUN2022
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
