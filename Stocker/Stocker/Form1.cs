using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stocker.Controller;
using Stocker.Models;
using Stocker.Models.Response;

namespace Stocker
{
    public partial class Stocker : Form
    {
        public Stocker()
        {
            InitializeComponent();
        }
        
        DateTime now = DateTime.Now;

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            StockControllController stockControllController = new StockControllController();
            try
            {

                var req = new UpdateStockRequest()
                {
                    UpdateDate = now,
                    Input = Convert.ToInt32("0" + tbIn.Text),
                    Output = Convert.ToInt32("0" + tbOut.Text),
                    ItemId = Convert.ToInt32(tbIdSearch.Text)
                };
                var result = stockControllController.UpdateStock(req);

                if (result.ErrorCode == ErrorCodeModel.Success)
                {
                    loadDataGrid();
                    resetUpdateFill();
                    MessageBox.Show($"{result.ErrorMessage}");
                }
                else
                {
                    loadDataGrid();
                    resetUpdateFill();
                    MessageBox.Show($"{result.ErrorMessage}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Incorrect input. The input must be number only.\nPlease chech your input again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void loadDataGrid()
        {
            StockControllController stockControllController = new StockControllController();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = stockControllController.GetStockItems();

            dataGridView1.DataSource = bindingSource;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void resetUpdateFill()
        {
            tbIdSearch.Text = "";
            tbIn.Text = "";
            tbOut.Text = "";
        }
    }
}
