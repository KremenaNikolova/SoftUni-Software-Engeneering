function attachEvents() {
  const baseUrl = "http://localhost:3030/jsonstore/blog/";
  const loadBtn = document.getElementById("btnLoadPosts");
  const viewBtn = document.getElementById("btnViewPost");
  const postSelect = document.getElementById("posts");
  const postTitle = document.getElementById("post-title");
  const postBody = document.getElementById("post-body");
  const postComments = document.getElementById("post-comments");

  let allPosts = [];

  loadBtn.addEventListener("click", async () => {
    postSelect.innerHTML = "";
    const response = await fetch(baseUrl + "posts");
    allPosts = await response.json();

    for (const [postId, postObj] of Object.entries(allPosts)) {
      const option = document.createElement("option");

      option.value = postId;
      option.textContent = postObj.title;
      postSelect.appendChild(option);
    }
  });
  viewBtn.addEventListener("click", async () => {
    postBody.innerHTML = "";
    postComments.innerHTML = "";

    const postId = postSelect.value;

    postTitle.textContent = allPosts[postId].title;
    postBody.textContent = allPosts[postId].body;

    const response = await fetch(baseUrl + "comments");
    comments = await response.json();

    const filteredComments = Object.values(comments).filter(
      (c) => c.postId === postId
    );
    filteredComments.forEach((comment) => {
      const li = document.createElement("li");
      li.id = comment.id;
      li.textContent = comment.text;
      postComments.appendChild(li);
    });
  });
}

attachEvents();
