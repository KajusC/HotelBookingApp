import Carousel from "react-bootstrap/Carousel";

function PictureCarousel({ links }) {
  console.log(links);
  return (
    <Carousel>
      {links.map((link, index) => {
        return (
          <Carousel.Item interval={5000}>
            <img
              key={index}
              className="card-img-top"
              src={link}
              alt="First slide"
            />
          </Carousel.Item>
        );
      })}
    </Carousel>
  );
}

export default PictureCarousel;
