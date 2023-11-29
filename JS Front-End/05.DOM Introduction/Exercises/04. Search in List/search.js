function search() {
   let townsArr = Array.from(document.querySelectorAll("ul > li"));

   let searchText = document.getElementById("searchText").value;

   let matches = 0;

   for (let i = 0; i < townsArr.length; i++) {
      if(townsArr[i].textContent.includes(searchText)){
         townsArr[i].style.textDecoration = "underline";
         townsArr[i].style.fontWeight = "bold";
         matches++;
      }
      
   }

   const resultMatchesDiv = document.getElementById("result");
   resultMatchesDiv.textContent = `${matches} matches found`;
}
