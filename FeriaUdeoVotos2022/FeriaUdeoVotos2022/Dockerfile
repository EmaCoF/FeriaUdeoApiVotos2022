#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FeriaUdeoVotos2022/FeriaUdeoVotos2022.csproj", "FeriaUdeoVotos2022/"]
RUN dotnet restore "FeriaUdeoVotos2022/FeriaUdeoVotos2022.csproj"
COPY . .
WORKDIR "/src/FeriaUdeoVotos2022"
RUN dotnet build "FeriaUdeoVotos2022.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeriaUdeoVotos2022.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeriaUdeoVotos2022.dll"]