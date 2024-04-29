FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/StudentService/Infrastructure/EduHub.StudentService.Infrastructure.Migrator/EduHub.StudentService.Infrastructure.Migrator.csproj", "src/Services/StudentService/Infrastructure/EduHub.StudentService.Infrastructure.Migrator/"]
COPY ["src/Services/StudentService/Domain/Eduhub.StudentService.Domain/Eduhub.StudentService.Domain.csproj", "src/Services/StudentService/Domain/Eduhub.StudentService.Domain/"]
COPY ["src/Services/StudentService/Application/EduHub.StudentService.Application.Services/EduHub.StudentService.Application.Services.csproj", "src/Services/StudentService/Application/EduHub.StudentService.Application.Services/"]
COPY ["src/Services/StudentService/Infrastructure/Eduhub.StudentService.Infrastructure.Data/Eduhub.StudentService.Infrastructure.Data.csproj", "src/Services/StudentService/Infrastructure/Eduhub.StudentService.Infrastructure.Data/"]
RUN dotnet restore "src/Services/StudentService/Infrastructure/EduHub.StudentService.Infrastructure.Migrator/EduHub.StudentService.Infrastructure.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Services/StudentService/Infrastructure/EduHub.StudentService.Infrastructure.Migrator"
RUN dotnet build "EduHub.StudentService.Infrastructure.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EduHub.StudentService.Infrastructure.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduHub.StudentService.Infrastructure.Migrator.dll"]
