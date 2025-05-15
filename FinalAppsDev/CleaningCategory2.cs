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
    public partial class CleaningCategory2 : Form
    {
        private CleaningCategorycs mainForm;
        private string? _productNameSummary;
        private int _servingsSummary;
        private decimal _tpcSummary;
        private decimal _srpTotalSummary;
        private decimal _srpPerUnitSummary;
        private bool _isSummaryAvailable = false;


        public string? ProductNameFromCategory { get; set; }
        public CleaningCategory2(CleaningCategorycs callingForm)
        {
            InitializeComponent();
            mainForm = callingForm;
            Beautypm_cmb.Items.Clear();
            Beautypm_cmb.Items.Add("20%");
            Beautypm_cmb.Items.Add("30%");
            Beautypm_cmb.Items.Add("50%");
            Beautypm_cmb.Items.Add("100%");
        }

        private void CleaningCategory2_Load(object sender, EventArgs e)
        {
            bool isChecked = Btchx_Chckbox.Checked;

            UnitsProduced_Textbox.Visible = isChecked;
            label19.Visible = isChecked;
        }


        private void Add_pcbtn_Click_1(object sender, EventArgs e)
        {
            string material = Beautypck_txt.Text.Trim();
            string qtyText = BeautyQua_txtbox.Text.Trim();
            string costText = Cpubeauty_txt.Text.Trim();

            if (string.IsNullOrWhiteSpace(material) ||
                string.IsNullOrWhiteSpace(qtyText) ||
                string.IsNullOrWhiteSpace(costText))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(qtyText, out decimal quantity) ||
                !decimal.TryParse(costText, out decimal costPerUnit))
            {
                MessageBox.Show("Please enter valid numeric values for Quantity and Cost per Unit.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = quantity * costPerUnit;


            string[] row = new string[]
            {
        material,
        quantity.ToString("0.##"),
        costPerUnit.ToString("0.##"),
        subtotal.ToString("0.##")
            };

            Pc_dgv.Rows.Add(row);


            Beautypck_txt.Clear();
            BeautyQua_txtbox.Clear();
            Cpubeauty_txt.Clear();
        }

        private void Calc_btn_Click(object sender, EventArgs e)
        {
            decimal totalPC = 0;

            foreach (DataGridViewRow row in Pc_dgv.Rows)
            {
                if (row.IsNewRow) continue;

                decimal subtotal = 0;
                decimal.TryParse(Convert.ToString(row.Cells[3].Value), out subtotal); // Subtotal column

                totalPC += subtotal;
            }

            Pctotal_txt.Text = totalPC.ToString("0.##");
        }

        private void Add_ohbtn_Click(object sender, EventArgs e)
        {
            string overheadItem = Oh_txt.Text.Trim();
            string monthlyCostText = Beautymoc_txt.Text.Trim();
            string prodVolumeText = Prodvolbeauty_txt.Text.Trim();

            if (string.IsNullOrWhiteSpace(overheadItem) ||
                string.IsNullOrWhiteSpace(monthlyCostText) ||
                string.IsNullOrWhiteSpace(prodVolumeText))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(monthlyCostText, out decimal monthlyCost) ||
                !decimal.TryParse(prodVolumeText, out decimal prodVolume))
            {
                MessageBox.Show("Please enter valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (prodVolume == 0)
            {
                MessageBox.Show("Production volume cannot be zero.", "Math Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal oc = monthlyCost / prodVolume;

            string[] row = new string[]
            {
        overheadItem,
        monthlyCost.ToString("0.##"),
        oc.ToString("0.####")
            };

            Overhead_dgv.Rows.Add(row);

            Oh_txt.Clear();
            Beautymoc_txt.Clear();
        }

        private void Overheadtotal_btn_Click(object sender, EventArgs e)
        {
            decimal totalMonthlyOverhead = 0;
            decimal prodVolume;


            if (!decimal.TryParse(Prodvolbeauty_txt.Text.Trim(), out prodVolume) || prodVolume <= 0)
            {
                MessageBox.Show("Please enter a valid production volume for overhead calculation.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in Overhead_dgv.Rows)
            {
                if (row.Cells.Count > 1 && row.Cells[1].Value != null &&
                    decimal.TryParse(row.Cells[1].Value.ToString(), out decimal monthlyCost))
                {
                    totalMonthlyOverhead += monthlyCost;
                }
            }

            Totaloh_txt.Text = totalMonthlyOverhead.ToString("0.##");

            decimal overheadPerUnit = totalMonthlyOverhead / prodVolume;
            Perunit_ohc.Text = overheadPerUnit.ToString("0.####");
        }

        private void Btchx_Chckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = Btchx_Chckbox.Checked;

            UnitsProduced_Textbox.Visible = isChecked;
            label19.Visible = isChecked;

            if (!isChecked)
            {
                UnitsProduced_Textbox.Clear();
            }
        }

        private void Add_oebtn_Click(object sender, EventArgs e)
        {
            string description = Expense_txt.Text.Trim();
            string costText = Costpb_txt.Text.Trim();
            bool isBatchBased = Btchx_Chckbox.Checked;
            string unitsProducedText = UnitsProduced_Textbox.Text.Trim();

            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(costText))
            {
                MessageBox.Show("Please enter description and cost.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(costText, out decimal cost))
            {
                MessageBox.Show("Please enter a valid cost value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal costPerUnit = cost;

            if (isBatchBased)
            {
                if (string.IsNullOrWhiteSpace(unitsProducedText) || !decimal.TryParse(unitsProducedText, out decimal unitsProduced) || unitsProduced == 0)
                {
                    MessageBox.Show("Enter valid Units Produced for batch-based cost.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                costPerUnit = cost / unitsProduced;
            }

            string[] row = new string[]
            {
        description,
        cost.ToString("0.##"),
        isBatchBased ? "Yes" : "No",
        isBatchBased ? unitsProducedText : "-",
        costPerUnit.ToString("0.####")
            };

            Oe_dgv.Rows.Add(row);


            Expense_txt.Clear();
            Costpb_txt.Clear();
            UnitsProduced_Textbox.Clear();
            Btchx_Chckbox.Checked = false;
        }

        private void Totaloe_btnbeauty_Click(object sender, EventArgs e)
        {
            decimal totalOE = 0;

            foreach (DataGridViewRow row in Oe_dgv.Rows)
            {
                if (row.IsNewRow) continue;

                if (decimal.TryParse(Convert.ToString(row.Cells[4].Value), out decimal costPerUnit))
                {
                    totalOE += costPerUnit;
                }
            }

            Totaloe_txt.Text = totalOE.ToString("0.####");

        }

        private void Calculate_allcost_Click(object sender, EventArgs e)
        {
            // Check if required fields are filled
            if (string.IsNullOrWhiteSpace(mainForm.MyProductName) ||
                string.IsNullOrWhiteSpace(mainForm.TotalRawMaterialCost) ||
                string.IsNullOrWhiteSpace(mainForm.UtilitiesCost) ||
                string.IsNullOrWhiteSpace(mainForm.TotalLaborCost) ||
                string.IsNullOrWhiteSpace(mainForm.LaborCostPerUnit) ||
                string.IsNullOrWhiteSpace(Pctotal_txt.Text) ||
                string.IsNullOrWhiteSpace(Totaloh_txt.Text) ||
                string.IsNullOrWhiteSpace(Perunit_ohc.Text) ||
                string.IsNullOrWhiteSpace(Totaloe_txt.Text) ||
                string.IsNullOrWhiteSpace(Beautypm_cmb.Text) ||
                string.IsNullOrWhiteSpace(Servings_txt.Text))
            {
                MessageBox.Show("Please fill in all required fields before calculating.", "Missing Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Parse input values
                decimal rmc = decimal.Parse(mainForm.TotalRawMaterialCost);
                decimal uc = decimal.Parse(mainForm.UtilitiesCost);
                decimal tlc = decimal.Parse(mainForm.TotalLaborCost);
                decimal laborPerUnit = decimal.Parse(mainForm.LaborCostPerUnit);
                decimal pc = decimal.Parse(Pctotal_txt.Text);
                decimal ohc = decimal.Parse(Totaloh_txt.Text);
                decimal ohcPerUnit = decimal.Parse(Perunit_ohc.Text);
                decimal oe = decimal.Parse(Totaloe_txt.Text);
                int servings = int.Parse(Servings_txt.Text);
                string productName = mainForm.MyProductName;

                // Parse profit margin
                if (!decimal.TryParse(Beautypm_cmb.Text.Replace("%", ""), out decimal profitPercentage))
                {
                    MessageBox.Show("Please select a valid profit margin.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal profitMargin = profitPercentage / 100;

                // Calculate total product cost and cost per unit
                decimal tpc = rmc + uc + tlc + pc + ohc + oe;
                decimal tpcPerUnit = servings > 0 ? tpc / servings : 0;

                // Calculate SRP
                decimal srpTotal = tpc * (1 + profitMargin);
                decimal srpPerUnit = servings > 0 ? srpTotal / servings : 0;

                // Clear the DataGridView
                product_costing_dgv.Rows.Clear();

                // Helper to add cost breakdown rows
                void AddRow(string category, decimal amount, decimal totalCost)
                {
                    decimal percentage = (amount / totalCost) * 100;
                    product_costing_dgv.Rows.Add(category,
                        "₱" + amount.ToString("0.00"),
                        percentage.ToString("0.##") + "%");
                }

                // Add breakdown rows
                AddRow("Raw Material Cost", rmc, tpc);
                AddRow("Utilities Cost", uc, tpc);
                AddRow("Labor Cost", tlc, tpc);
                AddRow("Packaging Cost", pc, tpc);
                AddRow("Overhead Cost", ohc, tpc);
                AddRow("Other Expenses", oe, tpc);

                // Add summary rows
                product_costing_dgv.Rows.Add("Total Product Cost", "₱" + tpc.ToString("0.00"), "100%");
                product_costing_dgv.Rows.Add("Cost per Unit", "₱" + tpcPerUnit.ToString("0.00"), "-");
                product_costing_dgv.Rows.Add("SRP (Total)", "₱" + srpTotal.ToString("0.00"), "-");
                product_costing_dgv.Rows.Add("SRP per Unit", "₱" + srpPerUnit.ToString("0.00"), "-");

                _productNameSummary = productName;
                _servingsSummary = servings;
                _tpcSummary = tpc;
                _srpTotalSummary = srpTotal;
                _srpPerUnitSummary = srpPerUnit;
                _isSummaryAvailable = true;

                // Open the summary dialog and pass the calculated values
                ShowProductSummaryDialog(productName, servings, tpc, srpTotal, srpPerUnit);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during calculation:\n" + ex.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowProductSummaryDialog(string productName, int servings, decimal tpc, decimal srpTotal, decimal srpPerUnit)
        {
            ProductSummaryDialog3 summaryForm = new ProductSummaryDialog3(this);
            summaryForm.SetSummaryData(productName, servings, tpc, srpTotal, srpPerUnit);
            summaryForm.ShowDialog();
        }

        private void View_productcost_Click(object sender, EventArgs e)
        {

            if (!_isSummaryAvailable)
            {
                MessageBox.Show("Please calculate the product cost first before viewing the summary.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ProductSummaryDialog3 summaryForm = new ProductSummaryDialog3(this);
            summaryForm.SetSummaryData(
                _productNameSummary ?? "Unnamed Product",
                _servingsSummary,
                _tpcSummary,
                _srpTotalSummary,
                _srpPerUnitSummary
            );
            summaryForm.ShowDialog();
        }

        private void Explore_categories_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
        "Are you sure you want to go back to the category section?  progress might be lost.",
        "Confirm Navigation",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Category categoryForm = new Category();
                categoryForm.Show();
                this.Hide();
            }
        }

        private void Back_picbox_Click(object sender, EventArgs e)
        {
            mainForm.Show(); 
            this.Hide(); 
        }
    }
}





