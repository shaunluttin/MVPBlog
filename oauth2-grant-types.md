
# Authorization Grant Type

* The client uses the access token to access the user's private resources.
* The resource owner (end user) must grant the client permission to access those resources. 
* OAuth 2.0 has three standard ways of representing that grant.
* Each grant type also has a flow. 

## Authorization Code Grant

* **The resource owner gives permission to the client via the authorization endpoint.**

* The authorization endpoint responds with an authorization code. 
* The client presents that authorization code to the token endpoint.
* The token endpoint verifies the client secret. 

* **The token endpoint responds with an access token.**

* The benefits are that 
    * the client does not see the resource owner's username/password
    * the token endpoint verifies the client
* tags: redirection-based-flow, confidential-client, access-token, refresh-token, client-secret-verification, no-stored-credentials


## Implicit Grant

* **The resource owner gives permission to the client via the authorization endpoint.**

* The authorization endpoint verifies the redirect URL.

* **The authorization endpoint responds with an access token.**

* The benefits are that
    * the client does not see the resource owner's username/password
    * we can do this in a fully public client
* tags: redirection-based-flow, public-client, access-token, no-refresh-token, client-redirect-verification, no-stored-credentials

## Resource Owner Password Credentials Grant

* The client presents the resource owner's username/password to the authorization server.
* **The authorization endpoint responds with an access token.

* Note: only use this flow when others are not available.
* tags: high-trust-client, access-token, refresh-token

## Extension Grants

* These are ways for Authentication Providers to offer other, non-standard grant types.