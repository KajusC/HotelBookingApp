import React from 'react';

const fetchData = async () => {
    try {
        const response = await fetch('http://localhost:5188/Hotel');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const jsonData = await response.json();
        console.log('GET request successful');
        console.log('Data:', jsonData);
    } catch (error) {
        console.error('Error fetching data:', error);
    }
};

const postData = async () => {
    try {
        const response = await fetch('http://localhost:5188/api/DataSeed/seed', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                // Add your POST request payload here if needed
            }),
        });
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        console.log('POST request successful');
    } catch (error) {
        console.error('Error making POST request:', error);
    }
};


function ApiControl() {
    const postData = async () => {
        // Paste the POST request code here
    };

    const fetchData = async () => {
        // Paste the GET request code here
    };

    return (
        <div>
            <button onClick={postData}>Post Data</button>
            <button onClick={fetchData}>Fetch Data</button>
        </div>
    );
}

export default MyComponent;
