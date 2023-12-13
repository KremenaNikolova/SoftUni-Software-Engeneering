function solution() {
  const baseUrl = "http://localhost:3030/jsonstore/advanced/articles/";
  const main = document.getElementById("main");

  async function load() {
    const response = await fetch(baseUrl + "list");
    const articles = await response.json();
    main.innerHTML = "";

    for (const article of articles) {
      const articleRespone = await fetch(baseUrl + `details\\${article._id}`);
      const articleInfo = await articleRespone.json();

      const divContainer = document.createElement("div");
      divContainer.classList.add("accordion");
      divContainer.innerHTML = `
            <div class="head">
                    <span>${article.title}</span>
                    <button class="button" id="${article._id}">More</button>
                </div>
                <div class="extra">
                    <p>${articleInfo.content}</p>
                </div>
                `;

      main.appendChild(divContainer);
      const extraText = divContainer.querySelector('div[class="extra"]');
      extraText.style.display = "none";

      const showBtn = divContainer.querySelector("button");

      showBtn.addEventListener("click", async () => {
        if (showBtn.textContent === "More") {
          extraText.style.display = "block";
          showBtn.textContent = "Less";
        } else {
          extraText.style.display = "none";
          showBtn.textContent = "More";
        }
      });
    }
  }

  load();
}

solution();
