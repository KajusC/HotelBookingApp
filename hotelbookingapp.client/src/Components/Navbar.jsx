// src/Navbar.jsx
import React, { useState, useEffect} from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import logo from "../assets/o.png";
import Cookies from "js-cookie";
import { IoMenu } from "react-icons/io5";
import { IoLocationSharp } from "react-icons/io5";
import { Link } from "react-router-dom";
import { verifyToken, postUserLogout } from "../functions/api";

function Navbar() {

  const [isAuthenticated, setIsAuthenticated] = useState(null); // Initial state

  useEffect(() => {
    const token = Cookies.get('token');
    if (token) {
      verifyToken(token)
        .then(response => {
          setIsAuthenticated(response); // Set based on verification
        })
        .catch(() => {
          setIsAuthenticated(false); // Handle errors by setting false
        });
    } else {
      setIsAuthenticated(false); // No token, not authenticated
    }
  }, []);

  let changingButtons = (
    <div className="hidden md:flex items-center space-x-4">
      <Link to="/login" className="mx-3 login navbar-collapse ">
        Login
      </Link>
      <Link
        to="/register"
        className="mx-3 signup navbar-collapse align-items-sm-end"
      >
        Register
      </Link>
    </div>
  );

  if(isAuthenticated) {
    changingButtons = (
      <div className="hidden md:flex items-center space-x-4">
        <Link to="/" onClick={postUserLogout} className="mx-3 login navbar-collapse">
          Logout
        </Link>
        <Link
          to="/profile"
          className="mx-3 signup navbar-collapse align-items-sm-end"
        >
          Profile
        </Link>
      </div>
    );
  }
  
  return (
    <nav className="flex justify-between items-center p-4 bg-[#f3f8ff] shadow-lg">
      <div className="flex items-center ">
        <a href="/">
          <img src={logo} alt="logo" className=" w-28 h-28 rounded-2xl" />
        </a>
        <p className="ml-5 text-xl font-bold font-mono">HootBoot</p>
      </div>
      <div className="hidden md:flex items-center space-x-4">
        {changingButtons}
      </div>
    </nav>
  );
}

export default Navbar;
