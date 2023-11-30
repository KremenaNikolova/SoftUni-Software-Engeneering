function solve() {
  const text = document.getElementById("text").value.toLowerCase();
  const namingConvention = document.getElementById("naming-convention").value;

  let textArray = text.split(" ");
  let output = "";
  if (namingConvention === "Pascal Case") {
    for (let i = 0; i < textArray.length; i++) {
      const element = textArray[i];

      const firstLetter = element.charAt(0).toUpperCase();
      const rest = element.slice(1);

      const result = firstLetter + rest;
      output += result;
    }
  } else if (namingConvention === "Camel Case") {
    output += textArray[0];
    for (let i = 1; i < textArray.length; i++) {
      const element = textArray[i];

      const firstLetter = element.charAt(0).toUpperCase();
      const rest = element.slice(1);

      const result = firstLetter + rest;
      output += result;
    }
  } else {
    return (document.getElementById("result").textContent = "Error!");
  }

  return (document.getElementById("result").textContent = output);
}
