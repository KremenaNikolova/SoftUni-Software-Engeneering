function storeProvision(currentStock, orderedProducts) {
  const products = {};

  let productName = "";
  let productQuantity = 0;

  for (let i = 0; i < currentStock.length - 1; i += 2) {
    productName = currentStock[i];
    productQuantity = Number(currentStock[i + 1]);

    products[productName] = productQuantity;
  }

  for (let i = 0; i < orderedProducts.length - 1; i += 2) {
    productName = orderedProducts[i];
    productQuantity = Number(orderedProducts[i + 1]);

    if (products.hasOwnProperty(productName)) {
      products[productName] += productQuantity;
    } else {
      products[productName] = productQuantity;
    }
  }

  for (const [key, value] of Object.entries(products)) {
    console.log(`${key} -> ${value}`);
  }
}

storeProvision(
  ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
  ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
);

storeProvision(
  ["Salt", "2", "Fanta", "4", "Apple", "14", "Water", "4", "Juice", "5"],
  ["Sugar", "44", "Oil", "12", "Apple", "7", "Tomatoes", "7", "Bananas", "30"]
);
