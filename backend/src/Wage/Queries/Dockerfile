FROM be-base-image

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=be-base-image /app/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "FinancePlanner.Wage.Queries.API.dll"]