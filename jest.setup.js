document.body.innerHTML = `
  <form id="task-form">
    <input id="task-title">
    <ul id="task-list"></ul>
    <p id="message"></p>
  </form>
`;

global.fetch = () =>
  Promise.resolve({ ok: true, json: () => Promise.resolve([]) });