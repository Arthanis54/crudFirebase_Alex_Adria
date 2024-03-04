using crudFirebase_Alex_Adria.Models;

namespace crudFirebase_Alex_Adria.Domain
{
    public interface IFirebaseDomain
    {
        public Task<bool> ExistsMusica(String name);
        public Task<bool> ExistsDisc(String id);
        public Task<bool> ExistsSong(String id);

        public Task<bool> RemoveMusic(String name);
        public Task<bool> RemoveDisc(String id);
        public Task<bool> RemoveSong(String id);

        public Task<bool> AddMusic(Musica musica);
        public Task<bool> AddDisc(Musica musica, Disc disc);
        public Task<bool> AddSong(Disc disc, Song song);

        public Task<bool> UpdateMusica(Musica musica);
        public Task<bool> UpdateDisc(Musica musica, Disc disc);
        public Task<bool> UpdateSong(Disc disc, Song song);

        public Task<Musica> GetMusica(String name);
        public Task<List<Musica>> GetListMusiques();
    }
}
