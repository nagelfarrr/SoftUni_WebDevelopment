function attachEventsListeners() {
    const daysBtn = document.getElementById("daysBtn");
    const hoursBtn = document.getElementById("hoursBtn");
    const minutesBtn = document.getElementById("minutesBtn");
    const secondsBtn = document.getElementById("secondsBtn");

    daysBtn.addEventListener("click", convertDays);
    hoursBtn.addEventListener("click", convertHours);
    minutesBtn.addEventListener("click", convertMinutes);
    secondsBtn.addEventListener("click", convertSeconds);

    function convertDays() {
        const hoursField = getHoursField();
        const minutesField = getMinutesField();
        const secondsField = getSecondsField();

        const daysToConvert = Number(document.getElementById("days").value);

        hoursField.value = daysToConvert * 24;
        minutesField.value = hoursField.value * 60;
        secondsField.value = minutesField.value * 60;
    }

    function convertHours() {
        const daysField = getDaysField();
        const minutesField = getMinutesField();
        const secondsField = getSecondsField();

        const hoursToConvert = Number(getHoursField().value);
        daysField.value = hoursToConvert / 24;
        minutesField.value = hoursToConvert * 60;
        secondsField.value = minutesField.value * 60;
    }

    function convertMinutes() {
        const daysField = getDaysField();
        const hoursField = getHoursField();
        const secondsField = getSecondsField();

        const minutesToConvert = Number(getMinutesField().value);
        hoursField.value = minutesToConvert / 60;
        daysField.value = hoursField.value / 24;
        secondsField.value = minutesToConvert * 60;
    }

    function convertSeconds() {
        const daysField = getDaysField();
        const hoursField = getHoursField();
        const minutesField = getMinutesField();

        const secondsToConvert = Number(getSecondsField().value);

        minutesField.value = secondsToConvert / 60;
        hoursField.value = minutesField.value / 60;
        daysField.value = hoursField.value / 24;
    }

    function getDaysField() {
        return document.getElementById("days");
    }
    function getHoursField() {
        return document.getElementById("hours");
    }
    function getMinutesField() {
        return document.getElementById("minutes");
    }
    function getSecondsField() {
        return document.getElementById("seconds");
    }


}