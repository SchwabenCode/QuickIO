Try
{
	$Branch='dev';
	$wc=New-Object System.Net.WebClient;
	$wc.Proxy=[System.Net.WebRequest]::DefaultWebProxy;
	$wc.Proxy.Credentials=[System.Net.CredentialCache]::DefaultNetworkCredentials;
	Invoke-Expression ($wc.DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))
	
	Invoke-Expression -Command "dnvm install $env:dnvmVersion"
	Invoke-Expression -Command "dnvm upgrade"
	Invoke-Expression -Command "dnvm update-self"
	Invoke-Expression -Command "dnvm list"
	Invoke-Expression -Command "dnvm use $env:dnvmVersion"
	Invoke-Expression -Command "dnu restore"
}
Catch
{
    exit -1
}