
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

* Implicit flow is the way to go for single page applications. If you are not comfortable with with the interactive flows, use Resource Owner Password Credentails.
* Why?
* The Authorization Code Grant/Flow is most approriate confidential clients.
    * The expectation is that client must keep its stored client secret private.
    * SPA tend to be public.
* The Resource Owner Password Credential Grant/Flow is most appropriate for highly trusted clients.
    * The expectation is that the client must keep its stored user credentials private.
    * SPAs tend to be public.
* The Implicit Flow is most appropriate for public clients.
    * The client must register its redirection URL.
    * Via domain registration, clients have full ownership of thier URLs.

# SPA implicit OpenID Connect.

Anatomy

* relying party
* redirect uri
* user agent
* resource owner
* authorization server / authorization endpoint
* access token
* id token
* resource server

Physiology

* authentication
* authorization
* redirection

# The mechanics of SPA resource access. 

* Cookies: access a resource server at a single domain
* Bearer Tokens & Local/Session Storage: access resource servers at multiple domains

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