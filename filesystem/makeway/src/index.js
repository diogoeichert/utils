"use static";

const fs = require("fs");
const path = require("path");

function makeway(directory) {
	if (!fs.existsSync(directory)) {
		const elements = directory.split(path.sep);

		if (elements.length > 1) {
			elements.pop();
			makeway(elements.join(path.sep));
		}

		fs.mkdirSync(directory);
	}
}

module.exports = makeway;
