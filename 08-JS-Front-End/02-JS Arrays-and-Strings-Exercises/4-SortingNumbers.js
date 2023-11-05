function sort(numArray) {
    numArray.sort((a, b) => a -b);
    let newArray = [];

    while (numArray.length>0) {
        newArray.push(numArray.shift());
        newArray.push(numArray.pop());
    }

    return newArray
}

sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);