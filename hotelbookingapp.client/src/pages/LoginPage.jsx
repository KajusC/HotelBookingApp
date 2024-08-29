import React, { useRef, useContext } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import FloatingLabel from "react-bootstrap/FloatingLabel";

export default function LoginPage() {
  return (
    <div className="flex flex-col justify-center items-center pt-20">
      <div className="card flex flex-col w-1/4">
        <h1 className="card-header text-4xl text-center">Login</h1>
        <Form className="flex flex-col p-4 w-full">
          <FloatingLabel
            controlId="floatingInput"
            label="Email address or Username"
            className="mb-3"
          >
            <Form.Control type="email" placeholder="Email or username" />
          </FloatingLabel>
          <FloatingLabel controlId="floatingPassword" label="Password">
            <Form.Control type="password" placeholder="Password" />
          </FloatingLabel>
          <Form.Group className="mb-3 text-left" controlId="formBasicCheckbox">
            <Form.Check type="checkbox" label="Remember me" />
          </Form.Group>
          <a href="/register" className="text-center text-blue-500 underline">
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
