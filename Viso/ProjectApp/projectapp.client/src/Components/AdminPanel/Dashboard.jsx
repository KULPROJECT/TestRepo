import React from 'react';
import styles from './AdminPanel.module.scss';
import { Outlet } from 'react-router-dom';

const Dashboard = () => {
    return (
        <div className={styles.dashboard}>
            <h1>Dashboard</h1>
            <p>Welcome to the admin dashboard!</p>
            <Outlet />
        </div>
    );
};

export default Dashboard;
