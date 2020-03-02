import Axios from "axios";

class LoginAuth {
    constructor(authUrl, username, password){
        this.authUrl = authUrl;
        this.username = username;
        this.password = password;
    }

    async login(){
        let authFormResp = await Axios.get(this.authUrl);
        
        let regexp = /<input name="__RequestVerificationToken" type="hidden" value="([^"]+)/;
        let verificationToken = authFormResp.data.match(regexp)[1];
        console.log(verificationToken);

        var formData = new FormData();

        formData.set("username", this.username);
        formData.set("password", this.password);
        formData.set("__RequestVerificationToken", verificationToken);
        formData.set("RememberLogin", false);
        formData.set("button", "login");

        let authLoginResp = await Axios.post(this.authUrl, formData, {headers: {'Content-Type': 'multipart/form-data' }});
        console.log(authLoginResp.data);
    }
}

export default LoginAuth;