function reverse(char1, char2, char3) {
  let chars = [char1, char2, char3];
  let string = "";
  chars.reverse();

  chars.forEach((element) => {
    string += element + " ";
  });

  console.log(string);
}

reverse("A", "B", "C");
reverse("1", "L", "&");