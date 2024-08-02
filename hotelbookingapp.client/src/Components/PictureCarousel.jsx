import React from "react";
import Carousel from "react-bootstrap/Carousel";

function PictureCarousel({ links, showControls }) {
  return (
    <Carousel controls={showControls} indicators={showControls}>
      {links.map((link, index) => (
        <Carousel.Item key={index} interval={3000}>
          <img className="d-block w-100" src={link} alt={`Slide ${index}`} />
        </Carousel.Item>
      ))}
    </Carousel>
  );
}

export default PictureCarousel;
