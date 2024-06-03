using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;

[CollectionDefinition(nameof(DatabaseCollection))]
public class IntegrationTestDatabaseCollection : ICollectionFixture<IntegrationTestFixture>
{
    public const string DatabaseCollection = nameof(DatabaseCollection);
}