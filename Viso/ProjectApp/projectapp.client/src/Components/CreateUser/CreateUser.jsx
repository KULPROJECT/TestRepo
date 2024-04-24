import * as React from 'react';
import styles from './CreateUser.module.scss'
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
import { Link } from 'react-router-dom';



function CreateUser() {
    const [showPassword, setShowPassword] = React.useState(false);

    const handleClickShowPassword = () => setShowPassword((show) => !show);

    const handleMouseDownPassword = (event) => {
        event.preventDefault();
    };
    
    return (
        <div className={styles.container}>  
        <form>
            <Paper className={styles.MuiPaperElevation3} elevation={3}>
        
            <LockOutlinedIcon sx={{
                color: 'purple',
                fontSize: 45,
                width:1
            }} />
            <h1 className={styles.header1}>CREATE ACCOUNT</h1>
            <Divider sx={{
                mb: 1,
                border: 1.2,
                borderRadius:4,
                opacity:0.2,
                width:3/4
                }}></Divider>
            
            <Grid container spacing={4} columns={12}>
                <Grid xs md={6}>
                              
                        <TextField
                         label="Name"
                        type="name"
                        helperText=" "
                        id="demo-helper-text-misaligned"
                        
                        />
                    
                </Grid>
                <Grid xs md={6}>
                    
                         <TextField
                         label="Surname"
                         type="surname"
                         helperText=" "
                         id="demo-helper-text-misaligned"
                            
                        />
                    
                    </Grid>
            </Grid>
                    <TextField
                    label="Email"
                    type="email"
                    helperText=" "
                    id="demo-helper-text-misaligned"
                
                />
                    <TextField
                    label="Phone Number"
                    type="phonenumber"
                    helperText=" "
                    id="demo-helper-text-misaligned"
                    
                />
                    <FormControl sx={{ mb: 2 }} variant="outlined">
                        <InputLabel htmlFor="outlined-adornment-password" type="password">Password</InputLabel>
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
            

                    <Button variant="contained">Create Account</Button>
             
                <Link to="/login">
                    Do you have an account ?
                    </Link>
                </Paper>
            </form>
        </div>  
    );
}
export default CreateUser;