window.addEventListener("load", solve);

function solve() {
    const inputForm = document.querySelector("form.scoring-content");
    const addBtn = document.getElementById("add-btn");
    const sureList = document.getElementById("sure-list");
    const clearBtn = document.querySelector("button.clear");
    

    addBtn.addEventListener("click", getInformation);
    clearBtn.addEventListener("click", reloadApp);

    function getInformation(e) {
        e.preventDefault();
        this.disabled = true;
        const playerName = document.getElementById("player").value;
        const playerScore = document.getElementById("score").value;
        const round = document.getElementById("round").value;

        const liDartItem = document.createElement("li");
        liDartItem.classList = "dart-item";
        const article = document.createElement("article");

        const playerParagraph = document.createElement("p");
        playerParagraph.textContent = playerName;
        const scoreParagraph = document.createElement("p");
        scoreParagraph.textContent = `Score: ${playerScore}`;
        const roundParagraph = document.createElement("p");
        roundParagraph.textContent = `Round: ${round}`;

        const editBtn = document.createElement("button");
        editBtn.classList = "btn edit";
        editBtn.textContent = "edit";
        editBtn.addEventListener("click", editScore);

        const okBtn = document.createElement("button");
        okBtn.textContent = "ok";
        okBtn.classList = ("btn ok");
        okBtn.addEventListener("click", confirmScore);

        article.appendChild(playerParagraph);
        article.appendChild(scoreParagraph);
        article.appendChild(roundParagraph);
        liDartItem.appendChild(article);
        liDartItem.appendChild(editBtn);
        liDartItem.appendChild(okBtn);
        sureList.appendChild(liDartItem);

        inputForm.reset();

        function editScore(e) {
            e.preventDefault();
            addBtn.disabled = false;
            sureList.innerHTML = "";
            let formData = {
                player: playerName,
                score: Number(playerScore),
                round: Number(round),
            };

            for (let i = 0; i < inputForm.length; i++) {
                if (inputForm[i].id === "player") {
                    inputForm[i].value = formData.player;

                } else if (inputForm[i].id === "score") {
                    inputForm[i].value = formData.score;
                } else if (inputForm[i].id === "round") {
                    inputForm[i].value = formData.round;
                }
            }
        }

        function confirmScore(e) {
            e.preventDefault();
            const ulScoreboard = document.getElementById("scoreboard-list");

            let scoreboardLi = sureList.querySelector(".dart-item");
            scoreboardLi.removeChild(editBtn);
            scoreboardLi.removeChild(okBtn);

            ulScoreboard.appendChild(scoreboardLi);

            addBtn.disabled = false;

        }

    }

    function reloadApp() {
        location.reload();
    }
}
