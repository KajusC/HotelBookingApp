import "./DisplayCard.css";
import Container from "react-bootstrap/Container";
import PictureCarousel from "./PictureCarousel";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { MdOutlineStarBorderPurple500 } from "react-icons/md";
import { IoLocationSharp } from "react-icons/io5";
import { MdOutlineBed } from "react-icons/md";
import { IoPersonOutline } from "react-icons/io5";


export default function DisplayCard({ hotelName, rating, hotelAddress, pricing, beds, guests, pictureUrl}) {
  return (
    <div className="col-md-3 pt-2 pb-4">
      <div className="card sizing d-flex justify-content-center">
        <PictureCarousel links={pictureUrl}/>
        <div className="card-body">
          <Container >
            <Row xs={2} md={3} className="d-flex flex-row pb-3">
              <Col className="d-flex justify-content-end">{hotelName}</Col>
              <Col className="d-flex justify-content-start">
                <MdOutlineStarBorderPurple500 /> {rating}
              </Col>
              <span className="more">
                <IoLocationSharp /> {hotelAddress}
              </span>
            </Row>
            <div xs={2} md={5} className="d-flex align-items-end pb-3">
              <div className="d-flex align-items-center">
                <h3 className="bold d-sm-flex">{pricing}</h3>
                <p className="d-flex align-items-end pt-2">/per night</p>
              </div>
            </div>
            <Row xs="auto">
              <Col className="pb-4">
                <MdOutlineBed /> {beds} beds
              </Col>
              <Col>
                <IoPersonOutline /> {guests} guests
              </Col>
            </Row>
          </Container>
          <a href="#" className="btn btn-custom">
            Book now!
          </a>
        </div>
      </div>
    </div>
  );
}
