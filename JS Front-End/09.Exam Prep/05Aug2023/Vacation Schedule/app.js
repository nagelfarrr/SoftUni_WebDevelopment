class Vacation {
    constructor(name, days, date) {
        this.name = name,
            this.days = days,
            this.date = date
    }
}

const baseUrl = "http://localhost:3030/jsonstore/tasks/";

const loadBtn = document.getElementById("load-vacations");
loadBtn.addEventListener("click", loadVacations);

const editBtn = document.getElementById("edit-vacation");

const addBtn = document.getElementById("add-vacation");
addBtn.addEventListener("click", addVacation);



const divList = document.getElementById("list");
const inputForm = document.querySelector("form");

async function loadVacations() {

    const response = await fetch(baseUrl);
    const data = await response.json();

    let vacations = [];
    for (const iterator of Object.entries(data)) {
        let currentVacation = new Vacation(iterator[1].name, iterator[1].days, iterator[1].date);
        currentVacation._id = iterator[1]._id;
        vacations.push(currentVacation);
    }

    for (let i = 0; i < vacations.length; i++) {
        const divContainer = document.createElement("div");
        divContainer.classList = "container";

        const nameHeadingElement = document.createElement("h2");
        const dateHeadingElement = document.createElement("h3");
        const daysHeadingElement = document.createElement("h3");

        nameHeadingElement.textContent = vacations[i].name;
        dateHeadingElement.textContent = vacations[i].date;
        daysHeadingElement.textContent = vacations[i].days;

        const changeBtn = document.createElement("button");
        changeBtn.classList = "change-btn";
        changeBtn.textContent = "Change";

        const doneBtn = document.createElement("button");
        doneBtn.textContent = "Done";
        doneBtn.classList = "done-btn";

        divContainer.appendChild(nameHeadingElement);
        divContainer.appendChild(dateHeadingElement);
        divContainer.appendChild(daysHeadingElement);
        divContainer.appendChild(changeBtn);
        divContainer.appendChild(doneBtn);

        divList.appendChild(divContainer);
        editBtn.disabled = true;
    }
}

async function addVacation() {
    if(isFormEmpty(inputForm)) {
        return;
    }

    const nameInput = document.getElementById("name");
    const daysInput = document.getElementById("num-days");
    const dateInput = document.getElementById("from-date");

    const newVacation = new Vacation(nameInput.value, daysInput.value, dateInput.value)

    await fetch(baseUrl, {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(newVacation)
    })

    loadVacations();
    inputForm.reset();
}

function isFormEmpty(form) {
    let inputs = form.elements;

    for (let i = 0; i < inputs.length; i++) {
        if (inputs[i].type !== "button" && inputs[i].value.trim() !== "") {
            return false;
        }

    }
    return true;
}