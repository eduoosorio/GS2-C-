# Instruções para Criar Migrations

## Passo a Passo

1. **Instalar ferramentas do Entity Framework (se ainda não tiver)**
   ```bash
   dotnet tool install --global dotnet-ef
   ```

2. **Navegar até a pasta do projeto**
   ```bash
   cd SkillUp.API
   ```

3. **Criar a migration inicial**
   ```bash
   dotnet ef migrations add InitialCreate
   ```

4. **Aplicar a migration ao banco de dados**
   ```bash
   dotnet ef database update
   ```

## Comandos Adicionais Úteis

- **Ver todas as migrations**: `dotnet ef migrations list`
- **Remover última migration**: `dotnet ef migrations remove`
- **Aplicar migrations pendentes**: `dotnet ef database update`
- **Reverter para uma migration específica**: `dotnet ef database update NomeDaMigration`

## Nota

Certifique-se de que o SQL Server LocalDB está instalado e rodando antes de executar `dotnet ef database update`.

