public class Robot
{

    public int CherryPickup(int[][] grid)
    {
        var len = grid.Length;

        if (grid[0][0] == -1 || grid[len - 1][len - 1] == -1)
            return 0;

        var dp = new int[len, len, len, len];

        dp[0, 0, 0, 0] = grid[0][0];

        for (var i = 1; i < len * 2; i++)
        {
            var min = i - len + 1;
            if (min < 0) min = 0;

            for (int ax = min, ay = i - min; ay >= min; ax++, ay--)
            {
                for (int bx = min, by = i - min; by >= min; bx++, by--)
                {
                    if (grid[ax][ay] == -1 || grid[bx][by] == -1)
                    {
                        dp[ax, ay, bx, by] = -1;
                        continue;
                    }

                    var prev = new List<(int, int, int, int)>
                        {
                        (ax - 1, ay, bx - 1, by),
                        (ax - 1, ay, bx, by - 1),
                        (ax, ay - 1, bx - 1, by),
                        (ax, ay - 1, bx, by - 1),
                        };

                    var max = -1;

                    foreach (var p in prev)
                    {
                        if (p.Item1 >= 0 && p.Item2 >= 0 && p.Item3 >= 0 && p.Item4 >= 0)
                        {
                            if (dp[p.Item1, p.Item2, p.Item3, p.Item4] == -1)
                                continue;

                            max = (ax == bx && ay == by)
                              ? Math.Max(max, dp[p.Item1, p.Item2, p.Item3, p.Item4] + grid[ax][ay])
                              : Math.Max(max, dp[p.Item1, p.Item2, p.Item3, p.Item4] + grid[ax][ay] + grid[bx][by]);
                        }
                    }

                    dp[ax, ay, bx, by] = max;
                }
            }
        }

        return Math.Max(dp[len - 1, len - 1, len - 1, len - 1], 0);
    }
}