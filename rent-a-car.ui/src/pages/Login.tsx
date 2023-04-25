import { useNavigate } from "react-router-dom";
import corsConfig from "../helpers/CORSConfig";
import { LogInUserDto } from "../models/dtos/LogInUserDto";
import { Button, Form, Input } from "antd";
import logIn from "../functions/LogIn";

const Login = () => {

  const navigate = useNavigate();

  const navigateToRegistration = () => {
    navigate("/register")
  }

  return (
    <div style={{ display: "flex", justifyContent: "center" }}>
      <Form
        onFinish={async (values) => {
          const dto: LogInUserDto =
          {
            email: values.email,
            password: values.password
          }
          if (await logIn(dto, corsConfig) == true) {
            alert('You have been logged in!');
            navigate("/reservation")
          }
          else {
            alert("Logging in failed. Please try again.");
          }
        }}
      >
        <h3>Register</h3>
        <Form.Item label="Email" name="email">
          <Input placeholder="Email" required />
        </Form.Item>
        <Form.Item label="Password" name="password">
          <Input placeholder="Password" required />
        </Form.Item>
        <Form.Item>
          <Button block htmlType='submit'>Submit</Button>
        </Form.Item>
        <h3>Don't have account?</h3>
        <Button block htmlType='submit' onClick={navigateToRegistration}>Register</Button>
      </Form>
    </div>
  );
};

export default Login;