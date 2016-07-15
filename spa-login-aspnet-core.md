# Single Page Application Login with ASP.NET Core

# Meta

* Moratorium: Approx 20 hours, then make another decision. 
* 15 July 2016, 1 hour

# Terminology

* <dfn id="ro">resource owner</dfn>
* <dfn id="ua">user-agent</dfn>
    * A user-agent is software acting on behalf of the user.
    * Common examples are a Web Browser, native application, or OS component that is communicating over HTTP.
    * https://en.wikipedia.org/wiki/User_agent 
* <dfn id="c">client</dfn>
* <dfn id="re">redirection endpoint</dfn>
    * the authorization server uses the redirection endpoint
    * to return responses to the client
    * via the resource-owner user agent
    * https://tools.ietf.org/html/rfc6749#section-3    
* <dfn id="as">authorization server</dfn>
    * a server with two endpoints
    * the authorization endpoint and the token endpoint
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
    * The token endpoint typically authenticates the client.
    * https://tools.ietf.org/html/rfc6749#section-3
* <dfn id="ac">authorization code</dfn>
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