
ASP.NET Core security middleware includes both `UseCookieAuthentication()` and `UseJwtBearerAuthentication()`. Both Cookie and Bearer token authentication are involved in consuming and parsing secure HTTP requests. In the former, the middleware expects a cookie; in the latter, the middleware expects a bearer token. In both, the middleware parses the cookie or bearer token payload and populates the `HttpContext.User.Identity` object.

Both Cookies and Bearer tokens:
* are HTTP request headers
* are key-value pairs
* can contain arbitrary values

Cookies:
* use the `Cookie: some_value` HTTP header
* are stored in the web browser via JavaScript or via an HTTP Response header
* are added automatically via the web browser to every HTTP Request to the cookie's URL
* does not require JavaScript

Bearer tokens:
* use the `Authentication: Bearer some_value` HTTP header
* are stored in the browser via JavaScript
* are added manually via JavaScript to HTTP Requests
* require JavaScript

Cookies authentication is appropriate when we do NOT have the ability to set the HTTP Authorization header. For instance, when a user clicks a regular hyperlink, we do not have the opportunity to set the Authorization header. Hyperlinks just don't do that. If we want to have hyperlinks that make secure requests, we can use Cookie authorization, and rely on the web browser to automatically add the HTTP Cookie header to each request.

Bearer token authentication is appropriate when we do have the ability to set the HTTP Authorization header. This is the case in single page applications, when most if not all HTTP requests use AJAX. For instance, when we make a secure request for resources from Google, we will include the Google `access_token`. When we make a secure request for resources from Facebook, we will include the Facebook `access_token`. We we make a secure request for resources from our own servers, will will include the `access_token` that we aquired from our own authorization server. This flexibility allows us to integrate resource servers from multiple providers. 

There are three standard ways to flow access tokens.

* Authorization header.
* Query string. 
* Request form.

Note that Cookie is not one of these standard ways to flow access tokens. If we send a security assertion, such as an `access_token`, in a Cookie, we should avoid also sending it as a Bearer token. Conversely, if we send a security assetion via a Bearer token, we should avoid also sending it in a Cookie. Don't cross the streams.