# Documentación Técnica de la API

## Información General

**Nombre:** Bus Management API  
**Versión:** 1.0  
**Framework:** ASP.NET Core 9.0  
**Base URL:** `https://localhost:7XXX/api`  
**Formato de Datos:** JSON  
**Autenticación:** No requerida (versión actual)

## Arquitectura

### Patrón de Diseño
- **Arquitectura:** API RESTful
- **Patrón:** Repository Pattern con Entity Framework Core
- **ORM:** Entity Framework Core 9.0
- **Base de Datos:** SQL Server

### Estructura de Capas

```
Controllers (Capa de Presentación)
    ↓
DTOs (Objetos de Transferencia)
    ↓
Models (Entidades de Dominio)
    ↓
Data Context (Capa de Acceso a Datos)
    ↓
SQL Server Database
```

## Modelos de Datos

### Bus (Autobús)

```csharp
public class Bus
{
    public int Id { get; set; }
    public string BusNumber { get; set; }      // Máximo 50 caracteres
    public string Model { get; set; }          // Máximo 100 caracteres
    public int Capacity { get; set; }
    public int Year { get; set; }
    public string Status { get; set; }         // Máximo 20 caracteres
    public ICollection<Schedule> Schedules { get; set; }
}
```

**Validaciones:**
- BusNumber: Requerido, máximo 50 caracteres
- Model: Requerido, máximo 100 caracteres
- Capacity: Requerido, debe ser mayor a 0
- Year: Requerido, debe ser un año válido
- Status: Requerido, máximo 20 caracteres (ej: "Activo", "Inactivo", "Mantenimiento")

### Route (Ruta)

```csharp
public class BusRoute
{
    public int Id { get; set; }
    public string RouteName { get; set; }      // Máximo 100 caracteres
    public string Origin { get; set; }         // Máximo 100 caracteres
    public string Destination { get; set; }    // Máximo 100 caracteres
    public decimal Distance { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
}
```

**Validaciones:**
- RouteName: Requerido, máximo 100 caracteres
- Origin: Requerido, máximo 100 caracteres
- Destination: Requerido, máximo 100 caracteres
- Distance: Requerido, debe ser mayor a 0

### Schedule (Horario)

```csharp
public class Schedule
{
    public int Id { get; set; }
    public int BusId { get; set; }
    public Bus Bus { get; set; }
    public int RouteId { get; set; }
    public BusRoute Route { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
```

**Validaciones:**
- BusId: Requerido, debe existir en la tabla Buses
- RouteId: Requerido, debe existir en la tabla Routes
- DepartureTime: Requerido, debe ser una fecha/hora válida
- ArrivalTime: Requerido, debe ser posterior a DepartureTime

### Reservation (Reservación)

```csharp
public class Reservation
{
    public int Id { get; set; }
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
    public string PassengerName { get; set; }  // Máximo 100 caracteres
    public int SeatNumber { get; set; }
    public DateTime ReservationDate { get; set; }
}
```

**Validaciones:**
- ScheduleId: Requerido, debe existir en la tabla Schedules
- PassengerName: Requerido, máximo 100 caracteres
- SeatNumber: Requerido, debe ser mayor a 0, único por horario
- ReservationDate: Requerido, debe ser una fecha/hora válida

## Endpoints Detallados

### Buses

#### GET /api/Buses

**Descripción:** Recupera todos los autobuses registrados en el sistema.

**Método HTTP:** GET

**Parámetros:** Ninguno

**Headers:**
```
Content-Type: application/json
```

**Respuesta Exitosa (200):**
```json
[
  {
    "id": 1,
    "busNumber": "BUS-001",
    "model": "Mercedes-Benz Sprinter",
    "capacity": 45,
    "year": 2023,
    "status": "Activo",
    "schedules": null
  }
]
```

**Códigos de Estado:**
- 200: Éxito
- 500: Error interno del servidor

---

#### GET /api/Buses/{id}

**Descripción:** Recupera un autobús específico por su ID.

