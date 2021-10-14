using System.Windows;
using System.Windows.Interactivity;

namespace PDFtoAria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Interaction.GetBehaviors(this);
            InitializeComponent();
        }
    }
}
