﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hypatia.Commands
{
    public class Clear : Command {

        public Clear (String name) : base(name) { }

        public override string execute(string[] args)
        {
            Console.Clear();
            return "";
        }

    }
}
