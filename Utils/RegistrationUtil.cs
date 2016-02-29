//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace QuantumConcepts.Common.Forms.Utils
{
    public static class RegistrationUtil
    {
        private static RegistryKey GetRootHive(bool currentUser)
        {
            return (currentUser ? Registry.CurrentUser : Registry.ClassesRoot);
        }

        public static void RegisterProgId(string progId, string appId, string openWith, bool currentUser)
        {
            using (RegistryKey root = GetRootHive(currentUser))
            {
                using (RegistryKey progIdKey = root.CreateSubKey(progId))
                {
                    progIdKey.SetValue("FriendlyTypeName", "@shell32.dll,-8975");
                    progIdKey.SetValue("DefaultIcon", "@shell32.dll,-47");
                    progIdKey.SetValue("CurVer", progId);
                    progIdKey.SetValue("AppUserModelID", appId);

                    using (RegistryKey shell = progIdKey.CreateSubKey("shell"))
                    {
                        shell.SetValue(String.Empty, "Open");

                        using (RegistryKey shellOpen = shell.CreateSubKey("Open"))
                        {
                            using (RegistryKey shellOpenCommand = shellOpen.CreateSubKey("Command"))
                            {
                                shellOpenCommand.SetValue(String.Empty, openWith);
                            }
                        }
                    }
                }
            }
        }

        public static bool UnregisterProgId(string progId, bool currentUser)
        {
            using (RegistryKey root = GetRootHive(currentUser))
            {
                try
                {
                    root.DeleteSubKeyTree(progId);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static void RegisterFileExtensionAssociation(string progId, string extension, bool currentUser)
        {
            using (RegistryKey root = GetRootHive(currentUser))
            {
                using (RegistryKey openWithKey = root.CreateSubKey(Path.Combine(extension, "OpenWithProgIds")))
                {
                    openWithKey.SetValue(progId, String.Empty);
                    openWithKey.Close();
                }
            }
        }

        public static bool UnregisterFileExtensionAssociation(string progId, string extension, bool currentUser)
        {
            using (RegistryKey root = GetRootHive(currentUser))
            {
                try
                {
                    using (RegistryKey openWithKey = root.CreateSubKey(Path.Combine(extension, "OpenWithProgIds")))
                    {
                        openWithKey.DeleteValue(progId);
                        openWithKey.Close();
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
