function fruitsPrice(fruit, grams, pricerPerKilo) {
    let fruitPrice = (grams / 1000) * pricerPerKilo;

    console.log(`I need $${fruitPrice.toFixed(2)} to buy ${(grams/1000).toFixed(2)} kilograms ${fruit}.`);
}

fruitsPrice("apple", 1563, 2.35);