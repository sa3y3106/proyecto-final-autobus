# Pasos para Publicar el Proyecto en GitHub

## Resumen Rápido

Este documento contiene los pasos exactos para publicar tu proyecto completo en GitHub desde VSCode.

## Opción 1: Usando el Script Automatizado (Recomendado para Windows)

### Paso 1: Ejecutar el script de preparación

En la terminal de VSCode, ejecuta:

```bash
.\publicar-github.bat
```

Este script hará:
- Inicializar el repositorio Git
- Agregar todos los archivos
- Crear el commit inicial
- Configurar la rama principal como "main"

### Paso 2: Crear el repositorio en GitHub

1. Ve a https://github.com/new
2. Completa los datos:
   - **Nombre:** `proyecto-final-autobus`
   - **Descripción:** `Sistema de Gestión de Autobuses con ASP.NET Core y React`
   - **Visibilidad:** Público o Privado (según tu preferencia)
   - **NO marques:** "Add a README file", "Add .gitignore", "Choose a license"
3. Haz clic en **"Create repository"**

### Paso 3: Conectar y subir el código

Después de crear el repositorio en GitHub, copia la URL que aparece (algo como `https://github.com/TU_USUARIO/proyecto-final-autobus.git`)

En la terminal de VSCode, ejecuta estos comandos (reemplaza TU_USUARIO con tu usuario de GitHub):

```bash
git remote add origin https://github.com/TU_USUARIO/proyecto-final-autobus.git
git push -u origin main
```

## Opción 2: Comandos Manuales Paso a Paso

Si prefieres ejecutar los comandos manualmente, sigue estos pasos:

### Paso 1: Inicializar Git

```bash
git init
```

### Paso 2: Agregar archivos

```bash
git add .
```

### Paso 3: Crear commit inicial

```bash
git commit -m "Initial commit: Sistema de Gestión de Autobuses completo con API y Frontend"
```

### Paso 4: Configurar rama principal

```bash
git branch -M main
```

### Paso 5: Crear repositorio en GitHub

1. Ve a https://github.com/new
2. Nombre: `proyecto-final-autobus`
3. Descripción: `Sistema de Gestión de Autobuses con ASP.NET Core y React`
4. Selecciona público o privado
5. NO inicialices con README, .gitignore o licencia
6. Clic en "Create repository"

### Paso 6: Conectar con GitHub

```bash
git remote add origin https://github.com/TU_USUARIO/proyecto-final-autobus.git
```

### Paso 7: Subir el código

```bash
git push -u origin main
```

## Opción 3: Usando la Interfaz de VSCode

### Paso 1: Inicializar repositorio

1. Presiona `Ctrl+Shift+P` (o `Cmd+Shift+P` en Mac)
2. Escribe: `Git: Initialize Repository`
3. Selecciona la carpeta actual

### Paso 2: Hacer commit

1. Haz clic en el ícono de "Source Control" en la barra lateral (o presiona `Ctrl+Shift+G`)
2. Verás todos los archivos en "Changes"
3. Haz clic en el botón `+` junto a "Changes" para agregar todos los archivos
4. En el campo de mensaje, escribe: `Initial commit: Sistema de Gestión de Autobuses completo con API y Frontend`
5. Haz clic en el botón de check (✓) o presiona `Ctrl+Enter`

### Paso 3: Publicar en GitHub

1. Haz clic en el botón "Publish to GitHub" que aparece en la vista de Source Control
2. Selecciona si quieres un repositorio público o privado
3. Confirma el nombre: `proyecto-final-autobus`
4. VSCode subirá automáticamente el código

## Verificación

Después de publicar, verifica que todo esté correcto:

1. Ve a tu repositorio en GitHub: `https://github.com/TU_USUARIO/proyecto-final-autobus`
2. Verifica que veas todos los archivos:
   - `README.md`
   - `API_DOCUMENTATION.md`
   - `INSTRUCCIONES_GITHUB.md`
   - Carpeta `BusManagementAPI/`
   - Carpeta `bus-management-frontend/`
   - `.gitignore`
3. Confirma que el README.md se muestre correctamente en la página principal

## Archivos Incluidos en el Repositorio

Tu repositorio incluirá:

- **README.md**: Documentación principal con instrucciones de instalación y uso
- **API_DOCUMENTATION.md**: Documentación técnica completa de la API
- **INSTRUCCIONES_GITHUB.md**: Guía detallada para trabajar con GitHub
- **.gitignore**: Configurado para excluir archivos innecesarios
- **BusManagementAPI/**: Backend completo con ASP.NET Core
- **bus-management-frontend/**: Frontend completo con React

## Comandos Útiles Después de Publicar

### Ver el estado del repositorio

```bash
git status
```

### Hacer cambios y subirlos

```bash
git add .
git commit -m "Descripción de los cambios"
git push
```

### Ver el historial de commits

```bash
git log --oneline
```

### Clonar el repositorio en otra máquina

```bash
git clone https://github.com/TU_USUARIO/proyecto-final-autobus.git
```

## Solución de Problemas

### Error: "remote origin already exists"

```bash
git remote remove origin
git remote add origin https://github.com/TU_USUARIO/proyecto-final-autobus.git
```

### Error de autenticación al hacer push

Si te pide usuario y contraseña:

1. Ve a GitHub → Settings → Developer settings → Personal access tokens
2. Genera un nuevo token con permisos de "repo"
3. Usa el token como contraseña cuando Git te lo pida

### Archivos muy grandes

Si tienes archivos mayores a 100MB, Git los rechazará. Verifica el .gitignore para asegurarte de que no estés incluyendo archivos de compilación o dependencias.

## Notas Importantes

1. **No subas información sensible:**
   - Cadenas de conexión con contraseñas
   - Claves API
   - Tokens de acceso
   - Archivos de configuración con datos privados

2. **El .gitignore ya está configurado** para excluir:
   - Archivos de compilación (bin/, obj/)
   - Dependencias (node_modules/, packages/)
   - Archivos temporales
   - Configuraciones locales

3. **Documentación incluida:**
   - README.md: Guía completa de instalación y uso
   - API_DOCUMENTATION.md: Documentación técnica de la API
   - INSTRUCCIONES_GITHUB.md: Guía de Git y GitHub

## Comando Todo-en-Uno

Si quieres ejecutar todo de una vez (después de crear el repositorio en GitHub):

```bash
git init && git add . && git commit -m "Initial commit: Sistema de Gestión de Autobuses completo con API y Frontend" && git branch -M main && git remote add origin https://github.com/TU_USUARIO/proyecto-final-autobus.git && git push -u origin main
```

**Recuerda reemplazar `TU_USUARIO` con tu nombre de usuario de GitHub.**

## Próximos Pasos

Después de publicar el proyecto:

1. Agrega una descripción y temas (topics) al repositorio en GitHub
2. Considera agregar un archivo LICENSE si quieres especificar la licencia
3. Puedes agregar badges al README.md para mostrar el estado del proyecto
4. Configura GitHub Pages si quieres hospedar la documentación

## Contacto y Soporte

Si tienes problemas durante la publicación:

1. Revisa la documentación en INSTRUCCIONES_GITHUB.md
2. Consulta la documentación oficial de Git: https://git-scm.com/doc
3. Consulta la documentación de GitHub: https://docs.github.com

---

**¡Listo! Tu proyecto estará publicado en GitHub y accesible para compartir con otros.**
