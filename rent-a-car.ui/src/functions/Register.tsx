import axios from "axios";
import { RegisterUserDto } from "../models/dtos/RegisterUserDto";
import { RegisterResponse } from "../models/RegisterResponse";

export default async function register(registerData: RegisterUserDto, config: any): Promise<boolean> {
    try {
        const response = await axios.post<RegisterResponse>("https://localhost:7216/account/register", registerData, config);
        if (response.status == 200 || response.status == 201) {
            return true;
        }
    } catch (error) {
        console.error(error);
        alert("An error occurred while registration. Please try again later.");
        return false;
    }
    return false;
}

