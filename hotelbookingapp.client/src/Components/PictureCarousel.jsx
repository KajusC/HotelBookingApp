import React from "react";
import Carousel from "react-bootstrap/Carousel";

function PictureCarousel({ links, showControls, props, isCard = false }) {
  return (
    <Carousel controls={showControls} indicators={showControls} {...props}>
      {links.map((link, index) => (
        <Carousel.Item key={index} interval={3000}>
        <img className={`d-block ${!isCard ? `w-100 h-45` :`w-100 h-60` }`} src={link} alt={`Slide ${index}`} />
        </Carousel.Item>
      ))}
    </Carousel>
  );
}

export default PictureCarousel;
