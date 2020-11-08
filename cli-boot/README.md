[![build status](https://travis-ci.org/diogoeichert/cli-boot.svg)](https://travis-ci.org/diogoeichert/cli-boot)
[![downloads](https://img.shields.io/npm/dt/cli-boot.svg)](https://www.npmjs.com/package/cli-boot)
[![license](https://img.shields.io/github/license/diogoeichert/cli-boot.svg)](LICENSE)
[![npm version](https://img.shields.io/npm/v/cli-boot.svg)](https://www.npmjs.com/package/cli-boot)

# cli-boot
simple wrapper for command line interfaces

## usage
```
const app = require("./package.json");
const cli = require("cli-boot");

cli(app, {
  command: function() {
    if (arguments.length < 1) {
      return ["option1", "option2"];
    }

    console.log(`Got ${arguments}`);
  }
});
```
