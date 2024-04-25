import * as React from 'react';
import { useState } from 'react';
import styles from './CreateUser.module.scss';
import Button from '@mui/material/Button';
import Paper from '@mui/material/Paper';
import IconButton from '@mui/material/IconButton';
import TextField from '@mui/material/TextField';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputAdornment from '@mui/material/InputAdornment';
import FormControl from '@mui/material/FormControl';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Divider from '@mui/material/Divider';
import { Link } from 'react-router-dom';
import axios from 'axios';

function CreateUser() {
    const [formData, setFormData] = useState({
        username: '',
        email: '',
        phoneNumber: '',
        pass: ''
    });
    const [showPassword, setShowPassword] = useState(false);
    const [error, setError] = useState('');

    const handleChange = (event) => {
        setFormData({ ...formData, [event.target.name]: event.target.value });
    };

    const handleClickShowPassword = () => {
        setShowPassword(!showPassword);
    };

    const handleMouseDownPassword = (event) => {
        event.preventDefault();
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const response = await axios.post('https://localhost:5001/api/Registration/AddUser', formData);
            console.log('Server response:', response.data);
            
        } catch (error) {
            setError('Failed to create account. Please try again.');
            console.error('Error submitting form:', error.response?.data || error.message);
        }
    };

    return (
        <div className={styles.container}>
            <form onSubmit={handleSubmit}>
                <Paper className={styles.MuiPaperElevation3} elevation={3}>
                    <LockOutlinedIcon sx={{ color: 'purple', fontSize: 45, width: 1 }} />
                    <h1 className={styles.header1}>CREATE ACCOUNT</h1>
                    <Divider sx={{ mb: 1, border: 1.2, borderRadius: 4, opacity: 0.2, width: '75%' }} />
                    {error && <p className={styles.error}>{error}</p>}
                    <TextField
                        name="username"
                        label="Username"
                        type="text"
                        onChange={handleChange}
                        value={formData.username}
                        margin="normal"
                        fullWidth
                    />
                    <TextField
                        name="email"
                        label="Email"
                        type="email"
                        onChange={handleChange}
                        value={formData.email}
                        margin="normal"
                        fullWidth
                    />
                    <TextField
                        name="phoneNumber"
                        label="Phone Number"
                        type="tel"
                        onChange={handleChange}
                        value={formData.phoneNumber}
                        margin="normal"
                        fullWidth
                    />
                    <FormControl fullWidth margin="normal" variant="outlined">
                        <OutlinedInput
                            name="pass"
                            type={showPassword ? 'text' : 'password'}
                            onChange={handleChange}
                            value={formData.pass}
                            endAdornment={
                                <InputAdornment position="end">
                                    <IconButton
                                        aria-label="toggle password visibility"
                                        onClick={handleClickShowPassword}
                                        onMouseDown={handleMouseDownPassword}
                                        edge="end"
                                    >
                                        {showPassword ? <VisibilityOff /> : <Visibility />}
                                    </IconButton>
                                </InputAdornment>
                            }
                            labelWidth={70}
                        />
                    </FormControl>
                    <Button type="submit" variant="contained" color="primary" fullWidth>
                        Create Account
                    </Button>
                    <Link to="/login" style={{ marginTop: '20px', display: 'block' }}>Already have an account? Sign in</Link>
                </Paper>
            </form>
        </div>
    );
}

export default CreateUser;
