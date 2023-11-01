FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ./ ./

RUN dotnet restore ./Indolent.Retail.WebAPI.csproj
RUN dotnet publish ./Indolent.Retail.WebAPI.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Indolent.Retail.WebAPI.dll"]