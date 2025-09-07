# Imagem base para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos do projeto
COPY . .

# Restaura dependências
RUN dotnet restore

# Publica a aplicação (gera arquivos otimizados para produção)
RUN dotnet publish -c Release -o /app/publish

# Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia arquivos publicados do estágio anterior
COPY --from=build /app/publish .

# Expõe a porta padrão do ASP.NET Core
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "ProductClientHub.API.dll"]