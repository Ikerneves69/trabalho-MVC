# trabalho-MVC

# ASP.NET Core MVC — Mini Guia

## Criar Projeto MVC

```bash
dotnet new mvc -n MeuProjeto
cd MeuProjeto
```

### O que este comando faz?
Cria automaticamente:

- `Controllers`
- `Views`
- `Models`
- configuração MVC completa

---

# Instalar Ferramentas de Scaffolding

## Instalar o code generator

```bash
dotnet tool install -g dotnet-aspnet-codegenerator-tool
```

## Adicionar package ao projeto

```bash
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

### O que o scaffolding gera?

- Controllers
- Views
- CRUD completo
- integração com Entity Framework

---

# Criar um Model

## Exemplo

### `Models/Product.cs`

```csharp
namespace MeuProjeto.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### O que é um Model?

O Model representa os dados da aplicação.

---

# Configurar Entity Framework

## Instalar packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

---

# Criar DbContext

## `Data/AppDbContext.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using MeuProjeto.Models;

namespace MeuProjeto.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
```

### O que é o DbContext?

O DbContext faz a ligação entre:

- a aplicação
- a base de dados

---

# Registrar o DbContext

## `Program.cs`

```csharp
using MeuProjeto.Data;
using Microsoft.EntityFrameworkCore;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
```

---

# Criar Base de Dados

## Instalar ferramenta EF

```bash
dotnet tool install --global dotnet-ef
```

## Criar migration

```bash
dotnet ef migrations add InitialCreate
```

## Atualizar base de dados

```bash
dotnet ef database update
```

---

# Gerar Controller + Views Automaticamente

```bash
dotnet aspnet-codegenerator controller \
-name ProductsController \
-m Product \
-dc AppDbContext \
--relativeFolderPath Controllers \
--useDefaultLayout \
--referenceScriptLibraries
```

---

# O que este comando cria?

## Controller

```text
Controllers/ProductsController.cs
```

Responsável pela lógica da aplicação.

---

## Views CRUD

```text
Views/Products/
```

Inclui:

- Create
- Edit
- Delete
- Details
- Index

---

# Executar Projeto

```bash
dotnet run
```

Abrir:

```text
http://localhost:5000
```

ou:

```text
https://localhost:5001
```

---

# Hot Reload

```bash
dotnet watch run
```

Atualiza automaticamente quando guardas ficheiros.

---

# Estrutura MVC

| Pasta | Função |
|---|---|
| Models | Dados da aplicação |
| Views | Interface visual |
| Controllers | Lógica da aplicação |
| Data | Base de dados |

---

# Fluxo MVC

```text
Utilizador → Controller → Model → View → Utilizador
```

---

# Criar Controller Vazio

```bash
dotnet aspnet-codegenerator controller \
-name HomeController \
--relativeFolderPath Controllers
```

---

# Criar API Controller

```bash
dotnet aspnet-codegenerator controller \
-name ApiController \
-api
```

---

# Criar View Manualmente

## Exemplo

### `Views/Home/Index.cshtml`

```html
<h1>Olá MVC</h1>
```

---

# Retornar uma View

## Exemplo Controller

```csharp
public IActionResult Index()
{
    return View();
}
```

O MVC procura automaticamente:

```text
Views/Home/Index.cshtml
```

---

# Conceitos MVC

| Conceito | Função |
|---|---|
| Model | Dados |
| View | Interface |
| Controller | Lógica |

---

# CRUD

| Operação | Significado |
|---|---|
| Create | Criar |
| Read | Ler |
| Update | Atualizar |
| Delete | Apagar |

---
