using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;

[CollectionDefinition("DatabaseCollection")]
public class IntegrationTestDatabaseCollection : ICollectionFixture<IntegrationTestFixture>
{
}