"use strict";

const assert = require("assert");
const boot = require("./index.js");
const deltree = require("deltree");
const fs = require("fs");

const PATH = "temporary";

const tests = {
	basic: function () {
		assert.equal(boot(PATH), true);
	},
	dependency: function () {
		assert.equal(boot(PATH, "package-boot"), true);
	},
	dependencyList: function () {
		assert.equal(boot(PATH, ["package-boot"]), true);
	},
	dependencyObject: function () {
		assert.equal(boot(PATH,
			{dev: true, name: "package-boot", version: "1.0.0"}), true);
	},
	properties: function () {
		assert.equal(boot(PATH, null, null, {author: "test"}), true);

		assert.equal(JSON.parse(fs.readFileSync(PATH + "/package.json")).author,
			"test");
	},
	skel: function () {
		assert.equal(boot(PATH, null, "./node_modules"), true);
	}
};

for (let name in tests) {
	try {
		tests[name]();
	} catch (e) {
		console.log(e);
	}

	deltree(PATH);
}
