FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAssemplyApp/WebAssemplyApp.csproj", "WebAssemplyApp/"]
RUN dotnet restore "WebAssemplyApp/WebAssemplyApp.csproj"
COPY . .
WORKDIR "/src/WebAssemplyApp"
RUN dotnet build "WebAssemplyApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAssemplyApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAssemplyApp.dll"]
