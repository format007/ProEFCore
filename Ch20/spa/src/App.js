import React from 'react';
import './App.css';
import MainPage from "./components/MainPage";
import { BrowserRouter as Router} from 'react-router-dom';
import store from "./store";
import {Provider} from "react-redux";


function App() {
  return (
    <div className="App">
      <Provider store={store}>
        <Router>
          <MainPage/>
        </Router>
      </Provider>
    </div>
  );
}

export default App;