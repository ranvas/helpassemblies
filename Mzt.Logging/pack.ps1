#$packageId=[System.IO.Path]::GetFileNameWithoutExtension($MyInvocation.MyCommand.Definition)
param (
    [string]$packageId = $env:package
)

write-host "packageId: $packageId"; 

$filename = $PSScriptRoot + "\" + $packageId + ".nuspec"
write-host "filename: $filename"; 
[xml]$nuspec = Get-Content $filename
$version = $nuspec.SelectSingleNode("//package/metadata/version").InnerText
write-host "version: $version"; 
$packArgs = @(
    'pack'
    "$filename"
    "-properties", "configuration=release"
    "-outputdirectory", "\\mouzenidis.net\msk\M\NugetSources\"
)
write-host "packArgs: $packArgs"; 
nuget $packArgs
$nuspec.SelectSingleNode("//package/metadata/version").InnerText =  [int]$version + 1
$nuspec.Save($filename);
