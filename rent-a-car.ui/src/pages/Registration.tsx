import { useNavigate } from "react-router-dom";
import corsConfig from "../helpers/CORSConfig";
import { Button, Form, Input } from "antd";
import { RegisterUserDto } from "../models/dtos/RegisterUserDto";
import register from "../functions/Register";

const Registration = () => {

  const navigate = useNavigate();

  return (
    <div style={{ display: "flex", justifyContent: "center" }}>
      <Form
        onFinish={async (values) => {
          const dto: RegisterUserDto =
          {
            name: values.name,
            surname: values.surname,
            email: values.email,
            password: values.password,
            phoneNumber: values.phoneNumber
          }
          if (await register(dto, corsConfig) == true) {
            alert('You were registered!');
            navigate("/login")
          }
          else {
            alert("Registration failed. Please try again.");
          }
        }}
      >
        <h3>Create an account</h3>
        <Form.Item label="Name" name="name">
          <Input placeholder="Name" required />
        </Form.Item>
        <Form.Item label="Surname" name="surname">
          <Input placeholder="Surname" required />
        </Form.Item>
        <Form.Item label="Email" name="email">
          <Input placeholder="Email" required />
        </Form.Item>
        <Form.Item label="Password" name="password">
          <Input.Password placeholder="Password" required />
        </Form.Item>
        <Form.Item label="Phone number" name="phoneNumber">
          <Input placeholder="Phone number" required />
        </Form.Item>
        <Form.Item>
          <Button block type="primary" htmlType='submit'>Register</Button>
        </Form.Item>
      </Form>
    </div>
  );
};

export default Registration;