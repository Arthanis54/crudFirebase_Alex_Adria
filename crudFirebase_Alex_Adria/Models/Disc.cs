using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace crudFirebase_Alex_Adria.Models
{
    public class Disc
    {
        private string id;
        private DateTime dataAparicio;

        public Disc(string id, DateTime dataAparicio)
        {
            this.id = id;
            this.dataAparicio = dataAparicio;
            LlistaSongs = new Dictionary<string, Song>();
        }

        public string Id { get => this.id; set => this.id = value; }
        public string Nom { get; set; }
        public DateTime DataAparicio { get => this.dataAparicio; set => this.dataAparicio = value; }

        public Dictionary<string, Song> LlistaSongs { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nom: " + this.Nom);
            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Data Aparicio: " + this.dataAparicio);
            foreach (var song in LlistaSongs) sb.AppendLine("\t" + song.Value.Nom);
            return sb.ToString();
        }

    }
}
