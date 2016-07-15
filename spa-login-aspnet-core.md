# Single Page Application Login with ASP.NET Core

# Meta

* Moratorium: Approx 20 hours, then make another decision. 
* 15 July 2016, 1 hour

# Terminology

In the context of a single-page application, 
the user agent is a web browser, 
the resource owner is a person (an end-user, a human being), and 
the relying party is a single page application (YourSPA).

The resource server contains private user data, 
such as email, photos, and contacts, 
which YourSPA would like to access.

The authorization server is Google, Facebook, GitHub, 
or a roll-your-own OpenId Connect provider. 

The person clicks log-in in YourSPA, 
and YourSPA redirects to the authorization server.

The authorization server's authorization endpoint 
receives the person's username/password, 
says, "Some Application would like to access your private information...", 
and after receiving the okay from the person, 
redirects the web browser to YourSPA's redirection endpoint,
sending along an authorization code. 

YourSPA sends its client secret along with that authorization code 
to the authorization server's token endpoint.

The authorization server's token endpoint 
reads the client secret that's assocaited with YourSPA, 
reads the authorization code that's associated with the person, 
and if both check out okay, sends both an access token and id token
back to YourSPA's redirection endpoint. 

At this point, YourSPA can decode the id token 
to find out information about the person 
and can use the access token to access private user data from the resource server.

* <dfn id="ua">user-agent</dfn>
    * A user-agent is software acting on behalf of the user.
    * Common examples are a Web Browser, native application, or OS component that is communicating over HTTP.
    * https://en.wikipedia.org/wiki/User_agent 
* <dfn id="ro">resource owner</dfn>
    * An OAuth2 term
    * meaning any entity 
    * that is capable of granting access to a protected resource.
    * https://tools.ietf.org/html/rfc6749#section-1.1
* <dfn id="c">client / relying party</dfn>
    * In OIDC this is called the Relying Party.
    * In OAuth2 this is called the client. 
    * Both mean any application that is making protected resource requests
    * on behalf of the resource owner and with the resource owner's authorization.
    * http://openid.net/specs/openid-connect-core-1_0.html#Terminology 
    * https://tools.ietf.org/html/rfc6749#section-1.1
* <dfn>resource server</dfn>
    * The server that is hosting the protected resources and
    * that is capable of receiving an access token to unlock those resources.
    * https://tools.ietf.org/html/rfc6749#section-1.1 
* <dfn id="as">authorization server</dfn>
    * a server with an authorization endpoint and a token endpoint
    * the server 1. authenticates the resource owner, 2. obtains authorization from the resource owner, and 3. issues an access token to the client.
    * https://tools.ietf.org/html/rfc6749#section-1.1 
    * https://tools.ietf.org/html/rfc6749#section-3
* <dfn id="ae">authorization endpoint</dfn>
    * The client uses the authorization server 
    * to obtain authorization from the resource owner 
    * via user-agent redirection. 
    * https://tools.ietf.org/html/rfc6749#section-3
* <dfn id="te">token endpoint</dfn>
    * The client uses the token endpoint 
    * to exchange an authorization grant 
    * for an access token.
    * The token endpoint typically authenticates the client / relying party.
    * https://tools.ietf.org/html/rfc6749#section-3
* <dfn id="re">redirection endpoint</dfn>
    * the authorization server uses the redirection endpoint
    * to return responses to the client
    * via the resource-owner user agent
    * https://tools.ietf.org/html/rfc6749#section-3    
* <dfn id="auth_code">authorization code</dfn>
* <dfn id="id_token">id token</dfn>
* <dfn id="access_token">access token</dfn>
* <dfn id="client_secret">client secret</dfn>

# Login Flows and Single Page Applications

## Code

OAuth 2 Overview

* uses an authorization server as an intermediary between the client and the resource owner
* the client directs the resource owner to an authorization server
* the authorization server 
 * authenticates the resource owner, 
 * obtains authorization
 * directs the resource owner back to the client with an authorization code

OpenId Connect Overview

* all tokens are returned from the token endpoint
* the token endpoint returns an authorization code to the client
* the client can exchange the authorization code for an ID Token and Access Token. 

Benefits

* the resource owner's credentials are never shared with the client
* the authorization server can authenticate the client
* the authorization server passes the access token directly to the client without exposing it to the user-agent

Use Cases

* clients that can securely maintain a client secret between themselves and the Authorization Server

Sources

* https://tools.ietf.org/html/rfc6749#section-1.3.1
* http://openid.net/specs/openid-connect-core-1_0.html#CodeFlowAuth

## Implicit

## Hybrid

## Client Credentials / Resource Owner Password Grants

# Sources

http://kevinchalet.com/2016/07/13/creating-your-own-openid-connect-server-with-asos-choosing-the-right-flows/