using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter20
{
    class Program
    {
        static void Main(string[] args)
        {
            #region File I/O and Object Serializatio n

            //Console.WriteLine("***** Fun with FileStreams *****\n");
            //// Obtain a FileStream object.
            //using (FileStream fStream = File.Open(@"myMessage.dat",
            //FileMode.Create))
            //{
            //    // Encode a string as an array of bytes.
            //    string msg = "Hello!";
            //    byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
            //    // Write byte[] to file.
            //    fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
            //    // Reset internal position of stream.
            //    fStream.Position = 0;
            //    // Read the types from file and display to console.
            //    Console.Write("Your message as an array of bytes: ");
            //    byte[] bytesFromFile = new byte[msgAsByteArray.Length];
            //    for (int i = 0; i < msgAsByteArray.Length; i++)
            //    {
            //        bytesFromFile[i] = (byte)fStream.ReadByte();
            //        Console.Write(bytesFromFile[i]);
            //    }
            //    // Display decoded messages.
            //    Console.Write("\nDecoded Message: ");
            //    Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            //}
            //Console.ReadLine();
            #endregion


            //#region Writing to a Text File
            //Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");
            //// Get a StreamWriter and write string data.
            //using (StreamWriter writer = File.CreateText("reminders.txt"))
            //{
            //    writer.WriteLine("Don't forget Mother's Day this year...");
            //    writer.WriteLine("Don't forget Father's Day this year...");
            //    writer.WriteLine("Don't forget these numbers:");
            //    for (int i = 0; i < 10; i++)
            //        writer.Write(i + " ");
            //    // Insert a new line.
            //    writer.Write(writer.NewLine);
            //}
            //Console.WriteLine("Created file and wrote some thoughts...");
            //// Now read data from file.
            //Console.WriteLine("Here are your thoughts:\n");
            //using (StreamReader sr = File.OpenText("reminders.txt"))
            //{
            //    string input = null;
            //    while ((input = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(input);
            //    }
            //}
            //Console.ReadLine();
            //#endregion

            //#region Working with StringWriters and StringReaders
            //Console.WriteLine("***** Fun with StringWriter / StringReader *****\n");
            //// Create a StringWriter and emit character data to memory.
            //using (StringWriter strWriter = new StringWriter())
            //{
            //    strWriter.WriteLine("Don't forget Mother's Day this year...");
            //    // Get a copy of the contents (stored in a string) and dump
            //    // to console.
            //    Console.WriteLine("Contents of StringWriter:\n{0}", strWriter);
            //    // Get the internal StringBuilder.
            //    StringBuilder sb = strWriter.GetStringBuilder();
            //    sb.Insert(0, "Hey!! ");
            //    Console.WriteLine("-> {0}", sb.ToString());
            //    sb.Remove(0, "Hey!! ".Length);
            //    Console.WriteLine("-> {0}", sb.ToString());
            //    // Read data from the StringWriter.
            //    using (StringReader strReader = new StringReader(strWriter.ToString()))
            //    {
            //        string input = null;
            //        while ((input = strReader.ReadLine()) != null)
            //        {
            //            Console.WriteLine(input);
            //        }
            //    }
            //    Console.ReadLine();
            //    //#endregion

            //#region Working with BinaryWriters and BinaryReaders
            //Console.WriteLine("***** Fun with Binary Writers / Readers *****\n");
            //// Open a binary writer for a file.
            //FileInfo f = new FileInfo("BinFile.dat");
            //using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            //{
            //    // Print out the type of BaseStream.
            //    // (System.IO.FileStream in this case).
            //    Console.WriteLine("Base stream is: {0}", bw.BaseStream);
            //    // Create some data to save in the file.
            //    double aDouble = 1234.67;
            //    int anInt = 34567;
            //    string aString = "A, B, C";
            //    // Write the data.
            //    bw.Write(aDouble);
            //    bw.Write(anInt);
            //    bw.Write(aString);
            //}
            //using (BinaryReader br = new BinaryReader(f.OpenRead()))
            //{
            //    Console.WriteLine(br.ReadDouble());
            //    Console.WriteLine(br.ReadInt32());
            //    Console.WriteLine(br.ReadString());
            //}
            //Console.ReadLine();
            //#endregion

            #region Watching Files Programmatically
            Console.WriteLine("***** The Amazing File Watcher App *****\n");
            // Establish the path to the directory to watch.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"D:\Pass - Copy";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            // Set up the things to be on the lookout for.
            watcher.NotifyFilter = NotifyFilters.LastAccess
            | NotifyFilters.LastWrite
            | NotifyFilters.FileName
            | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.txt";
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            // Begin watching the directory.
            watcher.EnableRaisingEvents = true;
            // Wait for the user to quit the program.
            Console.WriteLine(@"Press 'q' to quit app.");
            while (Console.Read() != 'q')
                ;
            #endregion

        }


        #region Watching Files Programmatically
        static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType);
        }
        static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
        #endregion

        #region Working with the Directory Type
        static void FunWithDirectoryType()
        {
            // List all drives on current computer.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:");
            foreach (string s in drives)
                Console.WriteLine("--> {0} ", s);
            // Delete what was created.
            Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            {
                Directory.Delete(@".\MyFolder");
                // The second parameter specifies whether you
                // wish to destroy any subdirectories.
                Directory.Delete(@".\MyFolder2", true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Creating Subdirectories with the DirectoryInfo Type
        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            // Create \MyFolder off initial directory.
            dir.CreateSubdirectory("MyFolder");
            // Capture returned DirectoryInfo object.
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");
            // Prints path to ..\MyFolder2\Data.
            Console.WriteLine("New Folder is: {0}", myDataFolder);
        }
        #endregion

        #region Enumerating Files with the DirectoryInfo Type
        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\Images");
            // Get all files with a *.jpg extension.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            // How many were found?
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);
            // Now print out info for each file.
            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("File name: {0}", f.Name);
                Console.WriteLine("File size: {0}", f.Length);
                Console.WriteLine("Creation: {0}", f.CreationTime);
                Console.WriteLine("Attributes: {0}", f.Attributes);
                Console.WriteLine("***************************\n");
            }
        }
        #endregion

        #region Working with the DirectoryInfo Type

        static void ShowWindowsDirectoryInfo()
        {
            // Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("**************************\n");
        }
        #endregion
    }
}
