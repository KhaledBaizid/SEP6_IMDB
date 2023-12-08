FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "FrontendBlazorWebAssembly/FrontendBlazorWebAssembly.csproj"
COPY . .

WORKDIR "/src/FrontendBlazorWebAssembly"
RUN dotnet build "FrontendBlazorWebAssembly.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrontendBlazorWebAssembly.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY ["/FrontendBlazorWebAssembly/nginx.conf", "/etc/nginx/"]