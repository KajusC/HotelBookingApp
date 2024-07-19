import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Navbar.css';

function SearchWindow({SearchBar}) {

    return (
        <nav className="navbar d-flex justify-content-center nav-background">
            <SearchBar/>
        </nav>
    );
}

export default SearchWindow;
