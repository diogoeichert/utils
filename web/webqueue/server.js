"use strict";

const wideweb = require("wideweb");

const queue = [];
const stack = [];

wideweb.route({
	getRoot: (req, res) => {
		res.render("index.html");
	},
	getQueue: (req, res) => {
		const entry = queue.shift();

		if (entry) {
			res.status(wideweb.HTTP_STATUS.OK).send(entry);
		} else {
			res.status(wideweb.HTTP_STATUS.NO_CONTENT).send();
		}
	},
	getStack: (req, res) => {
		const entry = stack.pop();

		if (entry) {
			res.status(wideweb.HTTP_STATUS.OK).send(entry);
		} else {
			res.status(wideweb.HTTP_STATUS.NO_CONTENT).send();
		}
	},
	postQueue: (req, res) => {
		try {
			queue.push(req.body);
			res.status(wideweb.HTTP_STATUS.CREATED).send();
		} catch (e) {
			res.status(wideweb.HTTP_STATUS.BAD_REQUEST).send(e.message);
		}
	},
	postStack: (req, res) => {
		try {
			stack.push(req.body);
			res.status(wideweb.HTTP_STATUS.CREATED).send();
		} catch (e) {
			res.status(wideweb.HTTP_STATUS.BAD_REQUEST).send(e.message);
		}
	}
});
