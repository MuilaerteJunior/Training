using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;

namespace CSharp_TipsAndTraps
{

    /// <summary>
    /// This is a demo for demonstrating how an indexer can be used.
    /// </summary>
    public class DemoFileArray {
        public DemoFileArray(string filePath) { }

        public byte this[long index] {
            get {
                //Move to a position and return the stream to specific position
                return 42;
            }
            set {
                byte valueToWriteToFile = value;

                //Move to the position in the stream and set the value
            }
        }

    }

}