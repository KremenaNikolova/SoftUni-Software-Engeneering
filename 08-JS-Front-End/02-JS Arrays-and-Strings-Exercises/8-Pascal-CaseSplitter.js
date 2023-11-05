function spliter(string) {
    const stringArray = string.split(/(?=[A-Z])/);
    
    console.log(stringArray.join(', '));
}

spliter('SplitMeIfYouCanHaHaYouCantOrYouCan');
spliter('HoldTheDoor');
spliter('ThisIsSoAnnoyingToDo');