function extractText() {
  const elements = Array.from(document.getElementsByTagName("li"));
  const textReplaces = [];

  for (const element of elements) {
    textReplaces.push(element.textContent);
  }

  const textArea = document.getElementById("result");
  textArea.textContent = textReplaces.join("\n");
}
