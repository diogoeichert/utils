[![build status](https://travis-ci.org/diogoeichert/eslint-config-standard-js.svg)](https://travis-ci.org/diogoeichert/eslint-config-standard-js)
[![downloads](https://img.shields.io/npm/dt/eslint-config-standard-js.svg)](https://www.npmjs.com/package/eslint-config-standard-js)
[![license](https://img.shields.io/github/license/diogoeichert/eslint-config-standard-js.svg)](LICENSE)
[![npm version](https://img.shields.io/npm/v/eslint-config-standard-js.svg)](https://www.npmjs.com/package/eslint-config-standard-js)

# eslint-config-standard-js
A set of [ESlint](https://eslint.org) rules for optimal JavaScript programming.

These rules have been carefully crafted to be consistent with the best practices in JavaScript, minimal and unbiased. No anti patterns.

Each rule has its rationale, found under the rules section below.

## Install
```
npm install --save-dev eslint eslint-config-standard-js
```

## Usage
Add or edit an `.eslintrc.js` file in your repository to make it look like:
```
module.exports = {
	"extends": "standard-js"
};
```

### Bonus
Edit your `package.json` file and change the test script to precede it with eslint:
```
"scripts": {
	"test": "eslint . && node ./test.js"
},
```

## Rules

### Enforced Braces
Braces are an important part of the syntax, so they should be enforced and consistent for better readability and avoiding unnecessary mistakes, even when seemingly unnecessary, because otherwise the code simply becomes more difficult to read.

#### Background
[Apple's SSL/TLS bug](https://www.imperialviolet.org/2014/02/22/applebug.html)

### Indentation
Like braces, consistent indentation is an important part of the practices that improve readability, so it is also enforced.

### Keyword Spacing
The correct use of spaces in keywords is important, specifically to obtain consistent difference between function calls and control statements.

### Line breaks
A consistent line-break strategy is important to avoid garbage and keep consistency in shared repositories, to avoid issues with version control systems.

### Quotes
Using apostrophes instead of quotes prevents the usage of the apostrophe (which is very important to the English language) in the contained text itself, so quotes should be used instead, also consistently.

### Semicolons
Though the interpreter will tolerate missing semicolons, they are an important part of the language that clearly state the programmer's intention to end a statement and avoid problems that can be tough to spot after minification or other parsing operations.

#### Background
[Semicolons in JavaScript: To Use or Not to Use?](https://dev.to/adriennemiller/semicolons-in-javascript-to-use-or-not-to-use-2nli)

### Tab for Tabulation
Replacing the tab character with multiple spaces is a bad practice, as they can be inconsistent, generating garbage and will most certainly cause issues between different text editing tools, which can be extra-harmful for people with special conditions and thus should be discouraged.

#### Background
[Default to Tabs Instead of Spaces for an "Accessible First" Environment](https://alexandersandberg.com/tabs-for-accessibility/)
