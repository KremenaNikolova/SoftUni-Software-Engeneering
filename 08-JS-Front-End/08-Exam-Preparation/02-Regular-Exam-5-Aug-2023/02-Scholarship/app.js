window.addEventListener("load", solve);

function solve() {
  let formElement = document.querySelector("form");
  let nameInput = document.getElementById("student");
  let universityInput = document.getElementById("university");
  let scoreInput = document.getElementById("score");

  let nextBtn = document.getElementById("next-btn");

  let ulPreviewList = document.getElementById("preview-list");
  let ulCandidateList = document.getElementById("candidates-list");

  nextBtn.addEventListener("click", addToPreview);

  function addToPreview() {
    let name = nameInput.value;
    let university = universityInput.value;
    let score = scoreInput.value;

    let isValidInput = name && university && score;

    if (!isValidInput) {
      return;
    }

    let liEl = document.createElement("li");
    liEl.classList.add("application");

    let article = document.createElement("article");
    let h4Name = document.createElement("h4");
    h4Name.textContent = name;

    let pUniversity = document.createElement("p");
    pUniversity.textContent = `University: ${university}`;

    let pScore = document.createElement("p");
    pScore.textContent = `Score: ${score}`;

    let editBtn = document.createElement("button");
    editBtn.classList.add("action-btn");
    editBtn.classList.add("edit");
    editBtn.textContent = "edit";
    let applyBtn = document.createElement("button");
    applyBtn.classList.add("action-btn");
    applyBtn.classList.add("apply");
    applyBtn.textContent = "apply";

    article.appendChild(h4Name);
    article.appendChild(pUniversity);
    article.appendChild(pScore);

    liEl.appendChild(article);
    liEl.appendChild(editBtn);
    liEl.appendChild(applyBtn);

    ulPreviewList.appendChild(liEl);
    formElement.reset();
    nextBtn.disabled = true;

    editBtn.addEventListener("click", editInformation);
    applyBtn.addEventListener("click", addCandidate);

    function editInformation() {
      nameInput.value = name;
      universityInput.value = university;
      scoreInput.value = score;

      ulPreviewList.removeChild(liEl);
      nextBtn.disabled = false;
      
    }

    function addCandidate() {
      ulPreviewList.removeChild(liEl);
      liEl.removeChild(editBtn);
      liEl.removeChild(applyBtn);
      ulCandidateList.appendChild(liEl);
      nextBtn.disabled = false;
    }
  }
}
