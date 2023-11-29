function editElement(ref, currText, newText) {
  const content = ref.textContent;
  const getText = new RegExp(currText, "g");
  const swapText = content.replace(getText, newText);

  ref.textContent = swapText;
}
