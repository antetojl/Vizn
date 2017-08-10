using System.Linq;
using DevExpress.Xpf.Charts;

//WPF chart control
namespace Vizn
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly ReportCollection _reports;

        public MainWindow()
        {
            //reading in csv after initializing WPF
            InitializeComponent();
            var csv = CSVProcessing.ReadCSV("tsla.csv");
            _reports = CSVProcessing.GetReportCollection(csv);

            //Get linear regression
            var linearRegression = Calculations.Linear(_reports);

            //not implemented into this solution
            var predict = linearRegression.Transform(_reports.Count);
            var slope = linearRegression.Slope;
            var intercept = linearRegression.Intercept;

            //creating graph
            var dia = new XYDiagram2D
            {
                SeriesDataMember = "Open",
                SeriesTemplate = new LineSeries2D
                {
                    ArgumentDataMember = "Date",
                    ValueDataMember = "Open",
                    DisplayName = "Tesla (TSLA)"
                },
                AxisY = new AxisY2D
                {
                    Title = new AxisTitle {Content = "Price ($)"},
                    VisualRange = new Range
                    {
                        MinValue = _reports.MinOpen()
                    }
                },
                AxisX = new AxisX2D {Title = new AxisTitle {Content = "Date"}}
            };

            Graph.Diagram = dia;
            Graph.DataSource = _reports.GetDailyReports().Select(dr => new {dr.Date, dr.Open});
        }
    }
}