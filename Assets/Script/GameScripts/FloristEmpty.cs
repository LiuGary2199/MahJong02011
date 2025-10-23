using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mkey
{
    public static class FloristEmpty
    {
        #region sorting orders
        public static int Real        {
            get
            {
                return 2;
            }
        }
        public static int AngularTrim        {
            get
            {
                return Real + 5;
            }
        }

        public static int AngularTrimDyFront        {
            get
            {
                return Real + 1000;
            }
        }
        #endregion sorting orders
    }
}