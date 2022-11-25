FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Task6.Web/Task6.Web.csproj", "Task6.Web/"]
COPY ["Task6.Persistence/Task6.Persistence.csproj", "Task6.Persistence/"]
COPY ["Task6.Domain/Task6.Domain.csproj", "Task6.Domain/"]
COPY ["Task6.Application/Task6.Application.csproj", "Task6.Application/"]
RUN dotnet restore "Task6.Web/Task6.Web.csproj"
COPY . .
WORKDIR "/src/Task6.Web"
RUN dotnet build "Task6.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Task6.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "Task6.Web.dll"]
