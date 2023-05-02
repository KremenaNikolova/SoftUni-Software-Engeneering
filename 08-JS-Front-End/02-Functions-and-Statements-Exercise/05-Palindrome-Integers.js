function findPalindrome(numbers){

    for (let i = 0; i < numbers.length; i++) {
        let currNumber = numbers[i].toString();
        let reverseNumber = currNumber.split("").reverse().join("");

        if (currNumber === reverseNumber) {
            console.log(`true`);
        } else {
            console.log(`false`);
        }
    }
}

findPalindrome([123,323,421,121]);

findPalindrome([32,2,232,1010]);