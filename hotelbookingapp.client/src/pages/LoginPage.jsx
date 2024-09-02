import React, { useRef, useState, useEffect } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import FloatingLabel from "react-bootstrap/FloatingLabel";
import { postUserLogin } from "../functions/api";
import ToastList from "../Components/ToastList";
import { useNavigate } from "react-router-dom";

export default function LoginPage() {
  const [toastList, setToastList] = useState([]);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const usernameRef = useRef();
  const passwordRef = useRef();
  const navigate = useNavigate();

  useEffect(() => {
    if (isLoggedIn) {

      const timer = setTimeout(() => {
        navigate('/');
        window.location.reload();
      }, 1000);

      return () => clearTimeout(timer);
    }
  }, [isLoggedIn, navigate]);

  async function handleLogin(e) {
    e.preventDefault();
    const user = {
      username: usernameRef.current.value,
      password: passwordRef.current.value,
    };

    const login = await postUserLogin(user, addToast);

    if (login) {
      setIsLoggedIn(true);
    }
  }

  function removeToast(id) {
    setToastList((prev) => prev.filter((toast) => toast.id !== id));
  }

  function addToast(toast) {
    setToastList((prev) => [...prev, toast]);
  }

  return (
    <div className="flex flex-col justify-center items-center pt-20">
      <div className="card flex flex-col w-1/4">
        <ToastList toasts={toastList} removeToast={removeToast} />
        <h1 className="card-header text-4xl text-center">Login</h1>
        <Form className="flex flex-col p-4 w-full" onSubmit={handleLogin}>
          <FloatingLabel controlId="floatingInput" label="Username" className="mb-3">
            <Form.Control type="username" placeholder="Username" ref={usernameRef} />
          </FloatingLabel>
          <FloatingLabel controlId="floatingPassword" label="Password">
            <Form.Control type="password" placeholder="Password" ref={passwordRef} />
          </FloatingLabel>
          <Form.Group className="mb-3 text-left" controlId="formBasicCheckbox">
            <Form.Check type="checkbox" label="Remember me" />
          </Form.Group>
          <a href="/register" className="text-blue-500 underline text-sm text-left">
            Don't have an account? Register here
          </a>
          <Button variant="custom" type="submit" className="mt-4 card-footer">
            Submit
          </Button>
        </Form>
      </div>
    </div>
  );
}