**Método HTTP:** GET

**Parámetros de Ruta:**
- `id` (integer, requerido): ID del autobús

**Respuesta Exitosa (200):**
```json
{
  "id": 1,
  "busNumber": "BUS-001",
  "model": "Mercedes-Benz Sprinter",
  "capacity": 45,
  "year": 2023,
  "status": "Activo",
  "schedules": null
}
```

**Respuesta de Error (404):**
```json
{
  "message": "Autobús no encontrado"
}
```

**Códigos de Estado:**
- 200: Éxito
- 404: No encontrado
- 500: Error interno del servidor

---

#### POST /api/Buses

**Descripción:** Crea un nuevo autobús en el sistema.

**Método HTTP:** POST

**Headers:**
```
Content-Type: application/json
```

**Cuerpo de la Solicitud:**
```json
{
  "busNumber": "BUS-002",
  "model": "Volvo 9700",
  "capacity": 50,
  "year": 2024,
  "status": "Activo"
}
```

**Respuesta Exitosa (201):**
```json
{
  "id": 2,
  "busNumber": "BUS-002",
  "model": "Volvo 9700",
  "capacity": 50,
  "year": 2024,
  "status": "Activo",
  "schedules": null
}
```

**Headers de Respuesta:**
```
Location: /api/Buses/2
```

**Códigos de Estado:**
- 201: Creado exitosamente
- 400: Solicitud inválida
- 500: Error interno del servidor

---

#### PUT /api/Buses/{id}

**Descripción:** Actualiza un autobús existente.

**Método HTTP:** PUT

**Parámetros de Ruta:**
- `id` (integer, requerido): ID del autobús a actualizar

**Cuerpo de la Solicitud:**
```json
{
  "busNumber": "BUS-002",
  "model": "Volvo 9700 DD",
  "capacity": 52,
  "year": 2024,
  "status": "Activo"
}
```

**Respuesta Exitosa (200):**
```json
{
  "message": "Autobús actualizado exitosamente",
  "bus": {
    "id": 2,
    "busNumber": "BUS-002",
    "model": "Volvo 9700 DD",
    "capacity": 52,
    "year": 2024,
    "status": "Activo",
    "schedules": null
  }
}
```

**Códigos de Estado:**
- 200: Actualizado exitosamente
- 404: No encontrado
- 500: Error interno del servidor

---

#### DELETE /api/Buses/{id}

**Descripción:** Elimina un autobús del sistema.

**Método HTTP:** DELETE

**Parámetros de Ruta:**
- `id` (integer, requerido): ID del autobús a eliminar

**Respuesta Exitosa (200):**
```json
{
  "message": "Autobús eliminado exitosamente"
}
```

**Códigos de Estado:**
- 200: Eliminado exitosamente
- 404: No encontrado
- 500: Error interno del servidor

---

### Routes

#### GET /api/Routes

**Descripción:** Recupera todas las rutas registradas.

**Método HTTP:** GET

**Respuesta Exitosa (200):**
```json
[
  {
    "id": 1,
    "routeName": "Ruta Norte",
    "origin": "Ciudad A",
    "destination": "Ciudad B",
    "distance": 150.5,
    "schedules": null
  }
]
```

---

#### GET /api/Routes/{id}

**Descripción:** Recupera una ruta específica por su ID.

**Método HTTP:** GET

**Parámetros de Ruta:**
- `id` (integer, requerido): ID de la ruta

**Respuesta Exitosa (200):**
```json
{
  "id": 1,
  "routeName": "Ruta Norte",
  "origin": "Ciudad A",
  "destination": "Ciudad B",
  "distance": 150.5,
  "schedules": null
}
```

---

#### POST /api/Routes

**Descripción:** Crea una nueva ruta.

**Método HTTP:** POST

**Cuerpo de la Solicitud:**
```json
{
  "routeName": "Ruta Sur",
  "origin": "Ciudad C",
  "destination": "Ciudad D",
  "distance": 200.0
}
```

