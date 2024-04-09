import * as React from 'react';
import { Link } from 'react-router-dom';
import styles from './HomePage.module.scss'


function Header() {
    return (
        <header className={styles.header_1}>
            <h1 className={styles.header_logo}><Link to='/'>EAT TO GO</Link></h1>
            <nav>
                <ul className={styles.header_nav_links}>
                    <li><Link to='/'>Home</Link></li>
                    <li><Link to='/login'>Login</Link></li>
                    <li><Link to='/createuser'>Create Account</Link></li>
                </ul>
            </nav>
        </header>
    );
}
export default Header;