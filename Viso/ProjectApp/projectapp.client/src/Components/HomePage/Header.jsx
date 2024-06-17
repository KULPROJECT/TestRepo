import * as React from 'react';
import { Link } from 'react-router-dom';
import styles from './HomePage.module.scss';
import AccountCircle from '@mui/icons-material/AccountCircle';
import IconButton from '@mui/material/IconButton';
import Button from '@mui/material/Button';

const Header = () => {
    const user = JSON.parse(localStorage.getItem('user'));

    return (
        <header className={styles.header_1}>
            <h1 className={styles.header_logo}>
                <Link to='/'>EAT TO GO</Link>
            </h1>
            <nav>
                <ul className={styles.header_nav_links}>
                    <li><Link to='/'>Home</Link></li>
                    {user ? (
                        <li>
                            <IconButton component={Link} to="/userpanel" color="inherit">
                                <AccountCircle />
                            </IconButton>
                        </li>
                    ) : (
                        <>
                            <li>
                                <Button component={Link} to='/login' variant="contained" color="primary">
                                    Login
                                </Button>
                            </li>
                            <li>
                                <Button component={Link} to='/createuser' variant="outlined" color="primary">
                                    Create Account
                                </Button>
                            </li>
                        </>
                    )}
                </ul>
            </nav>
        </header>
    );
}

export default Header;
