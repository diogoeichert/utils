"use strict";

function assign(target, source) {
	for (let i in source) {
		if (Array.isArray(target[i])) {
			concat(target[i], source[i]);
		} else if (typeof(target[i]) == "object") {
			assign(target[i], source[i]);
		} else {
			target[i] = source[i];
		}
	}
}

function concat(target, source) {
	for (let i = 0; i < source.length; ++i) {
		if (target.indexOf(source[i]) < 0) {
			target.push(source[i]);
		}
	}
}

module.exports = {
	assign,
	concat
};
