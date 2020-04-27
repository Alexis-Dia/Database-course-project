using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProjectDB
{
    public partial class PrintTaskForm : Form
    {
        public PrintTaskForm()
        {
            InitializeComponent();
        }

        private void PrintTaskForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carriages_systemDataSet.task". При необходимости она может быть перемещена или удалена.
            this.taskTableAdapter.Fill(this.carriages_systemDataSet.task);

            this.reportViewer1.RefreshReport();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.taskTableAdapter.FillBy(this.carriages_systemDataSet.task, nAMEToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.taskTableAdapter.FillBy(this.carriages_systemDataSet.task, textBox1.Text);
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
