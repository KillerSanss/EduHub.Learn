using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Primitives;
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
    /// <param name="objectName">Имя файла.</param>
    /// <param name="stream">Поток файла.</param>
    /// <param name="size">Размер файла.</param>
    /// <param name="contentType">Тип содержимого файла.</param>
    /// <returns>Добавленный файл.</returns>
    public async Task<string> UploadFileAsync(string objectName, Stream stream, long size, string contentType)
    {
        await EnsureBucketExistsAsync();

        if (size > 10 * 1024 * 1024)
        {
            throw new FileSizeException(ErrorMessages.BigFileSize);
        }
        
        var permittedContentTypes = new[] { "image/png", "image/jpeg" };
        if (!permittedContentTypes.Contains(contentType))
        {
            throw new FileFormatException(ErrorMessages.FileFormat);
        }

        var putObjectArgs = new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithStreamData(stream)
            .WithObjectSize(size)
            .WithContentType(contentType);

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
}