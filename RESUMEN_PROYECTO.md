# Resumen Ejecutivo del Proyecto

## Sistema de Gestión de Autobuses

### Descripción General

Sistema completo de gestión de autobuses que permite administrar flotas de transporte, rutas, horarios y reservaciones de pasajeros. Desarrollado con tecnologías modernas y arquitectura escalable.

### Tecnologías Implementadas

#### Backend
- **Framework:** ASP.NET Core 9.0
- **Base de Datos:** SQL Server con Entity Framework Core
- **Arquitectura:** API RESTful
- **Documentación:** Swagger/OpenAPI
- **Patrón:** Repository Pattern

#### Frontend
- **Framework:** React 18.2.0
- **Enrutamiento:** React Router DOM 6.20.1
- **HTTP Client:** Axios 1.6.2
- **UI Framework:** Bootstrap 5.3.2
- **Arquitectura:** Componentes funcionales con Hooks

### Funcionalidades Principales

1. **Gestión de Autobuses**
   - Registro de autobuses con información detallada
   - Actualización de estado y características
   - Control de capacidad y modelo
   - Seguimiento por año de fabricación

2. **Administración de Rutas**
   - Definición de rutas con origen y destino
   - Cálculo de distancias
   - Nomenclatura personalizada
   - Gestión de múltiples rutas

3. **Programación de Horarios**
   - Asignación de autobuses a rutas
   - Definición de horarios de salida y llegada
   - Validación de disponibilidad
   - Vista consolidada de información

4. **Sistema de Reservaciones**
   - Reserva de asientos por pasajero
   - Validación de disponibilidad de asientos
   - Información completa del viaje
   - Gestión de cancelaciones

### Arquitectura del Sistema

```
┌─────────────────────────────────────────────────────────┐
│                    Cliente (Navegador)                   │
│                     React Frontend                       │
│                   http://localhost:3000                  │
└────────────────────────┬────────────────────────────────┘
                         │ HTTP/HTTPS
                         │ JSON
                         ▼
┌─────────────────────────────────────────────────────────┐
│                   ASP.NET Core API                       │
│                 https://localhost:7XXX                   │
│  ┌─────────────────────────────────────────────────┐   │
│  │            Controllers Layer                     │   │
│  │  • BusesController                              │   │
│  │  • RoutesController                             │   │
│  │  • SchedulesController                          │   │
│  │  • ReservationsController                       │   │
│  └──────────────────┬──────────────────────────────┘   │
│                     │                                    │
│  ┌──────────────────▼──────────────────────────────┐   │
│  │              DTOs Layer                          │   │
│  │  • BusDto, RouteDto                             │   │
│  │  • ScheduleDto, ReservationDto                  │   │
│  └──────────────────┬──────────────────────────────┘   │
│                     │                                    │
│  ┌──────────────────▼──────────────────────────────┐   │
│  │            Models Layer                          │   │
│  │  • Bus, Route                                   │   │
│  │  • Schedule, Reservation                        │   │
│  └──────────────────┬──────────────────────────────┘   │
│                     │                                    │
│  ┌──────────────────▼──────────────────────────────┐   │
│  │         Data Access Layer                        │   │
│  │       ApplicationDbContext                       │   │
│  │       Entity Framework Core                      │   │
│  └──────────────────┬──────────────────────────────┘   │
└────────────────────┬┴──────────────────────────────────┘
                     │
                     ▼
┌─────────────────────────────────────────────────────────┐
│                   SQL Server Database                    │
│                   BusManagementDB                        │
│  • Buses Table                                          │
│  • Routes Table                                         │
│  • Schedules Table                                      │
│  • Reservations Table                                   │
└─────────────────────────────────────────────────────────┘
```

### Modelo de Datos

#### Relaciones entre Entidades

```
Buses (1) ──────< (N) Schedules (N) >────── (1) Routes
                        │
                        │ (1)
                        │
                        ▼
                      (N) Reservations
```

#### Tablas Principales

1. **Buses**
   - Información del autobús
   - Capacidad y modelo
   - Estado operativo

2. **Routes**
   - Definición de rutas
   - Origen y destino
   - Distancia

3. **Schedules**
   - Relación Bus-Route
   - Horarios de operación
   - Tiempos de viaje

4. **Reservations**
   - Datos del pasajero
   - Asiento asignado
   - Fecha de reservación

### Endpoints de la API

#### Buses
- `GET /api/Buses` - Listar todos los autobuses
- `GET /api/Buses/{id}` - Obtener autobús específico
- `POST /api/Buses` - Crear nuevo autobús
- `PUT /api/Buses/{id}` - Actualizar autobús
- `DELETE /api/Buses/{id}` - Eliminar autobús

#### Routes
- `GET /api/Routes` - Listar todas las rutas
- `GET /api/Routes/{id}` - Obtener ruta específica
- `POST /api/Routes` - Crear nueva ruta
- `PUT /api/Routes/{id}` - Actualizar ruta
- `DELETE /api/Routes/{id}` - Eliminar ruta

