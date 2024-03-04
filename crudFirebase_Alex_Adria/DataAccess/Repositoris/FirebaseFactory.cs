namespace crudFirebase_Alex_Adria.DataAccess.Repositoris
{
    public class FirebaseFactory
    {
        public static IFirebaseRepository GetFirebaseRepository()
        {
            return new FirebaseRepository();
        }
    }
}
