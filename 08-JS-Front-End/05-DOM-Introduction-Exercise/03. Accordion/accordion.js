function toggle() {
    let buttonWord = document.getElementsByClassName('button')[0];
    const extraText = document.getElementById('extra');

    if (buttonWord.textContent === 'More') {
        extraText.style.display = 'block';
        buttonWord.textContent = 'Less';

    } else {
        extraText.style.display = 'none';
        buttonWord.textContent = 'More';
    }
}