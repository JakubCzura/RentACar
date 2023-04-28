import { useEffect, useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import "react-datepicker/dist/react-datepicker.css";
import axios from 'axios';
import corsConfig from "../helpers/CORSConfig";
import { PickupLocation } from "../models/PickupLocation";
import { DropoffLocation } from "../models/DropoffLocation";
import { Car } from "../models/Car";
import { MakeReservationDto } from "../models/dtos/MakeReservationDto";
import { Button, DatePicker, Form, Select } from "antd";
import createSummary from "../functions/CreateSummary";
import Navbar from "../components/Navbar";

const Reservation = () => {

    const navigate = useNavigate()
    const [cars, setCars] = useState<Car[]>([])
    const [pickupLocations, setPickupLocations] = useState<PickupLocation[]>([])
    const [dropoffLocations, setDropoffLocations] = useState<DropoffLocation[]>([])
    const [selectedCar, setSelectedCar] = useState<Car>()

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<Car[]>("https://localhost:7216/car/getAllAvailable")
            setCars(data)
        })()
    }, [])

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<PickupLocation[]>("https://localhost:7216/location/getPickupLocations")
            setPickupLocations(data)
        })()
    }, [])

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<DropoffLocation[]>("https://localhost:7216/location/getDropoffLocations")
            setDropoffLocations(data)
        })()
    }, [])

    const handleCarChange = (carId: number) => {
        const car = cars.find(car => car.id === carId)
        setSelectedCar(car)
    }

    if (localStorage.getItem("authenticated") != "true") {
        return <Navigate replace to="/login" />;
    } else {
        return (
            <div>
                <Navbar />
                <div style={{ display: "flex", justifyContent: "center" }}>
                    <Form
                        onFinish={async (values) => {
                            const dto: MakeReservationDto =
                            {
                                startDate: values.startDate,
                                endDate: values.endDate,
                                carId: values.car,
                                pickupLocationId: values.pickupLocation,
                                dropoffLocationId: values.dropoffLocation,
                                userId: Number(localStorage.getItem("userId"))
                            }
                            const response = await createSummary(dto, corsConfig)
                            {
                                if (response) {
                                    navigate("/summary", { state: { data: response } })
                                }
                            }
                        }
                        }
                    >
                        <h3>Rent a car</h3>
                        <Form.Item label="Start date" name="startDate">
                            <DatePicker showTime={false} />
                        </Form.Item>
                        <Form.Item label="End date" name="endDate">
                            <DatePicker showTime={false} />
                        </Form.Item>
                        <Form.Item label="Car" name="car" initialValue={selectedCar?.id}>
                            <Select onChange={handleCarChange}>
                                {cars.map(car => (
                                    <Select.Option key={car.id} value={car.id}>
                                        {car.make} {car.model}, {car.kind}, daily rate: {car.dailyRate} EUR
                                    </Select.Option>
                                ))}
                            </Select>
                        </Form.Item>
                        {selectedCar && (
                            <div>
                                <h3>Selected Car</h3>
                                <p>Make: {selectedCar.make}</p>
                                <p>Model: {selectedCar.model}</p>
                                <p>Plate Number: {selectedCar.plateNumber}</p>
                                <p>Daily Rate: {selectedCar.dailyRate} EUR</p>
                                <p>Kind: {selectedCar.kind}</p>
                            </div>)}
                        <Form.Item label="Pickup location" name="pickupLocation">
                            <Select >
                                {pickupLocations.map(location => (
                                    <Select.Option key={location.id} value={location.id}>
                                        {location.name}
                                    </Select.Option>
                                ))}
                            </Select>
                        </Form.Item>
                        <Form.Item label="Dropoff location" name="dropoffLocation">
                            <Select >
                                {dropoffLocations.map(location => (
                                    <Select.Option key={location.id} value={location.id}>
                                        {location.name}
                                    </Select.Option>
                                ))}
                            </Select>
                        </Form.Item>
                        <Form.Item>
                            <Button block type="primary" htmlType='submit'>Move to summary</Button>
                        </Form.Item>
                    </Form>
                </div>
            </div>
        )
    }
};

export default Reservation;
