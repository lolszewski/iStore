$directoryMainPath = "../../";
$fileExtenstionToFindFilter = "*.csproj";
$oldVersionTag = "<TargetFramework>netcoreapp2.0</TargetFramework>";
$newVersionTag = "<TargetFramework>netcoreapp2.1</TargetFramework>";

Get-ChildItem -Path $directoryMainPath -Filter $fileExtenstionToFindFilter -Recurse | ForEach-Object {
    (Get-Content $_.FullName).Replace($oldVersionTag, $newVersionTag) | Set-Content $_.FullName;
}