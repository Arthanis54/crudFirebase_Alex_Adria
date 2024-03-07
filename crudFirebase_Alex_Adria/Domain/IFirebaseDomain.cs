using crudFirebase_Alex_Adria.Models;
using Firebase.Database;

namespace crudFirebase_Alex_Adria.Domain
{
    public interface IFirebaseDomain
    {
        public Task<bool> RemoveMusic(String name);
        public Task<bool> RemoveDisc(String musicaName, String discName);
        public Task<bool> RemoveSong(String musicaName, String discName, String songName);

        public Task<bool> AddMusic(Musica musica);
        public Task<bool> AddDisc(String musicaName, Disc disc);
        public Task<bool> AddSong(String musicaName, String discName, Song song);

        public Task<bool> UpdateMusica(Musica musica);
        public Task<bool> UpdateDisc(String musicaName, Disc disc);
        public Task<bool> UpdateSong(String musicaName, String discName, Song song);

        public Task<Musica> GetMusica(String name);
        public Task<Disc> GetDisc(String musicaName, string discName);
        public Task<Song> GetSong(String musicaName, string discName, string songName);
        public Task<List<Musica>> GetMusiques();
    }
}
