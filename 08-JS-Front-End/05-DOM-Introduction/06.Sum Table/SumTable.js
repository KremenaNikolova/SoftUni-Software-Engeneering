function sumTable() {
  const elements = Array.from(document.getElementsByTagName("td"));
  let result = 0;
  let index = 0;

  for (const element of elements) {
    index++;
    if (index % 2 === 0) {
      result += Number(element.textContent);
    }
  }

  const sum = document.getElementById("sum");
  sum.textContent = Number(result);
}
