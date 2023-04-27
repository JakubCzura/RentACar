import axios from "axios";
import { MakeReservationDto } from "../models/dtos/MakeReservationDto";

export default async function createSummary(makeReservationDto: MakeReservationDto, config: any) : Promise<any> {
    try {        
        const response = await axios.post("https://localhost:7216/reservation/createSummary", makeReservationDto, config);   
        if (response.status == 200 || response.status == 201) {
            return response.data;
        }
    } catch (error) {
        console.error(error);
        alert("An error occurred while reserving the car. Please try again later.");
    }
}

