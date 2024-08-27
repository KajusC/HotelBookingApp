const express = require('express');
const cors = require('cors');
const app = express();

app.use(cors()); // Allow all origins for testing. Adjust as needed for production.

app.get('/api/Hotel', (req, res) => {
  res.json({ message: 'This is the hotel data' });
});

app.listen(7103, () => {
  console.log('API server is running on https://192.168.88.44/:7103');
});
