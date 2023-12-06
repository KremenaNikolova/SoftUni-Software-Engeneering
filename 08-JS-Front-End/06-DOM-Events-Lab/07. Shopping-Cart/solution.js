function solve() {
  const products = Array.from(document.getElementsByClassName("product"));
  const textarea = document.querySelector("textarea");
   const checkoutButton = document.querySelector(".checkout");
   const allButtons = document.getElementsByTagName('button');
  let boughtProducts = [];
  let totalPrice = 0;

  for (const product of products) {
    const button = product.querySelector("button");
    button.addEventListener("click", onClick);
  }

  function onClick(e) {
    const product = e.currentTarget.parentNode.parentNode;
    const productTitle = product.querySelector(".product-title").textContent;
    const productPrice = product.querySelector(
      ".product-line-price"
    ).textContent;

    if (!boughtProducts.includes(productTitle)) {
      boughtProducts.push(productTitle);
    }
    totalPrice += Number(productPrice);

    textarea.value += `Added ${productTitle} for ${productPrice} to the cart.\n`;
  }

  checkoutButton.addEventListener("click", checkoutResult);

  function checkoutResult(e) {
    textarea.value += `You bought ${boughtProducts.join(
      ", "
     )} for ${totalPrice.toFixed(2)}.`;
     
      for (const button of allButtons) {
         button.disabled = true;
      }
  }
}
