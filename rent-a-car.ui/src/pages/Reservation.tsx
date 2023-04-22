import { SetStateAction, useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import axios from 'axios';


const Reservation = () => {

type Car =
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
    startDate: Date,
    endDate: Date,
    car: Car
}

    const [startDate, setStartDate] = useState<Date | null>(new Date());
    const [endDate, setEndDate] = useState<Date | null>(new Date());
    const [cars, setCars] = useState<Car[]>([]);
    const [selectedCar, setSelectedCar] = useState<Car>();

    useEffect(() => {
        axios.get("https://localhost:7216/car").then((response) => {
            setCars(response.data);
        }).catch(error => console.error(error));;
    }, []);


    function handleCarSelection(event: any) {
        const carId = event.target.value;
        const selected = cars.find((car) => car.id === parseInt(carId));
        setSelectedCar(selected);
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
            </div>
        );
    }
};

export default Reservation;