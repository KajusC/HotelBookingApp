import axios from 'axios';

export const fetchHotels = async () => {
    const response = await axios.get('https://localhost:7103/api/Hotel');
    return response.data;
    }