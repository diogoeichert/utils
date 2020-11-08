"use strict";

function route(app, endpoints) {
	for (const name in endpoints) {
		const [method, ...words] = name.split(/(?=[A-Z])/)
			.map(word => word.toLowerCase());

		const path = words.join("/");
		app[method](path == "root" ? "/" : `/${path}`, endpoints[name]);
	}
}

module.exports = route;
