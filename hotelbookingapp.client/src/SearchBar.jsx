import React, { useState } from 'react';
import HotelView from './HotelView.jsx';

function SearchBar() {
    const [searchQuery, setSearchQuery] = useState('');
    const [hotels, setHotels] = useState([]); // State to store the fetched hotels

    const handleSearch = async () => {
        try {
            const response = await fetch(`https://localhost:7103/Hotel?countryOrCity=${searchQuery}`);
            const data = await response.json();
            setHotels(data);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    const handleInputChange = (event) => {
        setSearchQuery(event.target.value);
    };

    return (
        <div className="">
        <div className="d-flex align-items-center justify-content-center" style={{ backgroundColor: '#', color: 'white', height: '100px' }}>
            <div className="search-bar w-50 d-flex justify-contents-center">
                <input
                    type="text"
                    className="form-control form-control-lg rounded-pill"
                    placeholder="Search by city or country..."
                    value={searchQuery}
                    onChange={handleInputChange}
                    style={{ width: '85%' }}
                />
                <button type="submit" className="btn rounded-circle ml-2 d-flex align-items-center justify-content-center" onClick={handleSearch} style={{ backgroundColor: '#0B3954', border: 'none', width: '50px', height: '50px' }}>
                    <i style={{ color: 'white' }}>✔</i>
                </button>
                </div>
            </div>
            <HotelView hotels={hotels} />
        </div>
    );
}

export default SearchBar;
