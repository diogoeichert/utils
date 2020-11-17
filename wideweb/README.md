[![build status](https://travis-ci.org/diogoeichert/wideweb.svg)](https://travis-ci.org/diogoeichert/wideweb)
[![license](https://img.shields.io/github/license/diogoeichert/wideweb.svg)](LICENSE)
[![npm version](https://img.shields.io/npm/v/wideweb.svg)](https://www.npmjs.com/package/wideweb)
[![downloads](https://img.shields.io/npm/dt/wideweb.svg)](https://www.npmjs.com/package/wideweb)

# wideweb
microframework for the web

## about
this tool provides a CLI that aims at scaffolding the fundamental structure of a web application and a fast web engine by putting together best in class libraries neatly integrated with minimal glue code and sensible defaults, making it for a lean but resourceful project foundation

## usage
```
npm install wideweb -g
wideweb new app-name
cd app-name
npm start
```

## adding routes
edit the sample server.js on our new app and add new functions, they will be routed automatically, e.g.
```
wideweb.route({
	getRoot: (req, res) => {
		res.render("index.html");
	},
	getHello: (req, res) => {
		res.send("Hello, world!");
	}
});
```
thanks to a simple convention, the new function will be accessible under http://localhost:3000/hello via GET HTTP method, without the need to manually create complicated or redundant routing, as the function name is the route and vice-versa, while the `req` and `res` parameters are pure [express](https://expressjs.com/) objects and we can also render views as demonstrated above
