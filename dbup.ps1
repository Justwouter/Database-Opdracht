#Easy update script. Use .\dbup {args} or put in PATH

#Check if any argument is passed
if($null -eq $args[0]){
    throw "Please enter a migration name or use the -d parameter for default naming"
}

$startLocation=Get-Location

try{
    #Get the project path from dotnet and parse to a usable string
    $projectLocation=dotnet sln list

    $projectLocationParseFirstResult = $projectLocation -replace '/[^/]*$',""
    $projectLocationParseString = $projectLocationParseFirstResult[2].Substring(0, $projectLocationParseFirstResult[2].lastIndexOf('\'))

    Set-Location "$projectLocationParseString"

    #Check if the default parameter is used
    if( -not($args.Contains(("-u")))){
        if($args[0] -eq "-d"){
            dotnet ef migrations add
        }
        else {
            $migration_name=$args[0]
            dotnet ef migrations add $migration_name
        }
    }
    dotnet ef database update
}
finally{
    Set-Location $startLocation
}

