# 🚀 ProductClientHub

## 🗂️ Visão Geral

O **ProductClientHub** é uma aplicação ASP.NET Core estruturada em múltiplas camadas, com foco em organização, escalabilidade e boas práticas. O projeto está dividido em três principais módulos:

- 📦 **ProductClientHub.API**: Camada de apresentação (Web API)
- 🔗 **ProductClientHub.Communication**: Camada de comunicação (DTOs, contratos)
- ⚠️ **ProductClientHub.Exceptions**: Camada de tratamento de exceções

---

## 🏗️ Estrutura dos Projetos

### 1. ProductClientHub.API

- 🧭 **Controllers**: Pontos de entrada da API, como o `Health` para verificação de status.
- 🛡️ **Filters**: Filtros globais, como o `ExceptionFilter`, para tratamento centralizado de erros.
- 🏗️ **Infrastructure**: Configuração de serviços, banco de dados e dependências.
- 🧩 **UseCases**: Implementação dos casos de uso (ex: RegisterClientUseCase, DeleteProductUseCase).
- 🗃️ **Entidades**: Modelos que representam os dados do domínio.
- 🗄️ **Migrations**: Gerenciamento da evolução do banco de dados via Entity Framework Core.

### 2. ProductClientHub.Communication

- 📤 **DTOs**: Objetos de transferência de dados entre as camadas da aplicação.
- 📑 **Contratos**: Interfaces e contratos para comunicação entre módulos.

### 3. ProductClientHub.Exceptions

- ⚠️ **Exceções customizadas**: Classes para tratamento de erros específicos do domínio.

---

## 🐳 Dockerização

A aplicação pode ser facilmente executada em containers Docker. O arquivo `Dockerfile` já está configurado para:

- 🏗️ Build e publish da aplicação em ambiente de produção.
- 🐳 Uso das imagens oficiais do .NET 8.
- 🌐 Exposição da porta 80 para acesso HTTP.

**Comandos principais:**

```bash
# Build da imagem
docker build -t product-client-hub .

# Rodar o container
docker run -p 80:80 product-client-hub
```

---

## 🛢️ Conexão com Banco de Dados

- Utiliza **PostgreSQL** via Entity Framework Core.
- A string de conexão é configurada no arquivo de configuração da aplicação (`appsettings.json`).
- As migrações são gerenciadas pelo EF Core, permitindo evolução do schema do banco.

**Exemplo de comando para aplicar migrações:**

```bash
dotnet ef database update --project ProductClientHub.API
```

---

## 🛡️ Filters

- O projeto utiliza filtros globais, como o `ExceptionFilter`, para capturar e tratar exceções de forma centralizada, retornando respostas padronizadas para erros.

---

## 🧩 UseCases

- Cada operação de negócio está encapsulada em um UseCase, facilitando testes, manutenção e separação de responsabilidades.
- Exemplos: `RegisterClientUseCase`, `DeleteClientUseCase`, `GetAllClientsUseCase`, `RegisterProductUseCase`.

---

## 🗄️ Migrações

- As migrações do banco de dados são geradas e aplicadas via Entity Framework Core.
- Permitem versionar e atualizar o schema do banco conforme o projeto evolui.

---

## 🗃️ Entidades

- As entidades representam os objetos principais do domínio, como `Client` e `Product`.
- São mapeadas para tabelas do banco de dados via EF Core.

---

## 📦 Pacotes Instalados

Principais pacotes NuGet utilizados no projeto:

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Design`
- `Microsoft.EntityFrameworkCore.Tools`
- `Npgsql.EntityFrameworkCore.PostgreSQL`
- `Swashbuckle.AspNetCore` (Swagger)
- `Microsoft.AspNetCore.Mvc`
- `Microsoft.AspNetCore.Authentication`

---

## 🩺 Como testar a saúde da aplicação

Acesse o endpoint de health check:

```
GET /health
```

Resposta esperada:

```json
{ "status": "Healthy" }
```

---

## 🧰 Requisitos

- .NET 8 SDK
- Docker
- PostgreSQL
- Pacotes NuGet listados acima

---

## 📁 Sugestão de Estrutura de Pastas

```
ProductClientHub/
├── ProductClientHub.API/
│   ├── Controllers/
│   ├── Filters/
│   ├── Infrastructure/
│   ├── UseCases/
│   ├── Entities/
│   ├── Migrations/
│   └── Program.cs
├── ProductClientHub.Communication/
│   └── ...
├── ProductClientHub.Exceptions/
│   └── ...
├── Dockerfile
├── ProductClientHub.sln
```

---

## 💡 Observações

- Para rodar localmente, configure o banco de dados PostgreSQL e ajuste a string de conexão.
- Para produção, utilize variáveis de ambiente para configuração segura.
- Consulte os arquivos de cada projeto para detalhes sobre entidades, DTOs e exceções.

---

**❓ Dúvidas ou sugestões? Abra