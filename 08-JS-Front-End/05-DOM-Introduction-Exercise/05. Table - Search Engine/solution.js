function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    const elements = Array.from(document.getElementsByTagName("tr"));
    const searchElement = document.getElementById("searchField").value;

    for (let i = 2; i < elements.length; i++) {
      const element = elements[i];
      element.className = "";
      console.log(element);

      let isExist = element.textContent.includes(searchElement);
      console.log(isExist);

      if (isExist) {
        element.className = "select";
      }
    }
  }
}
