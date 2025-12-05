# Sistema de Gestión de Autobuses

Sistema completo de gestión de autobuses desarrollado con ASP.NET Core Web API y React. Permite administrar autobuses, rutas, horarios y reservaciones de manera eficiente.

## Tabla de Contenidos

- [Características](#características)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Requisitos Previos](#requisitos-previos)
- [Instalación y Configuración](#instalación-y-configuración)
- [Ejecución del Proyecto](#ejecución-del-proyecto)
- [Documentación de la API](#documentación-de-la-api)
- [Estructura del Proyecto](#estructura-del-proyecto)

## Características

- Gestión completa de autobuses (CRUD)
- Administración de rutas de transporte
- Programación de horarios
- Sistema de reservaciones con validación de asientos
- Interfaz de usuario intuitiva con React
- API RESTful con ASP.NET Core
- Base de datos SQL Server con Entity Framework Core

## Tecnologías Utilizadas

### Backend
- ASP.NET Core 9.0
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI

### Frontend
- React 18.2.0
- React Router DOM 6.20.1
- Axios 1.6.2
- Bootstrap 5.3.2

## Requisitos Previos

Antes de comenzar, asegúrese de tener instalado:

- [.NET SDK 9.0](https://dotnet.microsoft.com/download) o superior
- [Node.js](https://nodejs.org/) (versión 16 o superior)
- [SQL Server](https://www.microsoft.com/sql-server) (Express, Developer o cualquier edición)
- [Git](https://git-scm.com/)
- Editor de código (Visual Studio, Visual Studio Code, etc.)

## Instalación y Configuración

### 1. Clonar el Repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
cd proyecto-final-autobus
```

### 2. Configuración del Backend

#### 2.1. Configurar la Cadena de Conexión

Edite el archivo `BusManagementAPI/BusManagementAPI/appsettings.json` y actualice la cadena de conexión según su configuración de SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=NOMBRE_SERVIDOR;Database=BusManagementDB;Integrated Security=true;TrustServerCertificate=true;Encrypt=true;MultipleActiveResultSets=true"
  }
}
```

Reemplace `NOMBRE_SERVIDOR` con el nombre de su instancia de SQL Server. Ejemplos comunes:
- `localhost` o `.` para instancia local predeterminada
- `localhost\SQLEXPRESS` para SQL Server Express
- `NOMBRE_EQUIPO\INSTANCIA` para instancias con nombre

#### 2.2. Restaurar Paquetes NuGet

```bash
cd BusManagementAPI/BusManagementAPI
dotnet restore
```

#### 2.3. Aplicar Migraciones de Base de Datos

```bash
dotnet ef database update
```

Si el comando anterior no funciona, instale la herramienta EF Core CLI:

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

### 3. Configuración del Frontend

#### 3.1. Instalar Dependencias

```bash
cd bus-management-frontend
npm install
```

#### 3.2. Configurar URL de la API

Verifique que el archivo `src/services/api.js` tenga la URL correcta del backend:

```javascript
const API_URL = 'https://localhost:7XXX/api';
```

El puerto puede variar. Verifique el archivo `BusManagementAPI/BusManagementAPI/Properties/launchSettings.json` para conocer el puerto HTTPS configurado.

## Ejecución del Proyecto

### Opción 1: Ejecución Manual

#### 1. Iniciar el Backend

```bash
cd BusManagementAPI/BusManagementAPI
dotnet run
```

La API estará disponible en:
- HTTPS: `https://localhost:7XXX`
- HTTP: `http://localhost:5XXX`
- Swagger UI: `https://localhost:7XXX/swagger`

#### 2. Iniciar el Frontend

En una nueva terminal:

```bash
cd bus-management-frontend
npm start
```

La aplicación React se abrirá automáticamente en `http://localhost:3000`

### Opción 2: Ejecución desde Visual Studio

1. Abra la solución `BusManagementAPI/BusManagementAPI.sln` en Visual Studio
2. Presione F5 o haga clic en "Iniciar" para ejecutar el backend
3. En una terminal separada, ejecute el frontend con `npm start`

## Documentación de la API

La API REST proporciona endpoints para gestionar todos los aspectos del sistema de autobuses.

### URL Base

```
https://localhost:7XXX/api
```

### Autenticación

Actualmente, la API no requiere autenticación. Todos los endpoints son de acceso público.

### Endpoints Disponibles

#### Autobuses (Buses)

##### GET /api/Buses
Obtiene la lista de todos los autobuses.

**Respuesta Exitosa (200 OK):**
```json
[
  {
    "id": 1,
    "busNumber": "BUS-001",
    "model": "Mercedes-Benz Sprinter",
    "capacity": 45,
    "year": 2023,
    "status": "Activo"
  }
]
```

##### GET /api/Buses/{id}
Obtiene un autobús específico por ID.

**Parámetros:**
- `id` (int): ID del autobús

**Respuesta Exitosa (200 OK):**
```json
{
  "id": 1,
  "busNumber": "BUS-001",
  "model": "Mercedes-Benz Sprinter",
  "capacity": 45,
  "year": 2023,
  "status": "Activo"
}
```

**Respuesta de Error (404 Not Found):**
```json
{
  "message": "Autobús no encontrado"
}
```

##### POST /api/Buses
Crea un nuevo autobús.

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

**Respuesta Exitosa (201 Created):**
```json
{
  "id": 2,
  "busNumber": "BUS-002",
  "model": "Volvo 9700",
  "capacity": 50,
  "year": 2024,
  "status": "Activo"
}
```

##### PUT /api/Buses/{id}
Actualiza un autobús existente.

**Parámetros:**
- `id` (int): ID del autobús a actualizar

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

**Respuesta Exitosa (200 OK):**
```json
{
  "message": "Autobús actualizado exitosamente",
  "bus": {
    "id": 2,
    "busNumber": "BUS-002",
    "model": "Volvo 9700 DD",
    "capacity": 52,
    "year": 2024,
    "status": "Activo"
  }
}
```

##### DELETE /api/Buses/{id}
Elimina un autobús.

**Parámetros:**
- `id` (int): ID del autobús a eliminar

**Respuesta Exitosa (200 OK):**
```json
{
  "message": "Autobús eliminado exitosamente"
}
```

#### Rutas (Routes)

##### GET /api/Routes
Obtiene la lista de todas las rutas.

**Respuesta Exitosa (200 OK):**
```json
[
  {
    "id": 1,
    "routeName": "Ruta Norte",
    "origin": "Ciudad A",
    "destination": "Ciudad B",
    "distance": 150.5
  }
]
```

##### GET /api/Routes/{id}
Obtiene una ruta específica por ID.

**Parámetros:**
- `id` (int): ID de la ruta

**Respuesta Exitosa (200 OK):**
```json
{
  "id": 1,
  "routeName": "Ruta Norte",
  "origin": "Ciudad A",
  "destination": "Ciudad B",
  "distance": 150.5
}
```

##### POST /api/Routes
Crea una nueva ruta.

**Cuerpo de la Solicitud:**
```json
{
  "routeName": "Ruta Sur",
  "origin": "Ciudad C",
  "destination": "Ciudad D",
  "distance": 200.0
}
```

**Respuesta Exitosa (201 Created):**
```json
{
  "id": 2,
  "routeName": "Ruta Sur",
  "origin": "Ciudad C",
  "destination": "Ciudad D",
  "distance": 200.0
}
```

##### PUT /api/Routes/{id}
Actualiza una ruta existente.

**Parámetros:**
- `id` (int): ID de la ruta a actualizar

**Cuerpo de la Solicitud:**
```json
{
  "routeName": "Ruta Sur Express",
  "origin": "Ciudad C",
  "destination": "Ciudad D",
  "distance": 195.0
}
```

**Respuesta Exitosa (200 OK):**
```json
{
  "message": "Ruta actualizada exitosamente",
  "route": {
    "id": 2,
    "routeName": "Ruta Sur Express",
    "origin": "Ciudad C",
    "destination": "Ciudad D",
    "distance": 195.0
  }
}
```

##### DELETE /api/Routes/{id}
Elimina una ruta.

**Parámetros:**
- `id` (int): ID de la ruta a eliminar

**Respuesta Exitosa (200 OK):**
```json
{
  "message": "Ruta eliminada exitosamente"
}
```

#### Horarios (Schedules)

##### GET /api/Schedules
Obtiene la lista de todos los horarios con información relacionada.

**Respuesta Exitosa (200 OK):**
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

##### GET /api/Schedules/{id}
Obtiene un horario específico por ID.

**Parámetros:**
- `id` (int): ID del horario

**Respuesta Exitosa (200 OK):**
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

##### POST /api/Schedules
Crea un nuevo horario.

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
- El autobús debe existir
- La ruta debe existir

**Respuesta Exitosa (201 Created):**
```json
{
  "id": 2,
  "busId": 1,
  "routeId": 1,
  "departureTime": "2024-01-15T14:00:00",
  "arrivalTime": "2024-01-15T17:30:00"
}
```

**Respuesta de Error (400 Bad Request):**
```json
{
  "message": "El autobús especificado no existe"
}
```

##### PUT /api/Schedules/{id}
Actualiza un horario existente.

**Parámetros:**
- `id` (int): ID del horario a actualizar

**Cuerpo de la Solicitud:**
```json
{
  "busId": 1,
  "routeId": 1,
  "departureTime": "2024-01-15T14:30:00",
  "arrivalTime": "2024-01-15T18:00:00"
}
```

**Respuesta Exitosa (200 OK):**
```json
{
  "message": "Horario actualizado exitosamente",
  "schedule": {
    "id": 2,
    "busId": 1,
    "routeId": 1,
    "departureTime": "2024-01-15T14:30:00",
    "arrivalTime": "2024-01-15T18:00:00"
  }
}
```

##### DELETE /api/Schedules/{id}
Elimina un horario.

**Parámetros:**
- `id` (int): ID del horario a eliminar

**Respuesta Exitosa (200 OK):**
```json
{
  "message": "Horario eliminado exitosamente"
}
```

#### Reservaciones (Reservations)

##### GET /api/Reservations
Obtiene la lista de todas las reservaciones con información completa.

**Respuesta Exitosa (200 OK):**
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

##### GET /api/Reservations/{id}
Obtiene una reservación específica por ID.

**Parámetros:**
- `id` (int): ID de la reservación

**Respuesta Exitosa (200 OK):**
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

##### POST /api/Reservations
Crea una nueva reservación.

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
- El horario debe existir
- El asiento no debe estar ocupado para ese horario

**Respuesta Exitosa (201 Created):**
```json
{
  "id": 2,
  "scheduleId": 1,
  "passengerName": "María García",
  "seatNumber": 20,
  "reservationDate": "2024-01-10T11:00:00"
}
```

**Respuesta de Error (400 Bad Request):**
```json
{
  "message": "El asiento ya está reservado para este horario"
}
```

##### DELETE /api/Reservations/{id}
Elimina una reservación.

**Parámetros:**
- `id` (int): ID de la reservación a eliminar

**Respuesta Exitosa (200 OK):**
```json
{
  "message": "Reserva eliminada exitosamente"
}
```

### Códigos de Estado HTTP

La API utiliza los siguientes códigos de estado HTTP:

- `200 OK`: Solicitud exitosa
- `201 Created`: Recurso creado exitosamente
- `400 Bad Request`: Solicitud inválida o datos incorrectos
- `404 Not Found`: Recurso no encontrado
- `500 Internal Server Error`: Error del servidor

### Formato de Respuestas de Error

Todas las respuestas de error siguen el siguiente formato:

```json
{
  "message": "Descripción del error",
  "error": "Detalles técnicos del error (solo en desarrollo)"
}
```

## Estructura del Proyecto

```
proyecto-final-autobus/
├── BusManagementAPI/
│   └── BusManagementAPI/
│       ├── Controllers/          # Controladores de la API
│       │   ├── BusesController.cs
│       │   ├── RoutesController.cs
│       │   ├── SchedulesController.cs
│       │   └── ReservationsController.cs
│       ├── Data/                 # Contexto de base de datos
│       │   └── ApplicationDbContext.cs
│       ├── DTOs/                 # Objetos de transferencia de datos
│       │   ├── BusDto.cs
│       │   ├── RouteDto.cs
│       │   ├── ScheduleDto.cs
│       │   └── ReservationDto.cs
│       ├── Models/               # Modelos de entidades
│       │   ├── Bus.cs
│       │   ├── Route.cs
│       │   ├── Schedule.cs
│       │   └── Reservation.cs
│       ├── Migrations/           # Migraciones de EF Core
│       ├── Program.cs            # Punto de entrada de la aplicación
│       └── appsettings.json      # Configuración de la aplicación
│
├── bus-management-frontend/
│   ├── public/                   # Archivos públicos
│   ├── src/
│   │   ├── components/           # Componentes React
│   │   │   ├── Buses/
│   │   │   ├── Routes/
│   │   │   ├── Schedules/
│   │   │   ├── Reservations/
│   │   │   ├── Home.js
│   │   │   └── Navbar.js
│   │   ├── services/             # Servicios de API
│   │   │   └── api.js
│   │   ├── App.js                # Componente principal
│   │   └── index.js              # Punto de entrada
│   └── package.json              # Dependencias del frontend
│
└── README.md                     # Este archivo
```

## Solución de Problemas Comunes

### Error de Conexión a la Base de Datos

Si recibe un error de conexión a SQL Server:

1. Verifique que SQL Server esté en ejecución
2. Confirme que la cadena de conexión en `appsettings.json` sea correcta
3. Asegúrese de tener permisos para crear bases de datos
4. Intente usar `Integrated Security=false` y proporcione credenciales explícitas si es necesario

### Error de CORS en el Frontend

Si el frontend no puede conectarse al backend:

1. Verifique que el backend esté en ejecución
2. Confirme que la URL en `src/services/api.js` sea correcta
3. Asegúrese de que la política CORS en `Program.cs` incluya el origen del frontend

### Puerto en Uso

Si el puerto está ocupado:

- Backend: Modifique el puerto en `Properties/launchSettings.json`
- Frontend: Use la variable de entorno `PORT=3001 npm start` para cambiar el puerto

## Contribución

Para contribuir al proyecto:

1. Haga un fork del repositorio
2. Cree una rama para su característica (`git checkout -b feature/nueva-caracteristica`)
3. Realice sus cambios y haga commit (`git commit -am 'Agregar nueva característica'`)
4. Suba los cambios a su fork (`git push origin feature/nueva-caracteristica`)
5. Abra un Pull Request

## Licencia

Este proyecto es de código abierto y está disponible bajo la licencia MIT.

## Contacto

Para preguntas o soporte, por favor abra un issue en el repositorio del proyecto.
