using Eduhub.StudentService.Infrastructure.Data;
using Microsoft.Extensions.Options;
using Minio;
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
    /// <param name="path">Путь к файлу.</param>
    /// <returns>Загруженный файл.</returns>
    public async Task<string> UploadFileAsync(string path)
    {
        var fileName = Path.GetFileName(path);
        await _minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(fileName)
            .WithFileName(path));

        return fileName;
    }
    
    /// <summary>
    /// Получение файла по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <returns>Файл.</returns>
    public async Task<string> GetFileUriAsync(string id)
    {
        return await _minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(id)
            .WithExpiry(1024 * 60 * 60));
    }

    /// <summary>
    /// Проверка наличия бакета
    /// </summary>
    public async Task<bool> EnsureBucketExistsAsync()
    {
        bool isExist = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(_bucketName));
        if (!isExist)
        {
            await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(_bucketName));
        }

        return isExist;
    }
}