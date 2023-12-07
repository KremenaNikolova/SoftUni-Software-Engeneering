function create(words) {
   const contentDiv = document.getElementById('content');

   words.forEach(word => {
       const divElement = document.createElement('div');

       const paragraphElement = document.createElement('p');
       paragraphElement.textContent = word;
       paragraphElement.style.display = 'none';

       divElement.addEventListener('click', () => {
           if (paragraphElement.style.display === 'none') {
               paragraphElement.style.display = 'block';
           } else {
               paragraphElement.style.display = 'none';
           }
       });

       divElement.appendChild(paragraphElement);

       contentDiv.appendChild(divElement);
   });
}
