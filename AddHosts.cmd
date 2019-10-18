@echo off
setlocal enabledelayedexpansion
TITLE Modifying your HOSTS file
ECHO.

REM Check if hostnames were provided
IF "%~1" == "" (
    ECHO No host names provided as the 2nd arg. Ex. 'AddHost.cmd "website0.com website1.com"'
    GOTO END
)

:: Get list of domains from first argument
set LIST=%1
set quote="

:: BatchGotAdmin
:-------------------------------------
REM  --> Check for permissions
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"

REM --> If error flag set, we do not have admin.
if '%errorlevel%' NEQ '0' (
    ECHO Requesting administrative privileges...
    goto UACPrompt
) else ( goto gotAdmin )

:UACPrompt
    echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
    set params=%*
    REM Need to execute different if params are quoted
    if "!LIST:~0,1!" EQU "!quote!" (
        echo UAC.ShellExecute "cmd.exe", "/c %~s0 "%params%"", "", "runas", 1 >> "%temp%\getadmin.vbs"
    ) else (
        echo UAC.ShellExecute "cmd.exe", "/c %~s0 %params%", "", "runas", 1 >> "%temp%\getadmin.vbs"
    )    

    "%temp%\getadmin.vbs"
    del "%temp%\getadmin.vbs"
    exit /B

:gotAdmin
    pushd "%CD%"
    CD /D "%~dp0"
:--------------------------------------

REM Backup original hosts file
ECHO Backing up hosts file...

set CUR_HH=%time:~0,2%
if %CUR_HH% lss 10 (set CUR_HH=0%time:~1,1%)

set CUR_NN=%time:~3,2%
set CUR_SS=%time:~6,2%
set CUR_MS=%time:~9,2%

set BACKUPFILENAME=%date%-%CUR_HH%%CUR_NN%%CUR_SS%
copy %WINDIR%\System32\drivers\etc\hosts hosts-%BACKUPFILENAME%.backup


ECHO Updating hosts file...
SET NEWLINE=^& echo.
:: If LIST begins with a quote, remove surrounding quotes
if "!LIST:~0,1!" EQU "!quote!" (
    set _list=%LIST:~1,-1%
    ) else ( set _list=%LIST% )

:: Loop through list and add host to hosts file
for  %%G in (%_list%) do (
    set  _name=%%G

    ECHO Carrying out requested modifications to your HOSTS file
    ::strip out this specific line and store in tmp file
    type %WINDIR%\System32\drivers\etc\hosts | findstr /v /L /C:"!_name!" > tmp.txt
    ::re-add the line to it
    ECHO %NEWLINE%^127.0.0.1            !_name!>>tmp.txt
    ::overwrite host file
    copy /b/v/y tmp.txt %WINDIR%\System32\drivers\etc\hosts
    del tmp.txt
)
ipconfig /flushdns
ECHO.
ECHO.
ECHO Finished, you may close this window now.
ECHO You should now open Chrome and go to "chrome://net-internals/#dns" (without quotes)
ECHO     then click the "clear host cache" button
GOTO END

:END
PAUSE