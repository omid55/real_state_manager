using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeginProject
{
    class ConfigParams
    {
        public int fontSize
        {
            set;
            get;
        }
        public bool isMaximized
        {
            get;
            set;
        }
        public bool simpleIsMaximized
        {
            get;
            set;
        }

        public ConfigParams()
        {
            fontSize=20;
            isMaximized = true;
            simpleIsMaximized = false;
        }
    }
}
