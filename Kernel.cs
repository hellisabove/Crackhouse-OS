using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Hypatia.Commands;
using Hypatia.Graphics;
using Cosmos.System.FileSystem;

namespace Hypatia
{
    public class Kernel : Sys.Kernel
    {
        private CommandManager commandManager;
        private CosmosVFS vfs;

        public static GUI gui;
        protected override void BeforeRun()
        {
            this.vfs = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.vfs);
            Console.Clear();
            this.commandManager = new CommandManager();
            Console.WriteLine("Crackhead OS has succesfully booted! Name inspired by the Multi-Fandom CrackHouse on discord!");
        }

        protected override void Run()
        {
            if(Kernel.gui != null)
            {
                Kernel.gui.HandleGUIInputs();

                return;
            }

            String shell = "[root@crackhouse-pc]>> ";
            String response;
            String input = Console.ReadLine();
            response = this.commandManager.processInput(input);
            Console.WriteLine(response);
        }
    }
}
