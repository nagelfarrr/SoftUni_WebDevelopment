async function loadCommits() {
    const ul = document.getElementById("commits");

    const username = document.getElementById("username").value;
    const repository = document.getElementById("repo").value;
    const fetchUrl = `https://api.github.com/repos/${username}/${repository}/commits`;

    try {
        const response = await fetch(fetchUrl);
        if (!response.ok) {
            throw new Error(`Error: ${response.status} (Not Found)`);
        }

        const commitEntries = await response.json();
        commitEntries.forEach(commitEntry => {
            const authorName = commitEntry.commit.author.name;
            const message = commitEntry.commit.message;
            const li = document.createElement("li");
            li.textContent = `${authorName}: ${message}`;
            ul.appendChild(li);
        })

    } catch (error) {
        const li = document.createElement("li");
        li.textContent = error.message;
        ul.appendChild(li);
    }
}