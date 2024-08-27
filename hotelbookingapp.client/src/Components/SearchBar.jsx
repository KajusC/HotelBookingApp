import React, { useRef, useContext } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import FloatingLabel from "react-bootstrap/FloatingLabel";
import { FaSearch, FaRegCalendarAlt } from "react-icons/fa";
import { IoPersonOutline } from "react-icons/io5";
import { useLocation, useNavigate } from "react-router-dom";
import { SearchContext } from "../contexts/search-context";

function SearchBar() {
  const location = useLocation();
  const navigate = useNavigate();

  const hotelRef = useRef();
  const CheckInRef = useRef();
  const CheckOutRef = useRef();
  const GuestsRef = useRef();
  const { handleSearch } = useContext(SearchContext);

  const handleLocalSearch = () => {
    handleSearch({
      countryOrCity: hotelRef.current.value,
      checkIn: CheckInRef.current.value,
      checkOut: CheckOutRef.current.value,
      guests: GuestsRef.current.value,
    });

    if (!isInBookings) {
      handleConditionalRedirect();
    }
  };

  const handleConditionalRedirect = () => {
    navigate("/bookings");
  };

  const isInBookings = location.pathname === "/bookings";

  return (
    <div className="w-full md:w-3/4 mx-auto">
      <div className="grid grid-cols-1 sm:grid-cols-2 md:flex items-center mb-3">
        <InputGroup className="w-full sm:w-3/4 md:w-auto">
          <InputGroup.Text className="p-3">
            <FaSearch />
          </InputGroup.Text>
          <FloatingLabel controlId="floatingSearch" label="City or a country" className="flex-grow-1">
            <Form.Control
              placeholder="Search for a hotel"
              aria-label="City or a country"
              aria-describedby="basic-addon2"
              ref={hotelRef}
            />
          </FloatingLabel>
        </InputGroup>

        <InputGroup className="w-full sm:w-3/4 md:w-auto">
          <InputGroup.Text className="p-3">
            <FaRegCalendarAlt />
          </InputGroup.Text>
          <FloatingLabel controlId="floatingCheckIn" label="Check-in" className="flex-grow-1">
            <Form.Control placeholder="Check-in" type="date" ref={CheckInRef} />
          </FloatingLabel>
        </InputGroup>

        <InputGroup className="w-full sm:w-3/4 md:w-auto">
          <InputGroup.Text className="p-3">
            <FaRegCalendarAlt />
          </InputGroup.Text>
          <FloatingLabel controlId="floatingCheckOut" label="Check-out" className="flex-grow-1">
            <Form.Control placeholder="Check-out" type="date" ref={CheckOutRef} />
          </FloatingLabel>
        </InputGroup>

        <InputGroup className="w-full sm:w-3/4 md:w-auto">
          <InputGroup.Text className="p-3">
            <IoPersonOutline />
          </InputGroup.Text>
          <FloatingLabel controlId="floatingGuests" label="Guests" className="flex-grow-1">
            <Form.Control placeholder="Guests" type="number" ref={GuestsRef} />
          </FloatingLabel>
        </InputGroup>
      <div className="flex justify-center md:justify-start">
        <Button
          variant="custom"
          className="w-full sm:w-3/4 md:w-auto h-14 "
          onClick={!isInBookings ? handleConditionalRedirect : handleLocalSearch}
          >
          Search
        </Button>
          </div>
      </div>
    </div>
  );
}

export default SearchBar;
