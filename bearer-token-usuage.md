
Both Cookie and Bearer token authentication are involved in consuming and parsing HTTP requests. In the former, the middleware expects a cookie; in the latter, the middleware expects a bearer token. In both, the middleware parses the payload and populates the HttpContext.User.Identity object.

Both Cookies and Bearer tokens: 
* are HTTP request headers
* are key-value pairs
* can contain arbitrary values

Cookies:
* use the `Cookie: some_value` HTTP header
* are stored in the web browser via JavaScript or via an HTTP Response header
    * JS: `document.cookie = 'cookie_name=cookie_value`
    * HTTP: `Set-Cookie: cookie_name=cookie_value`
* are added automatically via the web browser to every HTTP Request to the cookie's URL
* can also be added manually via JavaScript
* does not require JavaScript

Bearer tokens:
* use the `Authentication: Bearer some_value` HTTP header
* are stored in the browser via JavaScript
    * JS: `localStorage.setItem('some_key', 'some_value')`
    * JS: `sessionStorage.setItem('some_key', 'some_value')` 
* are added manually via JavaScript to HTTP Requests
* requires JavaScript

Cookies are good when we do not have the ability to set the HTTP Authorization header. For instance, when a user clicks a regular hyperlink, we do not have the opportunity to set the Authorization header. Hyperlinks just don't do that. If we want to have hyperlinks that make secure requests, we can use Cookie authorization, and rely on the web browser to automatically add the HTTP Cookie header to each request.

Three standard ways to flow access tokens. 

* Authorization header.
* Query string. 
* Request form.

Note: If we send a security assertion in a Cookie, we should avoid also sending it as a Bearer token. Conversely, if we send a security assetion via a Bearer token, we should avoid also sending it in a Cookie.