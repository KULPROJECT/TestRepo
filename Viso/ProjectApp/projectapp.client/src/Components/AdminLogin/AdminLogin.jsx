import React, { useState } from 'react';
import { TextField, Button, Typography, Paper, Grid } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const AdminLogin = () => {
    const [userName, setUsername] = useState('');
    const [pass, setPassword] = useState('');
    const [error, setError] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        const loginData = JSON.stringify([userName, pass]);

        try {
            const response = await axios.post('https://localhost:5001/api/Login/CheckLoginCredentials', loginData, {
                headers: { "Content-Type": "application/json" }
            });
            const { adminId, userName: adminUsername } = response.data;
            localStorage.setItem('admin', JSON.stringify({ adminId, userName: adminUsername }));
            navigate('/adminpanel');
        } catch (error) {
            setError('Failed to login. Please try again.');
            console.error('Error submitting form:', error);
        }
    };

    return (
        <Grid container justifyContent="center" alignItems="center" style={{ minHeight: '100vh' }}>
            <Grid item xs={12} sm={6} md={4}>
                <Paper elevation={3} style={{ padding: '20px' }}>
                    <Typography variant="h5" gutterBottom>
                        Admin Login
                    </Typography>
                    {error && <Typography color="error" gutterBottom>{error}</Typography>}
                    <form onSubmit={handleSubmit}>
                        <TextField
                            label="Username"
                            variant="outlined"
                            fullWidth
                            margin="normal"
                            value={userName}
                            onChange={(e) => setUsername(e.target.value)}
                            required
                        />
                        <TextField
                            label="Password"
                            type="password"
                            variant="outlined"
                            fullWidth
                            margin="normal"
                            value={pass}
                            onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                        <Button type="submit" variant="contained" color="primary" fullWidth>
                            Login
                        </Button>
                    </form>
                </Paper>
            </Grid>
        </Grid>
    );
};

export default AdminLogin;
