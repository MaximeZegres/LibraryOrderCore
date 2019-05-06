FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["LibraryOrderCore/LibraryOrderCore.csproj", "LibraryOrderCore/"]
RUN dotnet restore "LibraryOrderCore/LibraryOrderCore.csproj"
COPY . .
WORKDIR "/src/LibraryOrderCore"
RUN dotnet build "LibraryOrderCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LibraryOrderCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LibraryOrderCore.dll"]