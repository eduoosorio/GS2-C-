# SkillUp API

## 📋 Sobre o Projeto

A **SkillUp API** é uma API RESTful desenvolvida em ASP.NET Core Web API para gerenciar competências profissionais do futuro. O sistema permite que usuários adquiram habilidades, acompanhem seu desenvolvimento e explorem cursos relacionados.

### Objetivo

O projeto tem como objetivo criar uma plataforma completa para o gerenciamento de competências profissionais, permitindo:

- Cadastro e gerenciamento de usuários
- Cadastro e gerenciamento de habilidades (skills)
- Cadastro e gerenciamento de cursos
- Relacionamento entre usuários e habilidades (N:N)
- Acompanhamento do nível de proficiência em cada habilidade
- Ranking das habilidades mais cadastradas

---

## 🚀 Como Rodar o Projeto

### Pré-requisitos

- .NET 8.0 SDK ou superior
- SQL Server (LocalDB, Express ou Full) ou SQL Server LocalDB
- Visual Studio 2022, VS Code ou qualquer editor compatível

### Passos para Execução

1. **Clone o repositório**
   ```bash
   git clone <url-do-repositório>
   cd GS2-C#
   ```

2. **Navegue até a pasta do projeto**
   ```bash
   cd SkillUp.API
   ```

3. **Restore das dependências**
   ```bash
   dotnet restore
   ```

4. **Criar o banco de dados e aplicar migrations**
   ```bash
   dotnet ef database update
   ```
   
   Se ainda não tiver criado a migration:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Executar o projeto**
   ```bash
   dotnet run
   ```

6. **Acessar a API**
   - API Base: `https://localhost:5001` ou `http://localhost:5000`
   - Swagger UI: `https://localhost:5001/swagger` ou `http://localhost:5000/swagger`

### Configuração do Banco de Dados

A connection string está configurada no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SkillUpDB;Trusted_Connection=true;TrustServerCertificate=true"
  }
}
```

Para usar SQL Server Express ou Full, altere a connection string conforme necessário.

---

## 🎯 Funcionalidades

### Endpoints Disponíveis

#### Versão 1 (v1)

- **Users** (`/api/v1/users`)
  - `GET /api/v1/users` - Lista todos os usuários
  - `GET /api/v1/users/{id}` - Obtém um usuário por ID
  - `POST /api/v1/users` - Cria um novo usuário
  - `PUT /api/v1/users/{id}` - Atualiza um usuário
  - `DELETE /api/v1/users/{id}` - Deleta um usuário

- **Skills** (`/api/v1/skills`)
  - `GET /api/v1/skills` - Lista todas as habilidades
  - `GET /api/v1/skills/{id}` - Obtém uma habilidade por ID
  - `POST /api/v1/skills` - Cria uma nova habilidade
  - `PUT /api/v1/skills/{id}` - Atualiza uma habilidade
  - `DELETE /api/v1/skills/{id}` - Deleta uma habilidade

- **Courses** (`/api/v1/courses`)
  - `GET /api/v1/courses` - Lista todos os cursos
  - `GET /api/v1/courses/{id}` - Obtém um curso por ID
  - `POST /api/v1/courses` - Cria um novo curso
  - `PUT /api/v1/courses/{id}` - Atualiza um curso
  - `DELETE /api/v1/courses/{id}` - Deleta um curso

- **UserSkills** (`/api/v1/userskills`)
  - `GET /api/v1/userskills` - Lista todas as habilidades de usuários
  - `GET /api/v1/userskills/{id}` - Obtém uma habilidade de usuário por ID
  - `POST /api/v1/userskills` - Associa uma habilidade a um usuário
  - `PUT /api/v1/userskills/{id}` - Atualiza o nível de proficiência
  - `DELETE /api/v1/userskills/{id}` - Remove uma habilidade de um usuário

#### Versão 2 (v2)

- **Skills** (`/api/v2/skills`)
  - Todos os endpoints da v1, mais:
  - `GET /api/v2/skills/top?top=10` - Retorna ranking das habilidades mais cadastradas

---

## 🏗️ Arquitetura e Tecnologias

### Arquitetura

O projeto segue uma arquitetura em camadas:

```
SkillUp.API/
├── Controllers/        # Controladores da API (V1 e V2)
├── Services/           # Lógica de negócio
├── Repositories/       # Acesso a dados
├── Models/             # Entidades do domínio
├── DTOs/               # Data Transfer Objects
├── Mappings/           # Perfis do AutoMapper
└── Data/               # DbContext e configurações do EF Core
```

### Tecnologias Utilizadas

- **ASP.NET Core 8.0** - Framework web
- **Entity Framework Core 8.0** - ORM para acesso a dados
- **SQL Server** - Banco de dados relacional
- **AutoMapper** - Mapeamento entre entidades e DTOs
- **Swagger/OpenAPI** - Documentação da API
- **API Versioning** - Controle de versões da API

### Padrões e Boas Práticas

- **Repository Pattern** - Separação da lógica de acesso a dados
- **Service Layer** - Lógica de negócio isolada
- **DTO Pattern** - Transferência de dados otimizada
- **RESTful API** - Verbos HTTP corretos (GET, POST, PUT, DELETE)
- **Status Codes Adequados** - 200, 201, 400, 404, 500
- **Dependency Injection** - Injeção de dependências
- **Async/Await** - Operações assíncronas

---

## 📊 Fluxo da Aplicação

### Diagrama de Fluxo de Dados

```
┌─────────────┐
│   Cliente   │
│  (Postman/  │
│   Swagger)  │
└──────┬──────┘
       │
       │ HTTP Request
       ▼
