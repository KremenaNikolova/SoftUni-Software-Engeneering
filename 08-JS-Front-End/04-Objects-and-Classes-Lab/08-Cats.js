function createCat(catArgs) {
  let cats = [];

  class Cat {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }

    meow() {
      console.log(`${this.name}, age ${this.age} says Meow`);
    }
  }

  for (const element of catArgs) {
    const [name, age] = element.split(" ");
    const newCat = new Cat(name, age);

    newCat.meow();
    cats.push(newCat);
  }
}

createCat(["Mellow 2", "Tom 5"]);

createCat(["Candy 1", "Poppy 3", "Nyx 2"]);
