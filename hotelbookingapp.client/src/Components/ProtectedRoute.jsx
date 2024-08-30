import React, { useEffect, useState } from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { verifyToken } from '../functions/api';
import Cookies from 'js-cookie';

export default function ProtectedRoute() {
  const [isAuthenticated, setIsAuthenticated] = useState(null); // Initial state

  useEffect(() => {
    const token = Cookies.get('token');
    if (token) {
      verifyToken(token)
        .then(response => {
          setIsAuthenticated(response); // Set based on verification
        })
        .catch(() => {
          setIsAuthenticated(false); // Handle errors by setting false
        });
    } else {
      setIsAuthenticated(false); // No token, not authenticated
    }
  }, []);

  if (isAuthenticated === null) {
    return <div>Loading...</div>; // While loading
  }

  return isAuthenticated ? <Outlet /> : <Navigate to="/login" />;
}
