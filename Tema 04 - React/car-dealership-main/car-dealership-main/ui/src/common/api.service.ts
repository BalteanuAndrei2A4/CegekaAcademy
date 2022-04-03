import exp from "constants";
import { CarModel } from "../models/car.model";
import { CustomerModel } from "../models/customer.model";
import { OrderModel } from "../models/order.model";

export function getCars(): Promise<CarModel[]> {
    return fetch('https://localhost:7198/CarOffer')
        .then(r => r.json())
}
export function getCustomers(): Promise<CustomerModel[]> {
    return fetch('https://localhost:7198/Customer').
        then(r => r.json())
}
export function getCustomerById(id: number):Promise<CustomerModel>{
    console.log('https://localhost:7198/Customer/'+String(id))
    return fetch('https://localhost:7198/Customer/'+String(id), {method:"GET"}).
    then(r=>r.json())
}

export function postCar(car: CarModel) {
    fetch('https://localhost:7198/CarOffer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(car)
    })
}
export function postCustomer(customer: CustomerModel)
{
    fetch('https://localhost:7198/Customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })
}
export function getOrdersByCustomerId(id:number):Promise<OrderModel[]>{
    return fetch('https://localhost:7198/Order/'+id.toString()).then(r=>r.json())
}
export function getCarById(id:number):Promise<CarModel>{
    return fetch('https://localhost:7198/CarOffer/'+id.toString()).then(r=>r.json())
}
export function postOrder(order: OrderModel)
{
    fetch('https://localhost:7198/Order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    })
}