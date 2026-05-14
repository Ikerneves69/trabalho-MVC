# trabalho-MVC

ASP.NET Core MVC — Mini Guia
Criar Projeto MVC
dotnet new mvc -n MeuProjeto
cd MeuProjeto

Cria automaticamente:

Controllers
Views
Models
configuração MVC completa
Instalar Ferramentas de Scaffolding
Instalar code generator
dotnet tool install -g dotnet-aspnet-codegenerator-tool
Adicionar package ao projeto
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

O scaffolding gera:

Controllers
Views
CRUD completo
integração com Entity Framework
Criar um Model
Exemplo

Models/Product.cs

namespace MeuProjeto.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
O que é um Model?

O Model representa os dados da aplicação.

Configurar Entity Framework
Instalar packages
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
Criar DbContext

Data/AppDbContext.cs

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
O que é o DbContext?

O DbContext faz a ligação entre:

a aplicação
e a base de dados
Registrar o DbContext
Program.cs
using MeuProjeto.Data;
using Microsoft.EntityFrameworkCore;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
Criar Base de Dados
Instalar ferramenta EF
dotnet tool install --global dotnet-ef
Criar migration
dotnet ef migrations add InitialCreate
Atualizar base de dados
dotnet ef database update
Gerar Controller + Views Automaticamente
dotnet aspnet-codegenerator controller \
-name ProductsController \
-m Product \
-dc AppDbContext \
--relativeFolderPath Controllers \
--useDefaultLayout \
--referenceScriptLibraries
O que este comando cria?
Controller
Controllers/ProductsController.cs

Responsável pela lógica da aplicação.

Views CRUD
Views/Products/

Inclui:

Create
Edit
Delete
Details
Index
Executar Projeto
dotnet run

Abrir:

http://localhost:5000

ou:

https://localhost:5001
Hot Reload
dotnet watch run

Atualiza automaticamente quando guardas ficheiros.

Estrutura MVC
Pasta	Função
Models	Dados da aplicação
Views	Interface visual
Controllers	Lógica da aplicação
Data	Base de dados
Fluxo MVC
Utilizador → Controller → Model → View → Utilizador
Criar Controller Vazio
dotnet aspnet-codegenerator controller \
-name HomeController \
--relativeFolderPath Controllers
Criar API Controller
dotnet aspnet-codegenerator controller \
-name ApiController \
-api
Criar View Manualmente
Exemplo

Views/Home/Index.cshtml

<h1>Olá MVC</h1>
Retornar uma View
Exemplo Controller
public IActionResult Index()
{
    return View();
}

O MVC procura automaticamente:

Views/Home/Index.cshtml
