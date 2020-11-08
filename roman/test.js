"use strict";

const assert = require("assert");
const roman = require("./index.js");

assert.equal(roman.parse("I"), 1);
assert.equal(roman.parse("II"), 2);
assert.equal(roman.parse("III"), 3);
assert.equal(roman.parse("IV"), 4);
assert.equal(roman.parse("V"), 5);
assert.equal(roman.parse("VI"), 6);
assert.equal(roman.parse("VII"), 7);
assert.equal(roman.parse("VIII"), 8);
assert.equal(roman.parse("IX"), 9);
assert.equal(roman.parse("X"), 10);
assert.equal(roman.parse("XI"), 11);
assert.equal(roman.parse("XII"), 12);
assert.equal(roman.parse("XIII"), 13);
assert.equal(roman.parse("XIV"), 14);
assert.equal(roman.parse("XV"), 15);
assert.equal(roman.parse("XVI"), 16);
assert.equal(roman.parse("XVII"), 17);
assert.equal(roman.parse("XVIII"), 18);
assert.equal(roman.parse("XIX"), 19);
assert.equal(roman.parse("XX"), 20);
assert.equal(roman.parse("MMMDCCCLXXXVIII"), 3888);
assert.equal(roman.parse("MMMCMXCIX"), 3999);
