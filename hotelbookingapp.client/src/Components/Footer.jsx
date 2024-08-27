import React from "react";
import { FaFacebook } from "react-icons/fa";
import { FaInstagram } from "react-icons/fa";
import { FaTwitter } from "react-icons/fa";
import openInNewTab from "../functions/openTab";

const rickRoll = 'https://www.youtube.com/watch?v=dQw4w9WgXcQ';

export default function Footer() {
  return (
    <footer className="bg-gray-800 text-white p-4 w-full">
      <div className="container mx-auto">
        <div className="flex justify-between">
          <div>
            <h1 className="text-2xl font-bold">HootBoot</h1>
            <p className="text-sm">Your one stop shop for hotels</p>
          </div>
          <div>
            <h1 className="text-2xl font-bold">Contact Us</h1>
            <p className="text-sm">Email: testing@example.com</p>
            <a href="mailto: testing@example.com"></a>
            <p className="text-sm">Phone: 123-456-7890</p>
            <div className="flex space-x-4 justify-center">
                <button onClick={() => openInNewTab(rickRoll)} className="text-white">
                    <FaFacebook />
                </button>
                <button onClick={() => openInNewTab(rickRoll)} className="text-white">
                    <FaTwitter />
                </button>
                <button onClick={() => openInNewTab(rickRoll)} className="text-white">
                    <FaInstagram />
                </button>

            </div>
          </div>
        </div>
      </div>
    </footer>
  );
}
