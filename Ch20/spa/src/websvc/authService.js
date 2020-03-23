import Oidc, { User } from "oidc-client";
import config from "./authConfig";

export default class AuthService {
    UserManager;

    constructor(){
        this.UserManager = new Oidc.UserManager(config);

        //this.UserManager.events.addAccessTokenExpired(() => {
        //    console.log("token expired");
        //    this.refreshToken();
        //});
    }

    getUser = async () => {
        const user = await this.UserManager.getUser();
        if (!user) {
            return await this.UserManager.signinRedirectCallback();
        }
        return user;
    };

    signinRedirectCallback = () => {
        this.UserManager.signinRedirectCallback().then(() => {
            window.location = localStorage.getItem("redirectUri") || "";
        });
    };

    refreshTokenCallback = () => {
        this.UserManager.signinSilentCallback();
    }

    refreshToken = () => {
        console.log("refresh token initialized");
        this.UserManager.signinSilent()
        .then((user)=>{
            console.log("signed in", user);
        })
        .catch((err) => {
            console.log(err);
        });
    }

    getUserString = () => {
        return sessionStorage.getItem(`oidc.user:${config.authority}:${config.client_id}`);
    }

    isAuthenticated = () => {
        const userString = this.getUserString();
        const user = userString ? User.fromStorageString(this.getUserString()) : null;
        return user && !user.expired;
    }

    signinRedirect = () => {
        localStorage.setItem("redirectUri", window.location.pathname);
        this.UserManager.signinRedirect({});
    }

    signoutCallback = () => {
        this.UserManager.signoutRedirectCallback();
    }

    signOut = () => {
        this.UserManager.signoutRedirect();
    }
}