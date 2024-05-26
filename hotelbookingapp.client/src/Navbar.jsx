// src/Navbar.jsx
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate } from 'react-router-dom';
import logo from './assets/o.png'; // make sure the path to your image is correct

function Navbar() {
    const navigate = useNavigate();

    const handleNavigate = (path) => {
        navigate(path);
    };

    return (
        <nav className="navbar navbar-expand d-flex justify-content-between p-3" style={{ backgroundColor: '#0B3954' }}>
            <div className="d-flex align-items-center">
                <img src={logo} alt="Logo" style={{ height: '80px' }} />
                <a className="navbar-brand ml-2" href="#" style={{ color: 'white' }}>Hoot Boot</a>
            </div>
            <div className="collapse navbar-collapse d-flex justify-content-center flex-grow-0" id="navbarNav">
                <ul className="navbar-nav">
                    <li className="nav-item">
                        <button
                            className="nav-link btn btn-link"
                            onClick={() => handleNavigate('/')}
                            style={{ color: 'white' }}>
                            Bookings
                        </button>
                    </li>
                    <li className="nav-item">
                        <button
                            className="nav-link btn btn-link"
                            onClick={() => handleNavigate('/user-profile')}
                            style={{ color: 'white' }}>
                            Profile
                        </button>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="#" style={{ color: 'white' }}>Pricing</a>
                    </li>
                </ul>
            </div>
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation" style={{ borderColor: 'white', color: 'white' }}>
                <span className="navbar-toggler-icon"></span>
            </button>
        </nav>
    );
}

export default Navbar;
