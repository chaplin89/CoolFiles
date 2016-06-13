using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace CoolFiles
{
    public class CoolAccess : DynamicObject
    {
        string currentFile;
        private bool skipTheDot;

        public CoolAccess()
        {
        }

        CoolAccess(string initialPath)
        {
            currentFile = initialPath;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (currentFile != null)
            {
                if (skipTheDot)
                {
                    currentFile = currentFile + binder.Name;
                    skipTheDot = false;
                }
                else
                {
                    currentFile = currentFile + "." + binder.Name;
                }
            }
            else
            {
                currentFile = binder.Name;
            }

            result = this;
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = null;

            if (binder.Name == "Up")
            {
                if (currentFile == null)
                    currentFile = "";

                currentFile = Path.Combine(currentFile, "..\\");
            }
            else
            {
                currentFile = currentFile ?? "";
                currentFile += binder.Name;

                if (args.Length == 0)
                    return false;

                string format = args[0] as string;

                if (format == null)
                    return false;

                List<object> arguments = args.ToList();
                arguments.RemoveAt(0);

                currentFile += string.Format(format, arguments.ToArray());
            }

            skipTheDot = true;
            result = this;
            return true;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            result = null;
            try
            {
                if (binder.ReturnType == typeof(string))
                {
                    result = File.ReadAllText(currentFile);
                }
                else if (binder.ReturnType == typeof(string[]))
                {
                    result = File.ReadAllLines(currentFile);
                }
                else if (binder.ReturnType == typeof(byte[]))
                {
                    result = File.ReadAllBytes(currentFile);
                }
            }
            catch
            {
                result = null;
            }

            currentFile = null;
            return true;
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            result = null;

            if (args.Length != 1)
                return false;

            string toAdd = args[0] as string;

            if (toAdd == null)
                return false;

            if (currentFile == null)
                currentFile = toAdd;
            else
                currentFile += toAdd;

            skipTheDot = true;
            result = this;
            return true;
        }
    }
}
