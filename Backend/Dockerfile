FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443



FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Backend/Backend.csproj", "Backend/"]
RUN dotnet restore "Backend/Backend.csproj"
COPY . .
WORKDIR "/src/Backend"
RUN dotnet build "Backend.csproj" -c Release -o /app/build
ENV ConnectionStrings="BestMoviesDB":"Server=sep6bestmoviesdbcloud.postgres.database.azure.com;Database=BestMoviesDBCloud;Port=5432;User Id=sep6bestmoviesdbcloud;Password=dba_107882;Ssl Mode=Require;TrustServerCertificate=True;"

FROM build AS publish
RUN dotnet publish "Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.dll"]
