const baseUrl = "http://localhost:3030/jsonstore/tasks/";

class Meal {
    constructor(food, calories, time) {
        this.food = food,
            this.calories = calories,
            this.time = time
    };
}

const loadMealsBtn = document.getElementById("load-meals");
loadMealsBtn.addEventListener("click", loadMeals);

const addMealBtn = document.getElementById("add-meal");
addMealBtn.addEventListener("click", addMeal);

const editMealBtn = document.getElementById("edit-meal");

const divMealList = document.getElementById("list");

const inputForm = document.querySelector("form");
const foodInputElement = document.getElementById("food");
const timeInputElement = document.getElementById("time");
const caloriesInputElement = document.getElementById("calories");

async function loadMeals() {
    divMealList.innerHTML = "";
    const response = await fetch(baseUrl);
    const data = await response.json();

    for (const mealEntry of Object.entries(data)) {
        let food = mealEntry[1].food;
        let calories = mealEntry[1].calories;
        let time = mealEntry[1].time;

        let newMeal = new Meal(food, calories, time);
        newMeal._id = mealEntry[1]._id;


        const divMeal = document.createElement("div");
        divMeal.classList = "meal";

        const foodHeading = document.createElement("h2");
        foodHeading.textContent = newMeal.food;
        const timeHeading = document.createElement("h3");
        timeHeading.textContent = newMeal.time;
        const caloriesHeading = document.createElement("h3");
        caloriesHeading.textContent = newMeal.calories;

        const divMealButtons = document.createElement("div");
        divMealButtons.setAttribute("id", "meal-buttons");

        const changeBtn = document.createElement("button");
        changeBtn.classList = "change-meal";
        changeBtn.textContent = "Change";
        changeBtn.addEventListener("click", changeMeal);


        const deleteBtn = document.createElement("button");
        deleteBtn.classList = "delete-meal";
        deleteBtn.textContent = "Delete";
        deleteBtn.addEventListener("click", deleteMeal);

        divMealButtons.appendChild(changeBtn);
        divMealButtons.appendChild(deleteBtn);

        divMeal.appendChild(foodHeading);
        divMeal.appendChild(timeHeading);
        divMeal.appendChild(caloriesHeading);
        divMeal.appendChild(divMealButtons);

        divMealList.appendChild(divMeal);


        async function changeMeal() {
            foodInputElement.value = foodHeading.textContent;
            timeInputElement.value = timeHeading.textContent;
            caloriesInputElement.value = caloriesHeading.textContent;

            divMealList.removeChild(divMeal);
            addMealBtn.disabled = true;
            editMealBtn.disabled = false;


            editMealBtn.addEventListener("click", editMeal);
            console.log("Before");
            async function editMeal() {

                if (foodInputElement.value === ""
                    || timeInputElement.value === ""
                    || caloriesInputElement.value === "") {
                    return;
                }
                let res = await fetch(`${baseUrl}${newMeal._id}`)
                if(!res.ok){
                    return;
                }

                let meal = await res.json();
                if(!meal) {
                    return;
                }
                meal.food = foodInputElement.value;
                meal.time = timeInputElement.value;
                meal.calories = caloriesInputElement.value;
                console.log(meal);

               const result =  await fetch(`${baseUrl}${meal._id}`, {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(meal)
                });
                if(!result.ok){
                    return;
                }
                await loadMeals();
                inputForm.reset();
                editMealBtn.disabled = true;
                addMealBtn.disabled = false;

            }
            console.log("After");
        }
        async function deleteMeal() {
            await fetch(`${baseUrl}${newMeal._id}`, {
                method: "DELETE"
            })

            await loadMeals();
        }
    }
}

async function addMeal() {
    if (foodInputElement.value === ""
        || timeInputElement.value === ""
        || caloriesInputElement.value === "") {
        return;
    }

    const food = foodInputElement.value;
    const time = timeInputElement.value;
    const calories = caloriesInputElement.value;

    const newMeal = new Meal(food, calories, time);

    await fetch(baseUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(newMeal)
    })

    inputForm.reset();
    await loadMeals();
}