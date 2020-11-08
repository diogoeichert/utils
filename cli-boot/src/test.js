"use strict";

const assert = require("assert");
const cli = require("./index.js");

const log = console.log;
const logs = [];

console.log = function (string) {
	logs.push(string);
	log(string);
};

const app = {
	name: "test",
	version: "1.0.0"
};

const commands = {
	test: function () {
		console.log("test");
	}
};

const tests = {
	noargs: function () {
		cli(app, commands);
		assert.equal(logs.join("\n"), "Usage:\n  test test\n");
	}
};

for (let name in tests) {
	logs.length = 0;

	try {
		tests[name]();
	} catch (e) {
		log(e);
	}
}
