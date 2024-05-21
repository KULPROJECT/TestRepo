import React from 'react';
import { NavLink } from 'react-router-dom';
import styles from './AdminPanel.module.scss';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import DashboardIcon from '@mui/icons-material/Dashboard';
import PeopleIcon from '@mui/icons-material/People';
import InventoryIcon from '@mui/icons-material/Inventory';

const Sidebar = () => {
    return (
        <div className={styles.sidebar}>
            <List>
                <ListItem button component={NavLink} to="/dashboard" activeClassName={styles.activeLink}>
                    <ListItemIcon><DashboardIcon sx={{ color: 'white' }} /></ListItemIcon>
                    <ListItemText primary="Dashboard" />
                </ListItem>
                <ListItem button component={NavLink} to="/users" activeClassName={styles.activeLink}>
                    <ListItemIcon><PeopleIcon sx={{ color: 'white' }} /></ListItemIcon>
                    <ListItemText primary="Users" />
                </ListItem>
                <ListItem button component={NavLink} to="/products" activeClassName={styles.activeLink}>
                    <ListItemIcon><InventoryIcon sx={{ color: 'white' }} /></ListItemIcon>
                    <ListItemText primary="Products" />
                </ListItem>
            </List>
        </div>
    );
};

export default Sidebar;
