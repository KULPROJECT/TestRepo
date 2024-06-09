import React from 'react';
import { BrowserRouter as Router,Routes, Route } from 'react-router-dom';
import LoginForm from './Components/LoginForm/LoginForm';
import CreateUser from './Components/CreateUser/CreateUser';
import HomePage from './Components/HomePage/HomePage';
import AdminPanel from './Components/AdminPanel/AdminPanel';
import Dashboard from './Components/AdminPanel/Dashboard';
import Users from './Components/AdminPanel/Users';
function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginForm />} />
                <Route path="/createuser" element={<CreateUser />} />
                <Route path="adminpanel" element={<AdminPanel />} >
                    <Route path="dashboard" element={<Dashboard />} />
                    <Route path="users" element={<Users />} />
                </Route>
            </Routes>
        </Router>
    );
}

export default App;
