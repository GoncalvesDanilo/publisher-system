dotnet build .\publishers-works\ -o .\publishers-interface\publishers-worksDLL --nologo
Move-Item .\publishers-interface\publishers-worksDLL\publishers-works.dll .\publishers-interface\publishers-works.dll -force
Remove-Item -path .\publishers-interface\publishers-worksDLL\ -recurse
# clear
Write-host "--------------------------------------" -NoNewline
dotnet run -p .\publishers-interface
