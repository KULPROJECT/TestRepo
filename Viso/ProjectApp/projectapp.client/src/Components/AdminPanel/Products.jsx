import React, { useState, useEffect } from 'react';
import styles from './AdminPanel.module.scss';
import axios from 'axios';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';

const Products = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        axios.get('/api/products')
            .then(response => setProducts(response.data))
            .catch(error => console.error('Error fetching products:', error));
    }, []);

    return (
        <div className={styles.products}>
            <h1>Products</h1>
            <List>
                {products.map(product => (
                    <ListItem key={product.id}>
                        <ListItemText primary={product.name} />
                    </ListItem>
                ))}
            </List>
        </div>
    );
};

export default Products;
