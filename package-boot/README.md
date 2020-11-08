[![build status](https://travis-ci.org/diogoeichert/package-boot.svg)](https://travis-ci.org/diogoeichert/package-boot)
[![downloads](https://img.shields.io/npm/dt/package-boot.svg)](https://www.npmjs.com/package/package-boot)
[![license](https://img.shields.io/github/license/diogoeichert/package-boot.svg)](LICENSE)
[![npm version](https://img.shields.io/npm/v/package-boot.svg)](https://www.npmjs.com/package/package-boot)

# package-boot
npm package capable of creating npm packages

## usage
```
const boot = require("package-boot");

boot(path, dependencies, skel, properties);
```

**path** - mandatory string, specifies the path (with name) of the new package  
dependencies - optional list of objects containing the `name` and `version` and
optionally the `dev` status of the package to be added as a dependency for the
new package  
skel - optional string, specifies the path for skeleton files  
properties - optional object with properties to be merged to the final
package.json file  

## sample
```
const app = require("./package.json");
const boot = require("package-boot");

boot("name", [
  app,
  "deltree",
  {name: "package-boot", dev: true}
],
`${__dirname}/skel`,
{
  keywords: [
    "alpha",
    "beta",
    "omega"
  ],
  scripts: {
    test: "node ./test.js"
  }
});
```
