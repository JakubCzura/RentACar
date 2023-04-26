import axios from "axios";
import { RegisterUserDto } from "../models/dtos/RegisterUserDto";
import { RegisterResponse } from "../models/RegisterResponse";
import { MakeReservationDto } from "../models/dtos/MakeReservationDto";

export default async function reserve(makeReservationDto: MakeReservationDto, config: any): Promise<boolean> {
    try {        
        const response = await axios.post<MakeReservationDto>("https://localhost:7216/reservation/create", makeReservationDto, config);   
        if (response.status == 200 || response.status == 201) {
            return true;
        }
    } catch (error) {
        console.error(error);
        alert("An error occurred while reserving the car. Please try again later.");
        return false;
    }
    return false;
}

