import React from "react";
import PictureCarousel from "./PictureCarousel";
import { FaStar } from "react-icons/fa";
import { IoLocationSharp } from "react-icons/io5";
import { MdOutlineBed } from "react-icons/md";
import { IoPersonOutline } from "react-icons/io5";

export default function DisplayCard({
  id = 0,
  hotelName = "X",
  rating = "X",
  hotelAddress,
  pricing = "X",
  beds = "X",
  guests = "X",
  pictureUrl = [
    "https://images.pexels.com/photos/1285625/pexels-photo-1285625.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
  ],
}) {
  return (
    <div className="bg-white rounded-lg shadow-md overflow-hidden flex flex-col w-80 h-full md:w-70 mx-auto fb-4 transition duration-500 hover:shadow-transparen hover:scale-105">
      <PictureCarousel links={pictureUrl} showControls={true} isCard='true' />
      <div className="p-4 flex flex-col  transition-all">
        <div className="flex justify-between mb-4">
          <h5 className="text-xl font-bold">{hotelName}</h5>
          <div className="flex items-center">
            <span className="mr-2">{rating}</span>
            <FaStar fill="yellow" />
          </div>
        </div>
        <div className="flex items-center mb-3">
          <IoLocationSharp className="mr-2" />
          <p className="text-sm">{hotelAddress}</p>
        </div>
        <div className="mb-3">
          <h3 className="text-lg font-semibold">
            {pricing}
            <span className="text-sm text-gray-500">/night</span>
          </h3>
        </div>
        <div className="flex justify-between mb-4">
          <p className="text-sm">
            <MdOutlineBed className="mr-2 inline" />
            {beds} beds
          </p>
          <p className="text-sm">
            <IoPersonOutline className="mr-2 inline" />
            {guests} guests
          </p>
        </div>
        <a href={`/bookings/hotel/${id}`} className="btn btn-custom w-full items-end text-center py-2 px-1 rounded bg-blue-500 text-white">
          Book now!
        </a>
      </div>
    </div>
  );
}
