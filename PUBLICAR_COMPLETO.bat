@echo off
echo ========================================
echo Publicando Proyecto Completo en GitHub
echo ========================================
echo.
echo Este script subira TODA la carpeta del proyecto incluyendo:
echo - Documentacion (README.md, API_DOCUMENTATION.md, etc.)
echo - Backend (BusManagementAPI/)
echo - Frontend (bus-management-frontend/)
echo.
pause
echo.

REM Verificar si ya existe un repositorio Git
if exist .git (
    echo [!] Ya existe un repositorio Git. Eliminando...
    rmdir /s /q .git
    echo Repositorio anterior eliminado.
    echo.
)

REM Inicializar repositorio Git
echo [1/6] Inicializando repositorio Git...
git init
if %errorlevel% neq 0 (
    echo [ERROR] No se pudo inicializar Git
    echo Verifica que Git este instalado: git --version
    pause
    exit /b 1
)
echo [OK] Repositorio inicializado correctamente.
echo.

REM Verificar archivos a subir
echo [2/6] Verificando archivos a subir...
git status
echo.
echo Presiona cualquier tecla para continuar con la subida de archivos...
pause >nul
echo.

REM Agregar todos los archivos
echo [3/6] Agregando TODOS los archivos al repositorio...
git add .
if %errorlevel% neq 0 (
    echo [ERROR] No se pudieron agregar los archivos
    pause
    exit /b 1
)
echo [OK] Archivos agregados correctamente.
echo.

REM Verificar que archivos se agregaron
echo Archivos que se subiran:
git status --short
echo.
pause
echo.

REM Hacer el primer commit
echo [4/6] Creando commit inicial...
git commit -m "Initial commit: Sistema de Gestion de Autobuses - Proyecto completo con Backend ASP.NET Core y Frontend React"
if %errorlevel% neq 0 (
    echo [ERROR] No se pudo crear el commit
    pause
    exit /b 1
)
echo [OK] Commit creado correctamente.
echo.

REM Renombrar rama a main
echo [5/6] Configurando rama principal como 'main'...
git branch -M main
if %errorlevel% neq 0 (
    echo [ERROR] No se pudo renombrar la rama
    pause
    exit /b 1
)
echo [OK] Rama configurada correctamente.
echo.

REM Instrucciones para el usuario
echo [6/6] Configuracion del repositorio remoto en GitHub
echo.
echo ========================================
echo PASOS SIGUIENTES:
echo ========================================
echo.
echo 1. Ve a https://github.com/new
echo 2. Nombre del repositorio: proyecto-final-autobus
echo 3. Descripcion: Sistema de Gestion de Autobuses con ASP.NET Core y React
echo 4. Selecciona PUBLICO o PRIVADO
echo 5. NO marques: "Add a README file", "Add .gitignore", "Choose a license"
echo 6. Haz clic en "Create repository"
echo.
echo Despues de crear el repositorio, copia tu nombre de usuario de GitHub
echo.
set /p GITHUB_USER="Ingresa tu nombre de usuario de GitHub: "
echo.
echo Conectando con GitHub...
git remote add origin https://github.com/%GITHUB_USER%/proyecto-final-autobus.git
if %errorlevel% neq 0 (
    echo [ERROR] No se pudo agregar el repositorio remoto
    echo Verifica que el nombre de usuario sea correcto
    pause
    exit /b 1
)
echo.
echo Subiendo archivos a GitHub...
echo Esto puede tomar unos minutos dependiendo del tamano del proyecto...
echo.
git push -u origin main
if %errorlevel% neq 0 (
    echo.
    echo [ERROR] No se pudo subir el proyecto
    echo.
    echo Posibles soluciones:
    echo 1. Verifica que creaste el repositorio en GitHub
    echo 2. Verifica tu autenticacion (puede que necesites un Personal Access Token)
    echo 3. Si te pide usuario/contrasena, usa tu token de GitHub como contrasena
    echo.
    echo Para crear un token:
    echo - Ve a GitHub - Settings - Developer settings - Personal access tokens
    echo - Generate new token (classic)
    echo - Selecciona 'repo' scope
    echo - Copia el token y usalo como contrasena
    echo.
    pause
    exit /b 1
)
echo.
echo ========================================
echo EXITO! Proyecto subido correctamente
echo ========================================
echo.
echo Tu proyecto esta ahora en:
echo https://github.com/%GITHUB_USER%/proyecto-final-autobus
echo.
echo Verifica que todo este correcto visitando el enlace.
echo.
pause
