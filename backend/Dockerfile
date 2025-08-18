FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

COPY . .

RUN dotnet publish -c Release -o out

FROM build
WORKDIR /App/out

EXPOSE 8080

ENTRYPOINT ["dotnet", "FinancePlanner.Commands.Wage.API.dll"]