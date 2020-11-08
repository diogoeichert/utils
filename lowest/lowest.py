#!/usr/bin/env python

import math

number = '1.1'
fail = 0
result = 0

while fail < 10:
    value = float(number)

    if value == math.pow(value, math.sqrt(value)):
        if number[-10:] == '0000000000':
            result = number[:-10]
            break
        else:
            fail += 1
            number = number + '9'
    else:
        result = number
        fail = 0
        number = number[:-1] + str(int(number[-1:]) - 1)

print(result)
