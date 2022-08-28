
echo " - Installing dotnet format tool"
dotnet tool install dotnet-format

echo " - Formating code"
dotnet format .\bomberguy.sln

echo " - Done!"
