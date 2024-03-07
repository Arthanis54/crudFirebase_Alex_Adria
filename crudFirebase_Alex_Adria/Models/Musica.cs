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
        private DateTime dataCreacio = DateTime.Now;
        private string info;

        public Musica(string id)
        {
            this.id = id;

            Disc oneDisc = new Disc(Guid.NewGuid().ToString());
            oneDisc.Nom = "ExempleDisc" + oneDisc.Id;
            Disc secondDisc = new Disc(Guid.NewGuid().ToString());
            secondDisc.Nom = "ExempleDisc" + secondDisc.Id;

            Discografia = new Dictionary<string, Disc>
            {
                { oneDisc.Nom, oneDisc },
                { secondDisc.Nom, secondDisc }
            };
        }

        public string Id { get => this.id; set => this.id = value; }
        public string Nom { get; set; }
        public DateTime DataCreacio { get => this.dataCreacio; set => this.dataCreacio = value; }
        public string Info { get => this.info; set => this.info = value; }
        public Dictionary<string, Disc> Discografia { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nom: " + this.Nom);
            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Data Creació: " + this.DataCreacio);
            sb.AppendLine("Info: " + this.Info);
            foreach (var disc in Discografia) sb.AppendLine("\t" + disc);
            return sb.ToString();
        }
    }
}
