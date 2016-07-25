
In this example, we will use Google to authenticate our end-user and acquire an `id_token`. Once we know who the user is, we will no longer interact with Google. If we did want to further interact with Google, we would also request and store an `access_token`.

Run this example from the dotnet CLI. Then navigate to http://localhost:5000 and open the developer console.

```
dotnet restore
dotnet run
```

References:

https://console.developers.google.com/projectselector/apis/credentials

https://developers.google.com/identity/sign-in/web/