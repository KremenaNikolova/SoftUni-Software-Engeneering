function substring(string, startIndex, count) {
    string = string.substring(startIndex,startIndex + count);

    console.log(string);
}

substring('ASentence', 1, 8);
substring('SkipWord', 4, 7);