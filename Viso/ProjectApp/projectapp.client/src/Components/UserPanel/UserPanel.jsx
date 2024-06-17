import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Button from '@mui/material/Button';
import Avatar from '@mui/material/Avatar';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';

const UserPanel = () => {
    const [requestStatus, setRequestStatus] = useState('');
    const [applicationStatus, setApplicationStatus] = useState('');
    const [user, setUser] = useState(null);

    useEffect(() => {
        const userData = localStorage.getItem('user');
        setUser(userData);
    }, []);

    const requestRestaurateurStatus = () => {
        axios.post(`https://localhost:5001/api/Client/ApplyForRestaurateur?clientID=${user}`)
            .then(() => {
                setRequestStatus('Request sent successfully!');
                checkApplicationStatus();
            })
            .catch(error => {
                console.error('Error sending request:', error);
                setRequestStatus('Failed to send request.');
            });
    };

    const checkApplicationStatus = () => {
        axios.post(`https://localhost:5001/api/Client/GetClientApplicationStatus?clientID=${user}`)
            .then(response => {
                setApplicationStatus(response.data.status);
            })
            .catch(error => {
                console.error('Error fetching application status:', error);
                setApplicationStatus('Error fetching status');
            });
    };

    useEffect(() => {
        if (user && user.clientId) {
            checkApplicationStatus();
        }
    }, [user]);

    if (!user) {
        return <Typography>Loading...</Typography>;
    }

    return (
        <Box display="flex" justifyContent="center" alignItems="center" flexDirection="column" p={3}>
            <Paper elevation={3} sx={{ p: 3, maxWidth: 600, width: '100%' }}>
                <Box display="flex" flexDirection="column" alignItems="center" mb={3}>
                    <Avatar alt={user.userName} src={user.avatar} sx={{ width: 100, height: 100 }} />
                    <Typography variant="h5" mt={2}>{user.userName}</Typography>
                    <Typography variant="body1">{user.email}</Typography>
                    <Typography variant="body1">{user.phoneNumber}</Typography>
                </Box>
                <Box display="flex" flexDirection="column" alignItems="center">
                    <Typography variant="h6">Application Status: {applicationStatus}</Typography>
                    <Button variant="contained" color="primary" onClick={requestRestaurateurStatus} sx={{ mt: 2 }}>
                        Request Restaurateur Status
                    </Button>
                    {requestStatus && <Typography variant="body2" color="error" mt={2}>{requestStatus}</Typography>}
                </Box>
            </Paper>
        </Box>
    );
};

export default UserPanel;
