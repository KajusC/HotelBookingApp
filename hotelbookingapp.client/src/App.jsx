import "./App.css";

import Navbar from "./Components/Navbar.jsx";
import SearchBar from "./Components/SearchBar.jsx";
import DisplayCard from "./Components/DisplayCard.jsx";
import SearchWindow from "./Components/SearchWindow.jsx";
import HorizontalSlider from "./Components/HorizontalSlider.jsx";
import TitleCover from "./Components/TitleCover.jsx";
import HotelDetails from "./pages/HotelDetails.jsx";

import { Route, Routes } from "react-router-dom";
import { getHotelByCountryOrCity } from "./functions/api.js";
import { useEffect, useState } from "react";
import { SearchContext } from "./contexts/search-context.jsx";
import Footer from "./Components/Footer.jsx";
import LoginPage from "./pages/LoginPage.jsx";
import RegisterPage from "./pages/RegisterPage.jsx";

const picture = [
  "https://images.pexels.com/photos/5371575/pexels-photo-5371575.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
  "https://images.pexels.com/photos/164595/pexels-photo-164595.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
];

export default function App() {
  const [hotels, setHotels] = useState([]);
  const [selectedHotelId, setSelectedHotelId] = useState();
  const [error, setError] = useState(null);
  const [searches, setSearches] = useState({
    countryOrCity: " ",
    checkIn: " ",
    checkOut: " ",
    guests: 0,
  });

  function handleSearch(searches) {
    setSearches(searches);
  }

  useEffect(() => {
    const query = searches.countryOrCity.toLowerCase();

    getHotelByCountryOrCity(query)
      .then((data) => {
        setHotels(data);
        setError(null);
      })
      .catch((error) => {
        setError(error.message);
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
    <div className="flex flex-col min-h-screen">
      <Navbar />
      <main className="flex-grow">
        <SearchContext.Provider value={SearchTemplateCtx}>
          
          <Routes>
            <Route path="/" element={
              <>
              <SearchWindow SearchBar={SearchBar} />
              <TitleCover />
              </>
            } 
              />
            <Route
              path="/bookings"
              element={
                <>
                <SearchWindow SearchBar={SearchBar} />
                <div className="flex justify-center items-center">
                  <HorizontalSlider title="" id="bottom">
                    {error && <p>{error}</p>}
                    <h2 className="grid sm:grid-cols-1 md:grid-cols-4 gap-4 justify-items-center">
                      {hotels.map((hotel, index) => (
                        <DisplayCard
                          key={hotel.id}
                          id={hotel.id}
                          hotelName={hotel.name}
                          rating={hotel.rating}
                          hotelAddress={`${hotel.city}, ${hotel.country}`}
                          pricing={hotel.averagePrice}
                          beds={`${hotel.minBedCount} - ${hotel.maxBedCount}`}
                          guests={`${hotel.minGuestCount} - ${hotel.maxGuestCount}`}
                          pictureUrl={[hotel.imageUrl]}
                          show
                          />
                        ))}
                    </h2>
                  </HorizontalSlider>
                </div>
                        </>
              }
            />

            <Route path="/bookings/hotel/:hotelId" element={<HotelDetails />} />
            <Route path="/login" element={<LoginPage />} />
            <Route path="/register" element={<RegisterPage />} />
            <Route path="*" element={<h1>Not Found</h1>} />
          </Routes>
        </SearchContext.Provider>
      </main>
      <Footer />
    </div>
  );
}
