@echo off
echo ========================================
echo Publicando Proyecto en GitHub
echo ========================================
echo.

REM Inicializar repositorio Git
echo [1/5] Inicializando repositorio Git...
git init
if %errorlevel% neq 0 (
    echo Error al inicializar Git
    pause
    exit /b 1
)
echo Repositorio inicializado correctamente.
echo.

REM Agregar todos los archivos
echo [2/5] Agregando archivos al repositorio...
git add .
if %errorlevel% neq 0 (
    echo Error al agregar archivos
    pause
    exit /b 1
)
echo Archivos agregados correctamente.
echo.

REM Hacer el primer commit
echo [3/5] Creando commit inicial...
git commit -m "Initial commit: Sistema de Gestion de Autobuses completo con API y Frontend"
if %errorlevel% neq 0 (
    echo Error al crear commit
    pause
    exit /b 1
)
echo Commit creado correctamente.
echo.

REM Renombrar rama a main
echo [4/5] Configurando rama principal...
git branch -M main
if %errorlevel% neq 0 (
    echo Error al renombrar rama
    pause
    exit /b 1
)
echo Rama configurada correctamente.
echo.

REM Instrucciones para el usuario
echo [5/5] Configuracion del repositorio remoto
echo.
echo IMPORTANTE: Ahora necesitas crear un repositorio en GitHub
echo.
echo Pasos a seguir:
echo 1. Ve a https://github.com/new
echo 2. Nombre del repositorio: proyecto-final-autobus
echo 3. Descripcion: Sistema de Gestion de Autobuses con ASP.NET Core y React
echo 4. Selecciona publico o privado
echo 5. NO inicialices con README, .gitignore o licencia
echo 6. Haz clic en "Create repository"
echo.
echo Despues de crear el repositorio, ejecuta estos comandos:
echo.
echo git remote add origin https://github.com/TU_USUARIO/proyecto-final-autobus.git
echo git push -u origin main
echo.
echo (Reemplaza TU_USUARIO con tu nombre de usuario de GitHub)
echo.
echo ========================================
echo Preparacion completada exitosamente
echo ========================================
pause
