import React, { useState } from "react";
import "./App.css";
import LoginForm from "./LoginForm";
import LoginAttemptList from "./LoginAttemptList";

const App = () => {
    const [loginAttempts, setLoginAttempts] = useState([]);

    const handleLoginAttempt = (loginData) => {
        setLoginAttempts((prevAttempts) => [...prevAttempts, loginData]);
    };

    return (
        <div className="App">
            <LoginForm onSubmit={handleLoginAttempt} />
            <LoginAttemptList attempts={loginAttempts} />
        </div>
    );
};

export default App;