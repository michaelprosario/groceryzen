FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["DocStore.Server/DocStore.Server.csproj", "DocStore.Server/"]
COPY ["DocStore.Infrastructure/DocStore.Infrastructure.csproj", "DocStore.Infrastructure/"]
COPY ["DocumentStore.Core/DocumentStore.csproj", "DocumentStore.Core/"]
RUN dotnet restore "DocStore.Server/DocStore.Server.csproj"
COPY . .
WORKDIR "/src/DocStore.Server"
RUN dotnet build "DocStore.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocStore.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocStore.Server.dll"]