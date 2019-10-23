import React from "react";
import oidcManager from "../OidcManager";

export default () => {
  function handleLogin() {
    oidcManager.signinRedirect();
  }
  function handleCallApi() {
    oidcManager.getUser().then(function(user) {
      var url = "https://api.website.com:5003/identity";

      var xhr = new XMLHttpRequest();
      xhr.open("GET", url);
      xhr.onload = function() {
        const responseText = JSON.stringify(
          JSON.parse(xhr.responseText),
          null,
          2
        );
        let result = { status: xhr.status, responseText: responseText };
        setApiResult(result);
      };
      xhr.setRequestHeader("Authorization", "Bearer " + user.access_token);
      xhr.send();
    });
  }
  function handleLogout() {
    oidcManager.signoutRedirect();
  }

  const [user, setUser] = React.useState(null);
  const [apiResult, setApiResult] = React.useState(null);

  React.useEffect(() => {
    if (oidcManager) {
      oidcManager.getUser().then(userResult => {
        if (userResult) {
          if (!user) {
            setUser(userResult);
          }
        }
      });
    }
  });

  return (
    <div>
      <button onClick={handleLogin}>Login</button>
      <button onClick={handleCallApi}>Call Api</button>
      <button onClick={handleLogout}>Logout</button>
      {user ? (
        <div>
          <div>
            <span>User logged in.</span>
          </div>
          <pre>{JSON.stringify(user.profile, null, 2)}</pre>
        </div>
      ) : (
        <div>
          <span>User not logged in.</span>
        </div>
      )}
      {apiResult && (
        <div>
          <div>Status: {apiResult.status}</div>
          <pre>{apiResult.responseText}</pre>
        </div>
      )}
    </div>
  );
};
