#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Personnel_Records.Web/Personnel_Records.Web.csproj", "Personnel_Records.Web/"]
COPY ["Personnel_Records.BLL/Personnel_Records.BLL.csproj", "Personnel_Records.BLL/"]
COPY ["Personnel_Records.DAL/Personnel_Records.DAL.csproj", "Personnel_Records.DAL/"]
RUN dotnet restore "./Personnel_Records.Web/./Personnel_Records.Web.csproj"
COPY . .
WORKDIR "/src/Personnel_Records.Web"
RUN dotnet build "./Personnel_Records.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Personnel_Records.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Personnel_Records.Web.dll"]