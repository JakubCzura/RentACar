import { SetStateAction, useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import axios from 'axios';


const Reservation = () => {

interface PickupLocation
{
    id: number;
    name: string;
}

interface DropoffLocation
{
    id: number;
    name: string;
}

interface Car
{
    id: number;
    make: string;
    model: string;
    plateNumber: string;
    dailyRate: number;
    kind: string;
    isAvailable: boolean;
}

interface MakeReservationDto {
    startDate: Date | null,
    endDate: Date | null,
    carId?: number,
    pickupLocationId?: number,
    dropoffLocationId?: number,
    userId?: number
}

    const [startDate, setStartDate] = useState<Date | null>(new Date());
    const [endDate, setEndDate] = useState<Date | null>(new Date());
    const [cars, setCars] = useState<Car[]>([]);
    const [pickupLocations, setPickupLocations] = useState<PickupLocation[]>([]);
    const [dropoffLocations, setDropoffLocations] = useState<DropoffLocation[]>([]);
    const [selectedCar, setSelectedCar] = useState<Car>();
    const [selectedPickupLocation, setSelectedPickupLocation] = useState<PickupLocation>();
    const [selectedDropoffLocation, setSelectedDropoffLocation] = useState<DropoffLocation>();

    const r:MakeReservationDto = {
        startDate : startDate,
        endDate : endDate,
        carId: selectedCar?.id,
        pickupLocationId: selectedPickupLocation?.id,
        dropoffLocationId: selectedDropoffLocation?.id,
        userId : Number(localStorage.getItem("userId"))
    }

    useEffect(() => {
        (async() => {
            const { data } = await axios.get<Car[]>("https://localhost:7216/car/getAllAvailable");
            setCars(data);
        })()
    }, []);

    useEffect(() => {
        (async() => {
            const { data } = await axios.get<PickupLocation[]>("https://localhost:7216/location/getPickupLocations");
            setPickupLocations(data);
        })()
    }, []);

    useEffect(() => {
        (async() => {
            const { data } = await axios.get<DropoffLocation[]>("https://localhost:7216/location/getDropoffLocations");
            setDropoffLocations(data);
        })()
    }, []);


    function handleCarSelection(event: React.ChangeEvent<HTMLSelectElement>) {
        const carId = event.target.value;
        const selected = cars.find((car) => car.id === parseInt(carId));
        setSelectedCar(selected);
    }

    function handlePickupLocationSelection(event: any) {
        const locationId = event.target.value;
        const selected = pickupLocations.find((pickupLocation) => pickupLocation.id === parseInt(locationId));
        setSelectedPickupLocation(selected);
    }

    function handleDropoffLocationSelection(event: any) {
        const locationId = event.target.value;
        const selected = dropoffLocations.find((dropoffLocation) => dropoffLocation.id === parseInt(locationId));
        setSelectedDropoffLocation(selected);
    }

    if (localStorage.getItem("authenticated") != "true") {
        return <Navigate replace to="/login" />;
    } else {
        return (
            <div>
                <h2>Choose Reservation Dates</h2>
                <div>
                    <label>Start Date:</label>
                    <DatePicker selected={startDate} onChange={(date) => setStartDate(date)} />
                </div>
                <div>
                    <label>End Date:</label>
                    <DatePicker selected={endDate} onChange={(date) => setEndDate(date)} />
                <h2>Car Selection</h2>
                </div>
                <div>
                    <label htmlFor="car-select">Choose a Car:</label>
                    <select id="car-select" onChange={handleCarSelection}>
                        <option value="">Select a car</option>
                        {cars.map((car) => (
                            <option key={car.id} value={car.id}>
                                {car.make} {car.model}
                            </option>
                        ))}
                    </select>
                </div>
                {selectedCar && (
                    <div>
                        <h3>Selected Car</h3>
                        <p>Make: {selectedCar.make}</p>
                        <p>Model: {selectedCar.model}</p>
                        <p>Plate Number: {selectedCar.plateNumber}</p>
                        <p>Daily Rate: {selectedCar.dailyRate}</p>
                        <p>Kind: {selectedCar.kind}</p>
                        <p>Is Available: {selectedCar.isAvailable ? "Yes" : "No"}</p>
                    </div>
                )}
                <div>
                    <label htmlFor="pickupLocation-select">Choose pickup location:</label>
                    <select id="pickupLocation-select" onChange={handlePickupLocationSelection}>
                        <option value="">Select pickup location</option>
                        {pickupLocations.map((location) => (
                            <option key={location.id} value={location.id}>
                                {location.name}
                            </option>
                        ))}
                    </select>
                </div>
                {selectedPickupLocation && (
                    <div>
                        <h3>Selected pickedup location</h3>
                        <p>Name: {selectedPickupLocation.name}</p>
                    </div>
                )}
                <div>
                    <label htmlFor="dropoffLocation-select">Choose dropoff location:</label>
                    <select id="dropoffLocation-select" onChange={handleDropoffLocationSelection}>
                        <option value="">Select dropoff location</option>
                        {dropoffLocations.map((location) => (
                            <option key={location.id} value={location.id}>
                                {location.name}
                            </option>
                        ))}
                    </select>
                </div>
                {selectedDropoffLocation && (
                    <div>
                        <h3>Selected dropoff location</h3>
                        <p>Name: {selectedDropoffLocation.name}</p>
                    </div>
                )}
            </div>
        );
    }
};

export default Reservation;