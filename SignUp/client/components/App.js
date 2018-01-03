import React from "react";
import { Root } from "./Root";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import Greetings from "./Greetings";
import SignupPage from "./signup/SignupPage";
import LoginPage from "./login/LoginPage";
import NewEventPage from "./events/NewEventPage";

import requireAuth from "../utils/requireAuth";

export class App extends React.Component {
  render() {
    return(
      <BrowserRouter>
          <div>
              <Root>
                  <Switch>
                      <Route exact path="/" component={ Greetings } />
                      <Route path="/home" component={ Greetings } />
                      <Route path="/signup" component={ SignupPage } />
                      <Route path="/login" component={ LoginPage } />
                      <Route path="/new-event" component= { requireAuth(NewEventPage) } />
                  </Switch>
              </Root>
          </div>
      </BrowserRouter>
    );
  }
}
