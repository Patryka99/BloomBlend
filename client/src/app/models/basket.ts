export interface Basket {
    id: number;
    clientId: string;
    items: BasketItem[];
    paymentIntentId: string;
    clientSecret: string;
}

export interface BasketItem {
    productId: number;
    name: string;
    price: number;
    pricePercent: number;
    sizeMl: number;
    pictureUrl: string;
    brand: string;
    quantity: number;
}