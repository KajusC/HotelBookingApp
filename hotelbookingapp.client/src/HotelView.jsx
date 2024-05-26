import React, { useState, useEffect, useRef } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './HotelView.css'; // Import custom CSS for HotelView component

function HotelView({ hotels }) {
    const [selectedHotel, setSelectedHotel] = useState(null); // State to store the selected hotel
    const [rooms, setRooms] = useState([]); // State to store the rooms of the selected hotel
    const [users, setUsers] = useState([]); // State to store the users data]
    const [foods, setFoods] = useState([]); // State to store the foods data]
    const [orders, setOrders] = useState([]); // State to store the orders data]
    const [roomOrders, setRoomOrders] = useState([]); // State to store the room orders data]
    const [foodOrders, setFoodOrders] = useState([]); // State to store the food orders data]
    const searchBarRef = useRef(null);

    const [selectedUser, setSelectedUser] = useState(null); // State to store the selected user]
    const [selectedRoom, setSelectedRoom] = useState(null);
    const [checkInDate, setCheckInDate] = useState('');
    const [checkOutDate, setCheckOutDate] = useState('');
    const [selectedFood, setSelectedFood] = useState(null);
    const [peopleCount, setPeopleCount] = useState(1);

    // Function to fetch rooms data for the selected hotel
    const fetchRooms = async (hotelId) => {
        try {
            const response = await fetch(`https://localhost:7103/Room?HotelId=${hotelId}`);
            const data = await response.json();
            setRooms(data);
        } catch (error) {
            console.error('Error fetching rooms data:', error);
        }
    };

    const fetchUsers = async () => {
        try {
            const response = await fetch(`https://localhost:7103/User`);
            const data = await response.json();
            setUsers(data);
        } catch (error) {
            console.error('Error fetching users data:', error);
        }
    };

    const fetchFoods = async () => {
        try {
            const response = await fetch(`https://localhost:7103/Food`);
            const data = await response.json();
            setFoods(data);
        } catch (error) {
            console.error('Error fetching users data:', error);
        }
    };

    const handleSelectRoom = (roomId) => {
        const room = rooms.find(room => room.id === Number(roomId));
        if (room) {
            console.log(room.id);
            setSelectedRoom(room);
        } else {
            console.log(`Room with ID ${roomId} not found.`);
        }
    };

    const handleSelectFood = (foodId) => {
        const food = foods.find(food => food.id === Number(foodId));
        if (food) {
            console.log(food);
            setSelectedFood(food);
        } else {
            console.log(`Food with ID ${foodId} not found.`);
        }
    };

    const handleSelectUser = (userId) => {
        const user = users.find(user => user.id === Number(userId));
        if (user) {
            console.log(user);
            setSelectedUser(user);
        } else {
            console.log(`User with ID ${userId} not found.`);
        }
    };

    const handleOpenModal = (hotel) => {
        setSelectedHotel(hotel);
        $('#exampleModal').modal('show');
        fetchRooms(hotel.id);
        fetchUsers();
        fetchFoods();
    };


    //Missed part "All calculation logic must be implemented in the back-end"
    const countDays = (checkIn, checkOut) => {
        const date1 = new Date(checkIn);
        const date2 = new Date(checkOut);
        const diffTime = Math.abs(date2 - date1);
        const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
        return diffDays;
    }

    const totalPrice = () => {
        if (selectedRoom && selectedFood && checkInDate && checkOutDate) {
            const days = countDays(checkInDate, checkOutDate);
            const roomPrice = parseFloat(selectedRoom.price);
            const foodPrice = parseFloat(selectedFood.price);
            const people = parseInt(peopleCount, 10);
            const price = roomPrice + (foodPrice * people * days) + 20;
            return price;
        }
        return 0;
    }

    const handleOrder = async () => {
        try {
            const response = await fetch(`https://localhost:7103/Order?foodId=${selectedFood.id}&roomId=${selectedRoom.id}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    customerId: selectedUser.id,
                    hotelId: selectedHotel.id,
                    orderDate: new Date().toISOString(),
                    checkInDate: checkInDate,
                    checkOutDate: checkOutDate,
                    price: totalPrice(),
                    Status: "Pending"
                })
            });

            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            console.log('No data returned from server');
            showToast('Order created successfully, but no data returned from server!');

        } catch (error) {
            console.error('Error creating order:', error);
            showToast('Error creating order!');
        }

        $('#exampleModal').modal('hide');
    }

    const showToast = (message) => {
        const toastEl = document.getElementById('orderToast');
        const toastBodyEl = document.getElementById('orderToastBody');
        toastBodyEl.textContent = message;
        const toast = new bootstrap.Toast(toastEl, {
            autohide: true,
            delay: 5000
        });
        toast.show();
    }

    return (
        <div className="container">
            <div className="justify-content-center">
                {hotels && hotels.map((hotel) => (
                    <div className="col-12 col-md-6 col-lg-4 p-2 mb-4 mx-auto" key={hotel.id}>
                        <div className="card mb-3">
                            <img src={hotel.imageUrl} className="card-img-top img-thumbnail mx-auto" alt={hotel.name} />
                            <div className="card-body">
                                <h5 className="card-title">{hotel.name}</h5>
                                <p className="card-text">{hotel.description}</p>
                                <p className="card-text">Country: {hotel.country} | City: {hotel.city} | Address: {hotel.address}</p>
                                <button type="button" className="btn btn-primary" onClick={() => handleOpenModal(hotel)}>Book</button>
                            </div>
                        </div>
                    </div>
                ))}
            </div>

            {/* Modal */}
            <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">Booking Form</h5>
                            <button type="button" className="btn-close" data-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            {selectedHotel && (
                                <div>
                                    <p>User:</p>
                                    <select className="form-select" aria-label="Select User" onChange={(e) => handleSelectUser(e.target.value)}>
                                        <option selected disabled>Who are you?</option>
                                        {users.map((user) => (
                                            <option key={user.id} value={user.id}>{user.username}</option>
                                        ))}
                                    </select>
                                    <br></br>
                                    <p>Hotel: {selectedHotel.name}</p>
                                    <p>Select Room:</p>
                                    <select className="form-select" aria-label="Select Room" onChange={(e) => handleSelectRoom(e.target.value)}>
                                        <option selected disabled>Select a room</option>
                                        {rooms.map((room) => (
                                            <option key={room.id} value={room.id}>{room.name} | {room.price}$</option>
                                        ))}
                                    </select>
                                    <p>Check-In</p>
                                    <input type="date" className="form-control" onChange={(e) => setCheckInDate(e.target.value)} />
                                    <p>Check-Out</p>
                                    <input type="date" className="form-control" onChange={(e) => setCheckOutDate(e.target.value)} />

                                    <p>Food:</p>
                                    <select className="form-select" aria-label="Select Food" onChange={(e) => handleSelectFood(e.target.value)}>
                                        <option selected disabled>Select a food</option>
                                        {foods.map((food) => (
                                            <option key={food.id} value={food.id}>{food.name} | {food.price}$</option>
                                        ))}
                                    </select>

                                    <p>People:</p>
                                    <input type="number" className="form-control" onChange={(e) => setPeopleCount(parseInt(e.target.value))} />



                                    <p>this includes 20$ fees</p>
                                    <h3>Total Price: {totalPrice()} $</h3>


                                </div>
                            )}
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" className="btn btn-primary" onClick={handleOrder}>Book Now</button>
                        </div>
                    </div>
                </div>
            </div>

            {/* Toast */}
            <div className="toast-container position-fixed bottom-0 end-0 p-3" style={{ zIndex: 11 }}>
                <div id="orderToast" className="toast" role="alert" aria-live="assertive" aria-atomic="true">
                    <div className="toast-header">
                        <strong className="me-auto">Booking Notification</strong>
                        <button type="button" className="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                    <div className="toast-body" id="orderToastBody">
                    </div>
                </div>
            </div>
        </div>
    );
}

export default HotelView;
