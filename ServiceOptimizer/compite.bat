@echo off

set software_name=ServiceOptimizer
set software_core=netcoreapp2.1

cls
:menu
cls
color 80

date /t
echo Computador: %computername%        Usuario: %username%
@echo.  
echo ====================================
echo            MENU TAREFAS
echo ====================================
echo * 1. Compilar para Linux-ARM       * 
echo * 2. Compilar para Linux-x86       * 
echo * 3. Compilar para Linux-x64       * 
echo * 4. Compilar para Win7-x86        *
echo * 5. Compilar para Win7-x64        *
echo * 6. Compilar para Win8-x86        *
echo * 7. Compilar para Win8-x64        *
echo * 8. Compilar para Win10-x86       *
echo * 9. Compilar para Win10-x64       *
echo * 0. Sair                          * 
echo ====================================
@echo.  
set /p opcao= Escolha uma opcao: 

if %opcao% equ 1 (
	set software_os=linux-arm 
	goto GerarPath
)
if %opcao% equ 2 (
	set software_os=linux-x86
	goto GerarPath
)
if %opcao% equ 3 (
	set software_os=linux-x64
	goto GerarPath
)
if %opcao% equ 4 (
	set software_os=win7-x86
	goto GerarPath
)
if %opcao% equ 5 (
	set software_os=win7-x64
	goto GerarPath
)
if %opcao% equ 6 (
	set software_os=win8-x86
	goto GerarPath
)
if %opcao% equ 7 (
	set software_os=win8-x64
	goto GerarPath
)
if %opcao% equ 8 (
	set software_os=win10-x86
	goto GerarPath
)
if %opcao% equ 9 (
	set software_os=win10-x64
	goto GerarPath
)
if %opcao% equ 0 (
	cls
	exit
)
if %opcao% GEQ 10 (
	@echo.
	echo ===============================================
	echo * Opcao Invalida! Escolha outra opcao do menu *
	echo ===============================================
	pause
	goto menu
)

:GerarPath
	cls
	dotnet publish -c Release -r %software_os%
	
	@RD /S /Q %systemdrive%\Forbytech\%software_name%\
	xcopy /s /e %cd%\bin\Release\%software_core%\%software_os%\publish\* %systemdrive%\Forbytech\%software_name%\
	
	@echo.
	echo Arquivos copiandos para o diretorio diretorio: "%systemdrive%\Forbytech\%software_name%\"
	@RD /S /Q %cd%\bin\Release\
	pause
goto menu
