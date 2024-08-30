import axios from "axios";
import Cookies from "js-cookie";


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
  const response = (await api.post("/Auth/register", user));
  return response.data;
};

export async function postUserLogin(user, addToast) {
  try {
    const response =
      (await api.post("/Auth/login", user));

      if (response.status === 200) {
        addToast({
          id: Date.now().toString(),
          title: "Success",
          description: "Successfully logged in (Redirecting...)",
          type: "success",
        });

        Cookies.set("token", response.data.token, { expires: 1 });
        return true;
      } else {
        addToast({
          id: Date.now().toString(),
          title: "Error",
          description: "Invalid username or password",
          type: "error",
        });
        return false;
      }
  } catch (error) {
    addToast({
      id: Date.now().toString(),
      title: "Error",
      description: "Invalid username or password",
      type: "error",
    });
    return false;
  }
}

export async function postUserLogout() {
  const response = (await api.post("/Auth/logout"));
  Cookies.remove("token");

  window.location.reload();
}

export async function verifyToken(token) {
  const response = (await api.post(`/Auth/Validate?token=${token}`));
  console.log(response.data);
  
  return response.data;
}

export async function getUserInfo(id) {
  const response = (await api.get(`/User/${id}`));
  return response.data;
}