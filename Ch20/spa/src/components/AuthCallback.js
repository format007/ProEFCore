import React, { Component } from 'react';
import Oidc from "oidc-client";

export default class AuthCallback extends Component {

    componentDidMount(){
        new Oidc.UserManager({ response_mode: "query" }).signinRedirectCallback().then(function () {
            window.location = "/order";
        }).catch(function (e) {
            console.error(e);
        });
    }

    render() {
        return (
            <div>
                AuthCallback
            </div>
        )
    }
}