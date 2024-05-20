using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests;

[CollectionDefinition("DatabaseCollection")]
public class DatabaseCollection : ICollectionFixture<IntegrationTestFixture>
{
}