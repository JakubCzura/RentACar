import { SetStateAction, useEffect, useState } from "react";
import { Navigate, useLocation, useNavigate } from "react-router-dom";
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
import { getConfig } from "@testing-library/react";

const Summary = () => {
    const navigate = useNavigate()
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
            const { data } = await axios.get<Car>("https://localhost:7216/car/" + reservationData.carId);
            setCar(data)
            //setCar(data.find(car => car.id === reservationData.carId))
        })()
    }, []);

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<PickupLocation>("https://localhost:7216/location/getPickupLocation/" + reservationData.pickupLocationId);
            setPickupLocation(data);
            //setPickupLocation(data.find(location => location.id === reservationData.pickupLocationId))
        })()
    }, []);

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<DropoffLocation>("https://localhost:7216/location/getDropoffLocation/" + reservationData.dropoffLocationId);
            setDropoffLocation(data);
            //setDropoffLocation(data.find(location => location.id === reservationData.dropoffLocationId))
        })()
    }, []);

    if (localStorage.getItem("authenticated") != "true") {
        return <Navigate replace to="/login" />;
    } else {
        return (
            <div style={{ display: "flex", justifyContent: "center" }}>
                <Card title="Summary">
                    <p>Start date: {new Date(reservationData.startDate).toDateString()}</p>
                    <p>End date: {new Date(reservationData.endDate).toDateString()}</p>
                    <p>Car: {car?.make} {car?.model} - {car?.kind} - {car?.plateNumber}</p>
                    <p>Pickup location: {pickupLocation?.name} </p>
                    <p>Dropoff location: {dropoffLocation?.name}</p>
                    <p>Total cost: {reservationData.totalCost} EUR</p>
                    <p>User: {reservationData.name} {reservationData.surname}</p>
                    <p>Email: {reservationData.email}</p>
                    <p>Phone number: {reservationData.phoneNumber}</p>
                    <div>
                        <Button block type="primary" htmlType='submit' style={{ margin: 5 }}
                            onClick={() => reserve(new MakeReservationDto(new Date(reservationData.startDate),
                                new Date(reservationData.endDate),
                                reservationData.carId,
                                reservationData.pickupLocationId,
                                reservationData.dropoffLocationId,
                                Number(localStorage.getItem("userId"))),
                                getConfig)}>Rent the car</Button>
                        <Button block type="primary" danger htmlType='submit' style={{ margin: 5 }} onClick={() => navigate("/reservation")}>Cancell</Button>
                    </div>

                </Card>

            </div>
        )
    }
};

export default Summary;
