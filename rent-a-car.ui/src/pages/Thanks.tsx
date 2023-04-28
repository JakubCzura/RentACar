import { Navigate, useLocation, useNavigate } from "react-router-dom";
import "react-datepicker/dist/react-datepicker.css";
import { Button, Card } from "antd";
import Navbar from "../components/Navbar";

const Thanks = () => {
    const navigate = useNavigate()
    const location = useLocation()
    const confirmedReservation = location.state?.confirmedReservation
    const confirmedDate = location.state?.confirmedDate

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
