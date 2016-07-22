# Single Page Application Login with ASP.NET Core

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
* <dfn id="auth_grant">authorization grant</dfn>
    * The authorization grant is a credential
    * that represents the resource owner's consent
    * to let an application access its protected resources. 
    * An application in possession of this credential, 
    * can access the end-users stuff.
* <dfn id="auth_code">authorization code</dfn>
    * The authorization code is a type of authorization grant. 
    * That is, it represents the end-user's 
    * consent to let FoobarApp access protected resources.
    * The authorization code, though, does not work to access protected resources;  
    * rather, protected resource access requires an upgrade to an access token.
    * The audience for an authorization code is a token endpoint.
    * We can get an access token from the token endpoint 
    * by presenting the authorization code AND FoobarApp's client secret.
    * Why not just use an authorization code to access protected resources?
        * First, the authorization code only works for the relying party, 
        * which has to verify its identity before obtaining an access token. 
        * Second, we can pass the authorization code to the user-agent without worrying too much about security, 
        * and be more careful with the access token by passing it directly to the relying party.
* <dfn id="id_token">id token</dfn>
    * This is verifiable.
* <dfn id="access_token">access token</dfn>
    * The access token is a string representing an authorization issued to a relying party (aka a client).
    * Possessing an access token means three things have happened: 
    * 1. The authorization server has confirmed the end-users identity. 
    * 2. The end-user has given consent for FoobarApp to access protected resources.
    * 3. FoobarApp has verified its identity via presentation its client_secret.
    * 4. and FoobarApp has verified its possession of the authorization code.
    * The access token 
        * is not verifiable.
        * is opaque to the client. 
        * represents specific scopes and durations that the resource owner granted (and the resource & authorization servers enforce).
    * https://tools.ietf.org/html/rfc6749#section-1.4
* <dfn id="client_secret">client secret</dfn>
    * This is not a real secret, because we store it on the client, which is not entirely secure.
    * 
* <dfn id="refresh_token">refresh token</dfn>

# Login Flows and Single Page Applications

##  Code Grant (OAuth2 & OIDC)

The authorization grant, in this case, is an authorization code.

### Code Grant Trust Levels

The authorization server does not trust FoobarApp with people's usernames & passwords,
because FoobarApp could store those credentials, and use them to completely impersonate people.

No. `username/password --> FoobarApp (risk: might store it) --> authorization server`

The authorization server does trust the user-agent with usernames & passwords, 
as long as the user-agent has a known policy of asking a person before storing zer credentials (e.g. major web browsers).

Yes. `username/password --> user-agent --> authorization server`

The authorization server does not trust the user-agent with access tokens,
because the user-agent must store the token before passing it to FoobarApp.
The problem with storage is that the user-agent might be a public place. 
A malicious person could extract someone's token from e.g. a web browser at a library kiosk,
and then use the token to access that person's protected resources.

No. `access token --> user agent (must store it, risk: might reveal it) --> FoobarApp`

The authorization server does trust FoobarApp with people's access tokens, 
because access tokens are both time & scope limited, and 
FoobarApp stores access tokens in a less public location than user-agents do. 
[TODO Why is FoobarApp's storage considered to be more secure than the user-agent's storage?]

Yes. `authorization server --> access token --> FoobarApp`

### OAuth2 Overview

* uses an authorization server as an intermediary between the client and the resource owner
* the client directs the resource owner to an authorization server
* the authorization server 
    * authenticates the resource owner, 
    * obtains authorization
    * directs the resource owner back to the client with an authorization code

### OpenId Connect Overview

* all tokens are returned from the token endpoint
* the token endpoint returns an authorization code to the client
* the client can exchange the authorization code for an ID Token and Access Token. 

### Benefits

* the resource owner's credentials are never shared with the client
* the authorization server can authenticate the client (optionally)
* the authorization server passes the access token directly to the client without exposing it to the user-agent

### Use Cases

* clients that can securely maintain a client secret between themselves and the Authorization Server
* note: it is tough to hide the client secret thoroughly.

### Sources

* https://tools.ietf.org/html/rfc6749#section-1.3.1
* http://openid.net/specs/openid-connect-core-1_0.html#CodeFlowAuth

## Implicit Grant (OAuth2 & OIDC)

> implicit adj. Having no reservations or doubts; unquestioning or unconditional; usually said of faith or trust. 

### OAuth 2 Overview

The authorization grant, in this case, is non-existant!

* same as the `code` flow with the following differences: 
* the authorization server 
    * does NOT direct the resource owner back to the client with an authorization code
    * does NOT authenticate the client before issuing the access code
    * instead, after authentication and authorizations, 
    * immedicately directs the resource owner back to the client with an acces code

### OpenId Connect Overview

* the authorization endpoint
* returns an access token and id token 
* directly to the client
* via the user agent

### Benefits

* improved responsiveness of browser-based applications by reducing round trips

### Risks

* the authorization server exposes the user-agent to the access token
* the authorization server does not authenticate the client

### Use Cases

* Relying parties that run in a web browser using JavaScript.

### Sources

* https://www.wordnik.com/words/implicit
* https://tools.ietf.org/html/rfc6749#section-1.3.2 
* http://openid.net/specs/openid-connect-core-1_0.html#ImplicitFlowAuth

## Resource Owner Password Grant (OAuth2)

### OAuth2 Overview

The authorization grant, in this case, is...

* the person passes username/password to the client via the user-agent
* the client passes the username/password to the authorization server
* the authorization server responds with an access token

### Risks

* the client has direct access to the person's username/password

### Use Cases

* There is high trust between the resource owner and the client. 
* E.g. client is part of the operating system / is a highly privileged application.

### Sources

* https://tools.ietf.org/html/rfc6749#section-1.3.3

## Client Credentials Grant (OAuth2)

### OAuth2 Overview

The authorization grant, in this case, is...

### Use Cases

* When the client is accessing its own resources, or
* the client is accessing resources for which it has already arranged access permission.
* E.g. machine-to-machine communication.

### Sources

* https://tools.ietf.org/html/rfc6749#section-1.3.4

## Hybrid (OIDC)

### OpenID Connect Overview

TODO 

### Response Type Combinations

* `code token` [Why do we need the code when we already have an access_token?]
* `code id_token` [This makes sense. We have an id_token and can retrieve an access_token when needed.]
* `id_token token` [This seems just like the implicit flow.] 
* `code id_token token` [Why?]

### Benefits

* This can compliment the code flow by including the id_token in the initial response from the authorization endpoint
* Since the id_token is verifiable, we can validate it before requesting the access token.

### Sources

* http://openid.net/specs/openid-connect-core-1_0.html#HybridFlowAuth
* http://openid.net/specs/oauth-v2-multiple-response-types-1_0.html

## Combined Flows

# Sources

* http://kevinchalet.com/2016/07/13/creating-your-own-openid-connect-server-with-asos-choosing-the-right-flows/
* https://github.com/SoftwareMasons/aurelia-openiddict/
* https://github.com/openiddict/openiddict-core
* https://leastprivilege.com/2016/01/17/which-openid-connectoauth-2-o-flow-is-the-right-one 
    * Interesting discussion of the hybrid flow. 