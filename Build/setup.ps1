#--------------------------------
# Make sure Power Shell Version 5.0 is installed, 
# this version of powershell is required to install the
# VSSsetup Module
#--------------------------------
if($PSVersionTable.PSVersion.Major -lt 5 )
{  
    throw [System.Exception] "Power Shell 5.0 is not installed (https://www.microsoft.com/en-us/download/details.aspx?id=50395) ...Please install it to continue "
}

#--------------------------------
# Install the VSS Setup Module if it does not exist
#--------------------------------
$VSSetupModule =  Get-InstalledModule | Where-Object{$_.Name -like "*VSSETUP*"}
if (-Not($VSSetupModule))
{
	install-module VSSETUP -scope CurrentUser -force
}

#--------------------------------
# Get the path for MSSBuild
#--------------------------------
$VSSetupInstance = Get-VSSetupInstance | Select-VSSetupInstance -Latest
$msbuildpath = "$($VSSetupInstance.InstallationPath)$("\MSBuild\15.0\Bin\msbuild.exe")"
$msbuildPathQuoted =$("set msbuild=") +  $("`"")  + $msbuildpath + $("`"")
write-Host $msbuildPathQuoted

#--------------------------------
# Save the path to the Msbuild exe to the 
# msbuild location batch file
#--------------------------------
$FileName = "./msbuildLocation.bat" 
if (Test-Path $FileName) 
{
	Remove-Item $FileName
}

Add-Content msbuildLocation.bat $msbuildPathQuoted