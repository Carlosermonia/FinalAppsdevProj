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
    public partial class FurnitureCategory2 : Form
    {
        public FurnitureCategory? previousForm { get; set; }
        public FurnitureCategory2()
        {
            InitializeComponent();
            RentFrequency_cmb.Items.Clear();
            RentFrequency_cmb.Items.AddRange(new string[] { "Monthly", "Weekly", "Days", "Yearly" });

            Pr_cmb.Items.Clear();
            Pr_cmb.Items.Add("20%");
            Pr_cmb.Items.Add("30%");
            Pr_cmb.Items.Add("50%");
            Pr_cmb.Items.Add("100%");
        }

        private void Add_Uw_Click(object sender, EventArgs e)
        {

            if (!decimal.TryParse(Wrpd_txt.Text, out decimal rentAmount))
            {
                MessageBox.Show("Enter a valid rent amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int daysUsed = (int)Numdrop.Value;

            string? frequency = RentFrequency_cmb.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(frequency))
            {
                MessageBox.Show("Please select a valid rent frequency.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal dailyRate = frequency switch
            {
                "Days" => rentAmount,
                "Weekly" => rentAmount / 7m,
                "Monthly" => rentAmount / 30m,
                "Yearly" => rentAmount / 365m,
                _ => 0m
            };

            if (dailyRate == 0m)
            {
                MessageBox.Show("Invalid rent frequency selected.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalCost = dailyRate * daysUsed;
            TotalWc_Txt.Text = totalCost.ToString("0.00");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string toolName = ToolNameTxt.Text.Trim();
                int lifespan = (int)Numdrop2.Value;
                decimal toolCost = decimal.Parse(ToolCost.Text);
                decimal usagePerProduct = Numdrop_2.Value;

                if (string.IsNullOrWhiteSpace(toolName))
                {
                    MessageBox.Show("Please Enter a Tool Name");
                    return;
                }

                if (lifespan <= 0)
                {

                    MessageBox.Show("Lifespan must be greater than 0");
                    return;
                }

                decimal wearCostPerUnit = (toolCost / lifespan) * usagePerProduct;

                Twc_dgv.Rows.Add(toolName, lifespan, toolCost, usagePerProduct, wearCostPerUnit.ToString("F2"));
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid decimal value for Tool Cost.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void Total_Twc_Click(object sender, EventArgs e)
        {

            decimal totalWearCost = 0m;

            foreach (DataGridViewRow row in Twc_dgv.Rows)
            {
                if (row.Cells[4].Value != null &&
                    decimal.TryParse(row.Cells[4].Value.ToString(), out decimal wearCost))
                {
                    totalWearCost += wearCost;
                }
            }

            Totaltwc_txt.Text = totalWearCost.ToString("0.00");
        }

        private void Addoe_btn_Click(object sender, EventArgs e)
        {
            string expenseType = Expense_txt.Text.Trim();
            string costText = Expensecst_txt.Text.Trim();
            decimal expenseCost;


            if (string.IsNullOrEmpty(expenseType))
            {
                MessageBox.Show("Please enter an expense type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!decimal.TryParse(costText, out expenseCost) || expenseCost <= 0)
            {
                MessageBox.Show("Please enter a valid, positive number for expense cost.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Oe_dgv.Rows.Add(expenseType, expenseCost.ToString("0.00"));


            Expense_txt.Clear();
            Expensecst_txt.Clear();
        }

        private void Calcoe_btn_Click(object sender, EventArgs e)
        {
            decimal totalExpense = 0;


            foreach (DataGridViewRow row in Oe_dgv.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    decimal expense;
                    if (decimal.TryParse(row.Cells[1].Value.ToString(), out expense))
                    {
                        totalExpense += expense;
                    }
                }
            }

            TotalOe_txt.Text = totalExpense.ToString("0.00");
        }

        private void CalculateAllCost_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (previousForm == null)
                {
                    MessageBox.Show("Previous form reference is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get values from FurnitureCategory (previousForm)
                decimal rmc = decimal.Parse(previousForm.TotalRmc);
                decimal lc = decimal.Parse(previousForm.TotalLc);
                decimal uc = decimal.Parse(previousForm.TotalUc);
                string productType = previousForm.ProductType;
                string unitSize = previousForm.UnitSize;

                // Get values from FurnitureCategory2
                decimal wc = decimal.Parse(TotalWc_Txt.Text);
                decimal twc = decimal.Parse(Totaltwc_txt.Text);
                decimal oe = decimal.Parse(TotalOe_txt.Text);

                // Total product cost
                decimal totalCost = rmc + lc + uc + wc + twc + oe;

                // SRP (20% profit margin)
                decimal profitMargin = 0.20m;
                decimal srp = totalCost + (totalCost * profitMargin);

                // Fill DataGridView
                PrdCst_dgv.Rows.Clear();

                void AddRow(string name, decimal value)
                {
                    decimal percent = (value / totalCost) * 100;
                    PrdCst_dgv.Rows.Add(name, "₱" + value.ToString("0.00"), percent.ToString("0.##") + "%");
                }

                AddRow("Raw Material Cost", rmc);
                AddRow("Labor Cost", lc);
                AddRow("Utilities Cost", uc);
                AddRow("Workshop Cost", wc);
                AddRow("Tool Wear Cost", twc);
                AddRow("Other Expenses", oe);
                PrdCst_dgv.Rows.Add("Total Product Cost", "₱" + totalCost.ToString("0.00"), "100%");
                PrdCst_dgv.Rows.Add("Suggested Retail Price (SRP)", "₱" + srp.ToString("0.00"), "");

                // Show summary dialog
                FcSummary summary = new FcSummary();
                summary.ProductType.Text = productType;
                summary.UnitSize.Text = unitSize;
                summary.Tpctxt.Text = "₱" + totalCost.ToString("0.00");
                summary.SrpTxt.Text = "₱" + srp.ToString("0.00");
                summary.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during calculation:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FurnitureCategory2_Load(object sender, EventArgs e)
        {

        }

        private void Back_picbox_Click(object sender, EventArgs e)
        {
            if (previousForm != null)
            {
                previousForm.Show();  
            }

            this.Close();
        }

        private void ExploreCategories_btn_Click(object sender, EventArgs e)
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

        private void ViewProduct_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TotalWc_Txt.Text) ||
                string.IsNullOrWhiteSpace(Totaltwc_txt.Text) ||
                string.IsNullOrWhiteSpace(TotalOe_txt.Text) ||
                previousForm == null ||
                string.IsNullOrWhiteSpace(previousForm.TotalRmc) ||
                string.IsNullOrWhiteSpace(previousForm.TotalLc) ||
                string.IsNullOrWhiteSpace(previousForm.TotalUc))
            {
                MessageBox.Show("Please calculate all costs first before viewing the product summary.",
                                "Calculation Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Parse values
                decimal rmc = decimal.Parse(previousForm.TotalRmc);
                decimal lc = decimal.Parse(previousForm.TotalLc);
                decimal uc = decimal.Parse(previousForm.TotalUc);
                string productType = previousForm.ProductType;
                string unitSize = previousForm.UnitSize;

                decimal wc = decimal.Parse(TotalWc_Txt.Text);
                decimal twc = decimal.Parse(Totaltwc_txt.Text);
                decimal oe = decimal.Parse(TotalOe_txt.Text);

                decimal totalCost = rmc + lc + uc + wc + twc + oe;
                decimal profitMargin = 0.20m;
                decimal srp = totalCost + (totalCost * profitMargin);

                // Show summary form
                FcSummary summary = new FcSummary();
                summary.ProductType.Text = productType;
                summary.UnitSize.Text = unitSize;
                summary.Tpctxt.Text = "₱" + totalCost.ToString("0.00");
                summary.SrpTxt.Text = "₱" + srp.ToString("0.00");
                summary.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
