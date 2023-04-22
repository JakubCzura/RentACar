import React, { useState } from "react";
import { Navigate, redirect } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import axios from "axios";

interface LogInUserDto {
  email: string;
  password: string;
}

interface LoginResponse {
  userId: string;
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

const Login = () => {

  
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const navigate = useNavigate();
  const logIn = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const loginData: LogInUserDto = { email, password };
     try {
      const response = await axios.post<LoginResponse>("https://localhost:7216/account/login", loginData, config);
      const { userId } = response.data;
      if (userId) {      
        localStorage.setItem("authenticated", "true");
        localStorage.setItem("userID", userId);
        navigate("/reservation");
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
        <label>
          Email:
          <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
        </label>
        <label>
          Password:
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
        </label>
        <button type="submit">Log In</button>
      </form>
    </div>
  );


};

export default Login;