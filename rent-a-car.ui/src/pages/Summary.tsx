import { useEffect, useState } from "react";
import { Navigate, useLocation, useNavigate } from "react-router-dom";
import "react-datepicker/dist/react-datepicker.css";
import axios from 'axios';
import { PickupLocation } from "../models/PickupLocation";
import { DropoffLocation } from "../models/DropoffLocation";
import { Car } from "../models/Car";
import { MakeReservationDto } from "../models/dtos/MakeReservationDto";
import { Button, Card } from "antd";
import reserve from "../functions/Reserve";
import { getConfig } from "@testing-library/react";
import Navbar from "../components/Navbar";

const Summary = () => {
    const navigate = useNavigate()
    const [pickupLocation, setPickupLocation] = useState<PickupLocation>()
    const [dropoffLocation, setDropoffLocation] = useState<DropoffLocation>()
    const [car, setCar] = useState<Car>()
    const location = useLocation()
    console.log(location)
    const reservationData = location.state?.data

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<Car>("https://localhost:7216/car/" + reservationData.carId)
            setCar(data)
        })()
    }, []);

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<PickupLocation>("https://localhost:7216/location/getPickupLocation/" + reservationData.pickupLocationId)
            setPickupLocation(data)
        })()
    }, []);

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<DropoffLocation>("https://localhost:7216/location/getDropoffLocation/" + reservationData.dropoffLocationId)
            setDropoffLocation(data)
        })()
    }, []);

    async function handleReservation(makeReservationDto: MakeReservationDto, config: any) {
        const result = await reserve(new MakeReservationDto(new Date(reservationData.startDate),
            new Date(reservationData.endDate),
            reservationData.carId,
            reservationData.pickupLocationId,
            reservationData.dropoffLocationId,
            Number(localStorage.getItem("userId"))),
            getConfig
        )
        if (result) {
            navigate("/thanks", { state: { confirmedReservation: pickupLocation, confirmedDate: reservationData.startDate } })
        }
    }

    if (localStorage.getItem("authenticated") != "true") {
        return <Navigate replace to="/login" />
    } else {
        return (
            <div>
                <Navbar />
                <div style={{ display: "flex", justifyContent: "center" }}>
                    <Card title="Summary">
                        <p>Start date: {new Date(reservationData.startDate).toDateString()}</p>
                        <p>End date: {new Date(reservationData.endDate).toDateString()}</p>
                        <p>Pickup location: {pickupLocation?.name}</p>
                        <p>Dropoff location: {dropoffLocation?.name}</p>
                        <p>Total cost: {reservationData.totalCost} EUR</p>
                        <p>Client: {reservationData.name} {reservationData.surname}</p>
                        <p>Email: {reservationData.email}</p>
                        <p>Phone number: {reservationData.phoneNumber}</p>
                        <br></br>
                        <p>We are open 24/7</p>
                        <p>You can pay with cash and credit card</p>
                        <div>
                            <Button block type="primary" htmlType='submit' style={{ margin: 5 }}
                                onClick={() => handleReservation(new MakeReservationDto(new Date(reservationData.startDate),
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
            </div>
        )
    }
};

export default Summary;
