using System.Text;

namespace crudFirebase_Alex_Adria.Models
{
    public class Song
    {
        private string id;
        private string name;
        private double durada;

        public Song(string id, string name, double durada)
        {
            this.id = id;
            this.name = name;
            this.durada = durada;
        }

        public string Id { get => this.id; set => this.id = value; }
        public string Name { get => this.name; set => this.name = value; }
        public double Durada { get => this.durada; set => this.durada = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id: " + this.id);
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("Durada: " + this.Durada);
            return sb.ToString();
        }
    }
}
