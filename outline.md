
The history of SPA login.

* The history of SPA login is the history of distributed identification and access.
* OpenID 1.0 > OpenID 2.0 + OpenID 1.0 Attribute Exchange
* OAuth 1.0 > OAuth 2.0
* OpenIdConnect 
* http://security.stackexchange.com/questions/44611/difference-between-oauth-openid-and-openid-connect-in-very-simple-term/130411#130411

ASP.NET Core Security Out-of-the-Box.

* Token storage & transport: CookieAuthentication vs JwtBearerAuthentication
* Token acquisition: OAuthAuthentication vs OpenIdConnectAuthentication
* Token acquisition defaults:
    * GoogleAuthentication
    * FacebookAuthentication 
    * MicrosoftAccountAuthentication
    * TwitterAuthentication

SPA Related ASP.NET Core Security Contributions.

* OpenIddict & AspNet.Security.OpenIdConnect.Server
* Identity Server 3

Current alternatives for SPA login.

* Implicit flow

The mechanics of SPA login.

* OAuth Credential Types
* OpenID Connect Flows

Implementing OpenIdConnect SPA login with ASP.NET Core.

* Using Google as an identity provider
    * ID Token from Google
    * Access Token for Google's resource servers
* Using OpenIddict as an identity provider
    * ID Token from your servers
    * Access Token for your resource servers
* Checking the bearer token at your resource servers

Inspecting the SPA login traffic from Windows 10.

* Fiddler
* WireShark
* ASP.NET Core HTTP Logging
* IPv6 Capture