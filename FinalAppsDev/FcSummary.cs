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
    public partial class FcSummary : Form
    {

        public FcSummary()
        {
            InitializeComponent();
        }
        public void SetSummary(string productType, string unitSize, string totalProductCost, string srp)
        {
            ProductType.Text = productType;
            UnitSize.Text = unitSize;
            Tpctxt.Text = totalProductCost;
            SrpTxt.Text = srp;
        }

        private void Bck_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FcSummary_Load(object sender, EventArgs e)
        {

        }
    }
}
