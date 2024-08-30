import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

function UserProfile() {
    const [users, setUsers] = useState([]);
    const [selectedUser, setSelectedUser] = useState(null);
    const [userOrders, setUserOrders] = useState([]);
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        fetchUsers();
    }, []);

    const fetchUsers = async () => {
        try {
            const response = await fetch(`https://localhost:7103/User`);
            const data = await response.json();
            setUsers(data);
        } catch (error) {
            console.error('Error fetching users data:', error);
        }
    };

    const fetchUserOrders = async (userId) => {
        try {
            const response = await fetch(`https://localhost:7103/User/${userId}`);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const userData = await response.json();
            const userOrderIds = userData.orderIds;
            setUserOrders(userOrderIds);
            const orders = await Promise.all(userOrderIds.map(orderId => fetchOrderById(orderId)));
            setOrders(orders);
        } catch (error) {
            console.error('Error fetching user orders data:', error);
            setUserOrders([]);
            setOrders([]);
        }
    };

    const fetchOrderById = async (orderId) => {
        try {
            const response = await fetch(`https://localhost:7103/Order/${orderId}`);
            const data = await response.json();
            return data;
        } catch (error) {
            console.error('Error fetching order data:', error);
            return {};
        }
    };

    const handleSelectUser = (userId) => {
        fetchUserOrders(userId);
        const user = users.find(user => user.id === Number(userId));
        setSelectedUser(user);
    };

    return (
        <div className="d-flex flex-column align-items-center bg-[#D6CFCB]">
            <h2>User Info</h2>
            <select className="form-select w-25" aria-label="Select User" onChange={(e) => handleSelectUser(e.target.value)}>
                <option selected disabled>Who are you?</option>
                {users && users.map((user) => (
                    <option key={user.id} value={user.id}>{user.username}</option>
                ))}
            </select>
            {selectedUser && (
                <div className="mt-3">
                    <h3>User Details</h3>
                    <p>UserName: {selectedUser.username}</p>
                    <p>Name: {selectedUser.firstName}</p>
                    <p>Last name: {selectedUser.lastName}</p>
                    <p>Email: {selectedUser.email}</p>
                    <h3>Orders</h3>
                    <ul>
                        {orders && orders.map(order => (
                            <li key={order.id}>
                                <div>
                                    <p>Order ID: {order.id}</p>
                                    <p>Order Date: {order.orderDate}</p>
                                    <p>Order status: {order.status}</p>
                                    <p>Check-in date: {order.checkInDate}</p>
                                    <p>Check-out date: {order.checkOutDate}</p>                              
                                    <p>Hotel id: {order.hotelId}</p>
                                    <p>Order price: {order.price}$</p>
                                </div>
                            </li>
                        ))}
                    </ul>
                </div>
            )}
        </div>
    );
}

export default UserProfile;
