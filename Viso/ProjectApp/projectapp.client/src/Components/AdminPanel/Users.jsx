import React, { useState, useEffect } from 'react';
import styles from './AdminPanel.module.scss';
import axios from 'axios';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';

const Users = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:5001/api/Client/GetClients')
            .then(response => setUsers(response.data))
            .catch(error => console.error('Error fetching users:', error));
    }, []);

    return (
        <div className={styles.users}>
            <h1>Users</h1>
            <List>
                {users.map(user => (
                    <ListItem key={user.id}>
                        <ListItemText primary={user.name} />
                    </ListItem>
                ))}
            </List>
        </div>
    );
};

export default Users;
