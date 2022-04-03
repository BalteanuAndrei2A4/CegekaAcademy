import { useEffect } from "react";
import { render } from "react-dom";
import { getCustomerById } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";

interface TProps {
    customer: CustomerModel;
}

function Customer(props: TProps) {
    const { customer } = props;
    const id = customer.id;
    const name = customer.name;
    const email = customer.email;
    
    function makeRef():string{
        return '/customer/'+id.toString();
    }

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
                <td><a href={makeRef()}>{name}</a></td>
                <td>{email}</td>
            </tr></>
    )
}

export default Customer;