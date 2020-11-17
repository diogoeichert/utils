"use strict";

const assert = require("assert");
const deltree = require("deltree");
const makeway = require("./index.js");
const path = require("path");

const PATH = "temporary";

const tests = {
	basic: function () {
		makeway(path.join(PATH, PATH));
		assert.equal(deltree(PATH), true);
	}
};

for (let name in tests) {
	try {
		tests[name]();
	} catch (e) {
		console.log(e);
	}
}
