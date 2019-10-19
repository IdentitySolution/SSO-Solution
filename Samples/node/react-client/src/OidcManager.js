import Oidc from "oidc-client";

const config = {
  authority: "https://identity.website.com:5001",
  client_id: "react",
  redirect_uri: "https://react.website.com:5011/callback",
  response_type: "code",
  scope: "openid profile api1",
  post_logout_redirect_uri: "https://react.website.com:5011/"
};

const oidcManager = new Oidc.UserManager(config);

oidcManager.events.addUserSignedOut(() => {
  oidcManager.signoutRedirect();
});
export default oidcManager;
