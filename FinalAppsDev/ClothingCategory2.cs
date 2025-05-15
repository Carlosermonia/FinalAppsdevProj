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
    public partial class ClothingCategory2 : Form
    {
        private ClothingCategory? previousForm;

        private decimal lastCalculatedSRPPerUnit_XSM;
        private decimal lastCalculatedSRPPerUnit_L2XL;
        private int lastServings;
        private string? lastProductName;
        private decimal lastTotalProductCost;

        public ClothingCategory2(ClothingCategory form)
        {
            InitializeComponent();
            previousForm = form;

            Profitmargin_cmb.Items.Clear();
            Profitmargin_cmb.Items.Add("20%");
            Profitmargin_cmb.Items.Add("30%");
            Profitmargin_cmb.Items.Add("50%");
            Profitmargin_cmb.Items.Add("100%");

            
        }
        public void LoadData(decimal totalCost, decimal srp, decimal srpPerUnit, string selectedSize)
        {
            // Use the data as needed in your ClothingCategory2 form
            // For example, you can display the data or save it for later use
            Console.WriteLine($"Total Cost: {totalCost}, SRP: {srp}, SRP per Unit: {srpPerUnit}, Size: {selectedSize}");
        }
        public ClothingCategory2()
        {
            InitializeComponent();


        }

        private void ClothingCategory2_Load(object sender, EventArgs e)
        {
            bool isChecked = btchx_chckbox.Checked;

            Unit_produced.Visible = isChecked;
            label19.Visible = isChecked;
        }

        private void back_picbox_Click(object sender, EventArgs e)
        {
            if (previousForm != null)
            {
                previousForm.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Previous form not found.");
            }
        }

        private void Add_PC_Click(object sender, EventArgs e)
        {
            string material = Pckmaterial_txt.Text.Trim();
            string qtyText = Quatity_txtbox.Text.Trim();
            string costText = Cpu_txtbox.Text.Trim();

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

            Pc_datagridview.Rows.Add(row);


            Pckmaterial_txt.Clear();
            Quatity_txtbox.Clear();
            Cpu_txtbox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal totalPC = 0;

            foreach (DataGridViewRow row in Pc_datagridview.Rows)
            {
                if (row.IsNewRow) continue;

                decimal subtotal = 0;
                decimal.TryParse(Convert.ToString(row.Cells[3].Value), out subtotal); // Subtotal column

                totalPC += subtotal;
            }

            Txtpctotal.Text = totalPC.ToString("0.##");
        }

        private void Add_overheadbtn_Click(object sender, EventArgs e)
        {
            string overheadItem = Overhead_txt.Text.Trim();
            string monthlyCostText = Moc_txt.Text.Trim();
            string prodVolumeText = Prodvol_txt.Text.Trim();

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

            Overhead_txt.Clear();
            Moc_txt.Clear();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Servingstxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void overheadtotalbtn_Click(object sender, EventArgs e)
        {
            decimal totalMonthlyOverhead = 0;
            decimal prodVolume;


            if (!decimal.TryParse(Prodvol_txt.Text.Trim(), out prodVolume) || prodVolume <= 0)
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

            Totalohctxtbox.Text = totalMonthlyOverhead.ToString("0.##");

            decimal overheadPerUnit = totalMonthlyOverhead / prodVolume;
            perunitohc.Text = overheadPerUnit.ToString("0.####");
        }

        private void btchx_chckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = btchx_chckbox.Checked;

            Unit_produced.Visible = isChecked;
            label19.Visible = isChecked;

            if (!isChecked)
            {
                Unit_produced.Clear();
            }
        }

        private void add_oebtn_Click(object sender, EventArgs e)
        {
            string description = expense_txt.Text.Trim();
            string costText = costpb_txt.Text.Trim();
            bool isBatchBased = btchx_chckbox.Checked;
            string unitsProducedText = Unit_produced.Text.Trim();

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

            Oe_datagridview.Rows.Add(row);


            expense_txt.Clear();
            costpb_txt.Clear();
            Unit_produced.Clear();
            btchx_chckbox.Checked = false;
        }

        private void Totaloe_btn_Click(object sender, EventArgs e)
        {
            decimal totalOE = 0;

            foreach (DataGridViewRow row in Oe_datagridview.Rows)
            {
                if (row.IsNewRow) continue;

                if (decimal.TryParse(Convert.ToString(row.Cells[4].Value), out decimal costPerUnit))
                {
                    totalOE += costPerUnit;
                }
            }

            totaloe_txt.Text = totalOE.ToString("0.####");
        }

        private void button4_Click(object sender, EventArgs e)
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
        private bool isCalculationDone = false;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (previousForm != null)
                {
                    // Parse all required cost inputs from the previous form
                    decimal rmc = decimal.Parse(previousForm.TotalRawMaterialCost); // Raw Material Cost
                    decimal uc = decimal.Parse(previousForm.UtilitiesCost);         // Utilities Cost
                    decimal tlc = decimal.Parse(previousForm.TotalLaborCost);       // Total Labor Cost
                    decimal laborPerUnit = decimal.Parse(previousForm.LaborCostPerUnit); // Labor cost per unit
                    decimal pc = decimal.Parse(Txtpctotal.Text);                    // Packaging Cost
                    decimal ohc = decimal.Parse(Totalohctxtbox.Text);               // Overhead Cost
                    decimal ohcPerUnit = decimal.Parse(perunitohc.Text);            // Overhead cost per unit
                    decimal oe = decimal.Parse(totaloe_txt.Text);                   // Other Expenses
                    int servings = int.Parse(Servingstxt.Text);                     // Number of units produced
                    string productName = previousForm.myProductName;

                    // Default product name in case it's empty
                    productName = string.IsNullOrEmpty(productName) ? "Unknown Product" : productName;

                    // Parse profit margin from combobox (e.g., "30%")
                    if (!decimal.TryParse(Profitmargin_cmb.Text.Replace("%", ""), out decimal profitPercentage))
                    {
                        MessageBox.Show("Please select a valid profit margin.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Convert profit percentage to decimal form (e.g., 30% → 0.30)
                    decimal baseProfitMargin = profitPercentage / 100;

                    // Compute total product cost
                    decimal tpc = rmc + uc + tlc + pc + ohc + oe;

                    // Calculate SRP for size XS-M (no additional cost)
                    decimal srpTotal_XS_M = tpc + (tpc * baseProfitMargin);

                    // Calculate SRP for size L-2XL (add 50 to base SRP)
                    decimal srpTotal_L_2XL = srpTotal_XS_M + 50;

                    // NOTE: We're not dividing by servings anymore — we want total SRP per size
                    decimal srpPerSize_XS_M = srpTotal_XS_M;
                    decimal srpPerSize_L_2XL = srpTotal_L_2XL;

                    // Clear existing rows in the DataGridView
                    product_costing_datagridview.Rows.Clear();

                    // Local function to add a cost row with percentage calculation
                    void AddRow(string category, decimal amount, decimal totalCost)
                    {
                        decimal percentage = (amount / totalCost) * 100;
                        product_costing_datagridview.Rows.Add(
                            category,
                            "₱" + amount.ToString("0.00"),
                            percentage.ToString("0.##") + "%"
                        );
                    }

                    // Add each cost category to the grid
                    AddRow("Raw Material Cost", rmc, tpc);
                    AddRow("Utilities Cost", uc, tpc);
                    AddRow("Labor Cost", tlc, tpc);
                    AddRow("Packaging Cost", pc, tpc);
                    AddRow("Overhead Cost", ohc, tpc);
                    AddRow("Other Expenses", oe, tpc);

                    // Add final row for total product cost
                    product_costing_datagridview.Rows.Add("Total Product Cost", "₱" + tpc.ToString("0.00"), "100%");

                    // Save values for use in the summary dialog
                    lastCalculatedSRPPerUnit_XSM = srpPerSize_XS_M;
                    lastCalculatedSRPPerUnit_L2XL = srpPerSize_L_2XL;
                    lastServings = servings;
                    lastProductName = productName;
                    lastTotalProductCost = tpc;

                    isCalculationDone = true;

                    // Show the summary dialog with updated SRP values
                    var summaryDialog = new ProductSummaryDialog2(
                        lastProductName,
                        lastServings,
                        lastTotalProductCost,
                        lastCalculatedSRPPerUnit_XSM,
                        lastCalculatedSRPPerUnit_L2XL
                    );
                    summaryDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Previous form is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle and report any runtime errors during the calculation
                MessageBox.Show("An error occurred during calculation:\n" + ex.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isCalculationDone)
            {
                lastProductName = string.IsNullOrEmpty(lastProductName) ? "Unknown Product" : lastProductName;
                var summaryDialog = new ProductSummaryDialog2(
                    lastProductName,
                    lastServings,
                    lastTotalProductCost,
                    lastCalculatedSRPPerUnit_XSM,
                    lastCalculatedSRPPerUnit_L2XL
                );
                summaryDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please calculate the product cost first.", "Calculation Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
