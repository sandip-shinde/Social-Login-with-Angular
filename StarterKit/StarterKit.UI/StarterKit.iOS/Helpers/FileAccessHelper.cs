﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace StarterKit.UI.iOS.Helpers
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            // Use the SpecialFolder enum to get the Personal folder on the iOS file system.
            // Then get or create the Library folder within this personal folder.
            // Storing the database here is a best practice.
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libFolder = System.IO.Path.Combine(docFolder, "..", "Library");

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }

            return System.IO.Path.Combine(libFolder, filename);
        }
    }
}