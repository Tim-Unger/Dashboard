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
using Dashboard.Scheduler;
using static Dashboard.VVS.GetVVS;
using System.Windows.Forms;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal VVSTimetable Timetable { get; set; }
        public static MainWindow? Main { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Main = this;
            InitializeScheduler.Initialize();
            string vvsData = GetVVSClass();
            Timetable = ParseVVS.ParseVVSClass(vvsData);
            RenderVVS.RenderVVSClass(Timetable);
        }
    }
}
