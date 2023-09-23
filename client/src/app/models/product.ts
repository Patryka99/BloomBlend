export interface Product {
    id: number;
    name: string;
    description: string;
    pictureUrl: string;
    pictureUrl2: string;
    pictureUrl3: string;
    sex: string;
    brand: string;
    price: number;
    inventoryItems: InventoryItem[];
}

export interface InventoryItem {
    id: number;
    sizeMl: number;
    pricePercent: number;
    quantityInStock: number;
}