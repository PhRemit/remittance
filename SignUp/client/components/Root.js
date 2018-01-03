import React from "react";

import NavigationBar from "./NavigationBar";
import FlashMessagesList from "./flash/FlashMessagesList";

export class Root extends React.Component {
    render() {
        return (
            <div className="container">
                <NavigationBar />
                <br /><br /><br />
                <FlashMessagesList />
                {this.props.children}
            </div>
        )
    }
}