┌─────────────────┐
│   Controller    │ ◄─── Versionamento (v1/v2)
│   (V1/V2)       │
└────────┬────────┘
         │
         │ Chama Service
         ▼
┌─────────────────┐
│    Service      │ ◄─── Lógica de Negócio
│   (Business)    │
└────────┬────────┘
         │
         │ Usa Repository
         ▼
┌─────────────────┐
│   Repository    │ ◄─── Acesso a Dados
└────────┬────────┘
         │
         │ Query/Command
         ▼
┌─────────────────┐
│  DbContext      │
│  (EF Core)      │
└────────┬────────┘
         │
         │ SQL
         ▼
┌─────────────────┐
│   SQL Server    │
│   Database      │
└─────────────────┘
```

### Fluxo de Dados Detalhado

1. **Request** → Cliente envia requisição HTTP para o Controller
2. **Controller** → Valida a requisição e delega para o Service
3. **Service** → Aplica regras de negócio e usa o Repository
4. **Repository** → Executa operações no banco via DbContext
5. **DbContext** → Converte operações em SQL e executa no SQL Server
6. **Response** → Dados retornam pela mesma cadeia, convertidos em DTOs

---

## 📝 Exemplos de Requests/Responses

### 1. Criar Usuário

**Request:**
```http
POST /api/v1/users
Content-Type: application/json

{
  "name": "João Silva",
  "email": "joao.silva@email.com"
}
```

**Response (201 Created):**
```json
{
  "id": 1,
  "name": "João Silva",
  "email": "joao.silva@email.com",
  "createdAt": "2024-01-15T10:30:00Z"
}
```

### 2. Criar Habilidade

**Request:**
```http
POST /api/v1/skills
Content-Type: application/json

{
  "name": "Inteligência Artificial",
  "description": "Conhecimento em IA e Machine Learning",
  "category": "Tecnologia"
}
```

**Response (201 Created):**
```json
{
  "id": 1,
  "name": "Inteligência Artificial",
  "description": "Conhecimento em IA e Machine Learning",
  "category": "Tecnologia",
  "createdAt": "2024-01-15T10:35:00Z"
}
```

### 3. Associar Habilidade a Usuário

**Request:**
```http
POST /api/v1/userskills
Content-Type: application/json

