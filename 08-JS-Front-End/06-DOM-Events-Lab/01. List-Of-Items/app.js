function addItem() {
  const inputText = document.querySelector("#newItemText");

  const newListItem = document.createElement("li");
  newListItem.textContent = inputText.value;

  const parentElement = document.querySelector("#items");
  parentElement.appendChild(newListItem);

  inputText.value = "";
}
