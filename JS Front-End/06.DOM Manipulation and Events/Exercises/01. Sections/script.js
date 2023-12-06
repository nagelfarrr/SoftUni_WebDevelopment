function create(words) {
   const mainDiv = document.getElementById("content");

   for (let i = 0; i < words.length; i++) {
      let p = document.createElement("p");
      p.textContent = words[i];
      p.style.display = "none";

      let innerDiv = document.createElement("div");
      innerDiv.classList = "inner";
      innerDiv.appendChild(p);
      mainDiv.appendChild(innerDiv);
   }

   const divs = Array.from(document.querySelectorAll("div.inner"));
   console.log(divs);

   divs.forEach(div => {
      console.log(div);
      div.addEventListener("click", reveal);
   });

   function reveal(e) {
      this.firstChild.style.display = "inline-block";
   }
}