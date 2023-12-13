function attachEvents() {
  const baseUrl = "http://localhost:3030/jsonstore/collections/students";

  const firstNameInput = document.querySelector('input[name="firstName"]');
  const lastNameInput = document.querySelector('input[name="lastName"]');
  const facultyNumberInput = document.querySelector(
    'input[name="facultyNumber"]'
  );
  const gradeInput = document.querySelector('input[name="grade"]');
  const submitBtn = document.getElementById("submit");

  const tbody = document.querySelector("tbody");

  loadStudentsInfo();
  submitBtn.addEventListener("click", addStudentInfo);

  //Post method
  async function addStudentInfo() {
    let isValidInput =
      firstNameInput.value &&
      lastNameInput.value &&
      facultyNumberInput.value &&
      gradeInput.value;
    
    let isGradeValid = !Number.isNaN(gradeInput.value);

    if (isValidInput && isGradeValid) {
      const createStudent = {
        firstName: firstNameInput.value,
        lastName: lastNameInput.value,
        facultyNumber: facultyNumberInput.value,
        grade: gradeInput.value,
      };

      await fetch(baseUrl, {
        method: "POST",
        body: JSON.stringify(createStudent),
      });
    }

    firstNameInput.value = "";
    lastNameInput.value = "";
    facultyNumberInput.value = "";
    gradeInput.value = "";

    loadStudentsInfo();
  }

  //Get method
  async function loadStudentsInfo() {
    tbody.innerHTML = "";
    const response = await fetch(baseUrl);
    const students = await response.json();

    Object.values(students).forEach((student) => {
      const row = document.createElement("tr");

      row.innerHTML = `
    <tr>
    <td>${student.firstName}</td>
    <td>${student.lastName}</td>
    <td>${student.facultyNumber}</td>
    <td>${student.grade}</td>
    </tr>
    `;

      tbody.appendChild(row);
    });
  }
}

attachEvents();
