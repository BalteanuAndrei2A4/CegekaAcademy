export interface OrderModel {
    id: number
    customerId: number,
    carOfferId: number,
    quantity: number,
    date: Date,
    orderAmount: number,
}