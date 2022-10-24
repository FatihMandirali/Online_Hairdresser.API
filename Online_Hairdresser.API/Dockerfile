#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Online_Hairdresser.API/Online_Hairdresser.API.csproj", "Online_Hairdresser.API/"]
COPY ["Online_Hairdresser.Core/Online_Hairdresser.Core.csproj", "Online_Hairdresser.Core/"]
COPY ["Online_Hairdresser.Models/Online_Hairdresser.Models.csproj", "Online_Hairdresser.Models/"]
COPY ["Online_Hairdresser.Data/Online_Hairdresser.Data.csproj", "Online_Hairdresser.Data/"]
RUN dotnet restore "Online_Hairdresser.API/Online_Hairdresser.API.csproj"
COPY . .
WORKDIR "/src/Online_Hairdresser.API"
RUN dotnet build "Online_Hairdresser.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Online_Hairdresser.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Online_Hairdresser.API.dll"]