using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Entities.Enums;
using Npgsql;
using Npgsql.TypeMapping;

namespace Eduhub.StudentService.Infrastructure.Data;

public static class EduhubNpgsqlDataSource
{
    public static NpgsqlDataSource Create(string connectionString)
    {
        Guard.Against.NullOrEmpty(connectionString);

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

        RegisterEnums(dataSourceBuilder);

        return dataSourceBuilder.Build();
    }

    private static void RegisterEnums(INpgsqlTypeMapper dataSourceBuilder)
    {
        dataSourceBuilder.MapEnum<Gender>();
    }
}