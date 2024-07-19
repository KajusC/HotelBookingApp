import Navbar from "./Navbar";
import SearchBar from "./SearchBar";
import './App.css';
import DisplayCard from "./DisplayCard";

export default function App() {
    return (
        <div>
            <Navbar/>
            <SearchBar />
            <div className="d-flex justify-content-center row-cols-2">
            <DisplayCard pictureUrl={"https://imgs.search.brave.com/dbQOGFRbcKr9NO_IDmAxzbrl6X352tkcvNTApIRsGaQ/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvMTAw/NjE4NzEyMC9waG90/by9iZWF1dGlmdWwt/bW9kZXJuLWhvdGVs/LXJvb20uanBnP3M9/NjEyeDYxMiZ3PTAm/az0yMCZjPTR4X2lw/SW1fcUVoUW93ai1w/cGlRZ1VBTFdQZEt0/RFg5T2d0SndXN1R1/WkE9"} title={"booking"} text={"Good one"}/>
            <DisplayCard pictureUrl={"https://imgs.search.brave.com/dbQOGFRbcKr9NO_IDmAxzbrl6X352tkcvNTApIRsGaQ/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvMTAw/NjE4NzEyMC9waG90/by9iZWF1dGlmdWwt/bW9kZXJuLWhvdGVs/LXJvb20uanBnP3M9/NjEyeDYxMiZ3PTAm/az0yMCZjPTR4X2lw/SW1fcUVoUW93ai1w/cGlRZ1VBTFdQZEt0/RFg5T2d0SndXN1R1/WkE9"} title={"booking"} text={"Good one"}/>
            <DisplayCard pictureUrl={"https://imgs.search.brave.com/dbQOGFRbcKr9NO_IDmAxzbrl6X352tkcvNTApIRsGaQ/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvMTAw/NjE4NzEyMC9waG90/by9iZWF1dGlmdWwt/bW9kZXJuLWhvdGVs/LXJvb20uanBnP3M9/NjEyeDYxMiZ3PTAm/az0yMCZjPTR4X2lw/SW1fcUVoUW93ai1w/cGlRZ1VBTFdQZEt0/RFg5T2d0SndXN1R1/WkE9"} title={"booking"} text={"Good one"}/>
            <DisplayCard pictureUrl={"https://imgs.search.brave.com/dbQOGFRbcKr9NO_IDmAxzbrl6X352tkcvNTApIRsGaQ/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvMTAw/NjE4NzEyMC9waG90/by9iZWF1dGlmdWwt/bW9kZXJuLWhvdGVs/LXJvb20uanBnP3M9/NjEyeDYxMiZ3PTAm/az0yMCZjPTR4X2lw/SW1fcUVoUW93ai1w/cGlRZ1VBTFdQZEt0/RFg5T2d0SndXN1R1/WkE9"} title={"booking"} text={"Good one"}/>
            </div>
            <h1>Display</h1>
        </div>
    );
}