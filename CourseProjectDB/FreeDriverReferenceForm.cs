using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CourseProjectDB
{
    public partial class FreeDriverReferenceForm : Form
    {

        private string[] userParams;

        public FreeDriverReferenceForm(string[] userParams)
        {
            this.userParams = userParams;
            InitializeComponent();
        }

        private void FreeDriverReferenceForm_Load(object sender, EventArgs e)
        {

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter1", userParams[0]));
            reportParameters.Add(new ReportParameter("ReportParameter2", userParams[1]));
            reportParameters.Add(new ReportParameter("ReportParameter3", userParams[2]));
            reportParameters.Add(new ReportParameter("ReportParameter4", userParams[3]));
            reportParameters.Add(new ReportParameter("ReportParameter5", userParams[4]));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
