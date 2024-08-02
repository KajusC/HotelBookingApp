import "./App.css";

import Navbar from "./Components/Navbar.jsx";
import SearchBar from "./Components/SearchBar.jsx";
import DisplayCard from "./Components/DisplayCard.jsx";
import SearchWindow from "./Components/SearchWindow.jsx";
import HorizontalSlider from "./Components/HorizontalSlider.jsx";
import TitleCover from "./Components/TitleCover.jsx";

import { Route, Routes } from "react-router-dom";
import { getHotelByCountryOrCity } from "./functions/api.js";
import { useEffect, useState } from "react";
import { SearchContext } from "./contexts/search-context.jsx";

const picture = [
  "https://images.pexels.com/photos/5371575/pexels-photo-5371575.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
  "https://images.pexels.com/photos/164595/pexels-photo-164595.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
];

export default function App() {
  const [hotels, setHotels] = useState([]);
  const [searches, setSearches] = useState({
    countryOrCity: " ",
    checkIn: " ",
    checkOut: " ",
    guests: 0,
  });

  function handleSearch(searches) {
    setSearches(searches);
    console.log(searches);
  }

  useEffect(() => {
    const query = searches.countryOrCity;
    getHotelByCountryOrCity(query).then((data) => {
      setHotels(data);
    });
  }, [searches.countryOrCity]);

  const SearchTemplateCtx = {
    countryOrCity: searches.countryOrCity,
    checkIn: searches.checkIn,
    checkOut: searches.checkOut,
    guests: searches.guests,
    handleSearch: handleSearch,
  };

  return (
    <>
      <Navbar />
      <SearchContext.Provider value={SearchTemplateCtx}>
        <SearchWindow SearchBar={SearchBar} />
        <Routes>
          <Route path="/" element={<TitleCover />} />
          <Route
            path="/bookings"
            element={
              <div className="d-flex justify-content-center row-cols-2">
                <HorizontalSlider title={"Best deals"} id="bottom">
                  {hotels.map((hotel, index) => {
                    console.log(hotel);
                    return(
                    <DisplayCard
                      key={index}
                      hotelName={hotel.name}
                      // rating={hotel.rating} 
                      hotelAddress={ `${hotel.city}, ${hotel.country}` }
                      // pricing={hotel.price}
                      // beds={hotel.beds}
                      // guests={hotel.guests}
                      pictureUrl={[hotel.imageUrl]}
                      show
                    />
                  )
                  })}
                </HorizontalSlider>
              </div>
            }
          />
        </Routes>
      </SearchContext.Provider>
    </>
  );
}
