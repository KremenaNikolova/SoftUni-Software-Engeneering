function lockedProfile() {
  const baseUrl = "http://localhost:3030/jsonstore/advanced/profiles";
  const main = document.getElementById("main");

  loadProfiles();

  async function loadProfiles() {
    const response = await fetch(baseUrl);
    const profiles = await response.json();
    main.innerHTML = "";

    let userCount = 1;

    Object.values(profiles).forEach((profile) => {
      const profileDiv = document.createElement("div");
      profileDiv.id = profile._id;
      profileDiv.classList.add("profile");

      profileDiv.innerHTML = `

            <img src="./iconProfile2.png" class="userIcon" />
            <label>Lock</label>
            <input type="radio" name="user${userCount}Locked" value="lock" checked>
            <label>Unlock</label>
            <input type="radio" name="user${userCount}Locked" value="unlock"><br>
            <hr>
            <label>Username</label>
            <input type="text" name="user${userCount}Username" value="${profile.username}" disabled readonly />
            <div id="user${userCount}HiddenFields">
                <hr>
                <label>Email:</label>
                <input type="email" name="user${userCount}Email" value="${profile.email}" disabled readonly />
                <label>Age:</label>
                <input type="email" name="user${userCount}Age" value="${profile.age}" disabled readonly />
            </div>

            <button>Show more</button>        
            `;

      main.appendChild(profileDiv);
      const hideFields = profileDiv.querySelector(
        `div[id="user${userCount}HiddenFields"]`
      );
      const lockBtn = profileDiv.querySelector('input[value="lock"]');

      hideFields.style.display = "none";
      const showBtn = profileDiv.querySelector("button");

      showBtn.addEventListener("click", showOrHide);

        async function showOrHide() {
        if (!lockBtn.checked) {
          if ((showBtn.textContent === "Show more")) {
            hideFields.style.display = "block";
            showBtn.textContent = "Hide it";
          } else {
            hideFields.style.display = "none";
            showBtn.textContent = "Show more";
          }
        }
      }

      userCount++;
    });
  }
}
