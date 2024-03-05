using crudFirebase_Alex_Adria.DataAccess.Repositoris;
using crudFirebase_Alex_Adria.Models;

namespace crudFirebase_Alex_Adria.Domain
{
    public class FirebaseDomain : IFirebaseDomain
    {
        public IFirebaseRepository FirebaseRepository { get; set; }

        public FirebaseDomain()
        {
            FirebaseRepository = FirebaseFactory.GetFirebaseRepository();
        }

        public async Task<bool> RemoveMusic(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveDisc(string musicaName, string discName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveSong(string musicaName, string discName, string songName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddMusic(Musica musica)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddDisc(string musicaName, Disc disc)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddSong(string musicaName, string discName, Song song)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateMusica(Musica musica)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDisc(string musicaName, Disc disc)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateSong(string musicaName, string discName, Song song)
        {
            throw new NotImplementedException();
        }

        public async Task<Musica> GetMusica(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Musica>> GetMusiques()
        {
            throw new NotImplementedException();
        }
    }
}
