export interface ApiResponse {
    success: boolean;
    message: string;
    response: Product[]; // Assuming an array of products
  }
  
 export interface Product {
    id: number;
    name: string;
    description: string;
    price: number;
    stockId: number;
    stock: any; // Assuming stock is of any type, you might want to create a Stock interface
  }