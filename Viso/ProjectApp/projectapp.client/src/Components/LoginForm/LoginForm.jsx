import * as React from 'react';
import './LoginForm.css'
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



function loginForm () {
    const [showPassword, setShowPassword] = React.useState(false);

    const handleClickShowPassword = () => setShowPassword((show) => !show);

    const handleMouseDownPassword = (event) => {
        event.preventDefault();
    };

    return (
        
        <Grid container columns={12 }>
            <Grid lg md={6} xs>
                    <div className="login-Bg"></div>
                </Grid>
            <Grid lg md={6} xs >
                    <Paper elevation={1}>
                        <LockOutlinedIcon sx={{
                            color: 'purple',
                            fontSize: 45,
                            width:1
                        }} />
                        <h1>Sign in</h1>
                        <Divider sx={{
                            mb: 1,
                            border: 1.2,
                            borderRadius:4,
                            opacity:0.2,
                            width:3/4
                        }}></Divider>
                        <TextField
                            helperText=" "
                            id="demo-helper-text-misaligned"
                            label="Email"
                        />
                        <FormControl sx={{mb:2}} variant="outlined">
                            <InputLabel htmlFor="outlined-adornment-password" >Password</InputLabel>
                            <OutlinedInput
                                id="outlined-adornment-password"

                                    type={showPassword ? 'text' : 'password'}
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
            

                            <Button variant="contained">Sign in</Button>
                                </Paper>
                            </Grid>
            </Grid>
        
    );
};
export default loginForm;