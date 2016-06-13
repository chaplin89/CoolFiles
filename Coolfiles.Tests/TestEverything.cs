using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CoolFiles;
using System.Linq;
using System.Text;

namespace Coolfiles.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestEverything()
        {
            dynamic tooCoolFileAccess = new CoolAccess();
            string fileContent = "This is a test!\nYou got it!";

            File.WriteAllText("HeyHey1.txt", fileContent);
            File.WriteAllText(Path.Combine("..", "HeyHey1.txt"), fileContent);
            Directory.CreateDirectory(".\\Test");
            File.WriteAllText(Path.Combine("Test", "Heyhey1.txt"), fileContent);

            string fileContent1 = (string)tooCoolFileAccess.HeyHey("{0}.", 1).txt;
            string fileContent2 = (string)tooCoolFileAccess.HeyHey1.txt;
            string fileContent3 = (string)tooCoolFileAccess.Up().HeyHey1.txt;
            string fileContent4 = (string)tooCoolFileAccess("Test\\").HeyHey1.txt;
            string[] fileContent5 = (string[])tooCoolFileAccess.HeyHey1.txt;
            byte[] fileContent6 = (byte[])tooCoolFileAccess.HeyHey1.txt;

            Assert.IsTrue(fileContent1 == fileContent);
            Assert.IsTrue(fileContent2 == fileContent);
            Assert.IsTrue(fileContent3 == fileContent);
            Assert.IsTrue(fileContent4 == fileContent);
            Assert.IsTrue(fileContent5.SequenceEqual(fileContent.Split('\n')));
            Assert.IsTrue(fileContent6.SequenceEqual(Encoding.ASCII.GetBytes(fileContent)));

            File.Delete(Path.Combine("..", "HeyHey1.txt"));
            File.Delete("HeyHey1.txt");
            File.Delete(Path.Combine("Test", "Heyhey1.txt"));

            Directory.Delete("Test");
        }
    }
}
