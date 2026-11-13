const { prepareTitle, createTaskBody } = require("./wwwroot/app.js");

describe("prepareTitle", () => {
  test("gör första bokstaven stor", () => {
    expect(prepareTitle("köpa mjölk")).toBe("Köpa mjölk");
  });

  test("tar bort mellanslag i början och slutet", () => {
    expect(prepareTitle(" städa ")).toBe("Städa");
  });

  test("behåller en stor första bokstav ", () => {
    expect(prepareTitle("Handla mat")).toBe("Handla mat");
  });

  test("fungerar med en enda bokstav", () => {
    expect(prepareTitle("a")).toBe("A");
  });

  test("returnerar en tom sträng för tom input", () => {
    expect(prepareTitle("")).toBe("");
  });
});

describe("createTaskBody", () => {
  test("skapar JSON med rätt titel", () => {
    expect(createTaskBody("Köpa mjölk")).toBe('{"title":"Köpa mjölk"}');
  });

  test("fungerar med en annan titel", () => {
    expect(createTaskBody("Städa garaget")).toBe('{"title":"Städa garaget"}');
  });
});
