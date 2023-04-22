import { useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
const Reservation = () => {

  if (localStorage.getItem("authenticated") != "true") {
        return <Navigate replace to="/login" />;
  } else {
    return (
      <div>
        <p>Welcome to your Dashboard</p>
      </div>
    );
  }
};

export default Reservation;