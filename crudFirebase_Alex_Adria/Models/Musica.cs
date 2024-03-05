using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudFirebase_Alex_Adria.Models
{
    public class Musica
    {
        private string id;
        private DateTime dataCreacio;
        private string info;
        private List<Disc> discografia;

        public Musica(string id, DateTime dataCreacio, string info, List<Disc> discografia)
        {
            this.id = id;
            this.dataCreacio = dataCreacio;
            this.info = info;
            this.discografia = discografia;
        }

        public string Id { get => this.id; set => this.id = value; }
        public string Nom { get; set; }
        public DateTime DataCreacio { get => this.dataCreacio; set => this.dataCreacio = value; }
        public string Info { get => this.info; set => this.info = value; }
        public List<Disc> Discografia { get => this.discografia; set => this.discografia = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nom: " + this.Nom);
            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Data Creació: " + this.DataCreacio);
            sb.AppendLine("Info: " + this.Info);
            foreach (var disc in discografia) sb.AppendLine("\t" + disc);
            return sb.ToString();
        }
    }
}
