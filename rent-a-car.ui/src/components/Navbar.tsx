import { useNavigate } from "react-router-dom";
import { Button, Form, Input, Menu } from "antd";
import logOut from "../functions/LogOut";
import "../components/styles/Navbar.css"

const Navbar = () => {
  const navigate = useNavigate();

  return (
    <div>
      <Button block type="primary" htmlType='submit' className="navButton" onClick={() => navigate("/reservation")}>Main page</Button>
      <Button block type="primary" danger htmlType='submit' className="navButton" onClick={() => logOut() ? navigate("/login") : ""}>Log out</Button>
    </div>
  )
};

export default Navbar;