import React from 'react';
import {Link} from "react-router-dom";
import clientRoutes from "../routes/clientRoutes";

const MainMenu = () => {
    return <div>
        <Link to={clientRoutes.register}>Register</Link>
        <Link to={clientRoutes.signin}>Sign in</Link>
    </div>
};

export default MainMenu;