**Respuesta Exitosa (201):**
```json
{
  "id": 2,
  "routeName": "Ruta Sur",
  "origin": "Ciudad C",
  "destination": "Ciudad D",
  "distance": 200.0,
  "schedules": null
}
```

---

#### PUT /api/Routes/{id}

**Descripción:** Actualiza una ruta existente.

**Método HTTP:** PUT

**Parámetros de Ruta:**
- `id` (integer, requerido): ID de la ruta

**Cuerpo de la Solicitud:**
```json
{
  "routeName": "Ruta Sur Express",
  "origin": "Ciudad C",
  "destination": "Ciudad D",
  "distance": 195.0
}
```

**Respuesta Exitosa (200):**
```json
{
  "message": "Ruta actualizada exitosamente",
  "route": {
    "id": 2,
    "routeName": "Ruta Sur Express",
    "origin": "Ciudad C",
    "destination": "Ciudad D",
    "distance": 195.0,
    "schedules": null
  }
}
```

---

#### DELETE /api/Routes/{id}

**Descripción:** Elimina una ruta del sistema.

**Método HTTP:** DELETE

**Parámetros de Ruta:**
- `id` (integer, requerido): ID de la ruta

**Respuesta Exitosa (200):**
```json
{
  "message": "Ruta eliminada exitosamente"
}
```

---

### Schedules

#### GET /api/Schedules

**Descripción:** Recupera todos los horarios con información relacionada de autobuses y rutas.

**Método HTTP:** GET

**Respuesta Exitosa (200):**
```json
[
  {
    "id": 1,
    "busId": 1,
    "busNumber": "BUS-001",
    "busModel": "Mercedes-Benz Sprinter",
    "routeId": 1,
    "routeName": "Ruta Norte",
    "origin": "Ciudad A",
    "destination": "Ciudad B",
    "departureTime": "2024-01-15T08:00:00",
    "arrivalTime": "2024-01-15T11:30:00"
  }
]
```

---

#### GET /api/Schedules/{id}

**Descripción:** Recupera un horario específico con información relacionada.

**Método HTTP:** GET

**Parámetros de Ruta:**
- `id` (integer, requerido): ID del horario

**Respuesta Exitosa (200):**
```json
{
  "id": 1,
  "busId": 1,
  "busNumber": "BUS-001",
  "busModel": "Mercedes-Benz Sprinter",
  "routeId": 1,
  "routeName": "Ruta Norte",
  "origin": "Ciudad A",
  "destination": "Ciudad B",
  "departureTime": "2024-01-15T08:00:00",
  "arrivalTime": "2024-01-15T11:30:00"
}
```

---

#### POST /api/Schedules

**Descripción:** Crea un nuevo horario.

**Método HTTP:** POST

**Cuerpo de la Solicitud:**
```json
{
  "busId": 1,
  "routeId": 1,
  "departureTime": "2024-01-15T14:00:00",
  "arrivalTime": "2024-01-15T17:30:00"
}
```

**Validaciones:**
- El autobús (busId) debe existir
- La ruta (routeId) debe existir
- arrivalTime debe ser posterior a departureTime

**Respuesta Exitosa (201):**
```json
{
  "id": 2,
  "busId": 1,
  "routeId": 1,
  "bus": null,
  "route": null,
  "departureTime": "2024-01-15T14:00:00",
  "arrivalTime": "2024-01-15T17:30:00",
  "reservations": null
}
```

**Respuesta de Error (400):**
```json
{
  "message": "El autobús especificado no existe"
}
```

---

#### PUT /api/Schedules/{id}

**Descripción:** Actualiza un horario existente.

**Método HTTP:** PUT

**Parámetros de Ruta:**
- `id` (integer, requerido): ID del horario

**Cuerpo de la Solicitud:**
```json
{
  "busId": 1,
  "routeId": 1,
  "departureTime": "2024-01-15T14:30:00",
  "arrivalTime": "2024-01-15T18:00:00"
}
```

