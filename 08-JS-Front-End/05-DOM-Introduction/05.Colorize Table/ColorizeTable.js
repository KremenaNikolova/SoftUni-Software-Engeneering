function colorize() {
    let index = 0;
    const elements = Array.from(document.getElementsByTagName("tr"));

    for (const element of elements) {
        index++;
        if (index % 2 === 0) {
            element.style.background = 'Teal';
        }
    }
}