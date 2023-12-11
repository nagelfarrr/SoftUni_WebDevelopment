function loadRepos() {
	const username = document.getElementById("username").value;
	const reposList = document.getElementById("repos");

	console.log(username);
	const reposUrl = `https://api.github.com/users/${username}/repos`;

	let li = document.createElement("li");
	fetch(reposUrl)
		.then(response => {
			if(!response.ok) {
				if(response.status === 404) {
					li.textContent = `No repositories found for user ${username}`;
					reposList.appendChild(li);
				} else {
					li.textContent = `${response.status} = ${response.statusText}`;
				}
			}
			return response.json();
		})
		.then(repos => {
			repos.forEach(repo => {
				let a = document.createElement("a");
				a.href = repo.html_url;
				a.textContent = repo.full_name;
				li.appendChild(a);
				reposList.appendChild(li);
			});
		})
}