#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api-Key-Auth-Example/Api-Key-Auth-Example.csproj", "Api-Key-Auth-Example/"]
RUN dotnet restore "Api-Key-Auth-Example/Api-Key-Auth-Example.csproj"
COPY . .
WORKDIR "/src/Api-Key-Auth-Example"
RUN dotnet build "Api-Key-Auth-Example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api-Key-Auth-Example.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api-Key-Auth-Example.dll"]