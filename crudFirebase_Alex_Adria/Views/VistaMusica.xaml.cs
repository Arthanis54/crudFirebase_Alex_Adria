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

            GetListMusiques();
        }

        //Disc
        private async void DeleteDisc_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDiscName.Text) && cmbLlistaMusicsDiscos.SelectedItem != null)
            {
                string discName = txtDiscName.Text;
                string musicName = cmbLlistaMusicsDiscos.SelectedItem.ToString();

                if (await domain.RemoveDisc(musicName, discName)) MessageBox.Show("Disc eliminat");
                else MessageBox.Show("Error eliminant disc");
            }
            else MessageBox.Show("Camps buits!");
        }

        private async void btnAddDisc_Click(object sender, RoutedEventArgs e)
        {
            if (cmbLlistaMusicsDiscos.HasItems)
            {
                if (!string.IsNullOrEmpty(txtDiscName.Text) && DatePickerDisc.SelectedDate.HasValue && cmbLlistaMusicsDiscos.SelectedIndex > -1)
                {
                    string nomDisc = txtDiscName.Text;
                    DateTime dataAparicio = DatePickerDisc.SelectedDate.Value;
                    string artista = cmbLlistaMusicsDiscos.SelectedItem.ToString();

                    Disc oneDisc = new Disc(Guid.NewGuid().ToString(), dataAparicio);
                    oneDisc.Nom = nomDisc;

                    if (await domain.AddDisc(artista, oneDisc)) MessageBox.Show("Disc afegit");
                    else MessageBox.Show("Error afegint disc");
                }
                else MessageBox.Show("Camps buits!");
            }
            else MessageBox.Show("No hi ha artistes/grups!");

        }

        private async void btnUpdateDisc_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDiscName.Text) && cmbLlistaMusicsDiscos.SelectedIndex > -1)
            {
                string nomDisc = txtDiscName.Text;
                string artista = cmbLlistaMusicsDiscos.SelectedItem.ToString();

                Disc oneDisc = await domain.GetDisc(artista, nomDisc);

                if (DatePickerDisc.SelectedDate.HasValue)
                {
                    oneDisc.DataAparicio = DatePickerDisc.SelectedDate.Value;
                    await domain.UpdateDisc(artista, oneDisc);
                    MessageBox.Show("Disc modificat");
                }
                else MessageBox.Show("Res a modificar");
            }
            else MessageBox.Show("Camps buits!");
        }

        //.Musica
        private void btnAddMusic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateMusic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteMusic_Click(object sender, RoutedEventArgs e)
        {

        }

        //song
        private async void btnAfegirSong_Click(object sender, RoutedEventArgs e)
        {   
            if (!String.IsNullOrEmpty(txtbxNom.Text) && !String.IsNullOrEmpty(txtDuracio.Text) &&
                cmbNomArtistaSong.SelectedIndex > -1 && cmbNomDiscSong.SelectedIndex > -1)

            {
                string nomSong = txtbxNom.Text;
                double tempsDurada = Convert.ToDouble(txtDuracio.Text);

                string artista = cmbNomArtistaSong.SelectedIndex.ToString();
                string disc = cmbNomDiscSong.SelectedIndex.ToString();

                Song song = new Song(Guid.NewGuid().ToString(), tempsDurada);
                song.Nom = nomSong;


                bool afegit = await domain.AddSong(artista, disc, song);
                if (afegit) MessageBox.Show("Afegit correctament");
                else MessageBox.Show("No s'ha pogut afegir");
            }
            else MessageBox.Show("Camps buits!");
        }

        private async void btnEliminarSong_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbxNom.Text) &&
                cmbNomArtistaSong.SelectedIndex > -1 && 
                cmbNomDiscSong.SelectedIndex > -1)
            {
                string nomSong = txtbxNom.Text;
                string artista = cmbNomArtistaSong.SelectedIndex.ToString();
                string disc = cmbNomDiscSong.SelectedIndex.ToString();

                bool eliminat = await domain.RemoveSong(artista, disc, nomSong);
                if (eliminat) MessageBox.Show("Eliminat correctament");
                else MessageBox.Show("No s'ha pogut eliminar");
            }
            else MessageBox.Show("Camps buits!");
        }

        private async void btnModificarSong_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbxNom.Text) && !String.IsNullOrEmpty(txtDuracio.Text) && 
                cmbNomArtistaSong.SelectedIndex > -1 && cmbNomDiscSong.SelectedIndex > -1)
            {
                string nomSong = txtbxNom.Text;
                double tempsDurada = Convert.ToDouble(txtDuracio.Text);
                string artista = cmbNomArtistaSong.SelectedIndex.ToString();
                string disc = cmbNomDiscSong.SelectedIndex.ToString();
                
                Song song = await domain.GetSong(artista, disc, nomSong);
                song.Durada = tempsDurada;
                
                bool modificat = await domain.UpdateSong(artista, disc, song);
                if (modificat) MessageBox.Show("Modificat correctament");
                else MessageBox.Show("No s'ha pogut modificar");
            }
            else MessageBox.Show("Camps buits!");
        }

        public async void GetListMusiques()
        {
            cmbLlistaMusicsDiscos.Items.Clear();
            List<Musica> llistaMusiques = await domain.GetMusiques();
            foreach (Musica musica in llistaMusiques)
            {
                cmbLlistaMusicsDiscos.Items.Add(musica.Nom);
                cmbNomArtistaSong.Items.Add(musica.Nom);
            }
        }
    }
}