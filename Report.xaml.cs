using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Microsoft.Reporting;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WinForms;


namespace JakubToma_utwory
{
    /// <summary>
    /// Logika interakcji dla klasy Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {

            InitializeComponent();

            sngViewer.ServerReport.ReportServerUrl = new Uri("http://pc-1:80/ReportServer", System.UriKind.Absolute);
            sngViewer.ServerReport.ReportPath = "/Songs";
            sngViewer.RefreshReport();

        }
    }
}
