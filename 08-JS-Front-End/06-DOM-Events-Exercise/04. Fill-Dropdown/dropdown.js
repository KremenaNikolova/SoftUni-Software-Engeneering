function addItem() {
  let text = document.getElementById("newItemText");
  let value = document.getElementById("newItemValue");

  let dropdown = document.getElementById("menu");
  let option = document.createElement("option");
  option.textContent = text.value;
  option.value = value.value;

  if (text.value !== "" && value.value !== "") {
    dropdown.appendChild(option);
    text.value = "";
    value.value = "";
  }
}
