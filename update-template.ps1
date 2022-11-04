Write-Output "Updating template..."

dotnet new uninstall ./template
dotnet new install ./template
