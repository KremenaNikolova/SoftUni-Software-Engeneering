window.addEventListener("load", solve);

function solve() {
  const titleInput = document.getElementById("task-title");
  const categoryInput = document.getElementById("task-category");
  const contentArea = document.getElementById("task-content");
    const ulReviewList = document.getElementById("review-list");
    const ulPublishedList = document.getElementById('published-list');
  const publishBtn = document.getElementById("publish-btn");

  publishBtn.addEventListener("click", addReview);

  function addReview() {
    const title = titleInput.value;
    const category = categoryInput.value;
    const content = contentArea.value;

    let isValiInput = title && category && content;

    if (!isValiInput) {
      return;
    }

    const li = document.createElement("li");
    li.classList.add("rpost");

    const article = document.createElement("article");
    const h4Title = document.createElement("h4");
    h4Title.textContent = title;

    const pCategory = document.createElement("p");
    pCategory.textContent = `Category: ${category}`;

    const pContent = document.createElement("p");
    pContent.textContent = `Content: ${content}`;

    article.appendChild(h4Title);
    article.appendChild(pCategory);
    article.appendChild(pContent);

    const editBtn = document.createElement("button");
    editBtn.classList.add("action-btn", "edit");
    editBtn.textContent = "Edit";

    const postBtn = document.createElement("button");
    postBtn.classList.add("action-btn", "post");
    postBtn.textContent = "Post";

    li.appendChild(article);
    li.appendChild(editBtn);
    li.appendChild(postBtn);

    ulReviewList.appendChild(li);
    clearInputs();

      editBtn.addEventListener("click", editReview);
      postBtn.addEventListener('click', postReview);

    function editReview() {
      ulReviewList.removeChild(li);
      titleInput.value = title;
      categoryInput.value = category;
      contentArea.value = content;
      }
      
      function postReview() {
          ulReviewList.removeChild(li);
          li.removeChild(editBtn);
          li.removeChild(postBtn);
          ulPublishedList.appendChild(li);
      }
  }

  function clearInputs() {
    titleInput.value = "";
    categoryInput.value = "";
    contentArea.value = "";
  }
}
