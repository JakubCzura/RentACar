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
        <Form.Item label="User name" name="name">
          <Input placeholder="User name" required />
        </Form.Item>
        <Form.Item label="User surname" name="surname">
          <Input placeholder="User surname" required />
        </Form.Item>
        <Form.Item label="User email" name="email">
          <Input placeholder="User email" required />
        </Form.Item>
        <Form.Item label="User password" name="password">
          <Input.Password placeholder="User password" required />
        </Form.Item>
        <Form.Item label="User phone number" name="phoneNumber">
          <Input placeholder="User phone number" required />
        </Form.Item>
        <Form.Item>
          <Button block htmlType='submit'>Submit</Button>
        </Form.Item>
      </Form>
    </div>
  );
};

export default Registration;