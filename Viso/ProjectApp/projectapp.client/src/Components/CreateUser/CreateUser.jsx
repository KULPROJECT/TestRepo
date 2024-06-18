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
import InputLabel from '@mui/material/InputLabel';

const REGISTER_URL = 'https://localhost:5001/api/Registration/AddUser';
const EMAIL_EXIST = 'https://localhost:5001/api/Registration/CheckEmailExists';
const USERNAME_EXIST = 'https://localhost:5001/api/Registration/CheckUsernameExists';

function CreateUser() {
    const [userName, setUserName] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [pass, setPassword] = useState("");
    const [showPassword, setShowPassword] = useState(false);
    const [error, setError] = useState('');

    const handleClickShowPassword = () => {
        setShowPassword(!showPassword);
    };

    const handleMouseDownPassword = (event) => {
        event.preventDefault();
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const emailData = JSON.stringify([email]);
        const usernameData = JSON.stringify([userName]);

        try {
            const userNameResponse = await axios.post(USERNAME_EXIST, usernameData, {
                headers: { "Content-Type": "application/json" }
            });

            try {
                const emailResponse = await axios.post(EMAIL_EXIST, emailData, {
                    headers: { "Content-Type": "application/json" }
                });

                if (!emailResponse.data.exists && !userNameResponse.data.exists) {
                    const userData = JSON.stringify([
                        userName,
                        email,
                        phoneNumber,
                        pass
                    ]);

                    try {
                        const registerResponse = await axios.post(REGISTER_URL, userData, {
                            headers: { "Content-Type": "application/json" }
                        });
                        setError("Create User");
                        console.log('Server response:', registerResponse.data);
                    } catch (registerError) {
                        const errorMessage = registerError.response?.data?.message || registerError.message || 'Failed to create account. Please try again.';
                        setError(errorMessage);
                        console.error('Error submitting form:', errorMessage);
                    }
               }   
            } catch (emailError) {
                //const errorMessage = emailError.response?.data?.message || emailError.message || 'Error checking email existence';
                setError("Email Exists");
                //console.error('Error checking email:', errorMessage);
            }
        } catch (userNameError) {
            //const errorMessage = userNameError.response?.data?.message || userNameError.message || 'Error checking username existence';
            setError("Username Exists");
           // console.error('Error checking username:', errorMessage);
        }
    }

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
                        onChange={(e) => setUserName(e.target.value)}
                        value={userName}
                        margin="normal"
                        fullWidth
                        required
                    />
                    <TextField
                        name="email"
                        label="Email"
                        type="email"
                        onChange={(e) => setEmail(e.target.value)}
                        value={email}
                        margin="normal"
                        fullWidth
                        required
                    />
                    <TextField
                        name="phoneNumber"
                        label="Phone Number"
                        type="tel"
                        onChange={(e) => {
                            const value = e.target.value;
                            if (/^\d*$/.test(value) && value.length <= 9) {
                                setPhoneNumber(value);
                            }
                        }}
                        value={phoneNumber}
                        margin="normal"
                        fullWidth
                        required
                        inputProps={{
                            maxLength: 9,
                        }}
                    />

                    <FormControl fullWidth margin="normal" variant="outlined" required>
                        <InputLabel htmlFor="outlined-adornment-password">Password</InputLabel>
                        <OutlinedInput
                            id="outlined-adornment-password"
                            name="pass"
                            type={showPassword ? 'text' : 'password'}
                            onChange={(e) => setPassword(e.target.value)}
                            value={pass}
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
                            label="Password"
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
