#Easy update script. Use .\dbup {args} or put in PATH


if($null -eq $args[0]){
    throw "Please enter a migration name or use the -d parameter for default naming"
}

$startLocation=Get-Location

try{
    if($args[0] -eq "-d"){
        $migration_name=$null
    }
    else {
        $migration_name=$args[0]
    }
    
    $projectLocation=dotnet sln list

    $projectLocationParseFirstResult = $projectLocation -replace '/[^/]*$',""
    $projectLocationParseString = $projectLocationParseFirstResult[2].Substring(0, $projectLocationParseFirstResult[2].lastIndexOf('\'))

    Set-Location "$projectLocationParseString"
    dotnet ef migrations add $migration_name
    dotnet ef database update
}
finally{
    Set-Location $startLocation
}

