
EJERCICIO N.2 

- CRUD para la entidad Cliente (Nombre, CorreoElectronico, Telefono).
-Entity Framework Core 8 con SQL Server LocalDB por defecto (fácil de cambiar a otro proveedor).
-Middleware que exige un encabezado X-API-KEY en todas las peticiones.
-Swagger UI para probar los endpoints.
-Código limpio en una arquitectura básica: Controllers + Middleware + Data Access.


Variables principales:

Clave: ApiKey
Descripción: Valor que debe llegar en el header X-API-KEY.
Ejemplo: RFF2323


Clave: ConnectionStrings:Default
Descripción: adena de conexión para EF Core.
Ejemplo: Server=(localdb)\\mssqllocaldb;Database=ClienteApiDb;Trusted_Connection=True;