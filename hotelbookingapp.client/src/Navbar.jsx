// src/Navbar.jsx
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Navbar.css';
import logo from './assets/o.png';

function Navbar() {

    return (
        <nav className="navbar d-flex nav-background">
            <div className="align-items-center">
                <img className=' img-thumbnail' src={logo} alt="Logo" style={{ height: '80px' }} />
                <a className="navbar-brand px-4" href="#" style={{ color: 'white' }}>Hoot Boot</a>
            </div>
            <div className=' align-items-end list-buttons px-1 pt-2 align-items-md-end'>
                <a className="mx-3 login navbar-collapse " href="#">Log in</a>
                <a className="mx-3 signup navbar-collapse align-items-sm-end" href="#">Sign up</a>
            </div>
        </nav>
    );
}

export default Navbar;
