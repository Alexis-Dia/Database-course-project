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
    }
}
