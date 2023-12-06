function validate() {
  const pattern = /^[a-z]+@[a-z]+\.[a-z]+$/g;

  const input = document.getElementById("email");
  input.addEventListener("change", onChange);

  function onChange(e) {
    const compareElement = e.currentTarget;
    if (!pattern.test(compareElement.value)) {
      compareElement.classList.add("error");
    } else {
      compareElement.classList.remove("error");
    }
  }
}
