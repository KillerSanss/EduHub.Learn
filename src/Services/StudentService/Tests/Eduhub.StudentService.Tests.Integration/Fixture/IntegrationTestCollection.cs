using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;

[CollectionDefinition(nameof(IntegrationTestCollection))]
public class IntegrationTestCollection : ICollectionFixture<IntegrationTestFixture>
{
}