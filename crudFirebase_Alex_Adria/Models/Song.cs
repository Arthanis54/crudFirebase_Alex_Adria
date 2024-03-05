using System.Text;

namespace crudFirebase_Alex_Adria.Models
{
    public class Song
    {
        private string id;
        private string nom;
        private double durada;

        public Song(string id, double durada)
        {
            this.id = id;
            this.durada = durada;
        }

        public string Id { get => this.id; set => this.id = value; }
        public string Nom { get; set; }
        public double Durada { get => this.durada; set => this.durada = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + this.Nom);
            sb.AppendLine("Id: " + this.id);
            sb.AppendLine("Durada: " + this.Durada);
            return sb.ToString();
        }
    }
}
