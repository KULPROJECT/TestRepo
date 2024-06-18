import React, { useEffect, useState } from 'react';
import Avatar from '@mui/material/Avatar';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Paper from '@mui/material/Paper';
import Typography from '@mui/material/Typography';
import axios from 'axios';

const UserPanel = () => {
    const [requestStatus, setRequestStatus] = useState('');
    const [applicationStatus, setApplicationStatus] = useState('');
    const [user, setUser] = useState(null);
    const [userD, setUserD] = useState(null);

    useEffect(() => {
        const userId = localStorage.getItem('user');
        setUser(userId);
    }, []);

    useEffect(() => {
            getClientData();
            checkApplicationStatus();
        
    }, [user]);

    const getClientData = () => {
        axios.get(`https://localhost:5001/api/Client/GetClientData?clientID=${user}`)
            .then(response => {
                console.log(response.data)
                setUserD(response.data);
            })
            .catch(error => console.error('Error fetching user data:', error));
    };

    const requestRestaurateurStatus = () => {
        axios.post(`https://localhost:5001/api/Client/ApplyForRestaurateur?clientID=${user}`)
            .then(() => {
                setRequestStatus('Sent successfully!');
                checkApplicationStatus();
            })
            .catch(error => {
                console.error('Error sending request:', error);
                setRequestStatus('Failed to send request.');
            });
    };

    const checkApplicationStatus = () => {
        axios.get(`https://localhost:5001/api/Client/GetClientApplicationStatus?clientID=${user}`)
            .then(response => {
                setApplicationStatus(response.data.status);
            })
            .catch(error => {
                console.error('Error fetching application status:', error);
                setApplicationStatus('Waiting for admin decision');
            });
    };

    if (!userD) {
        return <Typography>Loading...</Typography>;
    }

    return (
        <Box display="flex" justifyContent="center" alignItems="center" flexDirection="column" p={3}>
            <Paper elevation={3} sx={{ p: 3, maxWidth: 600, width: '100%' }}>
                <Box display="flex" flexDirection="column" alignItems="center" mb={3}>
                    <Avatar sx={{ width: 100, height: 100 }} />
                    {userD.map(user => (
                        <div key={user.id }>
                    <Typography variant="h5" mt={2} >{user.userName}</Typography>
                    <Typography variant="body1">{user.email}</Typography>
                    <Typography variant="body1">{user.phoneNumber}</Typography>
                     </div>
                    ))}
                </Box>
                <Box display="flex" flexDirection="column" alignItems="center">
                    <Typography variant="h6">Application Status: {applicationStatus}</Typography>
                    <Button variant="contained" color="primary" onClick={requestRestaurateurStatus} sx={{ mt: 2 }}>
                        Apply for Restaurateur Status
                    </Button>
                    {requestStatus && <Typography variant="body2" color="error" mt={2}>{requestStatus}</Typography>}
                </Box>
            </Paper>
        </Box>
    );
};

export default UserPanel;
