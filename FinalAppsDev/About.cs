﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalAppsDevProject
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void home_page_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void category_page_Click(object sender, EventArgs e)
        {
            Category categoryForm = new Category();
            categoryForm.Show();
            this.Hide();
        }

        private void contact_page_Click(object sender, EventArgs e)
        {
            Contact Contact = new Contact();
            Contact.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_2(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Category categoryForm = new Category();
            categoryForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
             Contact contact = new Contact();
             contact.Show();
             this.Hide();
        }
    }
}
