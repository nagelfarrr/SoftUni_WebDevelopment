function lockedProfile() {
    const showMoreBtns = Array.from(document.getElementsByTagName("button"));

    showMoreBtns.forEach(btn => {
        btn.addEventListener("click", showMore);
    });


    function showMore(e) {
        const profile = this.parentNode;
        const hiddenContent = profile.querySelector("div");
        const radioBtns = profile.querySelectorAll(`input[type="radio"]`);

        let lockedRadioBtn;
        let unlockedRadioBtn;
        
        for (let i = 0; i < radioBtns.length; i++) {
            if (radioBtns[i].value === "lock") {
                lockedRadioBtn = radioBtns[i];
            } else if (radioBtns[i].value === "unlock") {
                unlockedRadioBtn = radioBtns[i];
            }

        }

        if (unlockedRadioBtn.checked) {

            if (this.textContent === "Show more") {
                hiddenContent.style.display = "block";
                this.textContent = "Hide it";
            } else {
                hiddenContent.style.display = "none";
                this.textContent = "Show more";
            }
        }
    }

}