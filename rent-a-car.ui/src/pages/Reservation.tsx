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
import reserve from "../functions/Reserve";

const Reservation = () => {
    
    const navigate = useNavigate();
    const config: any = corsConfig;
    const [startDate, setStartDate] = useState<Date | null>(new Date());
    const [endDate, setEndDate] = useState<Date | null>(new Date());
    const [cars, setCars] = useState<Car[]>([]);
    const [pickupLocations, setPickupLocations] = useState<PickupLocation[]>([]);
    const [dropoffLocations, setDropoffLocations] = useState<DropoffLocation[]>([]);
    const [selectedCar, setSelectedCar] = useState<Car>();
    const [selectedPickupLocation, setSelectedPickupLocation] = useState<PickupLocation>();
    const [selectedDropoffLocation, setSelectedDropoffLocation] = useState<DropoffLocation>();

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<Car[]>("https://localhost:7216/car/getAllAvailable");
            setCars(data);
        })()
    }, []);

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<PickupLocation[]>("https://localhost:7216/location/getPickupLocations");
            setPickupLocations(data);
        })()
    }, []);

    useEffect(() => {
        (async () => {
            const { data } = await axios.get<DropoffLocation[]>("https://localhost:7216/location/getDropoffLocations");
            setDropoffLocations(data);
        })()
    }, []);

    const handleCarChange = (carId: number) => {
        const car = cars.find(car => car.id === carId);
        setSelectedCar(car);
    };

    if (localStorage.getItem("authenticated") != "true") {
        return <Navigate replace to="/login" />;

    } else {
        return (
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
                        const response = await reserve(dto, corsConfig)
                        {
                            alert('You have been reserved the car!');
                            navigate("/summary", { state: {data: response} })

                        }
                            //navigate("/login")
                       
                    }
                    }
                >
                    <Form.Item label="Start date" name="startDate">
                        <DatePicker showTime={false} />
                    </Form.Item>
                    <Form.Item label="End date" name="endDate">
                        <DatePicker showTime={false} />
                    </Form.Item>
                    <Form.Item label="Car" name="car" initialValue={selectedCar?.id}>
                        {/* <Select onChange={setSelectedCar}> */}
                        <Select onChange={handleCarChange}>
                            {cars.map(car => (
                                <Select.Option key={car.id} value={car.id}>
                                    {car.make} {car.model}, {car.kind}, daily rate: {car.dailyRate}
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
                            <p>Daily Rate: {selectedCar.dailyRate}</p>
                            <p>Kind: {selectedCar.kind}</p>
                        </div>)}
                    <Form.Item label="Pickup location" name="pickupLocation" initialValue={selectedPickupLocation?.id}>
                        <Select >
                            {pickupLocations.map(location => (
                                <Select.Option key={location.id} value={location.id}>
                                    {location.name}
                                </Select.Option>
                            ))}
                        </Select>
                    </Form.Item>
                    <Form.Item label="Dropoff location" name="dropoffLocation" initialValue={selectedDropoffLocation?.id}>
                        <Select >
                            {dropoffLocations.map(location => (
                                <Select.Option key={location.id} value={location.id}>
                                    {location.name}
                                </Select.Option>
                            ))}
                        </Select>
                    </Form.Item>

                    <Form.Item>
                        <Button block htmlType='submit'>Submit</Button>
                    </Form.Item>
                </Form>
            </div>
        )
    }
};

export default Reservation;
