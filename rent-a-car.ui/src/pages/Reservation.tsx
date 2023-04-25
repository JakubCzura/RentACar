import { SetStateAction, useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
import "react-datepicker/dist/react-datepicker.css";
import axios from 'axios';
import corsConfig from "../helpers/CORSConfig";
import { PickupLocation } from "../models/PickupLocation";
import { DropoffLocation } from "../models/DropoffLocation";
import { Car } from "../models/Car";
import { MakeReservationDto } from "../models/dtos/MakeReservationDto";
import { Button, DatePicker, Form, Input, Select } from "antd";


const Reservation = () => {
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


    // function handleCarSelection(event: React.ChangeEvent<HTMLSelectElement>) {
    //     const carId = event.target.value;
    //     const selected = cars.find((car) => car.id === parseInt(carId));
    //     setSelectedCar(selected);
    // }

    // function handlePickupLocationSelection(event: any) {
    //     const locationId = event.target.value;
    //     const selected = pickupLocations.find((pickupLocation) => pickupLocation.id === parseInt(locationId));
    //     setSelectedPickupLocation(selected);
    // }

    // function handleDropoffLocationSelection(event: any) {
    //     const locationId = event.target.value;
    //     const selected = dropoffLocations.find((dropoffLocation) => dropoffLocation.id === parseInt(locationId));
    //     setSelectedDropoffLocation(selected);
    // }

    async function makeReservation() {
        const makeReservationDto: MakeReservationDto = {
            startDate: startDate,
            endDate: endDate,
            carId: selectedCar?.id,
            pickupLocationId: selectedPickupLocation?.id,
            dropoffLocationId: selectedDropoffLocation?.id,
            userId: Number(localStorage.getItem("userId"))
        }
        const response = await axios.post<MakeReservationDto>("https://localhost:7216/reservation/create", makeReservationDto, config);
    }

    if (localStorage.getItem("authenticated") != "true") {
        return <Navigate replace to="/login" />;

    } else {
        return (
            <div style={{ display: "flex", justifyContent: "center" }}>
                <Form
                // onFinish={async (values) => {
                //     const dto: MakeReservationDto =
                //     {
                //         name: values.name,
                //         carId: values.car.id
                //         surname: values.surname,
                //         email: values.email,
                //         password: values.password,
                //         phoneNumber: values.phoneNumber
                //     }
                //     if (await register(dto, corsConfig) == true) {
                //         alert('You were registered!');
                //         //navigate("/login")
                //     }
                //     else {
                //         alert("Registration failed. Please try again.");
                //     }
                // }
                //}
                >
                    <Form.Item label="Start date" name="startDate">
                        <DatePicker />
                    </Form.Item>
                    <Form.Item label="End date" name="endDate">
                        <DatePicker />
                    </Form.Item>
                    {/* <Form.Item label="Select" name="car" initialValue={selectedCar?.id}> */}
                    <Form.Item label="Car" name="car" initialValue={selectedCar?.id}>
                        {/* <Select onChange={setSelectedCar}> */}
                        <Select >
                            {cars.map(car => (
                                <Select.Option key={car.id} value={car.id}>
                                    {car.make} {car.model}, {car.kind}, daily rate: {car.dailyRate}
                                </Select.Option>
                            ))}
                        </Select>
                    </Form.Item>
                    <Form.Item label="Pickup location" name="pickupLocation" initialValue={selectedPickupLocation?.id}>
                        {/* <Select onChange={setSelectedCar}> */}
                        <Select >
                            {pickupLocations.map(location => (
                                <Select.Option key={location.id} value={location.id}>
                                    {location.name}
                                </Select.Option>
                            ))}
                        </Select>
                    </Form.Item>
                    <Form.Item label="Dropoff location" name="dropoffLocation" initialValue={selectedDropoffLocation?.id}>
                        {/* <Select onChange={setSelectedCar}> */}
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

            // return (
            //     <div>
            //         <h2>Choose Reservation Dates</h2>
            //         <div>
            //             <label>Start Date:</label>
            //             <DatePicker selected={startDate} onChange={(date) => setStartDate(date)} />
            //         </div>
            //         <div>
            //             <label>End Date:</label>
            //             <DatePicker selected={endDate} onChange={(date) => setEndDate(date)} />
            //             <h2>Car Selection</h2>
            //         </div>
            //         <div>
            //             <label htmlFor="car-select">Choose a Car:</label>
            //             <select id="car-select" onChange={handleCarSelection}>
            //                 <option value="">Select a car</option>
            //                 {cars.map((car) => (
            //                     <option key={car.id} value={car.id}>
            //                         {car.make} {car.model}
            //                     </option>
            //                 ))}
            //             </select>
            //         </div>
            //         {selectedCar && (
            //             <div>
            //                 <h3>Selected Car</h3>
            //                 <p>Make: {selectedCar.make}</p>
            //                 <p>Model: {selectedCar.model}</p>
            //                 <p>Plate Number: {selectedCar.plateNumber}</p>
            //                 <p>Daily Rate: {selectedCar.dailyRate}</p>
            //                 <p>Kind: {selectedCar.kind}</p>
            //                 <p>Is Available: {selectedCar.isAvailable ? "Yes" : "No"}</p>
            //             </div>
            //         )}
            //         <div>
            //             <label htmlFor="pickupLocation-select">Choose pickup location:</label>
            //             <select id="pickupLocation-select" onChange={handlePickupLocationSelection}>
            //                 <option value="">Select pickup location</option>
            //                 {pickupLocations.map((location) => (
            //                     <option key={location.id} value={location.id}>
            //                         {location.name}
            //                     </option>
            //                 ))}
            //             </select>
            //         </div>
            //         {selectedPickupLocation && (
            //             <div>
            //                 <h3>Selected pickedup location</h3>
            //                 <p>Name: {selectedPickupLocation.name}</p>
            //             </div>
            //         )}
            //         <div>
            //             <label htmlFor="dropoffLocation-select">Choose dropoff location:</label>
            //             <select id="dropoffLocation-select" onChange={handleDropoffLocationSelection}>
            //                 <option value="">Select dropoff location</option>
            //                 {dropoffLocations.map((location) => (
            //                     <option key={location.id} value={location.id}>
            //                         {location.name}
            //                     </option>
            //                 ))}
            //             </select>
            //         </div>
            //         {selectedDropoffLocation && (
            //             <div>
            //                 <h3>Selected dropoff location</h3>
            //                 <p>Name: {selectedDropoffLocation.name}</p>
            //             </div>
            //         )}
            //         <div>
            //             <button onClick={makeReservation}>Submit reservation</button>
            //         </div>
            //     </div>
            // );
        )
    }
};

export default Reservation;
