# =========================
# Build Stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy ONLY solution structure first (safer for restore)
COPY DailyBytesServices/*.csproj DailyBytesServices/
COPY DailyBytesDAL/*.csproj DailyBytesDAL/

RUN dotnet restore DailyBytesServices/DailyBytesServices.csproj

# Copy everything
COPY . .

RUN dotnet publish DailyBytesServices/DailyBytesServices.csproj -c Release -o /app/publish

# =========================
# Runtime Stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT

EXPOSE 80

ENTRYPOINT ["dotnet", "DailyBytesServices.dll"]