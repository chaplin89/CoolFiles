# CoolFiles

CoolFiles is a useless library for file access.

It will make you save precious keystrokes while adding horrible performance penalties!

## How it works

It's damn simple!

If you want to access the file "CoolFile.dat" in your working folder, you can simply write:

    dynamic ca = new CoolAccess();
    byte[] myFileContent = (byte[])ca.CoolFile.dat;
    
And CoolFiles will do the magic!

If there are invalid C# characters in your file name, say CoolMyInvalidCharacters@##File.dat you can write:

    byte[] myFileContent = (byte[])ca.Cool("MyInvalidCharaters@##").File.dat

There are also casts for string and array of strings (lines):

    string myFileContent = (string)ca.CoolFile.dat;
    string[] myFileContentLines = (string[])ca.CoolFile.dat;

Awesome (or probably not)!
