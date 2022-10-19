# Sample WPF App

This app is a minimum WPF app to reproduce the error 'Unable to load DLL 'msalruntime_x86' when trying to follow [this doc](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/wam) to use the new version (4.47.2-preview) of `Microsoft.Identity.Client.Broker` instead of `Microsoft.Identity.Client.Desktop`.

When started, this app will try to create a `IPublicClientApplication` client and call `AcquireTokenInteractive` method. See code [here](./WPF/App.xaml.cs#L45). The following error occurs at this point:

```
Microsoft.Identity.Client.MsalClientException: 'Unable to load DLL 'msalruntime_x86': The specified module could not be found. (Exception from HRESULT: 0x8007007E) See https://aka.ms/msal-net-wam#troubleshooting'

Inner Exception
DllNotFoundException: Unable to load DLL 'msalruntime_x86': The specified module could not be found. (Exception from HRESULT: 0x8007007E)
```

## Steps to reproduce

1. Clone this repo.
2. Replace the [fake client id](./WPF/MainWindow.xaml.cs#L30) with a valid client id.
3. Build the solution to restore all nuget packages.
4. Start the project "WPF.Package".
