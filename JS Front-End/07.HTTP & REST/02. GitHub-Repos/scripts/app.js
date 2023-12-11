function loadRepos() {
   const repostUrl = "https://api.github.com/users/testnakov/repos";

   fetch(repostUrl)
      .then(response => response.text())
      .then(responseBody => {
         document.getElementById("res").textContent = responseBody;
      });
}