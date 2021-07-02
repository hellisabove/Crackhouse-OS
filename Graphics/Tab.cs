using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Cosmos.System.Graphics;
using Sys = Cosmos.System;
using Cosmos.System;

namespace Hypatia.Graphics
{
    public class Tab{
        private static List<Tab> tabs = new List<Tab>();
        private static Pen outlinePen = new Pen(Color.White),xBtnPen =  new Pen(Color.Red);

        internal const Int32 defaultWindowSize = 400, windowTopPartSize = 25, xBtnSize = 25;

        public Int32 X {

            get;

            private set;
        }

        public Int32 Y {

            get;

            private set;
        }

        private protected Boolean beingDragged;

    }
}
