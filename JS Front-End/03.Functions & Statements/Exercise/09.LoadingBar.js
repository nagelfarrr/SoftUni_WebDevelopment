function loadingBar(percentage) {

    if (percentage === 100) {
        console.log("100% Complete!");
    } else {
        let percentCount = "%".repeat(percentage / 10);
        let dotsCount = ".".repeat(10 - percentCount.length);

        console.log(`${percentage}% [${percentCount}${dotsCount}]`);
        console.log("Still loading...")
    }

}

loadingBar(30);