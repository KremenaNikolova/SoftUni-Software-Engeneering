function characktersInRange(charOne, charTwo){
    let result = new Array();
    if(charOne.charCodeAt() < charTwo.charCodeAt()){
        for (let i = charOne.charCodeAt()+1; i < charTwo.charCodeAt(); i++){
            result.push(String.fromCharCode(i));
        }
    } else {
        for (let i = charTwo.charCodeAt()+1; i < charOne.charCodeAt(); i++){
            result.push(String.fromCharCode(i));
        }
    }

    console.log(result.join(" "));
}

characktersInRange(
    'a',
    'd'
    );

characktersInRange(
    '#',
    ':'
    );

characktersInRange(
    'C',
    '#'
    );