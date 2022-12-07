using Dashboard.VVS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Dashboard.VVS.GetVVS;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal VVSTimetable Timetable { get; set; }
        public static MainWindow Main { get; set; }
        public MainWindow()
        {
            string vvsData = GetVVSClass();
            Timetable = ParseVVS.ParseVVSClass(vvsData);
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Main = this;
            RenderVVS.RenderVVSClass(Timetable);
        }
    }
}
