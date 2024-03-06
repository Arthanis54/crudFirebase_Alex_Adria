using crudFirebase_Alex_Adria.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Security.Policy;
using System.Xml.Linq;

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

        public async Task<bool> AddDisc(string musicaName, Disc disc)
        {
            bool done = false;

            if (!await ExistsDisc(musicaName, disc.Nom))
            {
                Disc unDisc = new Disc(
                    disc.Id,
                    disc.DataAparicio,
                    disc.LlistaSongs
                    );
                await Firebase
                    .Child("Musica")
                    .Child(musicaName)
                    .Child("Discografia")
                    .Child(disc.Nom)
                    .PutAsync(unDisc);

                done = true;
            }
            return done;
        }

        public async Task<bool> AddMusic(Musica musica)
        {
            bool done = false;

            if (!await ExistsMusica(musica.Nom))
            {
                Musica unaMusica = new Musica(
                    musica.Id,
                    musica.DataCreacio,
                    musica.Info,
                    musica.Discografia
                    );
                await Firebase
                    .Child("Musica")
                    .Child(musica.Nom)
                    .PutAsync(unaMusica);

                done = true;
            }
            return done;
        }

        public async Task<bool> AddSong(string musicaName, string discName, Song song)
        {
            bool done = false;

            if (!await ExistsSong(musicaName, discName, song.Nom))
            {
                Song oneSong = new Song(
                    song.Id,
                    song.Durada
                    );
                await Firebase
                    .Child("Musica")
                    .Child(musicaName)
                    .Child("Discografia")
                    .Child(discName)
                    .Child("Cançons")
                    .Child(song.Nom)
                    .PutAsync(oneSong);

                done = true;
            }
            return done;
        }

        private async Task<bool> ExistsDisc(string musicaName, string discName)
        {
            return await Firebase
                .Child("Musica")
                .Child(musicaName)
                .Child("Discografia")
                .Child(discName)
                .OnceSingleAsync<Disc>() != null;
        }

        private async Task<bool> ExistsMusica(string name)
        {
            return await Firebase
                .Child("Musica")
                .Child(name)
                .OnceSingleAsync<Musica>() != null;
        }

        private async Task<bool> ExistsSong(string musicaName, string discName, string songName)
        {
            return await Firebase
                .Child("Musica")
                .Child(musicaName)
                .Child("Discografia")
                .Child(discName)
                .Child("Cançons")
                .Child(songName)
                .OnceSingleAsync<Song>() != null;
        }

        public async Task<Musica> GetMusica(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<FirebaseObject<Musica>>> GetMusiques()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveDisc(string musicaName, string discName)
        {
            bool done = false;

            if (await ExistsDisc(musicaName, discName))
            {
                await Firebase
                    .Child("Musica")
                    .Child(musicaName)
                    .Child("Discografia")
                    .Child(discName)
                    .DeleteAsync();

                done = true;
            }
            return done;
        }

        public async Task<bool> RemoveMusic(string name)
        {
            bool done = false;

            if (await ExistsMusica(name))
            {
                await Firebase
                    .Child("Musica")
                    .Child(name)
                    .DeleteAsync();

                done = true;
            }
            return done;
        }

        public async Task<bool> RemoveSong(string musicaName, string discName, string songName)
        {
            bool done = false;

            if (await ExistsSong(musicaName, discName, songName))
            {
                await Firebase
                    .Child("Musica")
                    .Child(musicaName)
                    .Child("Discografia")
                    .Child(discName)
                    .Child("Cançons")
                    .Child(songName)
                    .DeleteAsync();

                done = true;
            }
            return done;
        }

        public async Task<bool> UpdateDisc(string musicaName, Disc disc)
        {
            bool done = false;

            if (await ExistsDisc(musicaName, disc.Nom))
            {
                Disc unDisc = new Disc(
                    disc.Id,
                    disc.DataAparicio,
                    disc.LlistaSongs
                    );
                await Firebase
                    .Child("Musica")
                    .Child(musicaName)
                    .Child("Discografia")
                    .Child(disc.Nom)
                    .PutAsync(unDisc);

                done = true;
            }
            return done;
        }

        public async Task<bool> UpdateMusica(Musica musica)
        {
            bool done = false;

            if (await ExistsMusica(musica.Nom))
            {
                Musica unaMusica = new Musica(
                    musica.Id,
                    musica.DataCreacio,
                    musica.Info,
                    musica.Discografia
                    );
                await Firebase
                    .Child("Musica")
                    .Child(musica.Nom)
                    .PutAsync(unaMusica);

                done = true;
            }
            return done;
        }

        public async Task<bool> UpdateSong(string musicaName, string discName, Song song)
        {
            bool done = false;

            if (await ExistsSong(musicaName, discName, song.Nom))
            {
                Song unaSong = new Song(
                    song.Id,
                    song.Durada
                    );
                await Firebase
                    .Child("Musica")
                    .Child(musicaName)
                    .Child("Discografia")
                    .Child(discName)
                    .Child("Cançons")
                    .Child(song.Nom)
                    .PutAsync(unaSong);

                done = true;
            }
            return done;
        }
    }
}
