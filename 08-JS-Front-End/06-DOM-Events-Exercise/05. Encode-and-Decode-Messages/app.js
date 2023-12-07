function encodeAndDecodeMessages() {
    let encodeTextArea = document.getElementsByTagName('textarea')[0]; 
    let decodeTextArea = document.getElementsByTagName('textarea')[1];

    let encodeBtn = document.getElementsByTagName('button')[0]; 
    let decodeBtn = document.getElementsByTagName('button')[1]; 

    encodeBtn.addEventListener('click', encodeMessaes);
    decodeBtn.addEventListener('click', decodeMessaes)

    function encodeMessaes() {
        let splittedMessage = encodeTextArea.value.split('');
        let newMessage = [];
        for (let char of splittedMessage) {
            char = String.fromCharCode(char.charCodeAt(0)+1);
            newMessage.push(char);
        }
        decodeTextArea.value = newMessage.join('');
        encodeTextArea.value = '';
    }

    function decodeMessaes() {
        let splittedMessage = decodeTextArea.value.split('');
        let newMessage = [];
        for (let char of splittedMessage) {
            char = String.fromCharCode(char.charCodeAt(0)-1);
            newMessage.push(char);
        }
        decodeTextArea.value = newMessage.join('');
        decodeBtn.disabled = true;
    }
}