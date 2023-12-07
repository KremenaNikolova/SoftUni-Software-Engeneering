function lockedProfile() {
  let showBtn = Array.from(document.querySelectorAll("button"));

  for (const btn of showBtn) {
    btn.addEventListener("click", showOrHide);
  }

  function showOrHide(event) {
    let btn = event.target;
    let currProfile = event.target.parentNode;
    let hiddenField = currProfile.querySelector("div");
    let unlocked = currProfile.querySelector('input[value="unlock"]');
    if (!unlocked.checked) {
      return;
    }

    if (btn.textContent === "Show more") {
      hiddenField.style.display = "block";
      btn.textContent = "Hide it";
    } else if (btn.textContent === "Hide it") {
      hiddenField.style.display = "none";
      btn.textContent = "Show more";
    }
  }
}
