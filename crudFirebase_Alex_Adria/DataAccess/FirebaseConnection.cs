using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudFirebase_Alex_Adria.DataAccess
{
    public class FirebaseConnection
    {
        public static FirebaseClient GetFirebaseClient(String url, string secret = null)
        {
            FirebaseClient client = null;
            if (!string.IsNullOrEmpty(secret))
            {
                FirebaseOptions options = new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(secret)
                };
                client = new FirebaseClient(url, options);
            }
            else client = new FirebaseClient(url);

            return client;
        }
    }
}
