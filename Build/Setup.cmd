@echo off
set script_path_setup=%~dp0
set msbuild=
set msbuild32=

set FrameworkVersion=v4.0.30319
call :GetMSBuildFullPath 


:GetMSBuildFullPath

powershell ./setup.ps1
call %script_path_setup%msbuildLocation.bat

if not exist %msbuild% echo Where's MSBuild.exe? && pause
if not defined msbuild exit /b 1