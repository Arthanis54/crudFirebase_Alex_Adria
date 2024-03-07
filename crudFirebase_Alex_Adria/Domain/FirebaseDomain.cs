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
            return await FirebaseRepository.RemoveMusic(name);
        }

        public async Task<bool> RemoveDisc(string musicaName, string discName)
        {
           return await FirebaseRepository.RemoveDisc(musicaName, discName);
        }

        public async Task<bool> RemoveSong(string musicaName, string discName, string songName)
        {
            return await FirebaseRepository.RemoveSong(musicaName, discName, songName);
        }

        public async Task<bool> AddMusic(Musica musica)
        {
            return await FirebaseRepository.AddMusic(musica);
        }

        public async Task<bool> AddDisc(string musicaName, Disc disc)
        {
            return await FirebaseRepository.AddDisc(musicaName, disc);
        }

        public async Task<bool> AddSong(string musicaName, string discName, Song song)
        {
            return await FirebaseRepository.AddSong(musicaName, discName, song);
        }

        public async Task<bool> UpdateMusica(Musica musica)
        {
            return await FirebaseRepository.UpdateMusica(musica);
        }

        public async Task<bool> UpdateDisc(string musicaName, Disc disc)
        {
            return await FirebaseRepository.UpdateDisc(musicaName, disc);
        }

        public async Task<bool> UpdateSong(string musicaName, string discName, Song song)
        {
            return await FirebaseRepository.UpdateSong(musicaName, discName, song);
        }

        public async Task<Musica> GetMusica(string name)
        {
            return await FirebaseRepository.GetMusica(name);
        }
        public async Task<Disc> GetDisc(string musicaName, string discName)
        {
            return await FirebaseRepository.GetDisc(musicaName, discName);
        }
        public async Task<Song> GetSong(string musicaName, string discName, string songName)
        {
            return await FirebaseRepository.GetSong(musicaName, discName, songName);
        }

        // per convertir de <IReadOnlyCollection<FirebaseObject<Musica>>> a <List<Musica>> sha de fer el metode seguent :
        public async Task<List<Musica>> GetMusiques()
        {
            var frbObjects = await FirebaseRepository.GetMusiques();
            var musiques = frbObjects.Select(firebaseObject => firebaseObject.Object).ToList();
            return musiques;
        }
    }
}
