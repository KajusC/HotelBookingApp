// src/Navbar.jsx
import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import logo from "../assets/o.png";
import { IoMenu } from "react-icons/io5";
import { IoLocationSharp } from "react-icons/io5";

function Navbar() {
  return (
    <nav className="flex justify-between items-center p-4">
      <div className="flex items-center ">
        <a href="/">
          <img src={logo} alt="logo" className=" w-28 h-28 rounded-2xl" />
        </a>
        <p className="ml-5 text-xl font-bold font-mono">HootBoot</p>
      </div>
      <div className="hidden md:flex items-center space-x-4">
        <a className="mx-3 login navbar-collapse " href="#">
          Log in
        </a>
        <a className="mx-3 signup navbar-collapse align-items-sm-end" href="#">
          Register
        </a>
      </div>
      <div className="md:hidden">
        <IoMenu size="30" />
      </div>
    </nav>
  );
}

export default Navbar;
