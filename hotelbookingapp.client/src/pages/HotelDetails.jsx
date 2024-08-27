import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getHotelById } from "../functions/api";

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
  }, []);

  return (
    <div className="flex justify-start">
      <div className="w-2/4">
        <img src={hotel?.imageUrl} alt={hotel?.name} className=""/>
      </div>
      
      <div className="grid grid-cols-1 divide-y divide-gray-400 justify-items-start bord">
        <div>{hotel?.name}</div>
        <div>{hotel?.description}</div>
        <div>{hotel?.address}</div>
        <div>{hotel?.minBedCount}</div>
      </div>
    </div>
  )
}
