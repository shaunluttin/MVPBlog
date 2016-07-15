# Single Page Application Login with ASP.NET Core

# Terminology

* <dfn id="ro">resource owner</dfn>
* <dfn id="client">client</dfn>. Not the same as the user-agent.
* <dfn id="as">authorization server</dfn>
* <dfn id="ac">authorization code</dfn>
* <dfn id="ua">user agent</dfn>

# Login Flows and Single Page Applications

## Code

Steps

* uses an authorization server as an intermediary between the client and the resource owner
* the client directs the resource owner to an authorization server
* the authorization server 
 * authenticates the resource owner, 
 * obtains authorization
 * directs the resource owner back to the client with an authorization code

Benefits

* the resource owner's credentials are never shared with the client
* the authorization server can authenticate the client
* the authorization server passes the access token directly to the client without exposing it to the user-agent

Sources

OpenId Connect, http://openid.net/specs/openid-connect-core-1_0.html#CodeFlowAuth
OAuth 2, https://tools.ietf.org/html/rfc6749#section-1.3.1 

## Implicit

## Hybrid

## Client Credentials / Resource Owner Password Grants