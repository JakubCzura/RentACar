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
import { GetTotalCost } from "../models/dtos/GetTotalCost";

const Summary = () => {

    const [makeReservationDto, setMakeReservationDto] = useState<MakeReservationDto>();
    const config: any = corsConfig;
    const [startDate, setStartDate] = useState<Date | null>(new Date());
    const [endDate, setEndDate] = useState<Date | null>(new Date());
    const [cars, setCars] = useState<Car[]>([]);
    const [pickupLocations, setPickupLocations] = useState<PickupLocation[]>([]);
    const [dropoffLocations, setDropoffLocations] = useState<DropoffLocation[]>([]);
    const [selectedCar, setSelectedCar] = useState<Car>();
    const [pickupLocation, setPickupLocation] = useState<PickupLocation>();
    const [dropoffLocation, setDropoffLocation] = useState<DropoffLocation>();
    const [car, setCar] = useState<Car>()
    const [totalCost, setTotalCost] = useState<number>()
    const location = useLocation();
    console.log(location)
    const reservationData = location.state?.data;

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<Car[]>("https://localhost:7216/car/getAll");
            setCars(data);
            setCar(data.find(location => location.id === reservationData.pickupLocationId))
        })()
    }, []);

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<PickupLocation[]>("https://localhost:7216/location/getPickupLocations");
            setPickupLocations(data);
            setPickupLocation(data.find(location => location.id === reservationData.pickupLocationId))
        })()
    }, []);

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<DropoffLocation[]>("https://localhost:7216/location/getDropoffLocations");
            setDropoffLocations(data);
            setDropoffLocation(data.find(location => location.id === reservationData.dropoffLocationId))
        })()
    }, []);

    return (
        <div style={{ display: "flex", justifyContent: "center" }}>
            <Card title="Summary">
                <p>Start date: {reservationData.startDate}</p>
                <p>End date: {reservationData.endDate}</p>
                <p>Car: {car?.make} {car?.model} - {car?.kind} - {car?.plateNumber}</p>
                <p>Pickup location: {pickupLocation?.name} </p>
                <p>Dropoff location: {dropoffLocation?.name}</p>
                <p>Total cost: {reservationData.totalCost} EUR</p>
            </Card>
        </div>
    )

};

export default Summary;
