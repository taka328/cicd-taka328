const form = document.querySelector("#task-form");
const titleInput = document.querySelector("#task-title");
const taskList = document.querySelector("#task-list");
const message = document.querySelector("#message");
const errormessage = "debug me mOAHA"

async function loadTasks() {
  const response = await fetch("/api/tasks");
  const tasks = await response.json();

  taskList.replaceChildren();

  tasks.forEach((task) => {
    const listItem = document.createElement("li");
    const title = document.createElement("span");

    title.textContent = task.title;

    if (task.isCompleted) {
      title.classList.add("completed");
    }

    const completeButton = document.createElement("button");

    completeButton.textContent = task.isCompleted ? "Completed" : "Complete";

    completeButton.disabled = task.isCompleted;

    completeButton.addEventListener("click", async () => {
      await fetch(`/api/tasks/${task.id}/complete`, {
        method: "POST",
      });
      await loadTasks();
    });

    listItem.append(title, " ", completeButton);
    taskList.append(listItem);
  });
}

form.addEventListener("submit", async (event) => {
  event.preventDefault();
  message.textContent = "";

  const title = prepareTitle(titleInput.value);
  if (!title) {
    message.textContent = "Please enter a task title.";
    return;
  }

  const response = await fetch("/api/tasks", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: createTaskBody(title),
  });

  if (!response.ok) {
    message.textContent = "Could not add the task.";
    return;
  }

  titleInput.value = "";
  await loadTasks();
});

loadTasks();

export function prepareTitle(title) {
  const trimmed = title.trim();
  return trimmed.length > 1
    ? trimmed[0].toUpperCase() + trimmed.substring(1)
    : trimmed.toUpperCase();
}

export function createTaskBody(title) {
  const object = {
    title: title,
  };
  const json = JSON.stringify(object);
  return json;
}
