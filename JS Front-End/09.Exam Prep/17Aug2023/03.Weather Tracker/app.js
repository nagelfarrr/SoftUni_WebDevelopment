const baseUrl = "http://localhost:3030/jsonstore/tasks/";

const loadBtn = document.getElementById("load-history");
loadBtn.addEventListener("click", loadHistory);

const addWeatherBtn = document.getElementById("add-weather");
addWeatherBtn.addEventListener("click", addWeather);

const editWeatherBtn = document.getElementById("edit-weather");

const weatherList = document.getElementById("list");
const inputForm = document.querySelector("#form form");

async function loadHistory() {
    weatherList.innerHTML = "";
    const response = await fetch(baseUrl);
    const records = await response.json();

    for (const record of Object.entries(records)) {

        const divContainer = document.createElement("div");
        divContainer.classList = "container";
        const locationElemenet = document.createElement("h2");
        const dateElement = document.createElement("h3");
        const celsiusElement = document.createElement("h3");
        celsiusElement.setAttribute("id", "celsius");

        const buttonsContainer = document.createElement("div");
        buttonsContainer.classList = "buttons-container";

        const changeBtn = document.createElement("button");
        changeBtn.classList = "change-btn";
        changeBtn.textContent = "Change";


        const deleteBtn = document.createElement("button");
        deleteBtn.classList = "delete-btn";
        deleteBtn.textContent = "Delete";

        locationElemenet.textContent = record[1].location;
        dateElement.textContent = record[1].date;
        celsiusElement.textContent = record[1].temperature;

        buttonsContainer.appendChild(changeBtn);
        buttonsContainer.appendChild(deleteBtn);
        divContainer.appendChild(locationElemenet);
        divContainer.appendChild(dateElement);
        divContainer.appendChild(celsiusElement);
        divContainer.appendChild(buttonsContainer);

        weatherList.appendChild(divContainer);

        changeBtn.addEventListener("click", async (e) => {
            const currentItemId = record[1]._id;
            populateForm(inputForm, locationElemenet.textContent,
                celsiusElement.textContent,
                dateElement.textContent);

            editWeatherBtn.disabled = false;
            addWeatherBtn.disabled = true;



            editWeatherBtn.addEventListener("click", async () => {
                if (!isFormEmpty(inputForm)) {
                    weatherList.innerHTML = "";
                    const locationFormElement = document.getElementById("location");
                    const temperatureFormElement = document.getElementById("temperature");
                    const dateFormElement = document.getElementById("date");

                    let weather = {
                        location: locationFormElement.value,
                        temperature: temperatureFormElement.value,
                        date: dateFormElement.value,
                        _id: currentItemId,
                    }
                    await fetch(`${baseUrl}${currentItemId}`, {
                        method: "PUT",
                        header: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify(weather),
                    })


                    await loadHistory();

                    editWeatherBtn.disabled = true;
                    addWeatherBtn.disabled = false;
                }
            })



        });

        deleteBtn.addEventListener("click", async (e) => {
            const currentItemId = record[1]._id;

            await fetch(`${baseUrl}${currentItemId}`, {
                method: "DELETE",
                headers: {
                    "Content-Type": "application/json"
                },
            })
            weatherList.innerHTML = "";
            await loadHistory();
        })
    }



}

async function addWeather() {

    if (!isFormEmpty(inputForm)) {




        const locationElement = document.getElementById("location");
        const temperatureElement = document.getElementById("temperature");
        const dateElement = document.getElementById("date");

        let weather = {
            location: locationElement.value,
            temperature: temperatureElement.value,
            date: dateElement.value,
        }

        await fetch(baseUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(weather),
        })
        weatherList.innerHTML = "";
        await loadHistory();

        inputForm.reset();
    }
}

function isFormEmpty(form) {

    const inputs = form.elements;
    for (let i = 0; i < inputs.length; i++) {
        let element = form.elements[i];

        if (inputs[i].type !== "button" && inputs[i].value.trim() === "") {
            return true;
        }

    }
    return false;
}

function populateForm(form, location, temperature, date) {
    const formData = {
        location: location,
        temperature: Number(temperature),
        date: date,
    }

    for (const key in formData) {
        if (formData.hasOwnProperty(key)) {
            form.elements[key].value = formData[key];

        }
    }
}

