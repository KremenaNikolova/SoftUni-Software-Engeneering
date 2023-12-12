function attachEvents() {
  const baseUrl = "http://localhost:3030/jsonstore/phonebook/";
  const phonebookUl = document.getElementById("phonebook");
  const loadBtn = document.getElementById("btnLoad");
  const personInput = document.getElementById("person");
  const phoneInput = document.getElementById("phone");
  const createBtn = document.getElementById("btnCreate");

  createBtn.addEventListener("click", createPhoneContact);
  loadBtn.addEventListener("click", loadPhoneContacts);

  async function createPhoneContact() {
    const personFormat = {
      person: personInput.value,
      phone: phoneInput.value,
    };

    await fetch(baseUrl, {
      method: "POST",
      body: JSON.stringify(personFormat),
    });

    personInput.value = "";
    phoneInput.value = "";
  }
  async function loadPhoneContacts() {
    phonebookUl.innerHTML = "";
    const response = await fetch(baseUrl);
    const personsInfo = await response.json();

    for (const person of Object.values(personsInfo)) {
      const li = document.createElement("li");
      li.textContent = `${person.person}: ${person.phone}`;

      const deleteBtn = document.createElement("button");
      deleteBtn.textContent = "Delete";
      li.appendChild(deleteBtn);

      phonebookUl.appendChild(li);

      deleteBtn.addEventListener("click", deletePhoneContact);

      async function deletePhoneContact() {
        const personId = person._id;
        await fetch(baseUrl + personId, {
          method: "DELETE",
        });
        li.remove();
      }
    }
  }
}

attachEvents();
