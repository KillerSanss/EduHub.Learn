using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests;

public class FileGetter
{
    public FormFile GetTestAvatar()
    {
        var testAvatarPath = Path.Combine("C:\\Users\\vantu\\RiderProjects\\EduHub.Learn\\src\\Services\\StudentService\\Tests\\Eduhub.StudentService.Tests.Integration",
            "test.jpg");
        var stream = new FileStream(testAvatarPath, FileMode.Open, FileAccess.Read);

        var file = new FormFile(stream, 0, stream.Length, "test", Path.GetFileName(testAvatarPath))
        {
            Headers = new HeaderDictionary(),
            ContentType = "image/jpeg"
        };

        return file;
    }
}