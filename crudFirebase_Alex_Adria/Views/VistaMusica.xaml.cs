using crudFirebase_Alex_Adria.Domain;
using System.Windows;

namespace crudFirebase_Alex_Adria.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VistaMusica : Window
    {
        private IFirebaseDomain domain;
        public VistaMusica()
        {
            this.domain = FirebaseDomainFactory.GetFirebaseDomain();

            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}