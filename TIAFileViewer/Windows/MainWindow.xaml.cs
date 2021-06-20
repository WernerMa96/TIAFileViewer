using System.Windows;
using TIAFileViewer.ViewModel;

namespace TIAFileViewer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Inital creation of the main datacontext
            DataContext = new MainViewModel();
        }
    }
}
