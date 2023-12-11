function attachEvents() {
  const baseUrl = "http://localhost:3030/jsonstore/messenger";
  const sendBtn = document.getElementById("submit");
  const refreshBtn = document.getElementById("refresh");
  const nameInput = document.querySelector('input[name="author"]');
  const messageInput = document.querySelector('input[name="content"]');
  const textarea = document.getElementById("messages");

  sendBtn.addEventListener("click", async () => {
    const msgFormat = {
      author: nameInput.value,
      content: messageInput.value,
    };

    await fetch(baseUrl, {
      method: "POST",
      body: JSON.stringify(msgFormat),
    });

    nameInput.value = "";
    messageInput.value = "";
  });

  refreshBtn.addEventListener("click", async () => {
    const response = await fetch(baseUrl);
    const messages = await response.json();
    console.log(messages);
    const showMsges = [];

    for (const msgInfo of Object.values(messages)) {
      showMsges.push(`${msgInfo.author}: ${msgInfo.content}`);
    }

    textarea.value = showMsges.join("\n");
  });
}

attachEvents();
