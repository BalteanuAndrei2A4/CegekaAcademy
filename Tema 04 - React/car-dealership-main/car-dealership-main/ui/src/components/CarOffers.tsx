import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getCars } from "../common/api.service";
import { CarModel } from "../models/car.model";
import Car from "./Car";

//1. Props change
//2. State change

function CarOffers() {
    const [cars, setCars] = useState<CarModel[]>([]);
    const navigate = useNavigate();
    useEffect(() => {
        getCars().then(c => setCars(c));
    }, [])
    function handleClick(){
        navigate('/newcar')
    }
    return (
        <div>
            <h2>All cars</h2>
            <div>
                <div className="btn btn-primary" onClick={handleClick}>
                    Add Car
                </div>
            </div>
            <div style={{ display: 'flex', flexWrap: 'wrap' }}>
                {cars.map(c => <Car car={c} />)}
            </div>
        </div>);
}

export default CarOffers;