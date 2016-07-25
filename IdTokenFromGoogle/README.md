
In this example, we will use Google to authenticate our end-user. Once we know who are user is, we will no longer interact with Google. If we wanted to do further secure interactions with Google, we would request an `access_token` in addition to an `id_token`.

Since we're using a single page application, we'll use the Implicit flow to acquire an `id_token` from Google. Recall that the [Implicit Flow follows the following steps][1]:

1. Client prepares an Authentication Request containing the desired request parameters.
1. Client sends the request to the Authorization Server.
1. Authorization Server Authenticates the End-User.
1. Authorization Server obtains End-User Consent/Authorization.
1. Authorization Server sends the End-User back to the Client with an ID Token and, if requested, an Access Token.
1. Client validates the ID token and retrieves the End-User's Subject Identifier.

Since we're using Google to authenticate, we'll use their [recommended steps and client-side library][2]. Instead of obtaining an access token, though, we will instead request only an id token.

1. Obtain OAuth 2.0 credentials from the Google API Console.
2. Obtain an access token from the Google Authorization Server.

[0]: https://developers.google.com/identity/protocols/OpenIDConnect

[1]: http://openid.net/specs/openid-connect-core-1_0.html#ImplicitFlowSteps

[2]: https://developers.google.com/identity/protocols/OAuth2?csw=1#clientside