 import clientRoutes from "../routes/clientRoutes";
 
 const authConfig = {
    authority: "http://localhost:5000",
    client_id: "js",
    redirect_uri: "http://localhost:3000" + clientRoutes.oidc.callback,
    response_type: "code",
    scope:"openid profile api1",
    post_logout_redirect_uri : "http://localhost:3000" + clientRoutes.oidc.signoutCallback,
    automaticSilentRenew: true,
    silent_redirect_uri: "http://localhost:3000" + clientRoutes.oidc.refreshToken
};

export default authConfig;