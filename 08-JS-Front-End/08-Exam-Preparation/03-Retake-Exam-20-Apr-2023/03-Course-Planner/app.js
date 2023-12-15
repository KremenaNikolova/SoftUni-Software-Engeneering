const baseUrl = "http://localhost:3030/jsonstore/tasks/";

const titleInput = document.getElementById("course-name");
const typeInput = document.getElementById("course-type");
const descriptionInput = document.getElementById("description");
const teacherInput = document.getElementById("teacher-name");

const divCoursesList = document.getElementById("list");
const loadBtn = document.getElementById("load-course");
const addBtn = document.getElementById("add-course");
const editMainBtn = document.getElementById("edit-course");

loadBtn.addEventListener("click", loadCourses);
addBtn.addEventListener("click", addCourse);

async function loadCourses() {
  divCoursesList.innerHTML = "";
  const response = await fetch(baseUrl);
  const courses = await response.json();
  const coursesList = Array.from(Object.values(courses));

  for (const course of coursesList) {
    const title = course.title;
    const type = course.type;
    const description = course.description;
    const teacher = course.teacher;
    const id = course._id;

    const divContainer = document.createElement("div");
    divContainer.classList.add("container");

    const h2title = document.createElement("h2");
    h2title.textContent = title;

    const h3teacher = document.createElement("h3");
    h3teacher.textContent = teacher;

    const h3type = document.createElement("h3");
    h3type.textContent = type;

    const h4description = document.createElement("h4");
    h4description.textContent = description;

    const editBtn = document.createElement("button");
    editBtn.classList.add("edit-btn");
    editBtn.textContent = "Edit Course";

    const finishBtn = document.createElement("button");
    finishBtn.classList.add("finish-btn");
    finishBtn.textContent = "Finish Course";

    divContainer.appendChild(h2title);
    divContainer.appendChild(h3teacher);
    divContainer.appendChild(h3type);
    divContainer.appendChild(h4description);
    divContainer.appendChild(editBtn);
    divContainer.appendChild(finishBtn);

    divCoursesList.appendChild(divContainer);

    editMainBtn.disabled = true;

    editBtn.addEventListener("click", editCourse);
    finishBtn.addEventListener("click", removeCourse);

    function editCourse() {
      titleInput.value = title;
      typeInput.value = type;
      descriptionInput.value = description;
      teacherInput.value = teacher;

      editMainBtn.disabled = false;
      addBtn.disabled = true;
      divCoursesList.removeChild(divContainer);

      editMainBtn.addEventListener("click", updateCourse);

      async function updateCourse() {
        const courseData = {
          title: titleInput.value,
          type: typeInput.value,
          description: descriptionInput.value,
          teacher: teacherInput.value,
        };

        await fetch(baseUrl + course._id, {
          method: "PUT",
          body: JSON.stringify(courseData),
        });

        editMainBtn.disabled = true;
        addBtn.disabled = false;
        clearInputData();
        await loadCourses();
      }
    }

      async function removeCourse() {
      await fetch(baseUrl + course._id, {
        method: "DELETE",
      });

      await loadCourses();
    }
  }
}

async function addCourse() {
  const title = titleInput.value;
  const type = typeInput.value;
  const description = descriptionInput.value;
  const teacher = teacherInput.value;

  let isValidInput = title && type && description && teacher;

  if (!isValidInput) {
    return;
  }

  const createCourse = {
    title,
    type,
    description,
    teacher,
  };

  await fetch(baseUrl, {
    method: "POST",
    body: JSON.stringify(createCourse),
  });

  clearInputData();
  await loadCourses();
}

function clearInputData() {
  titleInput.value = "";
  typeInput.value = "";
  descriptionInput.value = "";
  teacherInput.value = "";
}
