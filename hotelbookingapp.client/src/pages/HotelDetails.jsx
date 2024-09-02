import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getHotelById } from "../functions/api";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";

export default function HotelDetails() {
  const { hotelId } = useParams();
  const [hotel, setHotel] = useState();

  useEffect(() => {
    getHotelById(hotelId)
      .then((data) => {
        setHotel(data);
      })
      .catch((error) => {
        console.error(error);
      });
  }, [hotelId]);

  return (
    <div className="container mx-auto p-6 ">
      <div className="py-3 flex flex-col w-40">
        <Button variant="custom">
          <Link to="/bookings" className="no-decoration text-white">
            Back to Hotels
          </Link>
        </Button>
      </div>
      {hotel ? (
        <div className="bg-white rounded-lg shadow-lg overflow-hidden">
          <div className="flex flex-col md:flex-row">
            <div className="md:w-1/2">
              <img
                src={hotel.imageUrl}
                alt={hotel.name}
                className="object-cover w-full h-64 md:h-full"
              />
            </div>
            <div className="md:w-1/2 p-6">
              <h1 className="text-3xl font-bold text-gray-900 mb-4">
                {hotel.name}
              </h1>
              <p className="text-lg text-gray-700 mb-4">{hotel.description}</p>
              <div className="grid grid-cols-2 gap-4 mb-6">
                <div>
                  <h2 className="text-sm font-semibold text-gray-500 uppercase">
                    Address
                  </h2>
                  <p className="text-gray-700">{hotel.address}</p>
                  <p className="text-gray-700">
                    {hotel.city}, {hotel.country}
                  </p>
                </div>
                <div>
                  <h2 className="text-sm font-semibold text-gray-500 uppercase">
                    Contact
                  </h2>
                  <p className="text-gray-700">Phone: {hotel.phoneNumber}</p>
                  <p className="text-gray-700">Email: {hotel.email}</p>
                  <p className="text-gray-700">
                    Website:{" "}
                    <a
                      href={hotel.website}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="text-blue-500 underline"
                    >
                      {hotel.website}
                    </a>
                  </p>
                </div>
                <div>
                  <h2 className="text-sm font-semibold text-gray-500 uppercase">
                    Rating
                  </h2>
                  <p className="text-yellow-500 bold">
                    {hotel.rating > 0 ? <>{hotel.rating} ★ / 5</> : "No Rating"}
                  </p>
                </div>
                <div>
                  <h2 className="text-sm font-semibold text-gray-500 uppercase">
                    Hotel's room Info
                  </h2>
                  <p className="text-gray-700">
                    Beds: {hotel.minBedCount} - {hotel.maxBedCount}
                  </p>
                  <p className="text-gray-700">
                    Guests: {hotel.minGuestCount} - {hotel.maxGuestCount}
                  </p>
                </div>
                <div>
                  <h2 className="text-sm font-semibold text-gray-500 uppercase">
                    Average Price
                  </h2>
                  <p className="text-gray-700 bold">
                    ${hotel.averagePrice.toFixed(2)}
                  </p>
                </div>
              </div>
              <div className="flex justify-end">
                <Button variant="custom" className="px-4 py-2">
                  Book Now
                </Button>
              </div>
            </div>
          </div>
        </div>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
}
