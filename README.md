# SiaInteractive CControl Challenge

Este proyecto es una solución para el desafío de CControl de SiaInteractive. La solución está estructurada en varios niveles (*tiers*) y utiliza tecnologías como ASP.NET Core, Entity Framework Core y Serilog para el registro de logs.

## Estructura del Proyecto

La solución está organizada en los siguientes directorios:

- **SiaInteractive.CControl.Challenge.Api**: Contiene la API principal del proyecto.
- **SiaInteractive.CControl.Challenge.Application**: Contiene la lógica de aplicación.
- **SiaInteractive.CControl.Challenge.Domain**: Contiene las entidades de dominio y las interfaces.
- **SiaInteractive.CControl.Challenge.Infrastructure**: Contiene la implementación de la infraestructura, como el acceso a datos.
- **SiaInteractive.CControl.Challenge.Tests**: Contiene las pruebas unitarias del proyecto.

## Configuración

### `appsettings.json`

El archivo `appsettings.json` contiene la configuración de la aplicación, incluyendo la configuración de JWT, cadenas de conexión, niveles de registro y configuración de Serilog.

```json
{
  "Jwt": {
    "Key": "YourVeryLongSecretKeyThatIsAtLeast32CharactersLong",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=CControlDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "Serilog": {
    "Using": ["Serilog.Sinks.Console"],
    "MinimumLevel": "Information",
    "WriteTo": [
      { "Name": "Console" }
    ]
  },
  "Swagger": {
    "Endpoint": "/swagger/v1/swagger.json",
    "Name": "SiaInteractive API"
  }
}
```

## Construcción y Ejecución

### Restaurar Paquetes NuGet

Asegúrate de que todos los paquetes NuGet necesarios estén restaurados.

```sh
dotnet restore
```

### Construir la Solución

Construye la solución para identificar cualquier error.

```sh
dotnet build SiaInteractive.CControl.Challenge.sln
```

### Crear la Base de Datos

Aplica las migraciones para crear la base de datos.

```sh
dotnet ef migrations add InitialCreate --project SiaInteractive.CControl.Challenge.Infrastructure

dotnet ef database update --project SiaInteractive.CControl.Challenge.Infrastructure
```

### Ejecutar la Aplicación

Inicia la API.

```sh
dotnet run --project SiaInteractive.CControl.Challenge.Api
```

### Ejecutar Pruebas

Ejecuta las pruebas unitarias para asegurarte de que todo funcione correctamente.

```sh
dotnet test
```

## Controladores

### `AuthController`
- `POST /api/auth/login`: Inicia sesión y genera un token JWT.
- `POST /api/auth/logout`: Cierra la sesión del usuario actual.

### `UsersController`
- `POST /api/users/register`: Registra un nuevo usuario.
- `GET /api/users/{email}`: Obtiene un usuario por email.
- `PATCH /api/users/reset-password`: Restablece la contraseña de un usuario.
- `DELETE /api/users/{email}`: Elimina un usuario por email.

### `WindowAppController`
- `POST /api/windowapp`: Crea una nueva aplicación de ventana.
- `GET /api/windowapp/{id}`: Obtiene una aplicación de ventana por ID.
- `GET /api/windowapp`: Obtiene todas las aplicaciones de ventana.
- `PUT /api/windowapp/{id}`: Actualiza una aplicación de ventana.
- `DELETE /api/windowapp/{id}`: Elimina una aplicación de ventana por ID.
- `GET /api/windowapp/name/{windowAppName}/instance/{windowAppInstance}`: Obtiene una aplicación de ventana por nombre e instancia.

## Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un *issue* o un *pull request* para discutir cualquier cambio que desees realizar.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo `LICENSE` para más detalles.




