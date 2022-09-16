#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Taller.FullStack.Service/Taller.FullStack.Service.csproj", "Taller.FullStack.Service/"]
RUN dotnet restore "Taller.FullStack.Service/Taller.FullStack.Service.csproj"
COPY . .
WORKDIR "/src/Taller.FullStack.Service"
RUN dotnet build "Taller.FullStack.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Taller.FullStack.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taller.FullStack.Service.dll"]