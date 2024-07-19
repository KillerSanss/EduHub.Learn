using System.Reactive.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Minio;
using Minio.ApiEndpoints;
using Minio.DataModel.Args;

namespace EduHub.StudentService.Application.Services;

public class FileClient
{
    private readonly IMinioClient _minioClient;
    private readonly string _bucketName;

    public FileClient(IOptions<MinioSettings> minioSettings)
    {
        _bucketName = minioSettings.Value.BucketName;
        var settings = minioSettings.Value;
        _minioClient = new MinioClient()
            .WithEndpoint(settings.EndPoint)
            .WithCredentials(settings.AccessKey, settings.SecretKey)
            .Build();
    }
    
    /// <summary>
    /// Загрузка файла в бакет
    /// </summary>
    /// <param name="objectName">Имя файла.</param>
    /// <param name="file">Файл.</param>
    /// <returns>Добавленный файл.</returns>
    public async Task<string> UploadFileAsync(string objectName, IFormFile file)
    {
        await EnsureBucketExistsAsync();

        await using var stream = file.OpenReadStream();
        var putObjectArgs = new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithStreamData(stream)
            .WithObjectSize(file.Length)
            .WithContentType(file.ContentType);

        await _minioClient.PutObjectAsync(putObjectArgs);
        
        var statObjectArgs = new StatObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName);
        await _minioClient.StatObjectAsync(statObjectArgs);
        return objectName;
    }
    
    /// <summary>
    /// Получение URI файла по идентификатору.
    /// </summary>
    /// <param name="objectName">Имя объекта в бакете.</param>
    /// <returns>URI файла.</returns>
    public async Task<string> GetFileUriAsync(string objectName)
    {
        var getObjectArgs = new PresignedGetObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithExpiry(24 * 60 * 60);
        
        return await _minioClient.PresignedGetObjectAsync(getObjectArgs);
    }

    /// <summary>
    /// Проверка наличия бакета
    /// </summary>
    public async Task EnsureBucketExistsAsync()
    {
        var isExist = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(_bucketName));
        if (!isExist)
        {
            await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(_bucketName));
        }
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