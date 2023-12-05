function addItem() {
  const inputText = document.querySelector("#newItemText");

  const newListItem = document.createElement("li");
  newListItem.textContent = inputText.value;

  const deleteElement = document.createElement("a");
  deleteElement.href = "#";
  deleteElement.textContent = "[Delete]";

  deleteElement.addEventListener("click", deleteItem);
  newListItem.appendChild(deleteElement);

  function deleteItem(e) {
    const currTarget = e.currentTarget.parentNode;
    currTarget.remove();
  }

  const parentElement = document.querySelector("#items");
  parentElement.appendChild(newListItem);

  inputText.value = "";
}
