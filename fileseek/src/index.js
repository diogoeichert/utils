"use static";

const fs = require("fs");
const path = require("path");

function fileseek(directory, expression, recursive = true) {
	const result = [];
	directory = path.normalize(directory);

	fs.readdirSync(directory).forEach(file => {
		const current = path.join(directory, file);

		if (recursive && fs.lstatSync(current).isDirectory()) {
			result.push(...fileseek(current, expression));
		} else if (file.match(expression)) {
			result.push(current);
		}
	});

	return result;
}

module.exports = fileseek;
