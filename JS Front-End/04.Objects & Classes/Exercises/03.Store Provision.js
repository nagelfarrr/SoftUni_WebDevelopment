function getStoreProvisionInfo(productsInStock, orderedProducts) {

    let products = {};

    for (let index = 0; index < productsInStock.length; index += 2) {

        products[productsInStock[index]] = Number(productsInStock[index + 1]);
    }
   
    for (let index = 0; index < orderedProducts.length; index += 2) {

        if (!products.hasOwnProperty(orderedProducts[index])) {
            products[orderedProducts[index]] = Number(orderedProducts[index + 1]);
        } else {
            products[orderedProducts[index]] += Number(orderedProducts[index + 1]);
        }

    }

    let productsEntries = Object.entries(products);

    for (const iterator of productsEntries) {
        
        console.log(`${iterator[0]} -> ${iterator[1]}`);
    }

}

getStoreProvisionInfo(
    [
        'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);