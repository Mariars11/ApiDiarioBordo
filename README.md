# Diario de Bordo

* O projeto tem como objetivo servir de controle para todas as missões realizadas no universo a fora.


## Criando projeto

```
dotnet new webapi --use-controllers -o DiarioDeBordo
```
## Models

> Missão.cs <br>
> Nave.cs <br>
> Planeta.cs <br>
> Tripulante.cs <br>

## Banco de dados - SqlLite - CodeFirst

* Criar as models
* Instalar os pacotes
* DICA: User a extensão Sql viewer

### EntityFrameworkCore
```
dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### SqlLite
```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.10
```
### Design
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Tools
```
dotnet tool install --global dotnet-ef
```

## Context

- Criar a connection string no appsetings.json
- Abrir o program.cs e adicionar o seguinte código

```
var sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(sqlConnection)
);
```

- Migração / Migration - Criar base de dados

```
dotnet ef migrations add MigracaoInicial

dotnet ef database update

```
- Popular dados iniciais

```
dotnet ef migrations add CargaPlanetas


        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"Insert into Planetas(Nome) Values ('Terra')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Mercúrio')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Vênus')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Júpiter')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Saturno')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Urano')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Netuno')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Plutão')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Sol')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Lua')");       
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql(@"Delete from Planetas");
        }

dotnet ef database update


```

## Filters

- CustomExceptionFilter.cs

    - Filtra as exceções

- ApiLoggingFilter.cs

    - Adiciona log no console

## JWT

```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.10
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

dotnet user-jwts create

dotnet user-jwts list
```