# Instrucciones para Subir el Proyecto Completo a GitHub

## Problema Identificado

El proyecto no se ha subido todavía a GitHub. Necesitamos subir TODA la carpeta "proyecto final autobus" que contiene:
- Documentación (README.md, API_DOCUMENTATION.md, etc.)
- Backend (BusManagementAPI/)
- Frontend (bus-management-frontend/)

## Solución: Usar el Script Automatizado

### Paso 1: Ejecutar el Script

En la terminal de VSCode, ejecuta:

```bash
.\PUBLICAR_COMPLETO.bat
```

### Paso 2: Seguir las Instrucciones del Script

El script te guiará paso a paso:

1. **Inicialización:** El script inicializará Git en la carpeta actual
2. **Verificación:** Te mostrará todos los archivos que se van a subir
3. **Commit:** Creará un commit con todos los archivos
4. **Configuración:** Te pedirá tu nombre de usuario de GitHub
5. **Subida:** Subirá todo el proyecto a GitHub

### Paso 3: Crear el Repositorio en GitHub

Cuando el script te lo indique:

1. Ve a https://github.com/new
2. Nombre del repositorio: `proyecto-final-autobus`
3. Descripción: `Sistema de Gestión de Autobuses con ASP.NET Core y React`
4. Selecciona **Público** o **Privado**
5. **NO marques** ninguna opción adicional (README, .gitignore, licencia)
6. Haz clic en **"Create repository"**

### Paso 4: Ingresar tu Usuario de GitHub

El script te pedirá tu nombre de usuario de GitHub. Ingrésalo y presiona Enter.

### Paso 5: Autenticación

Si Git te pide usuario y contraseña:

- **Usuario:** Tu nombre de usuario de GitHub
- **Contraseña:** Usa un **Personal Access Token** (NO tu contraseña de GitHub)

#### Cómo crear un Personal Access Token:

1. Ve a GitHub → Settings → Developer settings → Personal access tokens → Tokens (classic)
2. Haz clic en "Generate new token (classic)"
3. Dale un nombre descriptivo (ej: "VSCode Upload")
4. Selecciona el scope: **repo** (marca toda la sección)
5. Haz clic en "Generate token"
6. **COPIA EL TOKEN** (solo se muestra una vez)
7. Usa este token como contraseña cuando Git te lo pida

## Alternativa: Comandos Manuales

Si prefieres hacerlo manualmente, ejecuta estos comandos uno por uno:

```bash
# 1. Inicializar Git
git init

# 2. Agregar todos los archivos
git add .

# 3. Verificar qué se va a subir
git status

# 4. Crear commit
git commit -m "Initial commit: Sistema de Gestión de Autobuses - Proyecto completo"

# 5. Configurar rama principal
git branch -M main

# 6. Agregar repositorio remoto (reemplaza TU_USUARIO)
git remote add origin https://github.com/TU_USUARIO/proyecto-final-autobus.git

# 7. Subir todo
git push -u origin main
```

## Verificación

Después de subir, verifica que todo esté correcto:

1. Ve a tu repositorio: `https://github.com/TU_USUARIO/proyecto-final-autobus`
2. Deberías ver:
   - ✅ README.md (se mostrará en la página principal)
   - ✅ Carpeta `BusManagementAPI/`
   - ✅ Carpeta `bus-management-frontend/`
   - ✅ Todos los archivos de documentación
   - ✅ .gitignore

## Solución de Problemas

### Error: "Git no está instalado"

Instala Git desde: https://git-scm.com/download/win

### Error: "Authentication failed"

Necesitas usar un Personal Access Token en lugar de tu contraseña. Sigue los pasos arriba.

### Error: "Repository not found"

Verifica que:
1. Creaste el repositorio en GitHub
2. El nombre del repositorio es exactamente: `proyecto-final-autobus`
3. Tu nombre de usuario es correcto

### Error: "Remote origin already exists"

Ejecuta:
```bash
git remote remove origin
git remote add origin https://github.com/TU_USUARIO/proyecto-final-autobus.git
git push -u origin main
```

### Los archivos son muy grandes

Si tienes problemas con archivos grandes:

1. Verifica que el .gitignore esté funcionando
2. Los archivos en `bin/`, `obj/`, `node_modules/` NO deberían subirse
3. Si ya se agregaron, ejecuta:
```bash
git rm -r --cached bin/ obj/ node_modules/
git commit -m "Remove large files"
```

## Contenido que se Subirá

El proyecto incluye:

```
proyecto-final-autobus/
├── README.md                          (Documentación principal)
├── API_DOCUMENTATION.md               (Documentación técnica de la API)
├── INSTRUCCIONES_GITHUB.md            (Guía de GitHub)
├── PASOS_PUBLICACION.md               (Pasos de publicación)
├── RESUMEN_PROYECTO.md                (Resumen ejecutivo)
├── .gitignore                         (Archivos a ignorar)
├── publicar-github.bat                (Script de publicación)
├── PUBLICAR_COMPLETO.bat              (Script completo)
├── BusManagementAPI/                  (Backend completo)
│   ├── BusManagementAPI.sln
│   └── BusManagementAPI/
│       ├── Controllers/
│       ├── Models/
│       ├── Data/
│       ├── DTOs/
│       ├── Migrations/
│       └── Program.cs
└── bus-management-frontend/           (Frontend completo)
    ├── package.json
    ├── public/
    └── src/
        ├── components/
        └── services/
```

## Notas Importantes

1. **NO se subirán** (gracias al .gitignore):
   - `bin/` y `obj/` (archivos compilados del backend)
   - `node_modules/` (dependencias de Node.js)
   - Archivos temporales
   - Configuraciones locales

2. **SÍ se subirán**:
   - Todo el código fuente
   - Toda la documentación
   - Archivos de configuración del proyecto
   - package.json y .csproj (para que otros puedan instalar dependencias)

3. **Tamaño aproximado:** El proyecto debería ser menos de 50MB sin los archivos excluidos

## Después de Subir

Una vez subido exitosamente:

1. Comparte el enlace: `https://github.com/TU_USUARIO/proyecto-final-autobus`
2. Otros podrán clonar tu proyecto con:
   ```bash
   git clone https://github.com/TU_USUARIO/proyecto-final-autobus.git
   ```
3. El README.md se mostrará automáticamente en la página principal del repositorio

## Ayuda Adicional

Si tienes problemas, revisa:
- INSTRUCCIONES_GITHUB.md (en este proyecto)
- https://docs.github.com/es/get-started
- https://git-scm.com/doc
