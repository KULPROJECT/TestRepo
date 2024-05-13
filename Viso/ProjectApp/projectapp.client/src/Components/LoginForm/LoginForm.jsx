import * as React from 'react';
import { useState } from 'react';
import styles from './LoginForm.module.scss';
import Button from '@mui/material/Button';
import Paper from '@mui/material/Paper';
import IconButton from '@mui/material/IconButton';
import InputLabel from '@mui/material/InputLabel';
import TextField from '@mui/material/TextField';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputAdornment from '@mui/material/InputAdornment';
import FormControl from '@mui/material/FormControl';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Divider from '@mui/material/Divider';
import Grid from '@mui/system/Unstable_Grid';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';



function LoginForm() {
    const [userName, setUserName] = useState("");
    const [pass, setPassword] = useState("");
    //const [isLoggedIn, setLoggedIn] = useState(false);
    const [error, setError] = useState("");

    const [showPassword, setShowPassword] = React.useState(false);

    const handleClickShowPassword = () => setShowPassword((show) => !show);

    const handleMouseDownPassword = (event) => {
        event.preventDefault();
    };


    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        const loginData = JSON.stringify([userName, pass]);
        
        try {
            const loginSuccess = await axios.post('https://localhost:5001/api/Login/CheckLoginCredentials', loginData,
            {
                headers: { "Content-Type": "application/json" }
            });
            console.log("Server response: ", loginSuccess.data)
            navigate('/');
        } catch (loginError) {
            const errorMessage = loginError.response?.data?.message || loginError.message || 'Failed to sign in. Please try again.';
            setError(errorMessage);
            console.error('Error submitting form:', errorMessage);
        }
    }


    return (
            <Grid container columns={12}>
                <Grid item xs={0} md={8}>
                    <div className={styles.loginBg}>   
                    </div>
                </Grid>
                <Grid item xs md={4}>
                <div className={styles.loginForm}>
                    <form onSubmit={handleSubmit}>
                    <Paper className={styles.MuiPaperElevation1} elevation={1}>
                        <LockOutlinedIcon sx={{
                            color: 'purple',
                            fontSize: 45,
                            width:1
                            }} />
                            <h1 className={styles.header1}>Sign in</h1>
                        <Divider sx={{
                            mb: 1,
                            border: 1.2,
                            borderRadius:4,
                            opacity:0.2,
                            width:3/4
                            }}></Divider>
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
            

                        <Button type="submit" variant="contained">Sign in</Button>
                        <Link to="/createuser">
                         Create an Account
                        </Link>
                        <Link to="#">
                            Do you forget password ?
                        </Link>
                        </Paper>
                    </form>
                    </div>
                    </Grid>
                
            </Grid>
    );
}
export default LoginForm;