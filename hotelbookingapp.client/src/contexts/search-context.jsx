import { createContext } from "react";

export const SearchContext = createContext(
    {
        countryOrCity: " ",
        checkIn: " ",
        checkOut: " ",
        guests: 0,
        handleSearch: (query) => {},   
      }
);
