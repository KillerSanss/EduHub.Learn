using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;

[CollectionDefinition(nameof(CollectionNames.DatabaseCollection))]
public class IntegrationTestDatabaseCollection : ICollectionFixture<IntegrationTestFixture>
{
}