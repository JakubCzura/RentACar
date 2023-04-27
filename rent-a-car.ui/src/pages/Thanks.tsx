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

const Thanks = () => {
    const navigate = useNavigate()
    const [pickupLocation, setPickupLocation] = useState<PickupLocation>()
    const [dropoffLocation, setDropoffLocation] = useState<DropoffLocation>()
    const [car, setCar] = useState<Car>()
    const location = useLocation()
    console.log(location)
    const confirmedReservation = location.state?.confirmedReservation
    const confirmedDate = location.state?.confirmedDate
    console.log(confirmedReservation)

    if (localStorage.getItem("authenticated") != "true") {
        return <Navigate replace to="/login" />
    } else {
        return (
        <div>
            <Navbar />
            <div style={{ display: "flex", justifyContent: "center" }}>
                <Card title="Reservation confirmed">
                    <h2>Thank you for choosing our company</h2>
                    <p>We expect you at {confirmedReservation.name}, {new Date(confirmedDate).toDateString()}</p>
                    <div>
                        <Button block type="primary" htmlType='submit' style={{ margin: 5 }}
                            onClick={() => navigate("/reservation")}>Back to main page</Button>
                    </div>
                </Card>
            </div>
        </div>
        )
    }
};

export default Thanks;
