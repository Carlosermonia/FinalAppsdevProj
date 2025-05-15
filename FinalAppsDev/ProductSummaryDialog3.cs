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
    public partial class ProductSummaryDialog3 : Form
    {
        private CleaningCategory2? _cleaningCategoryForm;

        public ProductSummaryDialog3(CleaningCategory2 cleaningCategoryForm)
        {
            InitializeComponent();
            _cleaningCategoryForm = cleaningCategoryForm;
        }

        public ProductSummaryDialog3()
        {
            InitializeComponent();
        }
        public void SetSummaryData(string productName, int servings, decimal totalProductCost, decimal srpTotal, decimal srpPerUnit)
        {
            View_p.Text = productName;
            View_unitbeauty.Text = servings.ToString();
            View_tpcbeauty.Text = "₱" + totalProductCost.ToString("0.00");
            View_srpbeauty.Text = "₱" + srpTotal.ToString("0.00");
            View_srppebeauty.Text = "₱" + srpPerUnit.ToString("0.00");
        }
        private void ProductSummaryDialog3_Load(object sender, EventArgs e)
        {

        }

        private void View_back_Click(object sender, EventArgs e)
        {
            if (_cleaningCategoryForm != null)
            {
                _cleaningCategoryForm.Show();
            }
            this.Close();          
        }
    }
}
