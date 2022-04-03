import React from 'react';
import logo from './logo.svg';
import './App.css';
import { NavigationBar } from './components/NavigationBar';
import { BrowserRouter, Outlet, Route, Routes, useParams } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import CarOffers from './components/CarOffers';
import Customers from './components/Customers';
import NewCar from './components/NewCar';
import NewCustomer from './components/NewCustomer';
import Order from './components/Order';
import Customer from './components/Customer';
import VisualizeCustomer from './components/VisualizeCustomer';
import path from 'path';

function MainLayout() {
  return (
    <div className="App">
      <NavigationBar />
      <div className='main-content'>
        <Outlet />
      </div>
    </div>)
}


function App() {
  const { id } = useParams();
  console.log(id)
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<MainLayout />} >
          <Route path="/caroffers" element={<CarOffers />}>
          </Route>
          <Route path="/customers" element={<Customers />}>
          </Route>
          <Route path="/newcar" element={<NewCar />}>
          </Route>
          <Route path="/" element={<div>Home</div>}>
          </Route>
          <Route path="/newcustomer" element={<NewCustomer />}>
          </Route>
          <Route path="/customer/:customerId" element={<VisualizeCustomer />}>
          </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
