function sumDigits(number) {

    let sum = 0;

    while (number > 0) {
     
         let digit = number % 10;
 
         sum += digit;
         number = Math.floor(number / 10);
   }

    console.log(sum);
}

sumDigits(543);