# datamakers
factories for common data structures

## usage
```
const {makeEnum, makeHashSet} = require('datamakers');

const RGB = makeEnum([
  'Red',
  'Green',
  'Blue'
]);

const CMYK = makeHashSet([
  'Cyan',
  'Magenta',
  'Yellow',
  'Black'
]);
```
