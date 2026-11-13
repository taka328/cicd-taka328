const js = require("@eslint/js");

module.exports = [
  js.configs.recommended,
  {
    languageOptions: {
      globals: {
        document: "readonly",
        fetch: "readonly",
        describe: "readonly",
        test: "readonly",
        expect: "readonly",
        require: "readonly",
        module: "readonly",
        global: "readonly",
      },
    },
  },
];
