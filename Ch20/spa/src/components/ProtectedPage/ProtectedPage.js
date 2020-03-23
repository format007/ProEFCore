import React, { Component } from 'react';
import SignOut from "../SignOut";

export default class ProtectedPage extends Component {
    render() {
        return (
            <div>
                protected page

                <SignOut/>
            </div>
        )
    }
}
