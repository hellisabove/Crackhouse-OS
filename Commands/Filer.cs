using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;


namespace Hypatia.Commands{
    public class Filer : Command{
        public Filer(String name) : base(name) { }

        public override string execute(string[] args){
            String response = "";
            switch (args[0]){
                case "create":
                    try {
                        Sys.FileSystem.VFS.VFSManager.CreateFile("0:\\" + args[1]);
                        response = "Your file, " + args[1] + " has been created succesfully!";
                    }
                    catch(Exception ex){
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "rm":
                    try{
                        Sys.FileSystem.VFS.VFSManager.DeleteFile("0:\\" + args[1]);
                        response = args[1] + " has been removed succesfully!";
                    }
                    catch(Exception ex){
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "mkdir":
                    try {
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\" + args[1]);
                        response = args[1] + " directory has been created succesfully!";
                    }
                    catch(Exception ex) {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "rmdir":
                    try {
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory("0:\\" + args[1],true);
                        response = args[1] + " directory has been deleted succesfully!";
                    }
                    catch (Exception ex) {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "echo":
                    try {
                        FileStream fs=(FileStream)Sys.FileSystem.VFS.VFSManager.GetFile("0:\\" + args[1]).GetFileStream();

                        if (fs.CanWrite){

                            int ctr = 0;
                            StringBuilder sb = new StringBuilder();
                            foreach (String s in args) {
                                if (ctr > 1)
                                    sb.Append(s + ' ');
                                ctr++;
                            }

                            String txt = sb.ToString();
                            Byte[] data = Encoding.ASCII.GetBytes(txt.Substring(0,txt.Length-1));
                            fs.Write(data,0,data.Length);
                            fs.Close();
                            response = "Succesfully wrote to file!";
                        }
                        else{
                            response = "Unable to open file for writing!";
                            break;
                        }
                    }
                    catch(Exception ex) {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "cat":
                    try
                    {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile("0:\\" + args[1]).GetFileStream();

                        if (fs.CanRead)
                        {
                            Byte[] data = new Byte[256];
                            fs.Read(data, 0, data.Length);
                            response = Encoding.ASCII.GetString(data);
                        }
                        else
                        {
                            response = "Unable to open file for reading!";
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;
                case "help":
                    try
                    {
                        response = "filer - program to create/remove file/directories using the following arguments\nhelp - displays this command\ncreate - creates a file\nrm - removes a file\nmkdir - makes a directory\nrmdir - removes a directory\necho - writes data into an existing file\ncat - read and display data from a file";
                        break;
                    }
                    catch(Exception ex)
                    {
                        response = ex.ToString();
                    }
                    break;

                default:
                    response = "Unknown argument! Please use filer help to see available arguments!";
                    break;
            }
            return response;
        }
    }
}
