# Due to the immutability of "BasicParsing" in modern Powershell, the Invoke-WebRequest and RESTMethod cmdlets strip excess whitespace, including newlines. from the request body. 
sl $PSScriptRoot
Write-Host "Encrypt (1) Decrypt (2)"
$choice = Read-Host
if ($choice -eq 1)
{
    Write-Host "Input file name:"
    $decryptedIn = Read-Host
    Invoke-RestMethod -Method Post -ContentType "text/plain" -Uri 'http://settersynology:9843/encrypt' -Body (gc $decryptedIn) -OutFile "encrypted_out.txt"
}
else
{
    Write-Host "Input file name:"
    $encryptedIn = Read-Host
    Invoke-RestMethod -Method Post -ContentType "text/plain" -Uri 'http://settersynology:9843/decrypt' -Body (gc $encryptedIn) -OutFile "decrypted_out.txt"
}