**Respuesta Exitosa (200):**
```json
{
  "message": "Horario actualizado exitosamente",
  "schedule": {
    "id": 2,
    "busId": 1,
    "routeId": 1,
    "bus": null,
    "route": null,
    "departureTime": "2024-01-15T14:30:00",
    "arrivalTime": "2024-01-15T18:00:00",
    "reservations": null
  }
}
```

---

#### DELETE /api/Schedules/{id}

**Descripción:** Elimina un horario del sistema.

**Método HTTP:** DELETE

**Parámetros de Ruta:**
- `id` (integer, requerido): ID del horario

**Respuesta Exitosa (200):**
```json
{
  "message": "Horario eliminado exitosamente"
}
```

---

### Reservations

#### GET /api/Reservations

**Descripción:** Recupera todas las reservaciones con información completa del horario, autobús y ruta.

**Método HTTP:** GET

**Respuesta Exitosa (200):**
```json
[
  {
    "id": 1,
    "scheduleId": 1,
    "passengerName": "Juan Pérez",
    "seatNumber": 15,
    "reservationDate": "2024-01-10T10:30:00",
    "schedule": {
      "id": 1,
      "busNumber": "BUS-001",
      "routeName": "Ruta Norte",
      "origin": "Ciudad A",
      "destination": "Ciudad B",
      "departureTime": "2024-01-15T08:00:00",
      "arrivalTime": "2024-01-15T11:30:00"
    }
  }
]
```

---

#### GET /api/Reservations/{id}

**Descripción:** Recupera una reservación específica con información completa.

**Método HTTP:** GET

**Parámetros de Ruta:**
- `id` (integer, requerido): ID de la reservación

**Respuesta Exitosa (200):**
```json
{
  "id": 1,
  "scheduleId": 1,
  "passengerName": "Juan Pérez",
  "seatNumber": 15,
  "reservationDate": "2024-01-10T10:30:00",
  "schedule": {
    "id": 1,
    "busNumber": "BUS-001",
    "routeName": "Ruta Norte",
    "origin": "Ciudad A",
    "destination": "Ciudad B",
    "departureTime": "2024-01-15T08:00:00",
    "arrivalTime": "2024-01-15T11:30:00"
  }
}
```

---

#### POST /api/Reservations

**Descripción:** Crea una nueva reservación.

**Método HTTP:** POST

**Cuerpo de la Solicitud:**
```json
{
  "scheduleId": 1,
  "passengerName": "María García",
  "seatNumber": 20,
  "reservationDate": "2024-01-10T11:00:00"
}
```

**Validaciones:**
- El horario (scheduleId) debe existir
- El asiento (seatNumber) no debe estar ocupado para ese horario
- passengerName no debe estar vacío

**Respuesta Exitosa (201):**
```json
{
  "id": 2,
  "scheduleId": 1,
  "schedule": null,
  "passengerName": "María García",
  "seatNumber": 20,
  "reservationDate": "2024-01-10T11:00:00"
}
```

**Respuesta de Error (400):**
```json
{
  "message": "El asiento ya está reservado para este horario"
}
```

---

#### DELETE /api/Reservations/{id}

**Descripción:** Elimina una reservación del sistema.

**Método HTTP:** DELETE

**Parámetros de Ruta:**
- `id` (integer, requerido): ID de la reservación

**Respuesta Exitosa (200):**
```json
{
  "message": "Reserva eliminada exitosamente"
}
```

---

## Configuración CORS

La API está configurada para aceptar solicitudes desde:
- `http://localhost:3000` (aplicación React en desarrollo)

Para agregar más orígenes, modifique la política CORS en `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://tu-dominio.com")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
```

## Manejo de Errores

### Estructura de Respuestas de Error

Todas las respuestas de error siguen este formato:

```json
{
  "message": "Descripción del error",
  "error": "Detalles técnicos (solo en desarrollo)"
}
```

### Códigos de Estado HTTP

