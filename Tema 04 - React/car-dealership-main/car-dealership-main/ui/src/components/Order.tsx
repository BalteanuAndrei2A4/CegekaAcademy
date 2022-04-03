import { useEffect, useState } from "react";
import { render } from "react-dom";
import { useNavigate, useParams } from "react-router-dom";
import { getCarById } from "../common/api.service";
import { CarModel } from "../models/car.model";
import { OrderModel } from "../models/order.model";

interface TProps {
    order: OrderModel;
}

function Order(props: TProps) {
    const { order } = props;
    const [ car, setCar] = useState<CarModel>();
    const navigate = useNavigate();
    useEffect(() => {
        getCarById(order.carOfferId).then(c => setCar(c));
    }, [])
    const car_name = car?.make+' '+car?.model
    const order_date = order.date;
    const order_quantity = order.quantity;
    const order_amount = order.orderAmount;

    return (
        <><style>{`
        tr{
            width: '50%';
            border: '1px solid';
            padding: '3px 13px';
            text-align: 'right';
          };
          td{
            width:'50%';
            border:'1px solid';
            padding: '3px 13px';
            text-align:'left';
          };
  `}</style>
            <tr>
                <td>{car_name}</td>
                <td>{order_date}</td>                
                <td>{order_amount}</td>
            </tr></>
    )
}

export default Order;