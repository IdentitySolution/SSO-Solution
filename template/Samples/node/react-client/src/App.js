import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";

import Home from "./components/Home";
import Callback from "./components/Callback";

function App() {
  return (
    <div>
      <BrowserRouter>
        <Switch>
          <Route exact path="/" component={Home} />
          <Route path="/callback" component={Callback} />
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
