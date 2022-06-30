const container = document.getElementById("char-container")

console.log("Hello my peeps!")

fetch("https://rickandmortyapi.com/api/character")
    // "=>" is a lambda function
    .then((res) => res.json())
    .then(data => {
        data.results.forEach(character => {
            const charDiv = document.createElement("div")
            const charName = document.createElement("h2")
            const charStatus = document.createElement("p")
            const charImg = document.createElement("img")
            charDiv.id = "char-container"
            charName.id = "char-name"
            charStatus.className = "char-status"

            charName.textContent = character.name
            charStatus.textContent = character.status === "Dead" ? "Send your flowers they're gone!" : "They might be alive but who really knows?"
            charImg.src = character.image

            charDiv.append(charImg, charName, charStatus)

            container.appendChild(charDiv)
        });
    })