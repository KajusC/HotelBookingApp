// src/index.jsx or src/index.js
import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Navbar.jsx';
import SearchBar from './SearchBar.jsx';
import HotelView from './HotelView.jsx';
import UserProfile from './UserProfile.jsx';
import './index.css';

ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <Router>
            <Navbar />
            
            <Routes>
                <Route path="/" element={
                    <div>
                        <SearchBar />
                        <HotelView />
                    </div>
                } />
                <Route path="/user-profile" element={<UserProfile />} />
            </Routes>
        </Router>
    </React.StrictMode>
);
