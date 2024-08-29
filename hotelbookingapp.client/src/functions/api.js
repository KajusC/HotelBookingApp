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
  const response = (await api.get(`/hotel/${query}`));
  return response.data;
};

export const getHotelById = async (hotelId) => {
  const response = (await api.get(`/hotel/${hotelId}`));
  return response.data;
}

export async function postUserRegister(user) {
  const response = (await api.post("/User/", user));
  return response.data;
};
