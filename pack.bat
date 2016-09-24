@rem NuGet.CommandLine is too old and does not support Xamarin.iOS libs
@rem @echo Please install the package "NuGet.CommandLine" from https://chocolatey.org/ before running this script
@rem @echo After chocolatey is installed, type: choco install NuGet.CommandLine

@echo Before running this script, download nuget.exe from @echo https://nuget.codeplex.com/releases/view/133091
@echo and put nuget.exe in the path.

@rem set /p nugetServer=Enter base nuget server url (with /): 
set nugetServer=http://nugets.vapolia.fr/

cd nuspec
del *.nupkg
set version=2.1.7
nuget pack ExCSS.nuspec -Version "%version%"
nuget push ExCSS.*.nupkg -Source %nugetServer%
cd ..

pause
