using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Csv;
using DevExpress.Xpf.Charts;

//WPF chart control
namespace Vizn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ReportCollection reports;
        public MainWindow()
        {
            InitializeComponent();
            var csv = CSVProcessing.ReadCSV("tsla.csv");
            reports = CSVProcessing.GetReportCollection(csv);

            var linearRegression = Calculations.Linear(reports);

            double predict = linearRegression.Transform(reports.Count);
            double slope = linearRegression.Slope;
            double intercept = linearRegression.Intercept;

            var dia = new XYDiagram2D
            {
                SeriesDataMember = "Change",
                SeriesTemplate = new BarFullStackedSeries2D()
                {
                    ArgumentDataMember = "Date",
                    ValueDataMember = "Change",
                    DisplayName = "Tesla (TSLA)"
                },
                AxisY = new AxisY2D {Title = new AxisTitle {Content = "Percent Changed (%)"}},
                AxisX = new AxisX2D {Title = new AxisTitle {Content = "Date"}} 
            };

            Graph.Diagram = dia;
            Graph.DataSource = reports.GetDailyReports().Select(dr => new { dr.Date, dr.Change });

        }

        
    }
}
