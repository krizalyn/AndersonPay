using System.Data.Entity;

namespace AndersonPayContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DBInitializer()
        {

        }

        protected override void Seed(Context context)
        {
            //To Do: Add default data here
        }
    }
}
