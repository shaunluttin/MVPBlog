
# Terminology in my own words.

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