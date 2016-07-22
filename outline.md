
# The history of SPA login.

* The history of SPA login is the history of distributed identification and access.
* Before distribution: HTTP Basic, Digest
* OpenID 1.0 > OpenID 2.0 + OpenID 1.0 Attribute Exchange
* OAuth 1.0 > OAuth 2.0
* OpenIdConnect 
* http://security.stackexchange.com/questions/44611/difference-between-oauth-openid-and-openid-connect-in-very-simple-term/130411#130411

# ASP.NET Core Security Out-of-the-Box.

* Token storage & transport: CookieAuthentication vs JwtBearerAuthentication
* Token acquisition: OAuthAuthentication vs OpenIdConnectAuthentication
* ASP.NET Core provides out-of-the-box middleware for the following OAuth providers:
    * GoogleAuthentication
    * FacebookAuthentication 
    * MicrosoftAccountAuthentication
    * TwitterAuthentication

# SPA Related ASP.NET Core Security Contributions.

* OpenIddict & AspNet.Security.OpenIdConnect.Server
* Identity Server 3

# Current alternatives for SPA login.

* Implicit flow is the way to go for single page applications. 
* Why?
* The Authorization Code Grant/Flow is for confidential clients. 
    * The client must keep its stored client secret private.
    * SPAs are public.
* The Resource Owner Password Credential Grant/Flow is for highly trusted clients. 
    * The client must keep its stored user credentials private.
    * SPAs are public.
* The Implicit Flow is for public clients.
    * The client must register its redirection URL.
    * Via domain registration, clients have full ownership of thier URLs.

# The mechanics of SPA authentication.

* OAuth Credential Types
* OpenID Connect Flows

# The mechanics of SPA resource access. 

* Cookies
* Bearer Tokens

# Implementing OpenIdConnect SPA login with ASP.NET Core.

* Using Google as an identity provider
    * ID Token from Google
    * Access Token for Google's resource servers
* Using OpenIddict as an identity provider
    * ID Token from your servers
    * Access Token for your resource servers
* Checking the bearer token at your resource servers

# Inspecting the SPA login traffic from Windows 10.

* Fiddler
* WireShark
* ASP.NET Core HTTP Logging
* IPv6 Capture