import React, { useState, useEffect } from 'react';
import axios from 'axios';
import styles from './HomePage.module.scss';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Typography from '@mui/material/Typography';

const ListRestaurants = () => {
    const [restaurants, setRestaurants] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const getRestaurants = async () => {
        try {
            const response = await axios.post('https://localhost:5001/api/Restaurant/GetRestaurantList?userID=8');
            setRestaurants(response.data);
            setLoading(false);
        } catch (error) {
            setError('Error fetching restaurants');
            setLoading(false);
        }
    };

    useEffect(() => {
        getRestaurants();
    }, []);

    if (loading) {
        return <Typography>Loading...</Typography>;
    }

    if (error) {
        return <Typography color="error">{error}</Typography>;
    }

    return (
        <div>
            <h1 className={styles.header_restaurants}>Restaurants</h1>
            <br/>
            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Name</TableCell>
                            <TableCell>Address</TableCell>
                            <TableCell>Phone Number</TableCell>
                            <TableCell>Working Hours</TableCell>
                            <TableCell>Total Grade</TableCell>
                            <TableCell>Description</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {restaurants.map((restaurant) => (
                            <TableRow key={restaurant.id}>
                                <TableCell>{restaurant.name}</TableCell>
                                <TableCell>{restaurant.address}</TableCell>
                                <TableCell>{restaurant.phoneNumber}</TableCell>
                                <TableCell>{restaurant.workingHours}</TableCell>
                                <TableCell>{restaurant.totalGrade}</TableCell>
                                <TableCell>{restaurant.description}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
};

export default ListRestaurants;
