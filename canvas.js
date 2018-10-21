var surv = document.createElement("img");
surv.src = "surveyExample.jpg";
document.body.appendChild(surv);

function printMousePos(event) {
  document.body.textContent =
    "clientX: " + event.clientX +
    " - clientY: " + event.clientY;
}

document.addEventListener("click", printMousePos);