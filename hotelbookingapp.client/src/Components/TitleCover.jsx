import React from "react";
import PictureCarousel from "./PictureCarousel"; // Adjust the import path as needed

const imageLinks = [
  'https://images.pexels.com/photos/1285625/pexels-photo-1285625.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  'https://images.pexels.com/photos/210186/pexels-photo-210186.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  'https://images.pexels.com/photos/2387418/pexels-photo-2387418.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  // Add more image links as needed
];

export default function TitleCover() {
  return (
    <article className="relative w-full overflow-hidden text-white">
      <PictureCarousel links={imageLinks} showControls={false} className="absolute inset-0 w-full h-full object-cover" />
      <div className="absolute inset-0 flex flex-col items-center justify-center px-4 md:px-8 py-5 md:py-8 text-shadow-md">
        <h1 className="text-3xl sm:text-4xl md:text-5xl lg:text-6xl font-bold mb-2 md:mb-4 text-center">
          Travel your way
        </h1>
        <h2 className="text-xl sm:text-2xl md:text-3xl lg:text-4xl font-semibold mb-2 md:mb-4 text-center">
          Find the best places to travel and explore the world
        </h2>
        <h3 className="text-lg sm:text-xl md:text-2xl lg:text-3xl pt-3 md:pt-5 text-center">
          With Hootboot
        </h3>
      </div>
    </article>
  );
}
