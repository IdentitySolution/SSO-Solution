import Oidc from "oidc-client";

const config = {
  authority: "http://identity.website.com:5000",
  client_id: "react",
  redirect_uri: "http://react.website.com:5005/callback",
  response_type: "code",
  scope: "openid profile api1",
  post_logout_redirect_uri: "http://react.website.com:5005/"
};

const oidcManager = new Oidc.UserManager(config);

oidcManager.events.addUserSignedOut(() => {
  oidcManager.signoutRedirect();
});
export default oidcManager;
