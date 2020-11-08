#!/usr/bin/env node

"use strict";

const MOVE = {
	left: 0,
	right: 1,
	up: 2,
	down: 3
};

function check(matrix) {
	let height = matrix.length;
	let width = matrix[0].length;

	for (let i = 0; i < (height * width) - 1; ++i) {
		let y = Math.floor(i / width);
		let x = i % width;
		let current = matrix[y][x];

		if (matrix[y][x] != i + 1) {
			return false;
		}
	}

	return true;
}

function available(matrix) {
	let height = matrix.length;
	let width = matrix[0].length;
	let options = [];
	let zero = findZero(matrix);

	if (zero.x > 0) {
		options.push(MOVE.left);
	}

	if (zero.x < width - 1) {
		options.push(MOVE.right);
	}

	if (zero.y > 0) {
		options.push(MOVE.up);
	}

	if (zero.y < height - 1) {
		options.push(MOVE.down);
	}

	return options;
}

function findZero(matrix) {
	let height = matrix.length;
	let width = matrix[0].length;

	for (let y = 0; y < height; ++y) {
		for (let x = 0; x < width; ++x) {
			if (!matrix[y][x]) {
				return { x, y };
			}
		}
	}
}

function move(matrix, move) {
	let zero = findZero(matrix);

	switch(move) {
		case MOVE.left:
			matrix[zero.y][zero.x] = matrix[zero.y][zero.x - 1];
			matrix[zero.y][zero.x - 1] = 0;
		break;

		case MOVE.right:
			matrix[zero.y][zero.x] = matrix[zero.y][zero.x + 1];
			matrix[zero.y][zero.x + 1] = 0;
		break;

		case MOVE.down:
			matrix[zero.y][zero.x] = matrix[zero.y + 1][zero.x];
			matrix[zero.y + 1][zero.x] = 0;
		break;

		case MOVE.up:
			matrix[zero.y][zero.x] = matrix[zero.y - 1][zero.x];
			matrix[zero.y - 1][zero.x] = 0;
		break;
	}
}

function random(length) {
	let random = Math.random();
	let raw = random * length;
	return Math.floor(raw);
}

function randomMove(matrix) {
	let options = available(matrix);
	move(matrix, options[random(options.length)]);
}

function randomSort(matrix) {
	let startTime = Date.now();

	while (!check(matrix)) {
		// process.stdout.write(".");
		randomMove(matrix);
	}

	let endTime = Date.now();
	let elapsedTime = endTime - startTime;
	console.log();
	console.log(`Finished in ${elapsedTime} milliseconds.`);
	console.log(matrix);
}

const matrix = [
	[1, 2, 3],
	[4, 5, 6],
	[7, 8, 0]
];

if (!check(matrix)) {
	console.log("You have a broken matrix, please fix it.");
	return;
}

for (let i = 0; i < (matrix.length * matrix[0].length); ++i) {
	randomMove(matrix);
}

console.log(matrix);
randomSort(matrix);
