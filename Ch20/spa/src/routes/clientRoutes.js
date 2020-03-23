const clientRoutes = {
    oidc : {
        callback: "/signin-oidc",
        refreshToken: "/refreshtoken",
        signoutCallback: "/signout-oidc"
    },
    register: "/register",
    signin: "/signin",
    signout: "/signout"
}

export default clientRoutes;