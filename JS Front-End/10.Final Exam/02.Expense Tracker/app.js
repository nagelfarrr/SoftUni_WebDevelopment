window.addEventListener("load", solve);

function solve() {
    const inputForm = document.querySelector("form.expense-content");

    const previewList = document.getElementById("preview-list");
    const expensesList = document.getElementById("expenses-list");

    const addBtn = document.getElementById("add-btn");
    addBtn.addEventListener("click", addToPreview);

    const deleteBtn = document.querySelector("button.delete");
    deleteBtn.addEventListener("click", () => location.reload());

    function addToPreview() {

        const expenseInputElement = document.getElementById("expense");
        const expense = expenseInputElement.value;
        const amountInputElement = document.getElementById("amount");
        const amount = amountInputElement.value;
        const dateInputElement = document.getElementById("date");
        const date = dateInputElement.value;

        if (expenseInputElement.value === ""
            || amountInputElement.value === ""
            || dateInputElement.value === "") {
            return;
        }



        let liElement = document.createElement("li");
        liElement.classList = "expense-item";
        let articleElement = document.createElement("article");

        let typeParagraph = document.createElement("p");
        typeParagraph.textContent = `Type: ${expense}`;

        let amountParagraph = document.createElement("p");
        amountParagraph.textContent = `Amount: ${amount}$`;

        let dateParagraph = document.createElement("p");
        dateParagraph.textContent = `Date: ${date}`;


        let buttonsDiv = document.createElement("div");
        buttonsDiv.classList = "buttons";

        let editBtn = document.createElement("button");
        editBtn.classList = "btn edit";
        editBtn.textContent = "edit";
        editBtn.addEventListener("click", edit);


        let okBtn = document.createElement("button");
        okBtn.classList = "btn ok";
        okBtn.textContent = "ok";
        okBtn.addEventListener("click", approveInfo);


        articleElement.appendChild(typeParagraph);
        articleElement.appendChild(amountParagraph);
        articleElement.appendChild(dateParagraph);

        buttonsDiv.appendChild(editBtn);
        buttonsDiv.appendChild(okBtn);

        liElement.appendChild(articleElement);
        liElement.appendChild(buttonsDiv);

        previewList.appendChild(liElement);

        addBtn.disabled = true;
        inputForm.reset();


        function edit() {
            expenseInputElement.value = expense;
            amountInputElement.value = amount;
            dateInputElement.value = date;

            previewList.removeChild(liElement);
            addBtn.disabled = false;
        }

        function approveInfo() {
            liElement.removeChild(buttonsDiv);
            previewList.removeChild(liElement);
            expensesList.appendChild(liElement);
            addBtn.disabled = false;
        }
    }


}