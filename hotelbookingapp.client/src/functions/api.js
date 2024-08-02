import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7103/api",
});

export const getHotelByCountryOrCity = async (countryOrCity) => {
  let query = "";
  if (countryOrCity === " ") {
    query = "";
  } else {
    query += "?countryOrCity=" + encodeURIComponent(countryOrCity);
  }
  console.log(query);
  const response = await api.get(`/hotel/${query}`);
  return response.data;
};
