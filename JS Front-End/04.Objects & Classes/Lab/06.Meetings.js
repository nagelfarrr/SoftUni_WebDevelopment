function scheduler(inputArr) {

    let scheduledDay = {};

    for (let index = 0; index < inputArr.length; index++) {
        
        let day = "";
        let person = ""

        let tokens = inputArr[index].split(" ");
        day = tokens[0];
        person = tokens[1];

        if(!(day in scheduledDay)){
            scheduledDay[day] = person;
            console.log(`Scheduled for ${day}`);
        }else {
            console.log(`Conflict on ${day}!`);
        }
    }
    let scheduleEntries = Object.entries(scheduledDay)

  for (const iterator of scheduleEntries) {
     let [day, name] = iterator
     console.log(`${day} -> ${name}`)
  }
}

scheduler(['Monday Peter', 'Wednesday Bill', 'Monday Tim', 'Friday Tim']);