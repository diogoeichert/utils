[![build status](https://travis-ci.org/diogoeichert/succinct-router.svg)](https://travis-ci.org/diogoeichert/succinct-router)
[![downloads](https://img.shields.io/npm/dt/succinct-router.svg)](https://www.npmjs.com/package/succinct-router)
[![license](https://img.shields.io/github/license/diogoeichert/succinct-router.svg)](LICENSE)
[![npm version](https://img.shields.io/npm/v/succinct-router.svg)](https://www.npmjs.com/package/succinct-router)

# succinct-router
create routes without redundant declarations

## usage
```
const express = require("express");
const route = require("succinct-router");

const app = express();

route({
	getRoot: (req, res) => {
		res.render("index.html");
	},
	getHello: (req, res) => {
		res.send("Hello, world!");
	}
});
```

The routes will be accessible via GET methods to / and /hello respectively.
