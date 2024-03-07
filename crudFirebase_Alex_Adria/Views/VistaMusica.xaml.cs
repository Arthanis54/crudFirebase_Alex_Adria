using crudFirebase_Alex_Adria.Domain;
using crudFirebase_Alex_Adria.Models;
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

       

        private async void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            
            if(!String.IsNullOrEmpty(txtbxNom.Text) && !String.IsNullOrEmpty(txtDuracio.Text)&& 
                !String.IsNullOrEmpty(txtNomArtista.Text)&& !String.IsNullOrEmpty(txtNomDisc.Text))
            {
                string nomSong=  txtbxNom.Text;
                double tempsDurada = Convert.ToDouble(txtDuracio.Text);
                string artista = txtNomArtista.Text;    
                string disc = txtNomDisc.Text; 
                
                Song song = new Song(Guid.NewGuid().ToString(), tempsDurada);
                song.Nom = nomSong;
                
                bool afegit = await domain.AddSong(artista, disc, song);

                
                if(afegit) MessageBox.Show("Afegit correctament");
                else MessageBox.Show("No s'ha pogut afegir");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}