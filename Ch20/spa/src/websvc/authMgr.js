import Oidc from "oidc-client";

var config = {
    authority: "http://localhost:5000",
    client_id: "js",
    redirect_uri: "http://localhost:3000/callback",
    response_type: "code",
    scope:"openid profile api1",
    post_logout_redirect_uri : "http://localhost:3000/",
};

const mgr = new Oidc.UserManager(config);

export default mgr;