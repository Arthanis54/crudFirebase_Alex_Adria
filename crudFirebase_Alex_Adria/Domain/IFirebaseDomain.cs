using crudFirebase_Alex_Adria.Models;
using Firebase.Database;

namespace crudFirebase_Alex_Adria.Domain
{
    public interface IFirebaseDomain
    {
        public Task<bool> ExistsMusica(String name);
        public Task<bool> ExistsDisc(String musicaName, String discName);
        public Task<bool> ExistsSong(String musicaName, String discName, String songName);

        public Task<bool> RemoveMusic(String name);
        public Task<bool> RemoveDisc(String musicaName, String discName);
        public Task<bool> RemoveSong(String musicaName, String discName, String songName);

        public Task<bool> AddMusic(Musica musica);
        public Task<bool> AddDisc(String musicaName, Disc disc);
        public Task<bool> AddSong(String musicaName, String discName, String songName);

        public Task<bool> UpdateMusica(Musica musica);
        public Task<bool> UpdateDisc(String musicaName, Disc disc);
        public Task<bool> UpdateSong(String musicaName, String discName, String songName);

        public Task<Musica> GetMusica(String name);
        public Task<List<Musica>> GetMusiques();
    }
}
