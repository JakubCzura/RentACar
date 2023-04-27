import { SetStateAction, useEffect, useState } from "react";
import { Navigate, useLocation } from "react-router-dom";
import "react-datepicker/dist/react-datepicker.css";
import axios from 'axios';
import corsConfig from "../helpers/CORSConfig";
import { PickupLocation } from "../models/PickupLocation";
import { DropoffLocation } from "../models/DropoffLocation";
import { Car } from "../models/Car";
import { MakeReservationDto } from "../models/dtos/MakeReservationDto";
import { Button, Card, DatePicker, Form, Input, Select } from "antd";
import reserve from "../functions/Reserve";
import { format, parseISO } from 'date-fns';

const Summary = () => {


    const [makeReservationDto, setMakeReservationDto] = useState<MakeReservationDto>();
    const config: any = corsConfig;
    const [startDate, setStartDate] = useState<Date | null >(new Date());
    const [endDate, setEndDate] = useState<Date | null >(new Date());
    const [cars, setCars] = useState<Car[]>([]);
    const [pickupLocations, setPickupLocations] = useState<PickupLocation[]>([]);
    const [dropoffLocations, setDropoffLocations] = useState<DropoffLocation[]>([]);
    const [selectedCar, setSelectedCar] = useState<Car>();
    const [selectedPickupLocation, setSelectedPickupLocation] = useState<PickupLocation>();
    const [selectedDropoffLocation, setSelectedDropoffLocation] = useState<DropoffLocation>();
    
    const location = useLocation();
    console.log(location)
    const reservationData = location.state?.data; 

   
        return (
            <div style={{ display: "flex", justifyContent: "center" }}>
                <Card title="Summary">
                <p>Name: { reservationData.startDate}</p>
      <p>Email: {reservationData.endDate}</p>
                </Card>
            </div>
        )
    
};

export default Summary;
