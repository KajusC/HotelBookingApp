import React, { useEffect, useState } from 'react';
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';
import { getUserInfo } from '../functions/api';
import { Button } from 'react-bootstrap';

export default function UserPanel() {
  const [userInfo, setUserInfo] = useState(null);
  const [decodedInfo, setDecodedInfo] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUserInfo = async () => {
      try {
        const token = Cookies.get('token');
        if (token) {
          const decodedToken = jwtDecode(token);
          setDecodedInfo(decodedToken);

          const user = await getUserInfo(decodedToken.nameid);
          setUserInfo(user);
        }
      } catch (err) {
        setError('Failed to fetch user data.');
        console.error('Error fetching user info:', err);
      } finally {
        setLoading(false);
      }
    };

    fetchUserInfo();
  }, []);

  if (loading) return <div className="flex justify-center items-center h-screen text-lg text-gray-500">Loading...</div>;
  if (error) return <div className="flex justify-center items-center h-screen text-lg text-red-500">{error}</div>;
  if (!userInfo) return <div className="flex justify-center items-center h-screen text-lg text-gray-500">No user data available.</div>;

  return (
    <div className="flex justify-center items-center h-screen bg-[#e6e6e6] p-6 ">
      <div className="bg-white shadow-lg rounded-lg overflow-hidden w-full max-w-md">
        <div className="bg-gradient-to-r from-stone-400 to-stone-500 p-4 text-white text-center">
          <h1 className="text-2xl font-bold">Welcome, {userInfo.userName}</h1>
        </div>
        <div className="p-6 space-y-4">
          <div className="flex justify-between bg-gray-50 p-4 rounded-lg shadow-sm">
            <span className="font-semibold text-gray-700">First Name:</span>
            <span className="text-gray-900 bold">{userInfo.firstName}</span>
          </div>
          <div className="flex justify-between bg-gray-50 p-4 rounded-lg shadow-sm">
            <span className="font-semibold text-gray-700">Last Name:</span>
            <span className="text-gray-900 bold">{userInfo.lastName}</span>
          </div>
          <div className="flex justify-between bg-gray-50 p-4 rounded-lg shadow-sm">
            <span className="font-semibold text-gray-700">Email:</span>
            <span className="text-gray-900 bold">{userInfo.email}</span>
          </div>
        </div>
        <div className='border-t-2 border-y-stone-300'>
          <p> Show order history </p>
          <Button variant="custom" className='mb-4'>Order History</Button>
        </div>
      </div>
    </div>
  );
}