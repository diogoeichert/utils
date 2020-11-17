"use static";

const fs = require("fs");
const makeway = require("makeway");

function clonefolder(input, output) {
	if (fs.existsSync(input)) {
		makeway(output);

		fs.readdirSync(input).forEach(file => {
			const current = `${input}/${file}`;

			if (fs.lstatSync(current).isDirectory()) {
				clonefolder(current, `${output}/${file}`);
			} else {
				fs.copyFileSync(current, `${output}/${file}`);
			}
		});
	}
}

module.exports = clonefolder;
