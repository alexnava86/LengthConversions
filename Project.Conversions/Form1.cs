using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[,] conversionTable = {
			{"Miles to kilometers", "Miles", "Kilometers", "1.6093"},
			{"Kilometers to miles", "Kilometers", "Miles", "0.6214"},
			{"Feet to meters", "Feet", "Meters", "0.3048"},
			{"Meters to feet", "Meters", "Feet", "3.2808"},
			{"Inches to centimeters", "Inches", "Centimeters", "2.54"},
			{"Centimeters to inches", "Centimeters", "Inches", "0.3937"}
		};

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(name + " must be a decimal number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            /*
             * SHOULD SUPPORT THE FOLLOWING CONVERSION TYPES
             * 
            Miles  Kilometers  1 mile = 1.6093 kilometers
            Kilometers  Miles   1 kilometer = 0.6214 miles
            Feet    Meters  1 foot = 0.3048 meters
            Meters  Feet    1 meter = 3.2808 feet
            Inches  Centimeters 1 inch = 2.54 centimeters
            Centimeters Inches  1 centimeter = 0.3937 inches
            */
            try
            {
                decimal i = Convert.ToDecimal(conversionTable[cboConversions.SelectedIndex, 3]);
                decimal j = Convert.ToDecimal(txtLength.Text);
                decimal k = i * j;
                lblCalculatedLength.Text = k.ToString();
            }
            catch
            {
                MessageBox.Show("Invalid number value entered.");
            }
            /*
            Add code to calculate and display the converted length 
            when the user clicks the Calculate button. To calculate
            the length, you can get the index for the selected conversion 
            and then use that index to get the multiplier from the array.
            Test the application to be sure this works correctly.
            Add code to check that the user enters a valid decimal value 
            for the length. Then, test the application one more time 
            to be sure the validation works correctly.
             */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboConversions.Items.Add(conversionTable[0, 0]);
            cboConversions.Items.Add(conversionTable[1, 0]);
            cboConversions.Items.Add(conversionTable[2, 0]);
            cboConversions.Items.Add(conversionTable[3, 0]);
            cboConversions.Items.Add(conversionTable[4, 0]);
            cboConversions.Items.Add(conversionTable[5, 0]);
            cboConversions.SelectedItem = cboConversions.Items[0];
            txtLength.Text = cboConversions.SelectedIndex.ToString();
            /*
            Add code to load the combo box with the first element in each row
            of the rectangular (2D) array, and display the first item in the combo box 
            when the form is loaded. 
             */
        }
        
        private void cboConversions_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblFromLength.Text = conversionTable[cboConversions.SelectedIndex, 1];
            lblToLength.Text = conversionTable[cboConversions.SelectedIndex, 2];
            txtLength.Focus();
            /*
            Add code to change the labels for the text boxes, clear the 
            calculated length, and move the focus to the entry text box 
            when the user selects a different item from the combo box.
            
            Test the application to be sure the conversions are displayed 
            in the combo box, the first conversion is selected by default, 
            and the labels change appropriately when a different 
            conversion is selected.
             */
        }
    }
}