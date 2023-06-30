class Solution(object):
    def romanToInt(self, s):
        """
        :type s: str
        :rtype: int
        """

        count = 0
        number = 0
        
        numbers = {
            "M": "1000",
            "D": "500",
            "C": "100",
            "L": "50",
            "X": "10",
            "V": "5",
            "I": "1"
        }
            
        while (count < len(s)):
            currentKey = s[count]
            currentValue = numbers[currentKey]
            
            if (count + 1 < len(s)):
                nextKey = s[count + 1]
                nextValue = numbers[nextKey]
            else:
                nextKey = currentKey
                nextValue = numbers[nextKey]

            if (int(nextValue) <= int(currentValue)):
                number += int(currentValue)
                count += 1
            else:
                number += int(nextValue) - int(currentValue) 
                count += 2
        
        return number
