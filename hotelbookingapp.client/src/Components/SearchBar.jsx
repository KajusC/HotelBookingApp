import React from "react";
import "./SearchBar.css";
import Button from 'react-bootstrap/Button';
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import { FaSearch } from "react-icons/fa";
import { FaRegCalendarAlt } from "react-icons/fa";
import { IoPersonOutline } from "react-icons/io5";


function SearchBar() {
  return (
    <>
      <InputGroup className="mb-3 inputs w-75">
        <InputGroup.Text className="p-3">
          <FaSearch />
        </InputGroup.Text>
        <Form.Control
          placeholder="Search for a hotel"
          aria-label="Search for a hotel"
          aria-describedby="basic-addon2"
        />

        <InputGroup.Text>
          <FaRegCalendarAlt />
        </InputGroup.Text>
        <Form.Control placeholder="Check-in" type="date" />

        <InputGroup.Text>
          <FaRegCalendarAlt />
        </InputGroup.Text>
        <Form.Control placeholder="Check-out" type="date" />

        <InputGroup.Text>
          <IoPersonOutline />
        </InputGroup.Text>
        <Form.Control placeholder="Guests" type="number" />
        <Button variant="custom" className="wideButton">Search</Button>
      </InputGroup>
    </>
  );
}

export default SearchBar;
