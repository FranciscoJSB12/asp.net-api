# CRUD con ASP.NET Core

## Paquetes para usar base de datos sqlServer con c#

Click derecho en **Dependecies**, luego elegir **Manage NuGet Packages**.
En la sección de **Browse**, buscar los siguientes paquetes para instalarlos:

1. `Microsoft.EntityFrameworkCore.SqlServer`
2. `Microsoft.EntityFrameworkCore.Tools`
3. `Microsoft.EntityFrameworkCore.Design`

## Paquete y código para realizar join de tablas en SQLServer con .Include

### Paquete a instalar

```
Microsoft.AspNetCore.Mvc.NewtonsoftJson
```

### Código a agregar en `Program.cs`

```
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
```

## Paquetes para realizar autenticación con JWT

1. `Microsoft.Extensions.Identity.Core`
2. `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
3. `Microsoft.AspNetCore.Authentication.JwtBearer`

## Migraciones en C# con Visual Studio

1. Ir a **Tools**, luego **NuGet Package Manager**, finalmente **Package Manager Console**.
1. Ejecutar: `add-migration "nombre de la migracion"`
1. Correr: `update-database`

## Migraciones con la CLI en VSCODE

1. Primero hay que instalar la herramienta `dotnet tool install --global dotnet-ef --version 8.0.0 `
2. Ejecutar `dotnet ef migrations add init`
3. Por último `dotnet ef database update`

## Cadena de conexión para la base de datos de SQL Server

```
server=DESKTOP-BQ6T811\\SQLEXPRESS;Database=EmployeesDb;Trusted_connection=true;TrustServerCertificate=true
```

## Comandos CLI

### Version de Dotnet

```
dotnet --version
```

### Listar tipos de aplicaciones

```
dotnet new list
```

### Crear web api

```
dotnet new webapi -o nombre
```

### Correr proyecto de la api en modo watch

```
dotnet watch run
```

## Línea del tiempo de los nombres de C#

1. .NET Framework - 2002 > ASP.NET
2. .NET Core - 2016 > ASP.NET Core
3. .NET - 2020
4. Finalmente se quiere que se llame .NET
