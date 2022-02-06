FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Jogging-Tracker/Jogging-Tracker.csproj", "Jogging-Tracker/"]
RUN dotnet restore "Jogging-Tracker/Jogging-Tracker.csproj"
COPY . .
WORKDIR "/src/Jogging-Tracker"
RUN dotnet build "Jogging-Tracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jogging-Tracker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jogging-Tracker.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Jogging-Tracker.dll
