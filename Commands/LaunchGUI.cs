using System;
using System.Collections.Generic;
using System.Text;
using Hypatia.Graphics;

namespace Hypatia.Commands
{
    public class LaunchGUI : Command{
        
        public LaunchGUI (String name) : base (name) { }

        public override string execute(string[] args)
        {
            if (Kernel.gui != null)
                return "GUI has already been launched!";

            Kernel.gui = new GUI();

            return "GUI has been launched!";
        }

    }
}
