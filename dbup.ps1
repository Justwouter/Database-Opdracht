#Easy update script. Use .\dbup {args} or put on PATH

$migration_name=$args[0]
$startLocation=Get-Location

$projectLocation=dotnet sln list

$projectLocationParseFirstResult = $projectLocation -replace '/[^/]*$',""
$projectLocationParseString = $projectLocationParseFirstResult[2].Substring(0, $projectLocationParseFirstResult[2].lastIndexOf('\'))

Set-Location "$projectLocationParseString"
dotnet ef migrations add $migration_name
dotnet ef database update
Set-Location $startLocation
