function catInfo(inputArr){
    
    class Cat{

        constructor(name, age){
            this.name = name;
            this.age = age;
        }

        Meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (let index = 0; index < inputArr.length; index++) {
       
        let catTokens = inputArr[index].split(" ");
        
        let catName = catTokens[0];
        let catAge = catTokens[1];

        let cat = new Cat(catName, catAge);
        cat.Meow();
    }

}

catInfo(['Candy 1', 'Poppy 3', 'Nyx 2']);