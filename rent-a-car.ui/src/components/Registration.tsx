import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import corsConfig from "../helpers/CORSConfig";

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

const Registration = () => {
    const config:any = corsConfig;
    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const navigate = useNavigate();
    
    const logIn = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const registerData: RegisterUserDto = {name, surname, email, password, phoneNumber };
     try {
      const response = await axios.post<RegisterResponse>("https://localhost:7216/account/register", registerData, config);
      if (response.status == 200 || response.status == 201) {      
        navigate("/login");
        alert('You were registered!');
      } else {
        alert("Registration failed. Please try again.");
      }
    } catch (error) {
      console.error(error);
      alert("An error occurred while registration. Please try again later.");
    }
  };

  return (
    <div>
      <form onSubmit={logIn}>
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