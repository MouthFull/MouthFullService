#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MouthFull.MVC/MouthFull.MVC.csproj", "MouthFull.MVC/"]
RUN dotnet restore "MouthFull.MVC/MouthFull.MVC.csproj"
COPY . .
WORKDIR "/src/MouthFull.MVC"
RUN dotnet build "MouthFull.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MouthFull.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MouthFull.MVC.dll"]