{
  "userId": 1,
  "skillId": 1,
  "proficiencyLevel": 4
}
```

**Response (201 Created):**
```json
{
  "id": 1,
  "userId": 1,
  "userName": "João Silva",
  "skillId": 1,
  "skillName": "Inteligência Artificial",
  "proficiencyLevel": 4,
  "acquiredAt": "2024-01-15T10:40:00Z"
}
```

### 4. Obter Ranking de Habilidades (v2)

**Request:**
```http
GET /api/v2/skills/top?top=5
```

**Response (200 OK):**
```json
[
  {
    "skillId": 1,
    "skillName": "Inteligência Artificial",
    "count": 15
  },
  {
    "skillId": 2,
    "skillName": "Cloud Computing",
    "count": 12
  },
  {
    "skillId": 3,
    "skillName": "Data Science",
    "count": 10
  },
  {
    "skillId": 4,
    "skillName": "Liderança Ágil",
    "count": 8
  },
  {
    "skillId": 5,
    "skillName": "Comunicação Digital",
    "count": 6
  }
]
```

### 5. Erro - Recurso Não Encontrado

**Request:**
```http
GET /api/v1/users/999
```

**Response (404 Not Found):**
```json
{
  "message": "Usuário com ID 999 não encontrado"
}
```

---

## 🔄 Versionamento da API

A API suporta versionamento através de rotas:

- **Versão 1**: `/api/v1/...`
- **Versão 2**: `/api/v2/...`

### Diferenças entre Versões

- **v1**: Funcionalidades básicas de CRUD para todas as entidades
- **v2**: Todas as funcionalidades da v1 + endpoint `/skills/top` para ranking

### Como Usar

Especifique a versão na URL:
- `GET /api/v1/skills` - Versão 1
- `GET /api/v2/skills` - Versão 2
- `GET /api/v2/skills/top` - Endpoint exclusivo da v2

O Swagger UI permite escolher a versão através do seletor no topo da página.

---

## 🗄️ Estrutura do Banco de Dados

### Entidades

- **User**: Usuários do sistema
  - Id, Name, Email, CreatedAt, UpdatedAt

- **Skill**: Habilidades/Competências
  - Id, Name, Description, Category, CreatedAt, UpdatedAt

- **Course**: Cursos disponíveis
  - Id, Title, Description, Duration, Instructor, Price, CreatedAt, UpdatedAt

- **UserSkill**: Relacionamento N:N entre User e Skill
  - Id, UserId, SkillId, ProficiencyLevel (1-5), AcquiredAt, UpdatedAt

### Relacionamentos

- User ↔ UserSkill (1:N)
- Skill ↔ UserSkill (1:N)
- UserSkill é a tabela de junção para o relacionamento N:N

---

## 📚 Documentação Adicional

### Swagger

A documentação interativa está disponível em:
- `/swagger` - Interface Swagger UI
- `/swagger/v1/swagger.json` - OpenAPI Spec v1
- `/swagger/v2/swagger.json` - OpenAPI Spec v2

### Status Codes Utilizados

- **200 OK**: Requisição bem-sucedida (GET, PUT, DELETE)
- **201 Created**: Recurso criado com sucesso (POST)
- **400 Bad Request**: Dados inválidos na requisição
- **404 Not Found**: Recurso não encontrado
- **500 Internal Server Error**: Erro interno do servidor

---

## 👥 Integrantes

- Eduardo Osorio Filho - RM 550161
- Fabio Hideki Kamikihara - RM 550610

---

## 🎥 Vídeo Demonstrativo

[Link do vídeo no YouTube ou plataforma equivalente - máximo 5 minutos]

---

## 📄 Licença

Este projeto foi desenvolvido para fins acadêmicos.

---

## 🔧 Comandos Úteis

### Entity Framework

```bash
# Criar migration
dotnet ef migrations add NomeDaMigration

# Aplicar migrations
dotnet ef database update

# Remover última migration
dotnet ef migrations remove

# Listar migrations
dotnet ef migrations list
```

### Build e Run

```bash
# Build
dotnet build

# Run
dotnet run

# Run com watch (desenvolvimento)
dotnet watch run
```

---

## 📞 Suporte

Para dúvidas ou problemas, entre em contato através do repositório GitHub.

---

**Desenvolvido com ❤️ para o futuro do trabalho**

