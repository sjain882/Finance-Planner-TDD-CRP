FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /App

COPY . .

RUN dotnet publish -c Release -o out --no-restore
EXPOSE 8080

ENTRYPOINT ["dotnet", "FinancePlanner.Queries.Wage.API.dll"]