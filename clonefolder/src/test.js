"use strict";

const assert = require("assert");
const deltree = require("deltree");
const clonefolder = require("./index.js");

const PATH = "temporary";

const tests = {
	basic: function () {
		try {
			clonefolder("node_modules", PATH);
		} finally {
			assert.equal(deltree(PATH), true);
		}
	}
};

for (let name in tests) {
	try {
		tests[name]();
	} catch (e) {
		console.log(e);
	}
}
