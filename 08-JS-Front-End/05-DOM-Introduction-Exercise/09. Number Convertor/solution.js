function solve() {
  const selectMenuTo = document.getElementById("selectMenuTo");
  const binaryOption = document.createElement("option");
  binaryOption.value = "binary";
  binaryOption.textContent = "Binary";
  const hexadecimalOption = document.createElement("option");
  hexadecimalOption.value = "hexadecimal";
  hexadecimalOption.textContent = "Hexadecimal";
  selectMenuTo.appendChild(binaryOption);
  selectMenuTo.appendChild(hexadecimalOption);

  document.querySelector("button").addEventListener("click", convertNumber);

  function convertNumber() {
    const inputNumber = document.getElementById("input").value;
    const fromOption = document.getElementById("selectMenuFrom").value;
    const toOption = document.getElementById("selectMenuTo").value;

    if (isNaN(inputNumber) || inputNumber === "") {
      alert("Please enter a valid number.");
      return;
    }
    let result;
    if (fromOption === "decimal" && toOption === "binary") {
      result = decimalToBinary(inputNumber);
    } else if (fromOption === "decimal" && toOption === "hexadecimal") {
      result = decimalToHexadecimal(inputNumber);
    } else {
      alert("Invalid conversion options.");
      return;
    }
    document.getElementById("result").value = result;
  }

  function decimalToBinary(decimalNumber) {
    return (decimalNumber >>> 0).toString(2);
  }

  function decimalToHexadecimal(decimalNumber) {
    return Number(decimalNumber).toString(16).toUpperCase();
  }
}
