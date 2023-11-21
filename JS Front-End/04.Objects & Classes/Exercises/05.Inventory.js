function getHeroInfo(inputArr) {

    class Hero {
        constructor(name, level, items) {
            this.name = name,
                this.level = level,
                this.items = items
        }
    }

    let heroes = [];

    for (let index = 0; index < inputArr.length; index++) {
        let heroTokens = inputArr[index].split(" / ");
        let heroName = heroTokens[0];
        let heroLevel = Number(heroTokens[1]);
        let heroItems = heroTokens[2].split(", ");

        let hero = new Hero(heroName, heroLevel, heroItems);
        heroes.push(hero);

    }

    let sortedHeroes = heroes.sort(( a ,  b ) => a.level - b.level)

    for (let index = 0; index < sortedHeroes.length; index++) {
        console.log(`Hero: ${heroes[index].name}\nlevel => ${heroes[index].level}\nitems => ${heroes[index].items.join(", ")}`)

    }
}

getHeroInfo([
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
    ]
    
);