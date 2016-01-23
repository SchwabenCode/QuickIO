# Build script for AppVeyor Environment

param([parameter(Mandatory=$true,ValueFromRemainingArguments=$true)]
    [string[]]$buildFolder,
    [string] $configuration)

Write-Host "BUILDING configuration $env:configuration"

Try
{
    for ($i = 0; $i -lt $buildFolder.Length; ++$i) {
        $path = $($buildFolder[$i])
        
        Write-Host " -- Project folder: $path"
        Invoke-Expression -Command "dnu build $path --configuration $configuration"
    }
}
Catch
{
    exit -1
}
