namespace Eduhub.StudentService.Infrastructure.IntegrationTests;

public class FileGetter
{
    public (Stream fileStream, long fileSize, string contentType) GetTestAvatarStream()
    {
        var testAvatarPath = Path.Combine("C:\\Users\\vantu\\RiderProjects\\EduHub.Learn\\src\\Services\\StudentService\\Tests\\Eduhub.StudentService.Tests.Integration",
            "test.jpg");
        var stream = new FileStream(testAvatarPath, FileMode.Open, FileAccess.Read);

        return (stream, stream.Length, "image/jpeg");
    }
}