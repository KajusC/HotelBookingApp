import React, { useState } from 'react';
import './SearchBar.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';

function SearchBar() {
    const [inputValue, setInputValue] = useState('');

    const handleInputChange = (event) => {
        setInputValue(event.target.value);
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(inputValue);
    }

    return (
        <div className="container-md5 d-flex justify-content-center">
            <div className="search-bar">
                <form onSubmit={handleSubmit} className="d-flex ">
                    <input
                        type="text"
                        className="form-control form-control-lg rounded-pill"
                        placeholder="Search..."
                        value={inputValue}
                        onChange={handleInputChange}
                        style={{ width: '85%' }}
                    />
                    <button type="submit" className="btn rounded-circle ml-2 d-flex align-items-center justify-content-center" style={{ backgroundColor: '#0B3954', border: 'none', width: '50px', height: '50px' }}>
                        <i style={{ color: 'white' }}>✔</i>
                    </button>
                </form>
            </div>
        </div>
    );
}

export default SearchBar;
