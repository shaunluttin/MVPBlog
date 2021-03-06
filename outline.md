
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
* If you are not comfortable with with the interactive implicit flow, use Resource Owner Password Credentails.

* Why?

* The Authorization Code Grant/Flow is most approriate for **confidential** clients.
    * Confidential, because we expect the client to keep its client secret private.
    * If the client is not confidential, a hacker could steal the secret and impersonate the client.
    * Since SPA are public, they cannot keep their client secret private.
    * E.g. The client secret would be in JavaScript source code, which is open to savvy end-users.
    * The authorization code flow does NOT need to have high trust, because it never sees the end-users credentials.
    * Generally:
        * User credential exchange: `User --> User-Agent --> Authorization Server`
        * Token acquisition: `Client Secret + Authorization Code --> Token Endpoint --> Access Token` (confidential)
        * Note: the authorization server responds with the authorization code.

* The Resource Owner Password Credential Grant/Flow is most appropriate for **trusted** clients.
    * Trusted, because the end-user gives zer credentials (e.g. username and password) directly to the client. 
    * If the client is malicious, it could store the end-user's credentails and impersonate zer.
    * Since SPA are public, their code is open to modification by an untrusted user. 
    * E.g. Someone modifies the JavaScript in the browser, which stores the end-user's credentials in another site.
    * Note: we can consider very few clients to be highly trusted.
    * Generally:
        * User credential exchange: `User --> User-Agent --> Client --> Authorization Server` (trusted)
        * Token acquisition: `Authorization Server --> Access Token`
    
* The Implicit Flow is appropriate for **non-confidential** and **non-highly trusted** clients.
    * In this case the implicit flow is the least bad option.
    * It does not need to be confidential, because there is no client secret involved. 
    * It does not need to be highly trusted, because it never sees the end-user credentials.
    * As in the other flows, the client has a redirection URL, which plays a similar role to the client secret.
        * Having the client secret verifies the client's identity; 
        * similarly, having control of the redirect URL verifies the client's identity, 
        * because strict domain registration rules prevent other clients from living there.
    * Generally: 
        * User credentials exchange: `User --> User-Agent --> Authorization Server`
        * Token acquisition: `Authorization Server --> Access Token`

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

## Authenticate a user

* request an `id_token` from Google.
* produce an `id_token` with OpenIddict.
* consume an `id_token` with ASP.NET Core security.

## Access a user's protected resources

* request an `access_token` from Google.
* use an `access_token` with Google.
* produce an `access_token` with OpenIddict.
* consume an `access_token` with OpenIddict.

# Inspecting the SPA login traffic from Windows 10.

* Fiddler http://www.telerik.com/fiddler
* WireShark https://www.wireshark.org
* Netmon https://www.microsoft.com/en-us/download/details.aspx?id=4865
* ASP.NET Core HTTP Logging
* IPv6 Capture