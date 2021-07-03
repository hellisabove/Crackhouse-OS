using System;
using System.Collections.Generic;
using System.Text;

namespace Hypatia.Commands
{
    public class LaunchMIV : Command {

        public LaunchMIV (String name) : base (name) { }

        public override string execute(string[] args)
        {
            MIV.StartMIV();
            return "";
        }

    }
}
