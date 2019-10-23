import React from "react";
import oidcManager from "../OidcManager";

export default props => {
  oidcManager
    .signinRedirectCallback()
    .then(function() {
      props.history.push("/");
    })
    .catch(function(e) {
      console.error(e);
    });
  return <div>Callback</div>;
};
