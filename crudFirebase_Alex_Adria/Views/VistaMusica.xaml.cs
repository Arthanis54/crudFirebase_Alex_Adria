﻿using crudFirebase_Alex_Adria.Domain;
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



        //Disc
        private void DeleteDisc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddDisc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateDisc_Click(object sender, RoutedEventArgs e)
        {

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
            if (!String.IsNullOrEmpty(txtbxNom.Text) && !String.IsNullOrEmpty(txtDuracio.Text) && !String.IsNullOrEmpty(txtNomArtista.Text) && !String.IsNullOrEmpty(txtNomDisc.Text))
            {
                string nomSong = txtbxNom.Text;
                double tempsDurada = Convert.ToDouble(txtDuracio.Text);
                string artista = txtNomArtista.Text;
                string disc = txtNomDisc.Text;
                Song song = new Song(nomSong, tempsDurada);


                bool afegit = await domain.AddSong(artista, disc, song);
                if (afegit)
                {
                    MessageBox.Show("Afegit correctament");
                }
                else
                {
                    MessageBox.Show("No s'ha pogut afegir");
                }



            }

        }

        private async Task btnEliminarSong_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbxNom.Text) && !String.IsNullOrEmpty(txtDuracio.Text) && !String.IsNullOrEmpty(txtNomArtista.Text) && !String.IsNullOrEmpty(txtNomDisc.Text))
            {
                string nomSong = txtbxNom.Text;
                double tempsDurada = Convert.ToDouble(txtDuracio.Text);
                string artista = txtNomArtista.Text;
                string disc = txtNomDisc.Text;



                bool afegit = await domain.RemoveSong(artista, disc, nomSong);
                if (afegit)
                {
                    MessageBox.Show("Eliminat correctament");
                }
                else
                {
                    MessageBox.Show("No s'ha pogut eliminar");
                }


            }


        }

        private async void btnModificarSong_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbxNom.Text) && !String.IsNullOrEmpty(txtDuracio.Text) && !String.IsNullOrEmpty(txtNomArtista.Text) && !String.IsNullOrEmpty(txtNomDisc.Text))
            {
                string nomSong = txtbxNom.Text;
                double tempsDurada = Convert.ToDouble(txtDuracio.Text);
                string artista = txtNomArtista.Text;
                string disc = txtNomDisc.Text;
                Song song = new Song(nomSong, tempsDurada);
                bool afegit = await domain.UpdateSong(artista, disc, song);
                if (afegit)
                {
                    MessageBox.Show("Modificat correctament");
                }
                else
                {
                    MessageBox.Show("No s'ha pogut modificar");
                }
            }



        }
    }
}