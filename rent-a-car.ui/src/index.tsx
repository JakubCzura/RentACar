import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './pages/Login';

import Registration from './pages/Registration';
import Reservation from './pages/Reservation';
import Summary from './pages/Summary';
import Thanks from './pages/Thanks';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
   <BrowserRouter>
      <Routes>
        <Route index element={<Login />} />
        <Route path="login" element={<Login />} />
        <Route path="register" element={<Registration />} />
        <Route path="reservation" element={<Reservation />} />
        <Route path="summary" element={<Summary />} />
        <Route path="thanks" element={<Thanks />} />
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
