import './DisplayCard.css';

export default function DisplayCard({ pictureUrl, title, text }) {
  return (
    <div className="col-md-4">
      <div className="card sizing d-flex justify-content-center">
        <img
          src={pictureUrl}
          className="card-img-top"
          alt="..."
        />
        <div className="card-body">
          <h5 className="card-title">{title}</h5>
          <p className="card-text">
            {text}
          </p>
          <a href="#" className="btn btn-primary">
            Book now!
          </a>
        </div>
      </div>
    </div>
  );
}
