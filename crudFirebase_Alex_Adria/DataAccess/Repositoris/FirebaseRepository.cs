using crudFirebase_Alex_Adria.Models;
using Firebase.Database;
using Firebase.Database.Query;

namespace crudFirebase_Alex_Adria.DataAccess.Repositoris
{
    public class FirebaseRepository : IFirebaseRepository
    {
        private const String URL = "https://crudfirebasealexadria-default-rtdb.firebaseio.com/";
        private const String SECRET = "K9qdM8irkyK0augEcQFLE4vpdG1ZB3MSGProMYlO";

        private FirebaseClient Firebase;
        
        public FirebaseRepository()
        {
            this.Firebase = FirebaseConnection.GetFirebaseClient(URL, SECRET);
            
            if (Firebase != null ) Console.WriteLine("Connected");
        }

        public Task<bool> AddDisc(Musica musica, Disc disc)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddMusic(Musica musica)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddSong(Disc disc, Song song)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsDisc(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsMusica(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsSong(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Musica> GetMusica(string name)
        {
            throw new NotImplementedException();
        }

        private async Task<Disc> GetDisc(string id)
        {
            throw new NotImplementedException();
        }

        private async Task<Song> GetSong(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<FirebaseObject<Musica>>> GetMusiques()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveDisc(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveMusic(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveSong(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDisc(Musica musica, Disc disc)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateMusica(Musica musica)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSong(Disc disc, Song song)
        {
            throw new NotImplementedException();
        }
    }
}