| Código | Significado | Uso |
|--------|-------------|-----|
| 200 | OK | Solicitud exitosa |
| 201 | Created | Recurso creado exitosamente |
| 400 | Bad Request | Datos inválidos o validación fallida |
| 404 | Not Found | Recurso no encontrado |
| 500 | Internal Server Error | Error del servidor |

## Swagger/OpenAPI

La API incluye documentación interactiva con Swagger UI.

**URL de Swagger:** `https://localhost:7XXX/swagger`

Swagger proporciona:
- Documentación interactiva de todos los endpoints
- Posibilidad de probar los endpoints directamente desde el navegador
- Esquemas de datos detallados
- Ejemplos de solicitudes y respuestas

## Base de Datos

### Cadena de Conexión

La cadena de conexión se configura en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SERVIDOR;Database=BusManagementDB;Integrated Security=true;TrustServerCertificate=true;Encrypt=true;MultipleActiveResultSets=true"
  }
}
```

### Migraciones

Para crear una nueva migración:

```bash
dotnet ef migrations add NombreDeLaMigracion
```

Para aplicar migraciones:

```bash
dotnet ef database update
```

Para revertir la última migración:

```bash
dotnet ef database update MigracionAnterior
```

### Esquema de Base de Datos

```
Buses
├── Id (PK)
├── BusNumber
├── Model
├── Capacity
├── Year
└── Status

Routes
├── Id (PK)
├── RouteName
├── Origin
├── Destination
└── Distance

Schedules
├── Id (PK)
├── BusId (FK → Buses.Id)
├── RouteId (FK → Routes.Id)
├── DepartureTime
└── ArrivalTime

Reservations
├── Id (PK)
├── ScheduleId (FK → Schedules.Id)
├── PassengerName
├── SeatNumber
└── ReservationDate
```

## Ejemplos de Uso con cURL

### Obtener todos los autobuses

```bash
curl -X GET "https://localhost:7XXX/api/Buses" -H "accept: application/json"
```

### Crear un nuevo autobús

```bash
curl -X POST "https://localhost:7XXX/api/Buses" \
  -H "Content-Type: application/json" \
  -d '{
    "busNumber": "BUS-003",
    "model": "Scania K410",
    "capacity": 48,
    "year": 2024,
    "status": "Activo"
  }'
```

### Actualizar un autobús

```bash
curl -X PUT "https://localhost:7XXX/api/Buses/1" \
  -H "Content-Type: application/json" \
  -d '{
    "busNumber": "BUS-001",
    "model": "Mercedes-Benz Sprinter 2024",
    "capacity": 45,
    "year": 2024,
    "status": "Activo"
  }'
```

### Eliminar un autobús

```bash
curl -X DELETE "https://localhost:7XXX/api/Buses/1" -H "accept: application/json"
```

## Consideraciones de Seguridad

### Recomendaciones para Producción

1. **Implementar Autenticación y Autorización**
   - JWT (JSON Web Tokens)
   - OAuth 2.0
   - Identity Server

2. **Validación de Datos**
   - Validar todos los inputs del usuario
   - Usar Data Annotations
   - Implementar FluentValidation

3. **Rate Limiting**
   - Limitar el número de solicitudes por IP
   - Implementar throttling

4. **HTTPS**
   - Forzar el uso de HTTPS en producción
   - Configurar certificados SSL válidos

5. **Logging y Monitoreo**
   - Implementar logging estructurado (Serilog)
   - Monitorear errores y excepciones
   - Usar Application Insights o similar

6. **Protección de Datos Sensibles**
   - No exponer cadenas de conexión
   - Usar Azure Key Vault o similar
   - Encriptar datos sensibles

## Versionado de la API

Para futuras versiones, considere implementar versionado:

```csharp
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BusesController : ControllerBase
{
    // ...
}
```

## Soporte y Contacto

Para reportar problemas o solicitar nuevas características, por favor abra un issue en el repositorio del proyecto.
