"use strict";

var fs = require("fs");

function main() {
	fs.readFile(process.argv[2], function(err, buf) {
		compile(parse(lex(buf.toString())));
	});
}

function lex(input) {
	function add(type, value) {
		tokens.push({
			type: type,
			value: value
		});
	}

	function testBreak(character) {
		return /[\r\n]/.test(character);
	}

	function testIdentifier(character) {
		return /[a-z]/i.test(character);
	}

	function testNumber(character) {
		return /[0-9]/.test(character);
	}

	function testOperator(character) {
		return "()[]{}<>'\"!@#$%&*-+=^.:?/".indexOf(character) > -1;
	}

	function testSpace(character) {
		return /\s/.test(character);
	}

	var tokens = [];

	for (var i = 0; i < input.length; ++i) {
		if (testBreak(input[i])) {
			var token = input[i];

			while (testBreak(input[i + 1])) {
				token += input[++i];
			}

			add("break", token);
		}
		else if (testSpace(input[i])) {
			continue;
		}
		else if (testIdentifier(input[i])) {
			var token = input[i];

			while (testIdentifier(input[i + 1])) {
				token += input[++i];
			}

			add("identifier", token);
		}
		else if (testNumber(input[i])) {
			var token = input[i];

			while (testNumber(input[i + 1])) {
				token += input[++i];
			}

			add("number", token);
		}
		else if (testOperator(input[i])) {
			var token = input[i];

			while (testOperator(input[i + 1])) {
				token += input[++i];
			}

			add("operator", token);
		}
	}

	return tokens;
}

function parse(lex) {
	function add(expression) {
		tree.push(expression);
	}

	function makeSymbol(token) {
		if (token.type == "break") {
			return "break";
		}

		if (token.type == "identifier") {
			if (/^[A-Z]/.test(token.value)) {
				return "titleCase";
			}

			return "lowerCase";
		}

		if (token.type == "operator") {
			if (token.value == "//") {
				return "comment";
			}

			if (token.value == "/*") {
				return "beginComment";
			}

			if (token.value == "*/") {
				return "endComment";
			}

			return token.value;
		}
	}

	var comment = 0;
	var tree = {
		classes: [],
		methods: []
	};

	for (var i = 0; i < lex.length; ++i) {
		var symbol = makeSymbol(lex[i]);

		// ignore comments
		if (symbol == "break") {
			if (comment == 1) {
				comment = 0;
			}

			continue;
		}

		if (symbol == "endComment") {
			comment = 0;
			continue;
		}

		if (comment > 0) {
			continue;
		}

		if (symbol == "beginComment") {
			comment = 2;
			continue;
		}

		if (symbol == "comment") {
			comment = 1;
			continue;
		}

		// expression
		if (symbol == "lowerCase") {
			console.log(lex[i].value);
			console.log(lex[i + 1].value);
			break;
		}

		// just add to the tree for now
		add(lex[i]);
	}

	return tree;
}

function compile(tree) {
	console.log(tree);
}

main();
