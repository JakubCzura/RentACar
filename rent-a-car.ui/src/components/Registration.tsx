import React, { useState } from "react";
import { Navigate, redirect } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import axios from "axios";

interface RegisterUserDto {
    name: string;
    surname: string;
    email: string;
    password: string;
    phoneNumber: string;
}

interface RegisterResponse {
    name: string;
    surname: string;
    email: string;
}

const config = {
  headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Headers': 'Origin, Methods, Content-Type, X-Auth-Token',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': ' GET, POST, PATCH, PUT, DELETE, OPTIONS',
      'Access-Control-Allow-Credentials': 'false',
      'Accept': 'application/json, text/plain, */*'
  }}

const Registration = () => {
    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [message, setMessage] = useState('');
  const navigate = useNavigate();
  const logIn = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const registerData: RegisterUserDto = {name, surname, email, password, phoneNumber };
     try {
      const response = await axios.post<RegisterResponse>("https://localhost:7216/account/register", registerData, config);
      if (response.status == 200 || response.status == 201) {      
        //localStorage.setItem("authenticated", "true");
        //localStorage.setItem("userId", userId);
        navigate("/login");
        setMessage('You were registered!');
      } else {
        alert("Login failed. Please try again.");
      }
    } catch (error) {
      console.error(error);
      alert("An error occurred while logging in. Please try again later.");
    }
  };
  


  return (
    <div>
      <form onSubmit={logIn}>
      {message && <p>{message}</p>} {/* render message if state is not empty */}
        <br/>
        <h2>
            Register
        </h2>
        <br/>
        <label>
          Name:
          <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
        </label>
        <br/>
        <label>
          Surname:
          <input type="text" value={surname} onChange={(e) => setSurname(e.target.value)} />
        </label>
        <br/>
        <label>
          Email:
          <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
        </label>
        <br/>
        <label>
          Password:
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
        </label>
        <br/>
        <label>
          Phone number:
          <input type="text" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} />
        </label>
        <br/>
        <button type="submit">Log In</button>
      </form>
    </div>
  );


};

export default Registration;