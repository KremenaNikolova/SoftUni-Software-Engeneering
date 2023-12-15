function attachEvents() {
  const baseUrl = "http://localhost:3030/jsonstore/tasks/";
  let editingWeatherId = "";

  const loadHistoryBtn = document.getElementById("load-history");
  const editBtn = document.getElementById("edit-weather");
  const addBtn = document.getElementById("add-weather");
  const historyDivSection = document.getElementById("list");
  const locationInput = document.getElementById("location");
  const temperatureInput = document.getElementById("temperature");
  const dateInput = document.getElementById("date");

  loadHistoryBtn.addEventListener("click", loadHistory);
  addBtn.addEventListener("click", addWeather);

  async function loadHistory() {
    historyDivSection.innerHTML = "";
    const response = await fetch(baseUrl);
    const weathersObject = await response.json();
    const weatherList = Array.from(Object.values(weathersObject));

    editBtn.setAttribute("disabled", "disabled");

    for (const weatherInfo of weatherList) {
      const divEl = document.createElement("div");
      divEl.classList.add("container");

      const h2 = document.createElement("h2");
      h2.textContent = weatherInfo.location;
      const h3Date = document.createElement("h3");
      h3Date.textContent = weatherInfo.date;
      const h3Celsius = document.createElement("h3");
      h3Celsius.id = "celsius";
      h3Celsius.textContent = weatherInfo.temperature;

      const divBtnContainer = document.createElement("div");
      divBtnContainer.id = "buttons-container";

      const changeBtn = document.createElement("button");
      changeBtn.classList.add("change-btn");
      changeBtn.textContent = "Change";
      const deleteBtn = document.createElement("button");
      deleteBtn.classList.add("delete-btn");
      deleteBtn.textContent = "Delete";

      divBtnContainer.appendChild(changeBtn);
      divBtnContainer.appendChild(deleteBtn);

      divEl.appendChild(h2);
      divEl.appendChild(h3Date);
      divEl.appendChild(h3Celsius);
      divEl.appendChild(divBtnContainer);

      historyDivSection.appendChild(divEl);

      editingWeatherId = weatherInfo._id;

      changeBtn.addEventListener("click", changeWeather);
      deleteBtn.addEventListener("click", deleteWeather);

      function changeWeather() {
        locationInput.value = weatherInfo.location;
        temperatureInput.value = weatherInfo.temperature;
        dateInput.value = weatherInfo.date;

        editBtn.removeAttribute("disabled");
        addBtn.setAttribute("disabled", "disabled");
        divEl.remove();

        editBtn.addEventListener("click", updateWeather);

        async function updateWeather() {
          const data = {
            location: locationInput.value,
            temperature: temperatureInput.value,
            date: dateInput.value,
          };
          await fetch(baseUrl + weatherInfo._id, {
            method: "PUT",
            body: JSON.stringify(data),
          });

          editBtn.setAttribute("disabled", "disabled");
          addBtn.removeAttribute("disabled");
          clearInputData();
          await loadHistory();
        }
      }

      async function deleteWeather() {
        await fetch(baseUrl + weatherInfo._id, {
          method: "DELETE",
        });
        await loadHistory();
      }
    }
  }

  async function addWeather() {
    let isValidInput =
      locationInput.value && temperatureInput.value && dateInput.value;

    if (!isValidInput) {
      return;
    }

    const createWeather = {
      location: locationInput.value,
      temperature: temperatureInput.value,
      date: dateInput.value,
    };

    await fetch(baseUrl, {
      method: "POST",
      body: JSON.stringify(createWeather),
    });

    clearInputData();
    await loadHistory();
  }

  function clearInputData() {
    locationInput.value = "";
    temperatureInput.value = "";
    dateInput.value = "";
  }
}
attachEvents();
