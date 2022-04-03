import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getCustomers } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";
import Customer from "./Customer";

function Customers() {
    const [customers, setCustomers] = useState<CustomerModel[]>([]);
    const navigate = useNavigate();
    useEffect(() => {
        getCustomers().then(c => setCustomers(c));
    }, [])
    function handleClick() {
        navigate('/newcustomer')
    }
    const customersMap = customers.map(
        customer => <Customer key={customer.name} customer={customer} />
    );
    return (<><h2>Customers</h2>
        <style>{`
    table{
        width:'90%'
      }
      th{
      width:'50%';
      border:'1px solid';
      padding: '7px';
      }
      .center {
        margin-left: auto;
        margin-right: auto;
      }
  `}</style>
        <div>
            <div className="btn btn-primary" onClick={handleClick}>
                Add Customer
            </div>
        </div>
 
        <table className='center'>
            <tbody>
                <tr>
                    <th>Name</th>
                    <th >Email</th>

                </tr>
                {customersMap}
            </tbody>
        </table>
    </>
    );
}
export default Customers;