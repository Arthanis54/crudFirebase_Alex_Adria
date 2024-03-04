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

        public async Task<bool> ExistsMusica(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsDisc(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsSong(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveMusic(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveDisc(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveSong(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddMusic(Musica musica)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddDisc(Musica musica, Disc disc)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddSong(Disc disc, Song song)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateMusica(Musica musica)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDisc(Musica musica, Disc disc)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateSong(Disc disc, Song song)
        {
            throw new NotImplementedException();
        }

        public async Task<Musica> GetMusica(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Musica>> GetListMusiques()
        {
            throw new NotImplementedException();
        }
    }
}
