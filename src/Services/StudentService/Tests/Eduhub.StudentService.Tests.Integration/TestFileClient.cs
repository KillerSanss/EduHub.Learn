using System.Reactive.Linq;
using EduHub.StudentService.Application.Services;
using Microsoft.Extensions.Options;
using Minio;
using Minio.ApiEndpoints;
using Minio.DataModel.Args;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests;

public class TestFileClient
{
    private readonly IMinioClient _minioClient;
    private readonly string _bucketName;
    
    public TestFileClient(IOptions<MinioSettings> minioSettings)
    {
        _bucketName = minioSettings.Value.BucketName;
        var settings = minioSettings.Value;
        _minioClient = new MinioClient()
            .WithEndpoint(settings.EndPoint)
            .WithCredentials(settings.AccessKey, settings.SecretKey)
            .Build();
    }
    
    /// <summary>
    /// Удаление всех объектов в бакете
    /// </summary>
    public async Task DeleteAllObjectsInBucketAsync()
    {
        var listObjectsArgs = new ListObjectsArgs()
            .WithBucket(_bucketName)
            .WithRecursive(true);
    
        var objects = _minioClient.ListObjectsAsync(listObjectsArgs);
        
        await objects.ForEachAsync(async item =>
        {
            await _minioClient.RemoveObjectAsync(new RemoveObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(item.Key));
        });
    }
}