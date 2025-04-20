![Badge en Desarollo](https://img.shields.io/badge/STATUS-EN%20DESAROLLO-green)

# API RESTFUL - Gestión de Productos y Usuarios

Esta es una API RESTful desarrollada con **ASP.NET Core**, diseñada para gestionar productos, usuarios y sus respectivas categorías. Incluye funcionalidades de autenticación y autorización utilizando **JWT**, así como **encriptación y desencriptación de contraseñas** para mayor seguridad.

## Características

- CRUD de productos, usuarios y categorías
- Autenticación con **JSON Web Tokens (JWT)**
- Encriptación y desencriptación de contraseñas
- Integración con **Entity Framework Core**
- Base de datos **SQL Server**

## Tecnologías utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT (Json Web Tokens)
- Swagger para documentación 

## Instalación

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/Ginto11/API-REST-NET-CORE.git
   cd tu-repo
   ```
2. Configurar la cadena de conexión a SQL Server en `appsettings.json`:

    ```json
    "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=NombreDeTuBD;Trusted_Connection=True;"}
    ```
3. Agregar las configuraciones para usar **JWT** y **Metodos de Encriptación** y **Desencriptación**:

    ```json
    "Jwt": {
    "Key": "WnU1bM3S9RlPC6SbA9TnYVfH+F+QkILs8oN0dRpHfns=",
    "Issuer": "http://localhost:5133",
    "Audience": "http://localhost:5133"
    },
    "Encryting": {
    "IV": "A1b2C3d4E5f6G7h8",
    "Key": "X9f2L8q7M4v1A6t3Z0b5K2d8W7e3R9y6"
    }
    ```


4. Aplicar las migraciones:
    ```bash
    dotnet ef database update
    ```
5. Ejecutar la API:
    ```bash
    dotnet run
    ```
## Estructura del Proyecto

- `Controllers/`: Endpoints de la API

- `Models/`: Modelos de datos

- `DTOs/`: Objetos de transferencia de datos

- `Services/`: Lógica de negocio

- `Data/`: Acceso a datos

- `Authentication/`: Autenticación y encriptación

- `Interfaces/`: Interfaces a implementes (ICRUD)

- `Migrations/`: Actualizaciones de la base de datos.

## Próximas actualizaciones
- [ ] Añadir nuevos modelos relacionales (e.g. órdenes, historial de compras, stock).
- [ ] Desarrollar el Front-Ent con Angular.
- [ ] Manejo de errores.
- [ ] Subir a un Hosting.





