#Easy update script. Use .\dbup {args} or put on PATH

$migration_name=$args[0]
$startLocation=Get-Location

$projectLocation=dotnet sln list

$projectLocationParse1 = $projectLocation -replace '/[^/]*$',""
$projectLocationParse2 = $projectLocationParse1[2].Substring(0, $projectLocationParse1[2].lastIndexOf('\'))

Set-Location "$projectLocationParse2"
dotnet ef migrations add $migration_name
dotnet ef database update
Set-Location $startLocation
