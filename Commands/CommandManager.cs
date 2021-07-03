using System;
using System.Collections.Generic;
using System.Text;

namespace Hypatia.Commands
{
    public class CommandManager
    {
        private List<Command> commands;

        public CommandManager()
        {
            this.commands = new List<Command>(3);
            this.commands.Add(new Help("help"));
            this.commands.Add(new Filer("filer"));
            this.commands.Add(new LaunchGUI("launch"));
            this.commands.Add(new Clear("clear"));
            this.commands.Add(new LaunchMIV("miv"));
        }

        public String processInput(String input)
        {
            String[] split = input.Split(' ');

            String label = split[0];

            List<String> args = new List<String>();

            int ctr = 0;
            foreach(String s in split)
            {
                if (ctr != 0)
                    args.Add(s);

                ctr++;
            }

            foreach(Command cmd in this.commands)
            {
                if (cmd.name == label)
                    return cmd.execute(args.ToArray());
            }

            return "Uknown command!";
        }
    }
}
