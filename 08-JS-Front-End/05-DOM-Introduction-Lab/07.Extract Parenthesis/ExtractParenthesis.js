function extract(content) {
  const text = document.getElementById(content);

  const regexPattern = /\((.+?)\)/g;

  let result = text.textContent.match(regexPattern);
    console.log(result.join('; '));
    return result.join('; ');
}
