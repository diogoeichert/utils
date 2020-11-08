"use strict";

const [command, ...args] = process.argv;

function usage(lines) {
	console.log("Usage:");
	lines.map(line => console.log(line));
	console.log();
}

module.exports = function (app, commands) {
	function prefix(command) {
		return `  ${app.name} ${command}`;
	}

	if (command && commands[command]) {
		const parameters = commands[command](...args);

		if (parameters) {
			usage(parameters.map(parameter => `${prefix(command)} ${parameter}`));
		}
	} else if ("version" == command) {
		console.log(`${app.name} version ${app.version}`);
	} else {
		usage(Object.keys(commands).map(prefix));
	}
};
