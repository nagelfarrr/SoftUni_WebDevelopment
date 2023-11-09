function palindrome(numArray) {

    
    for(let i = 0; i < numArray.length; i++) {
        
        let isPalindrome = false;
        let temp = String(numArray[i]);
        let reversedTemp = temp.split("").reverse().join("");

        if(temp === reversedTemp) {
            isPalindrome = true;
        }
        console.log(isPalindrome);
    }
}

palindrome([32,2,232,1010]);