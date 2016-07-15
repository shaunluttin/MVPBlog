# Single Page Application Login with ASP.NET Core

# Meta

* Moratorium: Approx 20 hours, then make another decision. 
* 15 July 2016, 4 hours

# Terminology

* <dfn id="ua">user-agent</dfn>
    * A user-agent is software acting on behalf of the user.
    * Common examples are a Web Browser, native application, or OS component that is communicating over HTTP.
    * https://en.wikipedia.org/wiki/User_agent 
* <dfn id="ro">resource owner</dfn>
    * This is best thought of as THE PERSON USING YOUR APPLICATION.
    * Specifically, it's an OAuth2 term meaning any entity 
    * that is capable of granting access to a protected resource.
    * https://tools.ietf.org/html/rfc6749#section-1.1
* <dfn id="c">client / relying party</dfn>
    * This is best thought of as THE APPLICATION THAT YOU ARE BUILDING.
    * In OIDC this is called the Relying Party; 
    * in OAuth2 this is called the client.
    * Both refer to any application that needs permission 
    * to access protected resources on behalf of a person.
    * http://openid.net/specs/openid-connect-core-1_0.html#Terminology 
    * https://tools.ietf.org/html/rfc6749#section-1.1
* <dfn>resource server</dfn>
    * The server that is hosting the protected resources and
    * that is capable of receiving an access token to unlock those resources.
    * https://tools.ietf.org/html/rfc6749#section-1.1 
* <dfn id="as">authorization server</dfn>
    * A server with an authorization endpoint and a token endpoint
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

## Code (OAuth2 & OIDC)

OAuth2 Overview

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
* the authorization server can authenticate the client (optionally)
* the authorization server passes the access token directly to the client without exposing it to the user-agent

Use Cases

* clients that can securely maintain a client secret between themselves and the Authorization Server

Sources

* https://tools.ietf.org/html/rfc6749#section-1.3.1
* http://openid.net/specs/openid-connect-core-1_0.html#CodeFlowAuth

## Implicit (OAuth2 & OIDC)

> implicit adj. Having no reservations or doubts; unquestioning or unconditional; usually said of faith or trust. 

OAuth 2 Overview

* same as the `code` flow with the following differences: 
* the authorization server 
    * does NOT direct the resource owner back to the client with an authorization code
    * does NOT authenticate the client before issuing the access code
    * instead, after authentication and authorizations, 
    * immedicately directs the resource owner back to the client with an acces code

OpenId Connect Overview

* the authorization endpoint
* returns an access token and id token 
* directly to the client
* via the user agent

Benefits

* improved responsiveness of browser-based applications by reducing round trips

Risks

* the authorization server exposes the user-agent to the access token
* the authorization server does not authenticate the client

Use Cases

* Relying parties that run in a web browser using JavaScript.

Sources

* https://www.wordnik.com/words/implicit
* https://tools.ietf.org/html/rfc6749#section-1.3.2 
* http://openid.net/specs/openid-connect-core-1_0.html#ImplicitFlowAuth

## Resource Owner Password Grants (OAuth2)

OAuth2 Overview

* the person passes username/password to the client via the user-agent
* the client passes the username/password to the authorization server
* the authorization server responds with an access token

Risks

* the client has direct access to the person's username/password

Use Cases

* There is high trust between the resource owner and the client. 
* E.g. client is part of the operating system / is a highly privileged application.

Sources

* https://tools.ietf.org/html/rfc6749#section-1.3.3

## Client Credentials (OAuth2)

OAuth2 Overview

Use Cases

* When the client is accessing its own resources, or
* the client is accessing resources for which it has already arranged access permission.

Sources

* https://tools.ietf.org/html/rfc6749#section-1.3.4

## Hybrid (OIDC)

OpenID Connect Overview

Response Type Combinations

* `code token` [Why do we need the code when we already have an access_token?]
* `code id_token` [This makes sense. We have an id_token and can retrieve an access_token when needed.]
* `id_token token` [This seems just like the implicit flow.] 
* `code id_token token` [Why?]

Sources

* http://openid.net/specs/openid-connect-core-1_0.html#HybridFlowAuth

## Combined Flows

# Sources

* http://kevinchalet.com/2016/07/13/creating-your-own-openid-connect-server-with-asos-choosing-the-right-flows/
* https://github.com/SoftwareMasons/aurelia-openiddict/
* https://github.com/openiddict/openiddict-core
* https://leastprivilege.com/2016/01/17/which-openid-connectoauth-2-o-flow-is-the-right-one Interesting discussion of the hybrid flow. 