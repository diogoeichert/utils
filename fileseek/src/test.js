"use static";

const assert = require("assert");
const fileseek = require("./index.js");

const tests = {
	basic: function () {
		assert.equal(JSON.stringify(fileseek("./src", /\w\.js$/)), JSON.stringify(["src/index.js", "src/test.js"]));
	},
	noRecursion: function () {
		assert.equal(JSON.stringify(fileseek("./src", /\w\.js$/, false)), JSON.stringify(["src/index.js", "src/test.js"]));
	}
};

for (let name in tests) {
	try {
		tests[name]();
	} catch (e) {
		console.log(e);
	}
}
