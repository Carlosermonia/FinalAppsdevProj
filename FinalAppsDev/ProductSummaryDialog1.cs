using System;
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
    public partial class ProductSummaryDialog1 : Form
    {
        private BeautyCategory2 _beautyCategoryForm;
        public ProductSummaryDialog1(BeautyCategory2 beautyCategoryForm)
        {
            InitializeComponent();
            _beautyCategoryForm = beautyCategoryForm;


        }

        public void SetSummaryData(string productName, int servings, decimal totalProductCost, decimal srpTotal, decimal srpPerUnit)
        {
            View_p.Text = productName;
            View_unitbeauty.Text = servings.ToString();
            View_tpcbeauty.Text = "₱" + totalProductCost.ToString("0.00");
            View_srpbeauty.Text = "₱" + srpTotal.ToString("0.00");
            View_srppebeauty.Text = "₱" + srpPerUnit.ToString("0.00");
        }

        private void ProductSummaryDialog1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void View_productbeauty_Click(object sender, EventArgs e)
        {

        }

        private void View_back_Click(object sender, EventArgs e)
        {
            _beautyCategoryForm.Show();
            this.Hide();
        }
    }
}
