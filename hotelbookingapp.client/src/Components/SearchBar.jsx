import React, { useRef, useState } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import FloatingLabel from "react-bootstrap/FloatingLabel";

import { FaSearch } from "react-icons/fa";
import { FaRegCalendarAlt } from "react-icons/fa";
import { IoPersonOutline } from "react-icons/io5";
import { useContext } from "react";
import { SearchContext } from "../contexts/search-context";
import { useLocation, useNavigate } from "react-router-dom";

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

  const isInBookings = Location.pathname === "/bookings";

  return (
    <>
      <InputGroup className="mb-3 w-75">
        <InputGroup.Text className="p-3">
          <FaSearch />
        </InputGroup.Text>
        <FloatingLabel
          controlId="floatingSearch"
          label="City or a country"
          className="flex-grow-1"
        >
          <Form.Control
            placeholder="Search for a hotel"
            aria-label="City or a country"
            aria-describedby="basic-addon2"
            ref={hotelRef}
          />
        </FloatingLabel>

        <InputGroup.Text>
          <FaRegCalendarAlt />
        </InputGroup.Text>
        <FloatingLabel
          controlId="floatingCheckIn"
          label="Check-in"
          className="flex-grow-1"
        >
          <Form.Control placeholder="Check-in" type="date" ref={CheckInRef} />
        </FloatingLabel>

        <InputGroup.Text>
          <FaRegCalendarAlt />
        </InputGroup.Text>
        <FloatingLabel
          controlId="floatingCheckOut"
          label="Check-out"
          className="flex-grow-1"
        >
          <Form.Control placeholder="Check-out" type="date" ref={CheckOutRef} />
        </FloatingLabel>

        <InputGroup.Text>
          <IoPersonOutline />
        </InputGroup.Text>
        <FloatingLabel
          controlId="floatingGuests"
          label="Guests"
          className="flex-grow-1"
        >
          <Form.Control placeholder="Guests" type="number" ref={GuestsRef} />
        </FloatingLabel>

        <Button
          variant="custom"
          className="wideButton warp align-content-center"
          onClick={isInBookings ? handleConditionalRedirect : handleLocalSearch}
        >
          <p className="m-0">Search</p>
        </Button>
      </InputGroup>
    </>
  );
}

export default SearchBar;
