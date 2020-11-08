# join-assign
deep assign to target from source, also performs distinct concat

## usage
```
const join = require("join-assign");

const source = {
  letters: [
    "c",
    "d"
  ]
};

const target = {
  letters: [
    "a",
    "b"
  ]
};

join.assign(target, source);

const a = [1, 2, 3, 4, 5];
const b = [4, 5, 6, 7, 8];

join.concat(a, b);
```
