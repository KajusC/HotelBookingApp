import React, {useRef, useState} from "react";
import { postUserRegister } from "../functions/api";
import {validateName, validateLastName, validateEmail, validatePassword} from "../functions/Validation";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import FloatingLabel from "react-bootstrap/FloatingLabel";
import ToastList from "../Components/ToastList.jsx";

export default function RegisterPage() {
    const [toastList, setToastList] = useState([]);

    const usernameRef = useRef();
    const firstNameRef = useRef();
    const lastNameRef = useRef();
    const emailRef = useRef();
    const passwordRef = useRef();

    function handleSubmit(e) {
      e.preventDefault();

      if(usernameRef.current.value === "" || firstNameRef.current.value === "" || lastNameRef.current.value === "" || emailRef.current.value === "" || passwordRef.current.value === "") {
            addToast({
                id: Date.now().toString(),
                title: "Error",
                description: "Please fill all fields",
                type: "error",
            });
            console.log(toastList);
            
        return;
        }

        const isNameValid = validateName(firstNameRef.current.value, addToast);
        if(!isNameValid) {
            return;
        }

        const isLastNameValid = validateLastName(lastNameRef.current.value, addToast);
        if(!isLastNameValid) {
            return;
        }

        const isEmailValid = validateEmail(emailRef.current.value, addToast);
        if(!isEmailValid) {
            return;
        }

        const isPasswordValid = validatePassword(passwordRef.current.value, addToast);
        if(!isPasswordValid) {
            return;
        }
        
        
      const userData = {
        username: usernameRef.current.value,
        firstName: firstNameRef.current.value,
        lastName: lastNameRef.current.value,
        email: emailRef.current.value,
        password: passwordRef.current.value,
      };
      console.log(userData);

      try {
        postUserRegister(userData);
        console.log("User Registered");
        addToast({
            id: Date.now().toString(),
            title: "Success",
            description: "User Registered",
            type: "success",
        });
      } catch (e) {
        console.log(e);
      }
    }

    function removeToast(id) {
      setToastList((prev) => prev.filter((toast) => toast.id !== id));
    }
    
    function addToast(toast) {
      setToastList((prev) => [...prev, toast]);
    }

  return (
    <div>
      <div className="flex flex-col justify-center items-center py-20">
        <ToastList toasts={toastList} removeToast={removeToast} />
        <div className="card flex flex-col w-1/4">
          <h1 className="card-header text-4xl text-center">Register</h1>
          <Form className="flex flex-col p-4 w-full gap-3" onSubmit={handleSubmit}>
            <FloatingLabel controlId="floatingInput" label="Username">
              <Form.Control
                type="text"
                placeholder="Username"
                ref={usernameRef}
              />
            </FloatingLabel>

            <FloatingLabel controlId="floatingInput" label="First Name">
              <Form.Control
                type="text"
                placeholder="First Name"
                ref={firstNameRef}
              />
            </FloatingLabel>
            <FloatingLabel controlId="floatingInput" label="Last Name">
              <Form.Control
                type="text"
                placeholder="Last Name"
                ref={lastNameRef}
              />
            </FloatingLabel>
            <FloatingLabel controlId="floatingInput" label="Email address">
              <Form.Control type="email" placeholder="Email" ref={emailRef} />
            </FloatingLabel>
            <FloatingLabel controlId="floatingPassword" label="Password">
              <Form.Control
                type="password"
                placeholder="Password"
                ref={passwordRef}
              />
            </FloatingLabel>
            <Button
              variant="custom"
              type="submit"
              className="mt-4 card-footer"
            >
              Submit
            </Button>
          </Form>
        </div>
      </div>
    </div>
  );
}
