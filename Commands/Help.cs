using System;
using System.Collections.Generic;
using System.Text;

namespace Hypatia.Commands {
	
	public class Help : Command {
		
		public Help (String name) : base (name) { }
		
		public override String execute (String[] args) {

			Console.WriteLine("help - runs this command");
			Console.WriteLine("filer - this command will allow you to make or delete files and directories");
			Console.WriteLine("launch - launches a simple gui with a cursor");
			Console.WriteLine("clear - clear the screen");
			Console.WriteLine("miv - a text editor that tries to imitate the ubiquitous text editor, vim");
			return "";
		}
	}
}