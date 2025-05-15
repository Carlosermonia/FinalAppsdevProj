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
    public partial class FurnitureCategory : Form
    {
        public string ProductType => Producttype_txt.Text;  // To access product type
        public string UnitSize => Us_txt.Text;             // To access unit size
        public string TotalRmc => Total_rmc.Text;          // To access total RMC
        public string TotalLc => Totallbr_txt.Text;        // To access total LC
        public string TotalUc => Totaluw_txt.Text;
        public FurnitureCategory()
        {
            InitializeComponent();
            Um_cmb.Items.Clear();
            Um_cmb.Items.AddRange(new string[]
         {
          "Board Foot",
          "Meter",
          "Sheet",
          "Piece",
          "Liter",
          "Gallon",
          "Kg",
          "Yard",
          "Tube",
          "Box",
          "Set",
          "Square Foot",
          "Roll",
          "Can",
          "Panel"
         });
        }

        private void FurnitureCategory_Load(object sender, EventArgs e)
        {

        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Material_txt.Text) ||
                 Um_cmb.SelectedIndex == -1 ||
                 string.IsNullOrWhiteSpace(Quantity_txt.Text) ||
                 string.IsNullOrWhiteSpace(Cpu_Txt.Text))
            {
                MessageBox.Show("Please complete all fields before adding.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!decimal.TryParse(Quantity_txt.Text, out decimal quantity) ||
                !decimal.TryParse(Cpu_Txt.Text, out decimal unitCost))
            {
                MessageBox.Show("Please enter valid numbers for Quantity and Unit Cost.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            decimal totalCost = quantity * unitCost;

           
            Rmc_Dgv.Rows.Add(
                Material_txt.Text.Trim(),
                Um_cmb.SelectedItem?.ToString() ?? string.Empty, 
                quantity,
                unitCost.ToString("0.00"),
                totalCost.ToString("0.00")
            );

            
            Material_txt.Clear();
            Um_cmb.SelectedIndex = -1;
            Quantity_txt.Clear();
            Cpu_Txt.Clear();
        }

        private void Calc_btn_Click(object sender, EventArgs e)
        {
            decimal subtotal = 0m;

            foreach (DataGridViewRow row in Rmc_Dgv.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[4].Value != null &&
                    decimal.TryParse(row.Cells[4].Value.ToString(), out decimal rowTotal))
                {
                    subtotal += rowTotal;
                }
            }

            Total_rmc.Text = subtotal.ToString("0.00");
        }

        private void Addlbr_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Lbrname_txt.Text) ||
        string.IsNullOrWhiteSpace(Hr_txt.Text) ||
        string.IsNullOrWhiteSpace(Lbrhr_txt.Text))
            {
                MessageBox.Show("Please complete all fields before adding.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(Hr_txt.Text, out decimal hoursWorked) ||
                !decimal.TryParse(Lbrhr_txt.Text, out decimal hourlyRate))
            {
                MessageBox.Show("Please enter valid numbers for Hours Worked and Hourly Rate.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal laborCost = hoursWorked * hourlyRate;

            Lbr_Dgv.Rows.Add(
                Lbrname_txt.Text.Trim(),
                hoursWorked.ToString("0.00"),
                hourlyRate.ToString("0.00"),
                laborCost.ToString("0.00")
            );

            Lbrname_txt.Clear();
            Hr_txt.Clear();
            Lbrhr_txt.Clear();
        }

        private void Calclbr_btn_Click(object sender, EventArgs e)
        {
            decimal totalLaborCost = 0m;

            foreach (DataGridViewRow row in Lbr_Dgv.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[3].Value != null &&
                    decimal.TryParse(row.Cells[3].Value.ToString(), out decimal laborCost))
                {
                    totalLaborCost += laborCost;
                }
            }

            Totallbr_txt.Text = totalLaborCost.ToString("0.00");
        }

        private void Totallbr_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Uw_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Exp_txt.Text) ||
        string.IsNullOrWhiteSpace(Ca_txt.Text))
            {
                MessageBox.Show("Please complete both fields before adding.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(Ca_txt.Text, out decimal costAmount))
            {
                MessageBox.Show("Please enter a valid number for the cost.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = costAmount;

            Uw_Dgv.Rows.Add(
                Exp_txt.Text.Trim(),
                costAmount.ToString("0.00"),
                subtotal.ToString("0.00")
            );

            Exp_txt.Clear();
            Ca_txt.Clear();


        }

        private void Calcuw_btn_Click(object sender, EventArgs e)
        {
            decimal total = 0m;

            foreach (DataGridViewRow row in Uw_Dgv.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[2].Value != null &&
                    decimal.TryParse(row.Cells[2].Value.ToString(), out decimal rowSubtotal))
                {
                    total += rowSubtotal;
                }
            }

            Totaluw_txt.Text = total.ToString("0.00");
        }

        private void Totaluw_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Back_picbox_Click(object sender, EventArgs e)
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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Forward_Click(object sender, EventArgs e)
        {
            FurnitureCategory2 form2 = new FurnitureCategory2();
            form2.previousForm = this; 
            form2.Show();
            this.Hide();
        }
    }
}

