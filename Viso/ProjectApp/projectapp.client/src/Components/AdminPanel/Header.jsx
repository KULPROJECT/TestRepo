import React from 'react';
import styles from './AdminPanel.module.scss';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import AccountCircle from '@mui/icons-material/AccountCircle';

const Header = () => {
    return (
        <AppBar position="static" className={styles.appBar}>
            <Toolbar>
                <Typography variant="h6" className={styles.title}>
                    Admin Panel
                </Typography>
                <div>
                    <IconButton edge="end" color="inherit">
                        <AccountCircle />
                    </IconButton>
                </div>
            </Toolbar>
        </AppBar>
    );
};

export default Header;
