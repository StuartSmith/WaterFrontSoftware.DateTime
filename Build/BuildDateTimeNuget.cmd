@echo off

set script_path=%~dp0
call %script_path%setup.cmd

%msbuild% /p:Configuration=Release %script_path%CreateNugetPackage.msbuild
