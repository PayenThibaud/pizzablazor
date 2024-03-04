FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjetPizza.csproj","."]
RUN dotnet restore "ProjetPizza.csproj"
COPY . .

RUN dotnet build "ProjetPizza.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetPizza.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","ProjetPizza.dll"]


# construire l'image
# Ouvrir un terminal a la racine du projet (ou se trouve le dockerfile)
# docker build -t asp-chouchou .

# test de l'image
# docker run -d --name chouchou-asp -p 5005:8080 asp-chouchou
# http://localhost:5005/weatherforecast