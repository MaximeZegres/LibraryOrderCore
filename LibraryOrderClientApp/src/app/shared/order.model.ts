export interface IOrder {
    orderId: number
    orderNumber: string
    orderDate: string
    isContacted: boolean
    customerFirstName: string
    customerLastName: string
    customerEmail: string
    customerPhoneNumber: string
    orderItems: IOrderItems[]
}

export interface IOrderItems {
    orderItemId: number
    book: {
        bookId: number
        title: string
        author: string
        editor: string
        isbn: string
    }
    quantity: number
    isOrdered: boolean
}