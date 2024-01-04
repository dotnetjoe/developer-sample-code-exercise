import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ login, password }) => (
    <li>
        <strong>Login:</strong> {login}, <strong>Password:</strong> {password}
    </li>
);

const LoginAttemptList = ({ attempts }) => {
    const [filter, setFilter] = useState("");

    const filteredAttempts = attempts.filter(
        (attempt) =>
            attempt.login.toLowerCase().includes(filter.toLowerCase()) ||
            attempt.password.toLowerCase().includes(filter.toLowerCase())
    );

    return (
        <div className="Attempt-List-Main">
            <p>Recent activity</p>
            <input
                type="input"
                placeholder="Filter..."
                value={filter}
                onChange={(e) => setFilter(e.target.value)}
            />
            <ul className="Attempt-List">
                {filteredAttempts.map((attempt, index) => (
                    <LoginAttempt key={index} {...attempt} />
                ))}
            </ul>
        </div>
    );
};

export default LoginAttemptList;