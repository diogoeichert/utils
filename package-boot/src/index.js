"use strict";

const child_process = require("child_process");
const clonefolder = require("clonefolder");
const deltree = require("deltree");
const fs = require("fs");
const join = require("join-assign");

const DESCRIPTOR_FILE = "./package.json";
const SILENT_NPM = "npm_config_loglevel=silent ";

function boot(path, dependencies, skel, properties) {
	function checkPath(path) {
		process.stdout.write(`Creating ${path} app... `);
		fs.mkdirSync(path);
		console.log("done");
	}

	function initialize() {
		process.stdout.write("Initializing... ");
		child_process.execSync(SILENT_NPM + "npm init -y");
		console.log("done");
	}

	function installDependencies(dependencies) {
		if (!dependencies) {
			return;
		}

		console.log("Installing dependencies:");

		for (let dependency of [].concat(dependencies)) {
			let name = dependency.name || dependency;
			let save = "--save";

			if (dependency.dev) {
				save += "-dev";
			}

			if (dependency.version) {
				name += "@" + dependency.version;
			}

			process.stdout.write(`- ${name}... `);
			child_process.execSync(SILENT_NPM + `npm install ${name} ${save}`);
			console.log("done");
		}
	}

	function joinProperties(properties) {
		if (!properties) {
			return;
		}

		process.stdout.write("Modifying package.json... ");
		const descriptor = JSON.parse(fs.readFileSync(DESCRIPTOR_FILE));
		join.assign(descriptor, properties);

		fs.writeFileSync(DESCRIPTOR_FILE,
			`${JSON.stringify(descriptor, null, 2)}\n`);

		console.log("done");
	}

	function skeleton(path, skel) {
		if (!skel) {
			return;
		}

		process.stdout.write("Copying skeleton files... ");
		clonefolder(skel, ".");
		console.log("done");
	}

	try {
		checkPath(path);
	} catch (e) {
		console.log(e.message);
		return false;
	}

	process.chdir(path);

	try {
		initialize();
		installDependencies(dependencies);
		joinProperties(properties);
		skeleton(path, skel);
	} catch (e) {
		console.log(`Error creating app ${path}: ${e.message}`);
		process.chdir("..");
		deltree(`./${path}`);
		return false;
	}

	process.chdir("..");
	return true;
}

module.exports = boot;
