import axios from "axios";
import { LogInUserDto } from "../models/dtos/LogInUserDto";
import { LogInResponse } from "../models/LogInResponse";

export default async function logIn(logInData: LogInUserDto, config: any): Promise<boolean> {
     try {
      const response = await axios.post<LogInResponse>("https://localhost:7216/account/login", logInData, config);
      const { userId } = response.data;
      if (userId) {      
        localStorage.setItem("authenticated", "true");
        localStorage.setItem("userId", userId);
        return true;
      } else {
        alert("Login failed. Please try again.");
        return false;
      }
    } catch (error) {
      console.error(error);
      alert("An error occurred while logging in. Please try again later.");
      return false;
    }
  };