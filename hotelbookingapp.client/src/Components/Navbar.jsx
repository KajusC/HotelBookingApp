// src/Navbar.jsx
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import logo from '../assets/o.png';
import { IoMenu } from "react-icons/io5";
import { IoLocationSharp } from "react-icons/io5";

function Navbar() {

    return (
        
        <nav className="navbar d-flex justify-content-between">
            <div className="flex align-items-center justify-center">
                <a href="/">
                <img src={logo} alt="logo" className=" size-[7rem] rounded-[2rem]" />
                </a>
                
                <p className='logo pl-5 pt-4'>HootBoot</p>
                
            </div>
            <div className=' align-items-end list-buttons px-1 pt-2 align-items-md-end'>
                <a className="mx-3 login navbar-collapse " href="#">Log in</a>
                <a className="mx-3 signup navbar-collapse align-items-sm-end" href="#">Register</a>
                <a className='pt-3 nav-link' href='#'>
                <span className='flex justify-center'>
                <IoLocationSharp size = '20'/>
                Location
                </span>
                    

                </a>
            </div>
        </nav>
    );
}

export default Navbar;
