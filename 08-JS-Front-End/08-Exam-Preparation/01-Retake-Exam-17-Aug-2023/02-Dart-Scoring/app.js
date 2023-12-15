window.addEventListener("load", solve)

function solve() {
  const nameInput = document.getElementById("player");
  const numberInput = document.getElementById("score");
  const roundInput = document.getElementById("round");
  const ulSureElement = document.getElementById("sure-list");
  const ulScoreElement = document.getElementById("scoreboard-list");

  const addBtn = document.getElementById("add-btn");
  const clearBtn = document.querySelector('.clear');

  addBtn.addEventListener("click", addInformation);
  clearBtn.addEventListener('click', clearPage);

  function addInformation() {
    let isFilled =
      nameInput.value !== "" &&
      numberInput.value !== "" &&
      roundInput.value !== "";

    if (!isFilled) {
      return;
    }
    addBtn.setAttribute("disabled", "disabled");

    const articleEl = document.createElement("article");
    const liEl = document.createElement("li");
    liEl.classList.add("dart-item");
    const pNameEl = document.createElement("p");
    pNameEl.textContent = nameInput.value;
    const pScoreEl = document.createElement("p");
    pScoreEl.textContent = `Score: ${numberInput.value}`;
    const pRountEl = document.createElement("p");
    pRountEl.textContent = `Round: ${roundInput.value}`;

    const editBtn = document.createElement("button");
    editBtn.classList.add("btn");
    editBtn.classList.add("edit");
    editBtn.textContent = "edit";
    const okBtn = document.createElement("button");
    okBtn.classList.add("btn");
    okBtn.classList.add("ok");
    okBtn.textContent = "ok";

    articleEl.appendChild(pNameEl);
    articleEl.appendChild(pScoreEl);
    articleEl.appendChild(pRountEl);

    liEl.appendChild(articleEl);
    liEl.appendChild(editBtn);
    liEl.appendChild(okBtn);

    ulSureElement.appendChild(liEl);

    nameInput.value = "";
    numberInput.value = "";
    roundInput.value = "";

    editBtn.addEventListener("click", editInformation);
    okBtn.addEventListener("click", addToScorebar);

    function editInformation() {
      addBtn.removeAttribute("disabled");

      nameInput.value = pNameEl.textContent;
      numberInput.value = pScoreEl.textContent.split(': ')[1];
      roundInput.value = pRountEl.textContent.split(': ')[1];

      ulSureElement.innerHTML = "";
    }

    function addToScorebar() {
      addBtn.removeAttribute("disabled");

      liEl.innerHTML = "";
      liEl.appendChild(articleEl);
      ulScoreElement.appendChild(liEl);

      ulSureElement.innerHTML = "";
    }
  }

  function clearPage() {
    location.reload();
  }
}
