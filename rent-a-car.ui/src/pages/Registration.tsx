import React, { useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import axios from "axios";
import corsConfig from "../helpers/CORSConfig";
import { Button, Form, Input } from "antd";
import form from "antd/es/form";
import { RegisterUserDto } from "../models/dtos/RegisterUserDto";
import register from "../functions/Register";

const Registration = () => {

  interface RegisterResponse {
    name: string;
    surname: string;
    email: string;
  }

  const navigate = useNavigate();
  const config: any = corsConfig;

  // async function register(registerData: RegisterUserDto, config: any): Promise<boolean> {
  //   try {
  //     const response = await axios.post<RegisterResponse>("https://localhost:7216/account/register", registerData, config);
  //     if (response.status == 200 || response.status == 201) {
  //       return true;
  //     }
  //   } catch (error) {
  //     console.error(error);
  //     alert("An error occurred while registration. Please try again later.");
  //     return false;
  //   }
  //   return false;
  // }

  return (

    <Form
      // layout="horizontal"
      style={{ maxWidth: 600 }}
      onFinish={async (values) => {
        const dto: RegisterUserDto =
        {
          name: values.name,
          surname: values.surname,
          email: values.email,
          password: values.password,
          phoneNumber: values.phoneNumber
        }
        if (await register(dto, config) == true) {
          alert('You were registered!');
          navigate("/login")
        }
        else {
          alert("Registration failed. Please try again.");
        }
      }}
    >
      <Form.Item label="User name" name="name">
        <Input placeholder="User name" required name="name" />
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
  );
};

export default Registration;