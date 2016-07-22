
UseCookieAuthentication
* is AuthenticationMiddleware
* This is for validating/parsing incoming Cookies that store user info.
* Send auth data to the server in the Cookie header.
* See also: http://stackoverflow.com/a/38470665/1108891

UseJwtBearerAuthentication
* IsAuthenticationMiddleware
* uses the OpenID Connect protocol
* This is for validating incoming Bearer tokens that comes from a known authority. 
* Send auth data to the server in the Authorization header.
* See also: http://stackoverflow.com/a/38470665/1108891

UseOAuthAuthentication
* is AuthenticationMiddleware
* The most generic out-of-the-box OAuth middleware.
    1. Credentials for authorization code. 
    2. Access code & client secret for access code. 
    3. Access token for protected resources.  

UseGoogleAuthentication
* is OAuthMiddleware
* Sets Google specific OAuth options. 
* Includes a handler that uses the access token to retrieve and parse Google profile information.

UseFacebookAuthentication
* is OAuthMiddleware
* Sets Facebook specific OAuth options. 
* Includes a handler that uses the access token to retrieve and parse Facebook profile information.

UseMicrosoftAccountAuthentication
* is OAuthMiddleware
* Sets Microsoft specific OAuth options. 
* Includes a handler that uses the access token to retrieve and parse Microsoft profile information.

UseTwitterAuthentication 
* is AuthenticationMiddleware
* uses the OAuth protocol, 
* but since Twitter's implementation of OAuth differs from that of Facebook, MSFT, and Google 
* the ASP.NET team did not inherit from the more generic OAuthMiddleware.

UseOpenIdConnectAuthentication 
* is AuthenticationMiddleware
* uses the OpenID Connect protocol