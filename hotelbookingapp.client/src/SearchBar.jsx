import React from "react";
import { useState } from "react";
import "./SearchBar.css";

function SearchBar() {
  const [searchQuery, setSearchQuery] = useState("");

  const handleInputChange = (event) => {
    setSearchQuery(event.target.value);
  };

  return (
<div className="transparent">
  <div className="d-flex p-4 justify-content-center search">
    <input
      type="text"
      className="form-control sizing form-control-lg rounded-pill search-input focus-ring-light"
      placeholder="Search by city or country..."
      value={searchQuery}
      onChange={handleInputChange}
    />
  </div>
</div>

  );
}

export default SearchBar;
