﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/**
 * author Vance Field
 * version 24-Jan-2017
 **/
namespace MetricConverter
{
    public partial class frame : Form
    {

        // global variables
        private double meters;
        private double inches;
        private int feet;

        public frame()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0; // default selection for combo box
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox.SelectedIndex; // get conversion selection 

            // if meters to feet/in selected
            if(index == 0)
            {
                lblInput.Text = "Meters";
                lblOutput.Text = "Feet/Inches";
                txtInput2.Enabled = false; // disable textfield 
            } 

            // if feet/in to meters selected
            if(index == 1)
            {
                lblInput.Text = "Feet / Inches";
                lblOutput.Text = "Meters";
                txtInput2.Enabled = true; // enable textfield
            }

            // clear text fields
            txtInput1.Text = "";
            txtInput2.Text = "";
            txtOutput.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {            
            int index = comboBox.SelectedIndex; // get conversion selection

            // if meters to feet/inches
            if (index == 0)
            {
                try
                { 
                    meters = Double.Parse(txtInput1.Text); // get meters
                    inches = meters * 39.37; // calculate inches
                    feet = (int) inches / 12; // calculate feet
                    double remInches = inches - (feet * 12); // remaining inches

                    // round 

                    txtOutput.Text = feet.ToString() + " ft " + remInches.ToString("0.##") + " in"; // output feet and inches
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Source);
                }
            }

            // if feet/inches to meters
            if (index == 1)
            {
                try
                {
                    // if input1 is empty
                    if (txtInput1.Text.Equals(""))
                    {
                        feet = 0; // set feet to 0
                    }
                    else
                    {
                        feet = Int32.Parse(txtInput1.Text); // get feet
                    }                  
                      
                    double ftInInches = feet * 12; // calculate inches in feet

                    // if input2 is empty
                    if(txtInput2.Equals(""))
                    {
                        inches = 0; // set inches to 0
                    }
                    else
                    {
                        inches = Double.Parse(txtInput2.Text) + ftInInches; // get inches

                    }

                    meters = inches / 39.37; // calculate meters  
                    txtOutput.Text = meters.ToString("0.##"); // output meters
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Source);
                }
            }
        }
    }
}
