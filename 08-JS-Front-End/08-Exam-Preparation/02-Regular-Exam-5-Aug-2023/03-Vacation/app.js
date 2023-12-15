const baseUrl = "http://localhost:3030/jsonstore/tasks/";

const nameInput = document.getElementById("name");
const daysInput = document.getElementById("num-days");
const dateInput = document.getElementById("from-date");
const divVacantionList = document.getElementById("list");
const addBtn = document.getElementById("add-vacation");
const editBtn = document.getElementById("edit-vacation");
const loadBtn = document.getElementById("load-vacations");

loadBtn.addEventListener("click", loadVacantions);
addBtn.addEventListener("click", addVacantion);

async function loadVacantions() {
  divVacantionList.innerHTML = "";
  const response = await fetch(baseUrl);
  const vacantionsObject = await response.json();
  const vacantionList = Array.from(Object.values(vacantionsObject));

  for (const vacantion of vacantionList) {
    const name = vacantion.name;
    const days = vacantion.days;
    const date = vacantion.date;
    const id = vacantion._id;

    const divContainer = document.createElement("div");
    divContainer.classList.add("container");

    const h2Name = document.createElement("h2");
    h2Name.textContent = name;

    const h3Date = document.createElement("h3");
    h3Date.textContent = date;

    const h3days = document.createElement("h3");
    h3days.textContent = days;

    const changeBtn = document.createElement("button");
    changeBtn.classList.add("change-btn");
    changeBtn.textContent = "Change";

    const doneBtn = document.createElement("button");
    doneBtn.classList.add("done-btn");
    doneBtn.textContent = "Done";

    divContainer.appendChild(h2Name);
    divContainer.appendChild(h3Date);
    divContainer.appendChild(h3days);
    divContainer.appendChild(changeBtn);
    divContainer.appendChild(doneBtn);

    divVacantionList.appendChild(divContainer);
    editBtn.disabled = true;

    changeBtn.addEventListener("click", changeVacantion);
    doneBtn.addEventListener("click", removeVacantion);

    function changeVacantion() {
      nameInput.value = name;
      daysInput.value = days;
      dateInput.value = date;

      editBtn.disabled = false;
      addBtn.disabled = true;
      divVacantionList.removeChild(divContainer);

      editBtn.addEventListener("click", updateVacantion);

      async function updateVacantion() {
        const vacantionData = {
          name: nameInput.value,
          days: daysInput.value,
          date: dateInput.value,
        };
        await fetch(baseUrl + vacantion._id, {
          method: "PUT",
          body: JSON.stringify(vacantionData),
        });

        editBtn.disabled = true;
        addBtn.disabled = false;
        clearInputData();
        await loadVacantions();
      }
    }
    async function removeVacantion() {
      console.log(doneBtn);
      console.log(vacantion._id);
      await fetch(baseUrl + vacantion._id, {
        method: "DELETE",
      });

      await loadVacantions();
    }
  }
}

async function addVacantion() {
  const name = nameInput.value;
  const days = daysInput.value;
  const date = dateInput.value;

  let isValidInput = name && days && date;
  debugger;
  if (!isValidInput) {
    return;
  }

  const createVacantion = {
    name,
    days,
    date,
  };

  await fetch(baseUrl, {
    method: "POST",
    body: JSON.stringify(createVacantion),
  });

  clearInputData();
  await loadVacantions();
}

function clearInputData() {
  nameInput.value = "";
  daysInput.value = "";
  dateInput.value = "";
}
