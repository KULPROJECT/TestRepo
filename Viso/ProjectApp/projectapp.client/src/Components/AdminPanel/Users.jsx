import React, { useState, useEffect } from 'react';
import styles from './AdminPanel.module.scss';
import axios from 'axios';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

const Users = () => {
    const [users, setUsers] = useState([]);

    const gUsers = () => {
        axios.get('https://localhost:5001/api/Administrator/GetClients')
            .then(response => {
                console.log(response);
                const getUsers = response.data;
                setUsers(getUsers);
            })
            .catch(error => console.error('Error fetching users:', error));
    };

    useEffect(() => {
        gUsers();
    }, []);

    return (
        <div className={styles.users}>
            <h1>Users</h1>
            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell>Name</TableCell>
                            <TableCell>Email</TableCell>
                            <TableCell>Phone Number</TableCell>
                            <TableCell>Status Reastauretur</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {users.map(user => (
                            <TableRow key={user.id}>
                                <TableCell>{user.clientId}</TableCell>
                                <TableCell>{user.userName}</TableCell>
                                <TableCell>{user.email}</TableCell>
                                <TableCell>{user.phoneNumber}</TableCell>
                                <TableCell>{user.restaurateurApplication}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
};

export default Users;
