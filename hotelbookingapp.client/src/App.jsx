import "./App.css";
import Navbar from "./Components/Navbar.jsx";
import SearchBar from "./Components/SearchBar.jsx";
import DisplayCard from "./Components/DisplayCard.jsx";
import SearchWindow from "./Components/SearchWindow.jsx";
import HorizontalSlider from "./Components/HorizontalSlider.jsx";

const picture = [
  "https://images.pexels.com/photos/5371575/pexels-photo-5371575.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
  "https://images.pexels.com/photos/164595/pexels-photo-164595.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
];
export default function App() {
  return (
    <div>
      <Navbar />
      <SearchWindow SearchBar={SearchBar} />
      <div className="d-flex justify-content-center row-cols-2">
        <HorizontalSlider title={"Best deals"}>
          <DisplayCard
            hotelName="Hotel 1"
            rating="4.5"
            hotelAddress="Brimmi UK,  1234dawdawddwdqwdweadwdawdawd"
            pricing="$100"
            beds="2"
            guests="4"
            pictureUrl={picture}
          />
          <DisplayCard
            hotelName="Hotel 1"
            rating="4.5"
            hotelAddress="Brimmi UK,  1234dawdawddwdqwdweadwdawdawd"
            pricing="$100"
            beds="2"
            guests="4"
            pictureUrl={picture}
          />
          <DisplayCard
            hotelName="Hotel 1"
            rating="4.5"
            hotelAddress="Brimmi UK,  1234dawdawddwdqwdweadwdawdawd"
            pricing="$100"
            beds="2"
            guests="4"
            pictureUrl={picture}
          />
          <DisplayCard
            hotelName="Hotel 1"
            rating="4.5"
            hotelAddress="Brimmi UK,  1234dawdawddwdqwdweadwdawdawd"
            pricing="$100"
            beds="2"
            guests="4"
            pictureUrl={picture}
          />
                    <DisplayCard
            hotelName="Hotel 1"
            rating="4.5"
            hotelAddress="Brimmi UK,  1234dawdawddwdqwdweadwdawdawd"
            pricing="$100"
            beds="2"
            guests="4"
            pictureUrl={picture}
          />
        </HorizontalSlider>
      </div>
    </div>
  );
}
