import React from 'react';
import { Routes, Route } from 'react-router-dom';
import LoginForm from './Components/LoginForm/LoginForm';
import CreateUser from './Components/CreateUser/CreateUser';
import HomePage from './Components/HomePage/HomePage';
import AdminPanel from './Components/AdminPanel/AdminPanel';

function App() {
    return (
        <>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginForm />} />
                <Route path="/createuser" element={<CreateUser />} />
                <Route path="/adminpanel" element={<AdminPanel />} />
            </Routes>
        </>
    );
}

export default App;
