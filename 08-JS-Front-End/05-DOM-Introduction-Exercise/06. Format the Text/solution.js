function solve() {
  const inputText = document.getElementById("input").value;
  const sentences = inputText.split(".");

  const filteredSentences = sentences.filter(
    (sentence) => sentence.trim().length > 0
  );

  document.getElementById("output").innerHTML = "";

  for (let i = 0; i < filteredSentences.length; i += 3) {
    const paragraphSentences = filteredSentences.slice(i, i + 3);
    const paragraphText = paragraphSentences.join(". ") + ".";
    const paragraphElement = `<p>${paragraphText}</p>`;
    document.getElementById("output").innerHTML += paragraphElement;
  }
}
