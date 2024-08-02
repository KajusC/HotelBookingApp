import Container from "react-bootstrap/Container";
import PictureCarousel from "./PictureCarousel";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { FaStar } from "react-icons/fa6";
import { IoLocationSharp } from "react-icons/io5";
import { MdOutlineBed } from "react-icons/md";
import { IoPersonOutline } from "react-icons/io5";

export default function DisplayCard({
  hotelName = "X",
  rating = "X",
  hotelAddress,
  pricing = "X",
  beds = "X",
  guests = "X",
  pictureUrl,
}) {
  return (
    <div className="col-md-3 pt-2 pb-4">
      <div className="card sizing d-flex justify-content-center">
        <PictureCarousel links={pictureUrl} showControls={true} />
        <div className="card-body">
          <div className="d-flex justify-content-between">
            <h5 className="card-title bold pb-4">{hotelName}</h5>
            <h5 className="card-title flex">
              {rating}
              <FaStar fill="yellow" className="" />
            </h5>
          </div>
          <div className="d-flex justify-content-between">
            <p className="card-text flex pb-3">
              <IoLocationSharp className="mr-3" />
              {hotelAddress}
            </p>
          </div>
          <div className="d-flex justify-content">
            <h3 className="card-text flex">
              {pricing}
              <p className="text-muted font-small pt-3">/night</p>
            </h3>
          </div>
          <div className="d-flex justify-content-between grid">
            <p className="card-text flex">
              <MdOutlineBed className="mr-3" />
              {beds} beds
            </p>
            <p className="card-text flex">
              <IoPersonOutline className="mr-3" />
              {guests} guests
            </p>
          </div>
          <a href="#" className="btn btn-custom">
            Book now!
          </a>
        </div>
      </div>
    </div>
  );
}
