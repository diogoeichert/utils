"use strict";

const symbols = {
	I: 1,
	V: 5,
	X: 10,
	L: 50,
	C: 100,
	D: 500,
	M: 1000
};

function parse(digits) {
	let result = 0;
	let lastSymbol;
	let lastValue;

	for (let i = 0; i < digits.length; ++i) {
		const symbol = digits[i];
		const value = symbols[symbol];
		lastValue = symbols[lastSymbol];
		result += value;

		if (lastSymbol && lastValue < value) {
			result -= (2 * lastValue);
		}

		lastSymbol = symbol;
	}

	return result;
}

module.exports = {
	parse
}
