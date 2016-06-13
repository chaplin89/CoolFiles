# CoolFiles

CoolFiles is a useless library for file access.

It will make you save typing precious characters while programming, while adding horrible performance penalties!

## How it works

It's damn simple!

If you want to access the file "CoolFile.dat" in your working folder, you can simply write:

    var fa = CoolAccess();
    byte[] myFileContent = (byte[])fa.CoolFile.dat;
    
And CoolFile will do the magic!

If there are invalid C# characters in your file name, say CoolMyInvalidCharacters@##.dat you can write:

    byte[] myFileContent = (byte[])fa.Cool("MyInvalidCharaters@##.").dat

There are also cast for string and array of strings (lines):

    string myFileContent = (string)fa.CoolFile.dat;
    string[] myFileContentLines = (string[])fa.CoolFile.dat;

Awesome (or probably not)!
