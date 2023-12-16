const baseUrl = "http://localhost:3030/jsonstore/tasks/";
const loadBtn = document.getElementById("load-meals");
const editBtn = document.getElementById("edit-meal");
const addBtn = document.getElementById("add-meal");

const foodInput = document.getElementById("food");
const timeInput = document.getElementById("time");
const caloriesInput = document.getElementById("calories");
const divMealList = document.getElementById("list");

loadBtn.addEventListener("click", loadMeals);
addBtn.addEventListener("click", addMeal);

async function loadMeals() {
  divMealList.innerHTML = "";
  editBtn.disabled = true;

  const response = await fetch(baseUrl);
  const meals = await response.json();
  const mealsList = Array.from(Object.values(meals));

  for (const meal of mealsList) {
    const calories = meal.calories;
    const food = meal.food;
    const time = meal.time;
    const id = meal._id;

    const divMealContainer = document.createElement("div");
    divMealContainer.classList.add("meal");

    const h2Food = document.createElement("h2");
    h2Food.textContent = food;

    const h3time = document.createElement("h3");
    h3time.textContent = time;

    const h3calories = document.createElement("h3");
    h3calories.textContent = calories;

    const divBtnContainer = document.createElement("div");
    divBtnContainer.id = "meal-buttons";

    const changeBtn = document.createElement("button");
    changeBtn.classList.add("change-meal");
    changeBtn.textContent = "Change";

    const deleteBtn = document.createElement("button");
    deleteBtn.classList.add("delete-meal");
    deleteBtn.textContent = "Delete";

    divBtnContainer.appendChild(changeBtn);
    divBtnContainer.appendChild(deleteBtn);

    divMealContainer.appendChild(h2Food);
    divMealContainer.appendChild(h3time);
    divMealContainer.appendChild(h3calories);
    divMealContainer.appendChild(divBtnContainer);

    divMealList.appendChild(divMealContainer);

    changeBtn.addEventListener("click", editMeal);
    deleteBtn.addEventListener("click", removeMeal);

    function editMeal() {
      caloriesInput.value = calories;
      foodInput.value = food;
      timeInput.value = time;

      editBtn.disabled = false;
      addBtn.disabled = true;

      divMealList.removeChild(divMealContainer);

      editBtn.addEventListener("click", updateMeal);

      async function updateMeal() {
        const mealData = {
          calories: caloriesInput.value,
          food: foodInput.value,
          time: timeInput.value,
        };

        await fetch(baseUrl + id, {
          method: "PUT",
          body: JSON.stringify(mealData),
        });

        editBtn.disabled = true;
        addBtn.disabled = false;
        clearInputData();
        await loadMeals();
      }
    }

    async function removeMeal() {
      await fetch(baseUrl + id, {
        method: "DELETE",
      });

      await loadMeals();
    }
  }
}

async function addMeal() {
  const calories = caloriesInput.value;
  const food = foodInput.value;
  const time = timeInput.value;

  let isValidInput = calories && food && time;

  if (!isValidInput) {
    return;
  }

  const createMeal = {
    calories,
    food,
    time,
  };

  await fetch(baseUrl, {
    method: "POST",
    body: JSON.stringify(createMeal),
  });

  clearInputData();
  await loadMeals();
}

function clearInputData() {
  caloriesInput.value = "";
  foodInput.value = "";
  timeInput.value = "";
}
