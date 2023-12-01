function search() {
  let matches = 0;

  const searchWord = document.getElementById("searchText").value;
  let towns = document.getElementsByTagName("li");

  for (let i = 0; i < towns.length; i++) {
    let town = towns[i];
    let isExist = town.textContent.includes(searchWord);

    console.log("check");
    town.style.fontWeight = "normal";
    town.style.textDecoration = "none";

    if (isExist) {
      matches++;
      town.style.fontWeight = "bold";
      town.style.textDecoration = "underline";
    }
  }
  document.getElementById("result").textContent = `${matches} matches found`;
}
