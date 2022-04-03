import { useState } from "react";
import { NavLink, Router, useNavigate } from "react-router-dom";
import { postCar } from "../common/api.service";
import { CarModel } from "../models/car.model";

function NewCar() {
    const navigate = useNavigate();
    const [make, setMake] = useState('');
    const [model, setModel] = useState('');
    const [availableStock, setAvailableStock] = useState(0);
    const [unitPrice, setUnitPrice] = useState(0);
    const [discountPercentage, setDiscountProcentage] = useState(0);
    const [image, setImage] = useState('');

    function handleClick() {
        const car:CarModel = {
            make,
            model,
            availableStock,
            unitPrice,
            discountPercentage,
            image
        };
        postCar(car);
        navigate('/caroffers');
        window.location.reload();
    }

    return (
        <>
            <h2>New Car</h2>
            <div>
                <div className="mb-3">
                    <label className="form-label">Make</label>
                    <input type="text" className="form-control" placeholder="Make" onChange={ev => setMake(ev.target.value)} />
                </div>
                <div className="mb-3">
                    <label className="form-label">Model</label>
                    <input type="text" className="form-control" placeholder="Model" onChange={ev => setModel(ev.target.value)}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Stock</label>
                    <input type="number" className="form-control" placeholder="Stock" onChange={ev => setAvailableStock(Number(ev.target.value))}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Price</label>
                    <input type="number" className="form-control" placeholder="Price" onChange={ev => setUnitPrice(Number(ev.target.value))}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Discount</label>
                    <input type="number" className="form-control" placeholder="For 7% enter 0.07" onChange={ev => setDiscountProcentage(Number(ev.target.value))}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Image</label>
                    <input type="text" className="form-control" placeholder="Url address of image" onChange={ev => setImage(ev.target.value)}/>
                </div>
                <a href="#" className="btn btn-primary" onClick={() => handleClick()}>Save</a>
            </div>
        </>);
}

export default NewCar;


