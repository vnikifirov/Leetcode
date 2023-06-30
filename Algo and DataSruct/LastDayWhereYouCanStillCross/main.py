import numpy as np

class Solution(object):
    def latestDayToCross(self, row, col, days):
        """
        :type row: int
        :type col: int
        :type cells: List[List[int]]
        :rtype: int
        """

        days_counter = 1
        while (days_counter <= len(days)):
            col_counter = 0
            row_counter = 0

            cells = days["day_{0}".format(days_counter)]

            # X axis steps
            while(row_counter < row):
            
                # straight path or is land No right No left steps
                if ((col_counter + 1) >= col and (col_counter - 1) < 0 and cells[row_counter, col_counter] == 1):
                    return days_counter

                # if right path or is land
                if ((col_counter + 1) < col and cells[row_counter, col_counter] != 1):
                    # Y axis right steps
                    while(col_counter < col):
                        if (col_counter > col or cells[row_counter, col_counter] == 1):
                            break
                        col_counter = col_counter + 1

                # if left path or is land
                if ((col_counter - 1) > 0 and [row_counter, col_counter] != 1):
                    # Y axis right steps
                    while(col_counter > col):
                        if (col_counter < 0 or cells[row_counter, col_counter] == 1):
                            break
                        col_counter = col_counter - 1
                    
                row_counter = row_counter + 1

            days_counter += 1

        return days_counter
            


days = {
    "day_1": [[0,0,0],[0,0,0],[0,0,0]],
    "day_2": [[0,0,0],[0,1,0],[0,0,0]],
    "day_3": [[0,0,0],[1,0,0],[1,0,0]],
    "day_4": [[0,1,0],[1,0,0],[0,0,1]],
    "day_5": [[0,0,0],[1,1,0],[0,0,1]]    
}
row = 3
col = 3


solver = Solution()
result = solver.latestDayToCross(row, col, days)
print("The last day where it is possible to cross from top to bottom is on day {0}".format(result))