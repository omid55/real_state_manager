using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeginProject
{
    public class Session
    {
        public String userType;
        public bool allowInsert;
        public bool allowSearch;
        public bool allowDelete;
        public bool allowEdit;

        public Session()
        {
        }

        public Session(String s)
        {
            userType = s;
            allowEdit = allowSearch = allowInsert = allowDelete = true;
        }

        public Session(String s, bool b1, bool b2, bool b3, bool b4)
        {
            userType = s;
            allowInsert = b1;
            allowSearch = b2;
            allowDelete = b3;
            allowEdit = b4;
        }
    }
}
