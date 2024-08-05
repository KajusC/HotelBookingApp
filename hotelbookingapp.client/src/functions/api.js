import axios from "axios";


const api = axios.create({
  baseURL: "https://192.168.88.44:7103/api",
});

export const getHotelByCountryOrCity = async (countryOrCity) => {
  let query = "";
  if (countryOrCity === " ") {
    query = "";
  } else {
    query += "?countryOrCity=" + encodeURIComponent(countryOrCity);
  }
  const response = (await api.get(`/hotel/${query}`));
  return response.data;
};
