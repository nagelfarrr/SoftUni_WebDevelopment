function attachEvents() {
    const allBooksUrl = "http://localhost:3030/jsonstore/collections/books";

    const loadBooksBtn = document.getElementById("loadBooks");
    const tableBody = document.querySelector("tbody");
    const submitBtn = document.querySelector("#form button");

    tableBody.innerHTML = ""

    loadBooksBtn.addEventListener("click", getAllBooks);
    submitBtn.addEventListener("click", createBook);


    function getAllBooks() {
        fetch(allBooksUrl)
            .then(res => res.json())
            .then(books => {
                Object.entries(books).forEach(book => {
                    const tr = document.createElement("tr");
                    const tdTitle = document.createElement("td");
                    const tdAuthor = document.createElement("td");
                    const tdButtons = document.createElement("td");
                    const editBtn = document.createElement("button");
                    const deleteBtn = document.createElement("button");
                    
                    const bookId = book[0];
                    tdTitle.textContent = book[1].title;
                    tdAuthor.textContent = book[1].author;
                    
                    
                    editBtn.textContent = "Edit";
                    editBtn.value = bookId;
                    deleteBtn.textContent = "Delete";
                    deleteBtn.value = bookId;
                    editBtn.addEventListener("click", editBook);

                    tdButtons.appendChild(editBtn);
                    tdButtons.appendChild(deleteBtn);

                    tr.appendChild(tdTitle);
                    tr.appendChild(tdAuthor);
                    tr.appendChild(tdButtons);

                    tableBody.appendChild(tr);
                })
            });

         
    }

   

    function createBook() {
        const form = document.getElementById("form");
        const bookTitle = form.querySelector("input[name=title]").value;
        const bookAuthor = form.querySelector("input[name=author]").value;

        let book = {
            title: bookTitle,
            author: bookAuthor,
        }

        fetch(allBooksUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(book),
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status : ${response.status}`);
                }
            })
            .catch(error => {
                console.error("Error creating book:", error);
            });
    }

    function editBook(){
        const bookId = this.value;
        const form = document.getElementById("form");
        const formTitle = form.querySelector("h3");
        const formBookTitle = form.querySelector("input[name=title");
        const formBookAuthor = form.querySelector("input[name=author");
        formTitle.textContent = "Edit FORM";
        


        fetch(`${allBooksUrl}/${bookId}`, {
            method: "PUT",
        })
            .then(response => response.json())
            .then(book => {
                formBookTitle.textContent = book.title;
                formBookAuthor.textContent = book.author;
            });
    }
}

attachEvents();