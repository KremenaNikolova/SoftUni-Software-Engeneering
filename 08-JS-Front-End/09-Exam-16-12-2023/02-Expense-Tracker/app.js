window.addEventListener("load", solve);

function solve() {
  const typeInput = document.getElementById("expense");
  const amountInput = document.getElementById("amount");
  const dateInput = document.getElementById("date");
    const addBtn = document.getElementById("add-btn");
    const deleteBtn = document.querySelector('.delete');

  const ulPreviewList = document.getElementById("preview-list");
  const ulExpensesList = document.getElementById("expenses-list");

    addBtn.addEventListener("click", addToPreview);
    deleteBtn.addEventListener('click', clearList);

  function addToPreview() {
    const type = typeInput.value;
    const amount = amountInput.value;
    const date = dateInput.value;

    let isValidInput = type && amount && date;

    if (!isValidInput) {
      return;
    }

    addBtn.disabled = true;
    clearInputData();

    const li = document.createElement("li");
    li.classList.add("expense-item");

    const article = document.createElement("article");

    const pType = document.createElement("p");
    pType.textContent = `Type: ${type}`;

    const pAmount = document.createElement("p");
    pAmount.textContent = `Amount: ${amount}$`;

    const pDate = document.createElement("p");
    pDate.textContent = `Date: ${date}`;

    article.appendChild(pType);
    article.appendChild(pAmount);
    article.appendChild(pDate);

    const divButtonsContainer = document.createElement("div");
    divButtonsContainer.classList.add("buttons");

    const editBtn = document.createElement("button");
    editBtn.classList.add("btn", "edit");
    editBtn.textContent = "edit";

    const okBtn = document.createElement("button");
    okBtn.classList.add("btn", "ok");
    okBtn.textContent = "ok";

    divButtonsContainer.appendChild(editBtn);
    divButtonsContainer.appendChild(okBtn);

    li.appendChild(article);
    li.appendChild(divButtonsContainer);

    ulPreviewList.appendChild(li);

    editBtn.addEventListener("click", editPreview);
    okBtn.addEventListener("click", addToExpenses);

    function editPreview() {
      typeInput.value = type;
      amountInput.value = amount;
      dateInput.value = date;

      ulPreviewList.removeChild(li);
      addBtn.disabled = false;
    }

    function addToExpenses() {
      ulPreviewList.removeChild(li);
      
      li.removeChild(divButtonsContainer);

      ulExpensesList.appendChild(li);

      addBtn.disabled = false;
    }
    }
    
    function clearList() {
        location.reload();
    }

  function clearInputData() {
    typeInput.value = "";
    amountInput.value = "";
    dateInput.value = "";
  }
}
