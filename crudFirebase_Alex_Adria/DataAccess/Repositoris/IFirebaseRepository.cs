using crudFirebase_Alex_Adria.Models;
using Firebase.Database;

namespace crudFirebase_Alex_Adria.DataAccess.Repositoris
{
    public interface IFirebaseRepository
    {
        public Task<bool> ExistsMusica(String name);
        public Task<bool> ExistsDisc(String id);
        public Task<bool> ExistsSong(String id);

        public Task<bool> RemoveMusic(String name);
        public Task<bool> RemoveDisc(String id);
        public Task<bool> RemoveSong(String id);

        public Task<bool> AddMusic(Musica musica);
        public Task<bool> UpdateMusica(Musica musica);
        public Task<Musica> GetMusica(String name);
        public Task<IReadOnlyCollection<FirebaseObject<Musica>>> GetMusiques();
    }
}
