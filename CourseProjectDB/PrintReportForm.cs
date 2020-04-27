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
    public partial class PrintReportForm : Form
    {
        public PrintReportForm()
        {
            InitializeComponent();
        }

        private void PrintReportForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carriages_systemDataSet.report". При необходимости она может быть перемещена или удалена.
            this.reportTableAdapter.Fill(this.carriages_systemDataSet.report);

            this.reportViewer1.RefreshReport();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.reportTableAdapter.FillBy(this.carriages_systemDataSet.report, ((System.DateTime)(System.Convert.ChangeType(departureToolStripTextBox.Text, typeof(System.DateTime)))), ((System.DateTime)(System.Convert.ChangeType(arrivalToolStripTextBox.Text, typeof(System.DateTime)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void departureToolStripTextBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.reportTableAdapter.FillBy(this.carriages_systemDataSet.report,
                    ((System.DateTime)(System.Convert.ChangeType(dateTimePicker1.Text, typeof(System.DateTime)))),
                    ((System.DateTime)(System.Convert.ChangeType(dateTimePicker2.Text, typeof(System.DateTime)))));
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
