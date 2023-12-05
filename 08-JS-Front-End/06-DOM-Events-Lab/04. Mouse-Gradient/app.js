function attachGradientEvents() {
    const gradient = document.getElementById('gradient');
    const result = document.getElementById('result');

    gradient.addEventListener('mousemove', function (event) {
        const mouseX = event.offsetX;
        const gradientWidth = gradient.clientWidth;

        if (gradientWidth > 0) {
            const percentage = (mouseX / gradientWidth) * 100;
            result.textContent = `${Math.floor(percentage)}%`;
        } else {
            result.textContent = 'Gradient was not detected.';
        }
    });

    gradient.addEventListener('mouseout', function () {
        result.textContent = '';
    });
}
