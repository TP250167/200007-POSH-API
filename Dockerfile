FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers


COPY ["EL.API/EL.API.csproj", "EL.API/"]

COPY ["EL.Service/EL.Service.csproj", "EL.Service/"]

COPY ["EL.ViewModel/EL.ViewModel.csproj", "EL.ViewModel/"]

COPY ["EL.Domain/EL.Domain.csproj", "EL.Domain/"]

COPY ["EL.Service/EL.Service.csproj", "EL.Servic/"]

COPY ["EL.ViewModel/EL.ViewModel.csproj", "EL.ViewModel/"]

COPY ["EL.Repository/EL.Repository.csproj", "EL.Repository/"]

RUN dotnet restore "EL.API/EL.API.csproj"

# Copy everything else and build
COPY . .

WORKDIR "/app/EL.API"

RUN dotnet build "EL.API.csproj" -c Release -o /out

#FROM build AS publish
RUN dotnet publish "EL.API.csproj" -c Release -o /out 

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app

COPY --from=build-env /out .

ENTRYPOINT ["dotnet", "EL.API.dll"]



