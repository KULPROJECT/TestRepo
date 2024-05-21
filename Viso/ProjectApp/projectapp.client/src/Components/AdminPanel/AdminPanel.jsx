import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Sidebar from './Sidebar';
import Header from './Header';
import Dashboard from './Dashboard';
import Users from './Users';
import Products from './Products';
import styles from './AdminPanel.module.scss';

const AdminPanel = () => {
    return (
        <div className={styles.adminPanel}>
            <Header />
            <div className={styles.main}>
                <Sidebar />
                <div className={styles.content}>
                    <Routes>
                        <Route path="/users" element={<Dashboard />} />
                        <Route path="/dashboard" element={<Dashboard />} />
                        <Route path="/" element={<Users />} />
                        <Route path="/products" element={<Products />} />
                    </Routes>
                </div>
            </div>
        </div>
    );
};

export default AdminPanel;
