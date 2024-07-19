// src/Navbar.jsx
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Navbar.css';
import logo from '../assets/o.png';
import { IoMenu } from "react-icons/io5";
import { IoLocationSharp } from "react-icons/io5";

function Navbar() {

    return (
        <nav className="navbar d-flex justify-content-between nav-background">
            <div className="align-items-center">
                <IoMenu size = '30'/>
            </div>
            <div className="navbar-brand d-flex justify-content-center">
                <h1 className='logo'>HotHell</h1>
            </div>
            <div className=' align-items-end list-buttons px-1 pt-2 align-items-md-end'>
                <a className="mx-3 login navbar-collapse " href="#">Log in</a>
                <a className="mx-3 signup navbar-collapse align-items-sm-end" href="#">Register</a>
                <a className='pt-3 nav-item nav-link active' href='#'>
                    <IoLocationSharp size = '20'/>
                    <span className="mx-1">Location</span>
                </a>
            </div>
        </nav>
    );
}

export default Navbar;
