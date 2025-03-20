document.querySelectorAll("button.solution").forEach(button => {
    button.addEventListener("click", () => {
        if(button.classList.contains("opened")){
            console.log("close");
            button.querySelector("span").textContent = "arrow_right";
            button.classList.remove("opened");
            button.nextElementSibling.classList.remove("opened"); // div with code snippet
        }
        else{
            console.log("open");
            button.querySelector("span").textContent = "arrow_drop_down";
            button.classList.add("opened");
            button.nextElementSibling.classList.add("opened"); // div with code snippet
        }
    });
});