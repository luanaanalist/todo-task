FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ToDoApp.Api/ToDoApp.Api.csproj", "src/ToDoApp.Api/"]
COPY ["src/ToDoApp.Application/ToDoApp.Application.csproj", "src/ToDoApp.Application/"]
COPY ["src/ToDoApp.Domain/ToDoApp.Domain.csproj", "src/ToDoApp.Domain/"]
COPY ["src/ToDoApp.IoC/ToDoApp.IoC.csproj", "src/ToDoApp.IoC/"]
COPY ["src/ToDoApp.Infrastructure/ToDoApp.Infrastructure.csproj", "src/ToDoApp.Infrastructure/"]
RUN dotnet restore "./src/ToDoApp.Api/ToDoApp.Api.csproj"
COPY . .
WORKDIR "src/ToDoApp.Api"
RUN dotnet build "./ToDoApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ToDoApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.Api.dll"]