function calculateCircleArea(radius) {
    
    let input = typeof(radius)
    let result;

    if(input !== "number") {
        result = `We can not calculate the circle area, because we receive a ${typeof(radius)}.`;
    }
    else {
        result = (radius * radius * Math.PI).toFixed(2);
    }

    console.log(result);
}

calculateCircleArea("name")