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
    public partial class ProductSummaryDialog2 : Form
    {

        public decimal TotalCost { get; set; }
        public decimal SRP { get; set; }
        public decimal SRPPerUnit { get; set; }
        public string SelectedSize { get; set; } = string.Empty;
        public ProductSummaryDialog2(string productName, int servings, decimal totalProductCost, decimal srpPerUnit_XSM, decimal srpPerUnit_L2XL)
        {
            InitializeComponent();

            // Example: assign to labels or store in variables
            View_p.Text = productName;
            View_unitbeauty.Text = servings.ToString();
            View_tpcbeauty.Text = "₱" + totalProductCost.ToString("0.00");
            Xs_Sizes.Text = "₱" + srpPerUnit_XSM.ToString("0.00");
            L_Sisez.Text = "₱" + srpPerUnit_L2XL.ToString("0.00");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void View_back_Click(object sender, EventArgs e)
        {
            ClothingCategory2 clothingCategory2 = new ClothingCategory2();
            clothingCategory2.LoadData(TotalCost, SRP, SRPPerUnit, SelectedSize);
            clothingCategory2.Show();
            this.Hide();
        }

        private void ProductSummaryDialog2_Load(object sender, EventArgs e)
        {

        }
    }
}
