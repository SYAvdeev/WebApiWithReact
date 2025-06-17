# Сборка образа для ASP.NET приложения
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app

# Копирование файлов для сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApiWithReact.Backend/WebApiWithReact.Backend/WebApiWithReact.Backend.csproj", "WebApiWithReact.Backend/WebApiWithReact.Backend/"]
RUN dotnet restore "WebApiWithReact.Backend/WebApiWithReact.Backend/WebApiWithReact.Backend.csproj"
COPY . .
WORKDIR "/src/WebApiWithReact.Backend/WebApiWithReact.Backend"
RUN dotnet build "WebApiWithReact.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Сборка приложения
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApiWithReact.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Копирование файлов в контейнер для запуска приложения
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Установка произвольного порта для ASP.NET приложения
ENV ASPNETCORE_URLS=http://+:5211

# Открытие порта в контейнере
EXPOSE 5211

# Запуск приложения
ENTRYPOINT ["dotnet", "WebApiWithReact.Backend.dll"]