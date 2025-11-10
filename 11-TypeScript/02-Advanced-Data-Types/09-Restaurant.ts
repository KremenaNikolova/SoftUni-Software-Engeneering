type OrderStatus = "Pending" | "Shipped" | "Delivered";

interface Dish {
  dishName: string;
  price: number;
  getDishInfo(): string;
}

interface OrderDetails {
  orderId: number;
  quantity: number;
  orderStatus: OrderStatus;
  getOrderSummary(): string;
  updateOrderStatus(): void;
  getOrderStatus(): string;
}

interface FullOrder extends CustomerOrder {
  discount: number;
  deliveryAddress: string;
  getFinalPrice(): string;
}

class CustomerOrder implements Dish, OrderDetails {
  dishName;
  price;
  isVegan;
  orderId;
  quantity;
  orderStatus: OrderStatus = "Pending";

  constructor(
    dishName: string,
    price: number,
    isVegan: boolean,
    orderId: number,
    quantity: number
  ) {
    this.dishName = dishName;
    this.price = price;
    this.isVegan = isVegan;
    this.orderId = orderId;
    this.quantity = quantity;
  }

  getDishInfo() {
    return `${this.dishName} - Price: $${this.price}, Vegan: ${
      this.isVegan ? "Yes" : "No"
    }`;
  }

  getOrderSummary() {
    return `Order ID: ${this.orderId} - Dish: ${this.dishName}, Quantity: ${
      this.quantity
    }, Total Price: $${this.price * this.quantity}, Status: ${
      this.orderStatus
    }`;
  }

  updateOrderStatus() {
    if (this.orderStatus === "Pending") {
      this.orderStatus = "Shipped";
    } else if (this.orderStatus === "Shipped") {
      this.orderStatus = "Delivered";
    }
  }

  getOrderStatus() {
    return `Order Status: ${this.orderStatus}`;
  }
}

let order: FullOrder = {
  dishName: "Cheese Burger",
  price: 12,
  isVegan: false,
  orderId: 101,
  quantity: 2,
  discount: 10,
  deliveryAddress: "456 Burger Lane, Food City",
  orderStatus: "Pending",
  getDishInfo(): string {
    return `${this.dishName} - Price: $${this.price}, Vegan: ${
      this.isVegan ? "Yes" : "No"
    }`;
  },
  getOrderSummary(): string {
    return `Order ID: ${this.orderId} - Dish: ${this.dishName}, Quantity: ${
      this.quantity
    }, Total Price: $${this.price * this.quantity}`;
  },
  updateOrderStatus(): void {
    if (this.orderStatus === "Pending") {
      this.orderStatus = "Shipped";
    } else if (this.orderStatus === "Shipped") {
      this.orderStatus = "Delivered";
    }
  },
  getOrderStatus(): string {
    return `Order Status: ${this.orderStatus}`;
  },
  getFinalPrice(): string {
    const totalPrice = this.price * this.quantity;
    const finalPrice = totalPrice - totalPrice * (this.discount / 100);
    return `Final Price after ${this.discount}% discount: $${finalPrice}`;
  },
};

console.log(order.getDishInfo());
console.log(order.getOrderSummary());
console.log(order.getFinalPrice());
console.log(order.getOrderStatus());
order.updateOrderStatus();
console.log(order.getOrderStatus());
