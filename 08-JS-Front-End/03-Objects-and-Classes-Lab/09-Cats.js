function cats(info){
    class Cat{
        constructor(name, age){
            this.name = name;
            this.age = age;
        }

        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    let kitties = [];
    for (let i = 0; i < info.length; i++) {
        let tokens = info[i].split(' ');

        let name = tokens[0];
        let age = tokens[1];
        
        kitties.push(new Cat(name, age));
    }


    for (const kitty of kitties) {
        kitty.meow();
    }
}

cats(['Mellow 2', 'Tom 5']);