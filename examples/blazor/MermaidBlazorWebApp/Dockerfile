FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MermaidBlazorWebApp/MermaidBlazorWebApp.csproj", "MermaidBlazorWebApp/"]
RUN dotnet restore "MermaidBlazorWebApp/MermaidBlazorWebApp.csproj"
COPY . .
WORKDIR "/src/MermaidBlazorWebApp"
RUN dotnet build "MermaidBlazorWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MermaidBlazorWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MermaidBlazorWebApp.dll"]
