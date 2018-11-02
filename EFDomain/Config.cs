using System.Data.SqlClient;

namespace EFDomain
{
    public static class Config
    {
        public static readonly string LocalDbConnectionStringEf = GetLocalDbConnectionStringForEf();
        public static readonly string LocalDbConnectionStringRegular = GetLocalDbConnectionStringRegular();

        public static readonly string LocalDbConnectionStringRegularWithNoDb =
            GetLocalDbConnectionStringWithNoDatabase();


        private static string GetLocalDbConnectionStringRegular()
        {
            var connectionBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "EF6DbContextDb",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };

            return connectionBuilder.ToString();
        }

        private static string GetLocalDbConnectionStringForEf()
        {
            var connectionBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "EF6DbContextDb",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true,
                ApplicationName = "EntityFramework"
            };


            return connectionBuilder.ToString();
        }

        private static string GetLocalDbConnectionStringWithNoDatabase()
        {
            var connectionBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };

            return connectionBuilder.ToString();
        }
    }
}