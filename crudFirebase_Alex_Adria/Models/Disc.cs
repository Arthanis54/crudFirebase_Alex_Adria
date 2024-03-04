using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudFirebase_Alex_Adria.Models
{
    public class Disc
    {
        private string id;
        private string nom;
        private DateTime dataAparicio;
        private List<Song> llistaSongs;

        public Disc(string id, string nom, DateTime dataAparicio, List<Song> llistaSongs)
        {
            this.id = id;
            this.nom = nom;
            this.dataAparicio = dataAparicio;
            this.llistaSongs = llistaSongs;
        }

        public string Id { get => this.id; set => this.id = value; }
        public string Nom { get => this.nom; set => this.nom = value; }
        public DateTime DataAparicio { get => this.dataAparicio; set => this.dataAparicio = value; }
        public List<Song> LlistaSongs { get => this.llistaSongs; set => this.llistaSongs = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Nom: " + this.Nom);
            sb.AppendLine("Data Aparicio: " + this.dataAparicio);
            foreach (var song in llistaSongs) sb.AppendLine("\t" + song);
            return sb.ToString();
        }

    }
}
