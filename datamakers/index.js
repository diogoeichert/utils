"use strict";

function makeEnum(array) {
	return makeHashSet(array, true);
}

function makeHashSet(array, indexed) {
	const RESULT = {};

	for (let i = 0; i < array.length; ++i) {
		const VALUE = array[i];
		RESULT[VALUE] = indexed ? i : VALUE;
	}

	return RESULT;
}

module.exports = {
	makeEnum,
	makeHashSet
};
