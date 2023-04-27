import { useNavigate } from "react-router-dom";
import { Button, Form, Input, Menu } from "antd";
import logOut from "../functions/LogOut";

const Navbar = () => {
  const navigate = useNavigate();

  return (
    <div>
      <Button block type="primary" htmlType='submit' style={{ margin: 5, width: 150 }} onClick={() => navigate("/reservation")}>Main page</Button>
      <Button block type="primary" danger htmlType='submit' style={{ margin: 5, width: 150 }} onClick={() => logOut() ? navigate("/login") : ""}>Log out</Button>
    </div>
  )
};

export default Navbar;