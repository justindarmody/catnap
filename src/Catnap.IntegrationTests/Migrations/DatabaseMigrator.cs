using Catnap.Adapters;
using Catnap.Migration;

namespace Catnap.IntegrationTests.Migrations
{
    public static class DatabaseMigrator
    {
        private static readonly DatabaseMigratorUtility migratorUtility = new DatabaseMigratorUtility(new SqliteAdapter());

        public static void Execute(IDatabaseMigration createSchemaMigration)
        {
            migratorUtility.Migrate
            (
                createSchemaMigration
            );
        }
    }
}