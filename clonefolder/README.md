[![build status](https://travis-ci.org/diogoeichert/clonefolder.svg)](https://travis-ci.org/diogoeichert/clonefolder)
[![downloads](https://img.shields.io/npm/dt/clonefolder.svg)](https://www.npmjs.com/package/clonefolder)
[![license](https://img.shields.io/github/license/diogoeichert/clonefolder.svg)](LICENSE)
[![npm version](https://img.shields.io/npm/v/clonefolder.svg)](https://www.npmjs.com/package/clonefolder)

# clonefolder
recursively copy a directory in filesystem

## Usage
```
npm install clonefolder --save
```
Then:
```
const clonefolder = require("clonefolder");
clonefolder("path/to/input/directory", "output/directory");
```
