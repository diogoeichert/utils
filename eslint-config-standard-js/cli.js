#!/usr/bin/env node

"use strict";

const app = require("./package.json");
const child_process = require("child_process");
const cli = require("cli-boot");

const SILENT = " &> /dev/null";

cli(app, {
	install: () => {
		process.stdout.write("Installing... ");
		child_process.execSync("cp ${__dirname}/.eslintrc.js ." + SILENT);
		console.log("done");
	}
});
