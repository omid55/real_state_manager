using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace NeginProject
{
    class MyPriceTextBox
    {
        public static void doMask(bool textBoxChanged,TextBox textb)
        {
            if (textBoxChanged)
            {
                if (textb.Text.Trim().Length == 0) return;
                String s = getStringFromMasked(textb.Text);
                String res = doMaskOnce(s);
                if (res != "" && textb.Text!=res)
                {
                    textb.Text = res;
                    textb.Select(textb.Text.Length, 0);
                }
                textBoxChanged = false;
            }
        }

        public static String doMaskOnce(String s)
        {
            String res = "";
            int len = s.Length;
            int index = len - 1;
            int r = len / 3;
            while (r != 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    res = s[index--] + res;
                }
                r--;
                res = "," + res;
            }
            r = len % 3;
            if (r == 0)
            {
                res = res.Remove(0, 1);
            }
            for (int i = 0; i < r; i++)
            {
                res = s[index--] + res;
            }
            return res;
        }

        public static String getStringFromMasked(String masked)
        {
            int ind=masked.IndexOf(',');
            while (ind != -1)
            {
                masked = masked.Remove(ind, 1);
                ind = masked.IndexOf(',');
            }
            return masked;
        }
    }
}
