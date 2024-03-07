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

            GetListMusiques();
        }

        private async void btnAddDisc_Click(object sender, RoutedEventArgs e)
        {
            if (cmbLlistaMusicsDiscos.HasItems)
            {
                if (!string.IsNullOrEmpty(txtDiscName.Text) && cmbLlistaMusicsDiscos.SelectedIndex > -1)
                {
                    string nomDisc = txtDiscName.Text;
                    string artista = cmbLlistaMusicsDiscos.SelectedItem.ToString();
                    Disc oneDisc = new Disc(Guid.NewGuid().ToString());
                    oneDisc.Nom = nomDisc;

                    if (DatePickerDisc.SelectedDate.HasValue) oneDisc.DataAparicio = DatePickerDisc.SelectedDate.Value;

                    if (await domain.AddDisc(artista, oneDisc)) MessageBox.Show("Disc afegit");
                    else MessageBox.Show("Error afegint disc");
                }
                else MessageBox.Show("Camps buits!");
            }
            else MessageBox.Show("No hi ha artistes/grups!");
            GetListMusiques();
        }

        private async void btnUpdateDisc_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDiscName.Text) && cmbLlistaMusicsDiscos.SelectedIndex > -1)
            {
                string nomDisc = txtDiscName.Text;
                string artista = cmbLlistaMusicsDiscos.SelectedItem.ToString();

                Disc oneDisc = await domain.GetDisc(artista, nomDisc);

                if (DatePickerDisc.SelectedDate.HasValue && oneDisc != null)
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
        private async void btnAddMusic_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNomMusica.Text))
            {
                Musica oneMusic = new Musica(Guid.NewGuid().ToString());
                oneMusic.Nom = txtNomMusica.Text;

                if (DatePickerMusic.SelectedDate.HasValue) oneMusic.DataCreacio = DatePickerMusic.SelectedDate.Value;
                if (!string.IsNullOrEmpty(txtInfoMusic.Text)) oneMusic.Info = txtInfoMusic.Text;

                bool afegit = await domain.AddMusic(oneMusic);
                if (afegit) MessageBox.Show("Afegit correctament");
                else MessageBox.Show("No s'ha pogut afegir");
            }
            else MessageBox.Show("Camps buits!");
            GetListMusiques();
        }

        private async void btnUpdateMusic_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomMusica.Text))
            {
                string nomMusica = txtNomMusica.Text;

                Musica oneMusica = await domain.GetMusica(nomMusica);

                if (DatePickerMusic.SelectedDate.HasValue && oneMusica != null)
                {
                    oneMusica.DataCreacio = DatePickerMusic.SelectedDate.Value;
                    await domain.UpdateMusica(oneMusica);
                    MessageBox.Show("Musica modificada");
                }
                else MessageBox.Show("Res a modificar");
            }
            else MessageBox.Show("Camps buits!");
        }

        private async void btnDeleteMusic_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNomMusica.Text))
            {
                string nomMusica = txtNomMusica.Text;

                bool eliminat = await domain.RemoveMusic(nomMusica);
                if (eliminat) MessageBox.Show("Eliminat correctament");
                else MessageBox.Show("No s'ha pogut eliminar");
            }
            else MessageBox.Show("Camps buits!");

            GetListMusiques();
        }

        //song
        private async void btnAfegirSong_Click(object sender, RoutedEventArgs e)
        {   
            if (!String.IsNullOrEmpty(txtbxNom.Text) && !String.IsNullOrEmpty(txtDuracio.Text) &&
                cmbNomArtistaSong.SelectedIndex > -1 && cmbNomDiscSong.SelectedIndex > -1)

            {
                string nomSong = txtbxNom.Text;
                double tempsDurada = Convert.ToDouble(txtDuracio.Text);

                string artista = cmbNomArtistaSong.SelectedItem.ToString();
                string disc = cmbNomDiscSong.SelectedItem.ToString();

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
            if (!String.IsNullOrEmpty(txtbxNom.Text) && cmbNomArtistaSong.SelectedIndex > -1 && cmbNomDiscSong.SelectedIndex > -1)
            {
                string nomSong = txtbxNom.Text;
                string artista = cmbNomArtistaSong.SelectedItem.ToString();
                string disc = cmbNomDiscSong.SelectedItem.ToString();

                bool eliminat = await domain.RemoveSong(artista, disc, nomSong);
                if (eliminat) MessageBox.Show("Eliminat correctament");
                else MessageBox.Show("No s'ha pogut eliminar");
            }
            else MessageBox.Show("Camps buits!");
            GetListMusiques();
        }

        private async void btnModificarSong_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbxNom.Text) && cmbNomArtistaSong.SelectedIndex > -1 && cmbNomDiscSong.SelectedIndex > -1)
            {
                string nomSong = txtbxNom.Text;
                string artista = cmbNomArtistaSong.SelectedItem.ToString();
                string disc = cmbNomDiscSong.SelectedItem.ToString();

                Song song = await domain.GetSong(artista, disc, nomSong);

                if (!String.IsNullOrEmpty(txtDuracio.Text) && song != null)
                {
                    song.Durada = Convert.ToDouble(txtDuracio.Text);

                    if (await domain.UpdateSong(artista, disc, song)) MessageBox.Show("Modificat correctament");
                    else MessageBox.Show("No s'ha pogut modificar");
                }
                else MessageBox.Show("Res a modificar");

            }
            else MessageBox.Show("Camps buits!");
        }

        public async void GetListMusiques()
        {
            cmbLlistaMusicsDiscos.Items.Clear();
            cmbNomArtistaSong.Items.Clear();
            cmbNomDiscSong.Items.Clear();

            List<Musica> llistaMusiques = await domain.GetMusiques();
            foreach (Musica musica in llistaMusiques)
            {
                cmbLlistaMusicsDiscos.Items.Add(musica.Nom);
                cmbNomArtistaSong.Items.Add(musica.Nom);
                foreach (String oneDisc in musica.Discografia.Keys)
                {
                    cmbNomDiscSong.Items.Add(oneDisc);
                }
                
            }
        }
    }
}