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
    public partial class ClothingCategory : Form
    {

        public string myProductName => product_nametxtbox.Text;
        public string UtilitiesCost => Uc_result.Text;
        public string TotalLaborCost => Tlc_txtbox.Text;
        public string LaborCostPerUnit => laborCostPerUnitTxt.Text;
        public string TotalRawMaterialCost => Totalrmc_txtbox.Text;


        public ClothingCategory()
        {
            InitializeComponent();
            metric_cmb.Items.Clear();
            metric_cmb.Items.Add("kg");
            metric_cmb.Items.Add("Meter");
            metric_cmb.Items.Add("pcs");
            metric_cmb.Items.Add("pack");
            metric_cmb.Items.Add("yd");
            metric_cmb.Items.Add("roll");
            metric_cmb.Items.Add("spool");
            metric_cmb.Items.Add("dozen");
            metric_cmb.Items.Add("set");
            metric_cmb.Items.Add("pair");
            metric_cmb.Items.Add("sheet");
            metric_cmb.Items.Add("box");
            metric_cmb.Items.Add("gram");
            metric_cmb.Items.Add("Box");

            metric_cmb.SelectedIndex = 0;

            Rub_cmb.Items.Clear();
            Rub_cmb.Items.Add("Monthly");

        }

        private void ClothingCategory_Load(object sender, EventArgs e)
        {

        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            string materialName = Ing_txtbox.Text;
            string unitMeasure = metric_cmb.SelectedItem?.ToString() ?? "";
            decimal quantityUsed = decimal.Parse(Quantity_txtbox.Text);
            decimal costPerUnit = decimal.Parse(Cost_txtbox.Text);

            string quantityWithUnit = $"{quantityUsed} {unitMeasure}";
            decimal subtotal = quantityUsed * costPerUnit;

            Rmc_Datagridview.Rows.Add(materialName, quantityWithUnit, costPerUnit, subtotal);

            Ing_txtbox.Clear();
            Quantity_txtbox.Clear();
            Cost_txtbox.Clear();
            metric_cmb.SelectedIndex = -1;
        }

        private void Totalrmc_btn_Click(object sender, EventArgs e)
        {
            decimal totalRmc = 0;

            foreach (DataGridViewRow row in Rmc_Datagridview.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    totalRmc += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            Totalrmc_txtbox.Text = totalRmc.ToString("0.00");
        }

        private void lbr_addbtn_Click(object sender, EventArgs e)
        {
            string name = lbrname_txtbox.Text.Trim();
            if (!decimal.TryParse(Hrwork_txtbox.Text.Trim(), out decimal hoursWorked) ||
                !decimal.TryParse(Laborhrrate_txtbox.Text.Trim(), out decimal hourlyRate))
            {
                MessageBox.Show("Please enter valid numbers for hours worked and hourly rate.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the laborer's name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = hoursWorked * hourlyRate;

            lbr_datagridview.Rows.Add(name, hoursWorked, hourlyRate, subtotal.ToString("0.##"));

            lbrname_txtbox.Clear();
            Hrwork_txtbox.Clear();
            Laborhrrate_txtbox.Clear();
        }

        private void total_lbr_Click(object sender, EventArgs e)
        {
            decimal totalLaborCost = 0;

            foreach (DataGridViewRow row in lbr_datagridview.Rows)
            {
                if (row.IsNewRow) continue;

                if (decimal.TryParse(Convert.ToString(row.Cells[3].Value), out decimal subtotal))
                {
                    totalLaborCost += subtotal;
                }
            }

            Tlc_txtbox.Text = totalLaborCost.ToString("0.##");

            if (int.TryParse(Up_txtbox.Text.Trim(), out int servings) && servings > 0)
            {
                decimal laborPerUnit = totalLaborCost / servings;
                laborCostPerUnitTxt.Text = laborPerUnit.ToString("0.##");
            }
            else
            {
                MessageBox.Show("Please enter a valid number of servings.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Add_Util_Click(object sender, EventArgs e)
        {
            string expenseType = Expenses_txt.Text.Trim();
            string billText = Month_txt.Text.Trim();
            string percentText = Production_txt.Text.Trim();
            string unitsText = Up_txtbox.Text.Trim();

            if (string.IsNullOrWhiteSpace(expenseType) ||
                string.IsNullOrWhiteSpace(billText) ||
                string.IsNullOrWhiteSpace(percentText) ||
                string.IsNullOrWhiteSpace(unitsText))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            percentText = percentText.Replace("%", "").Trim();

            if (!decimal.TryParse(billText, out decimal bill) ||
                !decimal.TryParse(percentText, out decimal percentUsed) ||
                !decimal.TryParse(unitsText, out decimal unitsProduced))
            {
                MessageBox.Show("Please enter valid numbers. For Production %, you can enter values like '25%'.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (unitsProduced == 0)
            {
                MessageBox.Show("Estimated Units Produced cannot be zero.", "Math Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal percentDecimal = percentUsed / 100;

            decimal UC = (bill * percentDecimal) / unitsProduced;

            string[] row = new string[]
            {
           expenseType,
           bill.ToString("0.##"),
           percentUsed.ToString("0.##") + "%",
           unitsProduced.ToString("0.##"),
           UC.ToString("0.####")
            };

            Util_DataGridView.Rows.Add(row);


            Expenses_txt.Clear();
            Month_txt.Clear();
            Production_txt.Clear();
        }

        private void TotalUc_btn_Click(object sender, EventArgs e)
        {
            decimal totalUC = 0;

            // Get total units produced from textbox
            if (!decimal.TryParse(Up_txtbox.Text, out decimal unitsProduced) || unitsProduced <= 0)
            {
                MessageBox.Show("Please enter a valid number of units produced.");
                return;
            }

            foreach (DataGridViewRow row in Util_DataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                decimal uc = 0;
                if (decimal.TryParse(Convert.ToString(row.Cells[4].Value), out uc))
                {
                    totalUC += uc * unitsProduced; // Multiply per-unit cost by total units
                }
            }

            Uc_result.Text = totalUC.ToString("0.##");
        }

        private void label17_Click(object sender, EventArgs e)
        {
            ClothingCategory2 clothingCategory2Form = new ClothingCategory2(this);
            clothingCategory2Form.Show();
            this.Hide();

        }

        private void back_picbox_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
     "Are you sure you want to go back? All inputs or progress will be lost.",
     "Confirm",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {

                Category categoryForm = new Category();
                categoryForm.Show();
                this.Close();
            }
        }
    }
}
