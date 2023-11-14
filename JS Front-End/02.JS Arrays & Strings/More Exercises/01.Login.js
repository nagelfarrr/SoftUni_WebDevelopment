function login(usernamePassword) {

    let username = usernamePassword[0];
    let passwordsArray = usernamePassword.slice(1);

    let tryCounts = 0;

    for (let i = 0; i < passwordsArray.length; i++) {

        tryCounts++;

        let reversedPassword = passwordsArray[i].split("").reverse().join("");

        if(username === reversedPassword){
            console.log(`User ${username} logged in.`)
            break;
        } else if(username !== reversedPassword && tryCounts === 4) {
            console.log(`User ${username} blocked!`);
            break;
        } 
        else {
            console.log("Incorrect password. Try again.")
        }
    }

}

login(['sunny','rainy','cloudy','sunny','not sunny']);