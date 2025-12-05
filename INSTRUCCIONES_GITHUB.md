# Instrucciones para Publicar el Proyecto en GitHub

Este documento contiene los pasos detallados para publicar el proyecto completo en GitHub desde Visual Studio Code.

## Requisitos Previos

1. Tener Git instalado en su sistema
2. Tener una cuenta de GitHub
3. Tener GitHub CLI (gh) instalado (opcional pero recomendado)

## Opción 1: Usando GitHub CLI (Recomendado)

### Paso 1: Verificar si GitHub CLI está instalado

```bash
gh --version
```

Si no está instalado, descárguelo desde: https://cli.github.com/

### Paso 2: Autenticarse en GitHub

```bash
gh auth login
```

Siga las instrucciones en pantalla para autenticarse.

### Paso 3: Inicializar el repositorio Git

```bash
git init
git add .
git commit -m "Initial commit: Sistema de Gestión de Autobuses completo"
```

### Paso 4: Crear y publicar el repositorio en GitHub

```bash
gh repo create proyecto-final-autobus --public --source=. --remote=origin --push
```

Opciones del comando:
- `--public`: Crea un repositorio público (use `--private` para privado)
- `--source=.`: Usa el directorio actual como fuente
- `--remote=origin`: Establece el nombre del remoto como "origin"
- `--push`: Sube automáticamente los cambios

## Opción 2: Usando Git y GitHub Web

### Paso 1: Crear un repositorio en GitHub

1. Vaya a https://github.com/new
2. Nombre del repositorio: `proyecto-final-autobus`
3. Descripción: "Sistema de Gestión de Autobuses con ASP.NET Core y React"
4. Seleccione público o privado según su preferencia
5. NO inicialice con README, .gitignore o licencia (ya los tenemos)
6. Haga clic en "Create repository"

### Paso 2: Inicializar y subir el repositorio local

Copie y ejecute estos comandos en la terminal de VSCode:

```bash
git init
git add .
git commit -m "Initial commit: Sistema de Gestión de Autobuses completo"
git branch -M main
git remote add origin https://github.com/TU_USUARIO/proyecto-final-autobus.git
git push -u origin main
```

Reemplace `TU_USUARIO` con su nombre de usuario de GitHub.

## Opción 3: Usando Visual Studio Code (Interfaz Gráfica)

### Paso 1: Inicializar el repositorio

1. Abra la paleta de comandos (Ctrl+Shift+P o Cmd+Shift+P)
2. Escriba "Git: Initialize Repository"
3. Seleccione la carpeta del proyecto

### Paso 2: Hacer el primer commit

1. Vaya a la vista de Control de Código Fuente (icono de rama en la barra lateral)
2. Haga clic en el botón "+" junto a "Changes" para agregar todos los archivos
3. Escriba el mensaje de commit: "Initial commit: Sistema de Gestión de Autobuses completo"
4. Haga clic en el botón de check (✓) para hacer commit

### Paso 3: Publicar en GitHub

1. Haga clic en el botón "Publish to GitHub" en la vista de Control de Código Fuente
2. Seleccione si desea un repositorio público o privado
3. Confirme el nombre del repositorio
4. VSCode subirá automáticamente el código

## Verificación

Después de publicar, verifique que todo esté correcto:

1. Visite su repositorio en GitHub
2. Confirme que todos los archivos estén presentes
3. Verifique que el README.md se muestre correctamente en la página principal

## Comandos Útiles Posteriores

### Actualizar el repositorio después de hacer cambios

```bash
git add .
git commit -m "Descripción de los cambios"
git push
```

### Ver el estado del repositorio

```bash
git status
```

### Ver el historial de commits

```bash
git log --oneline
```

### Crear una nueva rama

```bash
git checkout -b nombre-de-la-rama
```

### Cambiar entre ramas

```bash
git checkout nombre-de-la-rama
```

## Solución de Problemas

### Error: "remote origin already exists"

```bash
git remote remove origin
git remote add origin https://github.com/TU_USUARIO/proyecto-final-autobus.git
```

### Error de autenticación

Si usa HTTPS y tiene problemas de autenticación:

1. Configure un Personal Access Token en GitHub
2. Use el token como contraseña al hacer push

O configure SSH:

```bash
ssh-keygen -t ed25519 -C "tu_email@ejemplo.com"
```

Luego agregue la clave SSH a su cuenta de GitHub.

### Archivos grandes

Si tiene archivos muy grandes (>100MB), considere usar Git LFS:

```bash
git lfs install
git lfs track "*.extensión"
git add .gitattributes
```

## Notas Importantes

1. El archivo .gitignore ya está configurado para excluir:
   - Archivos de compilación (bin/, obj/)
   - Dependencias (node_modules/, packages/)
   - Archivos de configuración local
   - Archivos temporales y de sistema

2. NO suba información sensible como:
   - Cadenas de conexión con contraseñas
   - Claves API
   - Tokens de acceso
   - Archivos de configuración con datos privados

3. Si necesita compartir configuraciones sensibles, use variables de entorno o archivos de configuración de ejemplo (.env.example)

## Recursos Adicionales

- Documentación de Git: https://git-scm.com/doc
- Documentación de GitHub: https://docs.github.com
- GitHub CLI: https://cli.github.com/manual/
- Git LFS: https://git-lfs.github.com/
