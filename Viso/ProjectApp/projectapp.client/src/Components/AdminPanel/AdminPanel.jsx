import React from 'react';
import { Outlet } from 'react-router-dom';
import Sidebar from './Sidebar';
import Header from './Header';
import styles from './AdminPanel.module.scss';

const AdminPanel = () => {
    return (
        <div className={styles.adminPanel}>
            <Header />
            <div className={styles.main}>
                <Sidebar />
                <div className={styles.content}>
                    <Outlet />
                </div>
            </div>
        </div>
    );
};

export default AdminPanel;
