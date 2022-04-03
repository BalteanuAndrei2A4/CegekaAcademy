import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getCustomerById, getOrdersByCustomerId } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";
import { OrderModel } from "../models/order.model";
import Order from "./Order";

function VisualizeCustomer() {
    const { customerId } = useParams();
    const [customer, setCustomer] = useState<CustomerModel>();
    const [orders, setOrders] = useState<OrderModel[]>([]);
    const navigate = useNavigate();
    useEffect(() => {
        getCustomerById(Number(customerId)).then(c => setCustomer(c));
        getOrdersByCustomerId(Number(customerId)).then(o => setOrders(o));
    }, [])
    function handleClick() {
        navigate('/customers')
    }
    const ordersMap = orders.map(
        order => <Order key={order.id} order= {order} />
    );
    return (

        <div>
            <style>{`
    table{
        width:'90%'
      }
      th{
      width:'90%';
      border:'2px solid';
      padding: '10px';
      }
      .center {
        margin-left: auto;
        margin-right: auto;
      }
  `}</style>

            <h2>Customer</h2>
            <div>
                <div className="btn btn-primary" onClick={handleClick}>
                    Customers
                </div>
            </div>
            <p>{customer?.name}</p>
            <p>{customer?.email}</p>
            <p>Orders</p>
            <table className='center'>
                <tbody>
                    <tr>
                        <th>Car</th>
                        <th >Date</th>
                        <th >Price</th>
                    </tr>
                    {ordersMap}
                </tbody>
            </table>
        </div>);
}

export default VisualizeCustomer;