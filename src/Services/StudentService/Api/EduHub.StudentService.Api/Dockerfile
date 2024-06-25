FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/StudentService/Api/EduHub.StudentService.Api/EduHub.StudentService.Api.csproj", "src/Services/StudentService/Api/EduHub.StudentService.Api/"]
COPY ["src/Services/StudentService/Domain/Eduhub.StudentService.Domain/Eduhub.StudentService.Domain.csproj", "src/Services/StudentService/Domain/Eduhub.StudentService.Domain/"]
COPY ["src/Services/StudentService/Application/EduHub.StudentService.Application.Services/EduHub.StudentService.Application.Services.csproj", "src/Services/StudentService/Application/EduHub.StudentService.Application.Services/"]
COPY ["src/Services/StudentService/Infrastructure/Eduhub.StudentService.Infrastructure.Data/Eduhub.StudentService.Infrastructure.Data.csproj", "src/Services/StudentService/Infrastructure/Eduhub.StudentService.Infrastructure.Data/"]
COPY ["src/Services/StudentService/Infrastructure/EduHub.StudentService.Infrastructure.Repositories/EduHub.StudentService.Infrastructure.Repositories.csproj", "src/Services/StudentService/Infrastructure/EduHub.StudentService.Infrastructure.Repositories/"]
RUN dotnet restore "src/Services/StudentService/Api/EduHub.StudentService.Api/EduHub.StudentService.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/StudentService/Api/EduHub.StudentService.Api"
RUN dotnet build "EduHub.StudentService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EduHub.StudentService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduHub.StudentService.Api.dll"]
