function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const rows = Array.from(document.querySelectorAll("tbody tr"));
      let searchValue = document.getElementById("searchField").value;
      clearTable(rows);    
      rows.forEach(row => {
         
         if (row.textContent.includes(searchValue)) {
            row.classList = "select";
         }
                  
      });
   }

   function clearTable(rows) {
      for (let i = 0; i < rows.length; i++) {
         rows[i].classList.remove("select");
         
      }
   }
}