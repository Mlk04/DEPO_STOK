# .NET SDK ile derleme katmanı
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Proje dosyalarını kopyala ve derle
COPY . ./
RUN dotnet publish DEPO_STOK.csproj -c Release -o out

# .NET Runtime ile çalışma katmanı
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "DEPO_STOK.dll"]
