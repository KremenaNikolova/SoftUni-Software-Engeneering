function deleteByEmail() {
  const input = document.querySelector('input[name="email"]');
  const customers = Array.from(document.querySelector("tbody").children);

  const result = document.getElementById("result");
  let isRemoved = false;

  for (const customer of customers) {
    const currRow = customer.children[1];
    if (currRow.textContent === input.value) {
      customer.remove();
      isRemoved = true;
    }
  }

  if (isRemoved) {
    result.textContent = "Deleted.";
  } else {
    result.textContent = "Not found.";
  }
}
