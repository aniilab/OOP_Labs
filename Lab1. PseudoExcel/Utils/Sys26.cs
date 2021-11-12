namespace PseudoExcel.Utils
{
    public struct Index
    {
        public int row_;
        public int col_;
    }

    class Sys26
    {

        public static string To26Sys(int i)
        {
            int k = 0;
            int[] Arr = new int[100];
            while (i > 25)
            {
                Arr[k] = i / 26 - 1;
                k++;
                i = i % 26;
            }
            Arr[k] = i;
            string res = string.Empty;
            for (int j = 0; j <= k; j++)
            {
                res += ((char)('A' + Arr[j])).ToString();
            }
            return res;
        }

        public static Index From26Sys(string s)
        {
            Index res = new Index();
            res.col_ = 0;
            res.row_ = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 64 && s[i] < 91)
                {
                    res.col_ *= 26;
                    res.col_ += s[i] - 64;
                }
                else if (s[i] > 47 && s[i] < 58)
                {
                    res.row_ *= 10;
                    res.row_ += s[i] - 48;
                }
            }
            res.col_--;
            return res;
        }


    }
}
