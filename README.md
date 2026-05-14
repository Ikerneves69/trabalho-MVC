# trabalho-MVC

Mini tutorial ASP.NET MVC pelo terminal
1. Instalar o scaffolding

Isto instala a ferramenta que gera controllers e views automaticamente.

dotnet tool install -g dotnet-aspnet-codegenerator-tool

Adicionar o package ao projeto:

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
2. Criar um projeto MVC
dotnet new mvc -n MeuProjeto
cd MeuProjeto

Isto cria:

pasta Controllers
pasta Views
pasta Models
configuração MVC completa
3. Criar um Model

Cria um ficheiro:

Models/Product.cs

Exemplo:

namespace MeuProjeto.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

O Model representa dados da aplicação.

4. Criar DbContext (Entity Framework)

Instalar EF Core:

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

Criar:

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
5. Registrar no Program.cs

Adicionar:

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

e no topo:

using MeuProjeto.Data;
using Microsoft.EntityFrameworkCore;
6. Criar migrations

Instalar ferramenta:

dotnet tool install --global dotnet-ef

Criar DB:

dotnet ef migrations add InitialCreate
dotnet ef database update
7. Gerar Controller + Views automaticamente
dotnet aspnet-codegenerator controller -name ProductsController -m Product -dc AppDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

Isto cria automaticamente:

Controller
Controllers/ProductsController.cs
Views CRUD
Views/Products/

com:

Create
Edit
Delete
Details
Index
8. Executar projeto
dotnet run

Abrir:

http://localhost:5000

ou:

https://localhost:5001
O que cada coisa faz
Pasta	Função
Models	Estrutura dos dados
Views	Interface HTML
Controllers	Lógica da aplicação
Data	Ligação à base de dados
Fluxo MVC

Utilizador → Controller → Model → View → Utilizador

MVC significa:

Model = dados
View = interface
Controller = lógica
Criar controller vazio
dotnet aspnet-codegenerator controller -name HomeController --relativeFolderPath Controllers
Criar API controller
dotnet aspnet-codegenerator controller -name ApiController -api
Criar View manualmente
Views/Home/Index.cshtml

Exemplo:

<h1>Olá MVC</h1>
Retornar uma view no controller
public IActionResult Index()
{
    return View();
}

O MVC procura automaticamente:

Views/Home/Index.cshtml
Hot Reload
dotnet watch run

Atualiza automaticamente ao guardar ficheiros.