#### Schedules
- `GET /api/Schedules` - Listar todos los horarios
- `GET /api/Schedules/{id}` - Obtener horario específico
- `POST /api/Schedules` - Crear nuevo horario
- `PUT /api/Schedules/{id}` - Actualizar horario
- `DELETE /api/Schedules/{id}` - Eliminar horario

#### Reservations
- `GET /api/Reservations` - Listar todas las reservaciones
- `GET /api/Reservations/{id}` - Obtener reservación específica
- `POST /api/Reservations` - Crear nueva reservación
- `DELETE /api/Reservations/{id}` - Eliminar reservación

### Características Técnicas

#### Seguridad
- CORS configurado para desarrollo
- Validación de datos en servidor
- Manejo de errores centralizado
- Protección contra inyección SQL (EF Core)

#### Rendimiento
- Consultas optimizadas con Entity Framework
- Carga diferida de relaciones
- Índices en base de datos
- Respuestas JSON compactas

#### Escalabilidad
- Arquitectura desacoplada
- API RESTful stateless
- Separación de responsabilidades
- Fácil integración con otros sistemas

#### Mantenibilidad
- Código limpio y documentado
- Estructura de proyecto organizada
- Convenciones de nomenclatura consistentes
- Documentación completa

### Documentación Incluida

1. **README.md**
   - Guía de instalación completa
   - Instrucciones de configuración
   - Documentación de endpoints
   - Solución de problemas

2. **API_DOCUMENTATION.md**
   - Documentación técnica detallada
   - Ejemplos de uso con cURL
   - Esquemas de datos
   - Códigos de estado HTTP

3. **INSTRUCCIONES_GITHUB.md**
   - Guía para publicar en GitHub
   - Comandos de Git
   - Mejores prácticas
   - Solución de problemas

4. **PASOS_PUBLICACION.md**
   - Pasos específicos para publicar
   - Múltiples opciones de publicación
   - Verificación post-publicación
   - Comandos útiles

### Requisitos del Sistema

#### Desarrollo
- .NET SDK 9.0 o superior
- Node.js 16 o superior
- SQL Server (cualquier edición)
- Visual Studio Code o Visual Studio

#### Producción
- Servidor con .NET Runtime 9.0
- SQL Server para base de datos
- Servidor web para frontend (IIS, Nginx, Apache)
- Certificado SSL para HTTPS

### Instalación Rápida

```bash
# Backend
cd BusManagementAPI/BusManagementAPI
dotnet restore
dotnet ef database update
dotnet run

# Frontend (en otra terminal)
cd bus-management-frontend
npm install
npm start
```

### Acceso al Sistema

- **Frontend:** http://localhost:3000
- **API:** https://localhost:7XXX/api
- **Swagger:** https://localhost:7XXX/swagger

### Mejoras Futuras Sugeridas

1. **Autenticación y Autorización**
   - Implementar JWT
   - Roles de usuario (Admin, Operador, Cliente)
   - Protección de endpoints

2. **Funcionalidades Adicionales**
   - Sistema de pagos
   - Notificaciones por email/SMS
   - Reportes y estadísticas
   - Panel de administración avanzado

3. **Optimizaciones**
   - Caché de datos frecuentes
   - Paginación en listados
   - Búsqueda y filtros avanzados
   - Compresión de respuestas

4. **Integración**
   - API de mapas para rutas
   - Sistema de tracking GPS
   - Integración con sistemas de pago
   - Aplicación móvil

### Métricas del Proyecto

- **Líneas de Código:** ~2,000+ líneas
- **Endpoints API:** 19 endpoints
- **Componentes React:** 10+ componentes
- **Tablas de Base de Datos:** 4 tablas principales
- **Tiempo de Desarrollo:** Proyecto académico completo

### Casos de Uso

1. **Administrador de Flota**
   - Registra nuevos autobuses
   - Actualiza información de vehículos
   - Monitorea estado de la flota

2. **Planificador de Rutas**
   - Define nuevas rutas
   - Asigna autobuses a rutas
   - Programa horarios

3. **Agente de Ventas**
   - Consulta disponibilidad
   - Realiza reservaciones
   - Gestiona cancelaciones

4. **Pasajero**
   - Consulta horarios disponibles
   - Realiza reservaciones
   - Verifica información del viaje

### Conclusión

Sistema completo y funcional que demuestra conocimientos en:
- Desarrollo full-stack
- Arquitectura de software
- Bases de datos relacionales
- APIs RESTful
- Frameworks modernos
- Mejores prácticas de desarrollo

El proyecto está listo para ser desplegado, extendido y utilizado como base para sistemas más complejos de gestión de transporte.

---

**Desarrollado como proyecto académico**  
**Lenguaje de Programación 2**  
**Universidad**
