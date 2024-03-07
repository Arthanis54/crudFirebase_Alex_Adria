using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace crudFirebase_Alex_Adria.Models
{
    public class Disc
    {
        private string id;
        private DateTime dataAparicio = DateTime.Now;

        public Disc(string id)
        {
            this.id = id;

            Song oneSong = new Song(Guid.NewGuid().ToString(), 2.9);
            oneSong.Nom = "ExempleSong" + oneSong.Id;
            Song secondSong = new Song(Guid.NewGuid().ToString(), 3.8);
            secondSong.Nom = "ExempleSong" + secondSong.Id;

            Cançons = new Dictionary<string, Song>
            {
                { oneSong.Nom, oneSong },
                { secondSong.Nom, secondSong }
            };
        }

        public string Id { get => this.id; set => this.id = value; }
        public string Nom { get; set; }
        public DateTime DataAparicio { get => this.dataAparicio; set => this.dataAparicio = value; }

        public Dictionary<string, Song> Cançons { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nom: " + this.Nom);
            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Data Aparicio: " + this.dataAparicio);
            foreach (var song in Cançons) sb.AppendLine("\t" + song.Value.Nom);
            return sb.ToString();
        }

    }
}
