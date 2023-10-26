# CAPS

## Entity Framework Core
```bash
# instalar la herramienta dotnet-ef
dotnet tool install -g dotnet-ef

# actualizar herramientas
dotnet tool update -g dotnet-ef

# crear la migration inicial (req. compilar)
dotnet ef migrations add InitialCreate

# construir la base de datos (req. compilar)
dotnet ef database update

# para revertir la migración, elimina la base y
dotnet ef migrations remove
```

## Controllers
```bash
# crear un controlador

# instalar herramienta para generar código aspnet
dotnet tool install -g dotnet-aspnet-codegenerator

# instalar generadores de código
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 7.0.11
```
