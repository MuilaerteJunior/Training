using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;
using AliasForPersonWithDebuggerDisplay = CSharp_TipsAndTraps.PersonWithDebuggerDisplay;

namespace CSharp_TipsAndTraps {

    [TestClass]
    public class TipsAndTrapsTests {
        [TestMethod]
        public void DebuggerDisplayTest() {
            var p = new PersonWithDebuggerDisplay {
                Name = "My name",
                AgeInYears = 50,
                FavoriteColors = new List<string> {
                    "Red","White","Black"
                }
            };
        }

        [TestMethod]
        public void NullCoalescingOperator() {
            var name = "Muilaerte";

            var result = name ?? "Without name";

            name = null;

            result = name ?? "Without name";
        }

        [TestMethod]
        public void NullableTypes() {
            int? age = null;
            int result = age ?? 0;
        }

        [TestMethod]
        public void AvoidCallingVirtualMethodFromConstructor() {
            new DerivedClass();
        }

        [TestMethod]
        public void CallerInfoTest() {
            var c = new CallerInfoAttributeDemo();

            Debug.WriteLine(c.WhoCalledMe());
            Debug.WriteLine(c.WhatFilledCAlledMe());
            Debug.WriteLine(c.WhatLineCalledMe());
        }

        [TestMethod]
        public void ConvertChangeTypeTest() {
            Type targetType, convertedType;
            object convertedValue;
            object initialValue;

            initialValue = "99";
            targetType = typeof(int);

            convertedValue = Convert.ChangeType(initialValue, targetType);
            convertedType = convertedValue.GetType();

            targetType = typeof(double);
            convertedValue = Convert.ChangeType(initialValue, targetType);
            convertedType = convertedValue.GetType();
        }

        [TestMethod]
        public void PreprocessorDirectivesTest() {
            string s = null;
#if DEBUG
            s = " debug ! ";
#elif RELEASE
            s = " release ! ";
#else
            s = " other build ! ";
#endif
            Debug.WriteLine(s);
        }

        [TestMethod]
        public void UnicodeCategoryTest() {
            var validCharacter = 'q';

            var ucCategory = char.GetUnicodeCategory(validCharacter);

            var isValidUnicode = ucCategory != UnicodeCategory.OtherNotAssigned;

            var a = (char) 1;
            
            var isValidUnicode1 = char.GetUnicodeCategory(a) != UnicodeCategory.OtherNotAssigned;
        }

        [TestMethod]
        public void CultureInfoTest() {
            const string brazilCultureString = "pt-BR";
            const string turkeyCultureString = "tr-TR";
            const double number = 23.45;
            string iLetter = "i".ToUpper();


            Debug.WriteLine("BRASIL:");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(brazilCultureString);

            Debug.WriteLine(iLetter);
            Debug.WriteLine(number);
            Debug.WriteLine(DateTime.Now);

            Debug.WriteLine("Turquia:");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(turkeyCultureString);
            
            Debug.WriteLine(iLetter);
            Debug.WriteLine(number);
            Debug.WriteLine(DateTime.Now);
        }

        [TestMethod]
        public void RandomNumberGenerationTest() {
            #region Wrong way
            //Random isn't thread safe
            var r1 = new Random();
            var r2 = new Random();

            Debug.WriteLine("r1 sequence:");
            for(int i = 0; i < 5; i++ ) {
                Debug.WriteLine(r1.Next());
            }

            Debug.WriteLine("r2 sequence:");
            for(int i = 0; i < 5; i++ ) {
                Debug.WriteLine(r2.Next());
            }
            #endregion

            #region Right way
            var r3 = new Random();
            Debug.WriteLine("r3 sequence:");
            for(int i = 0; i < 5; i++ ) {
                Debug.WriteLine(r3.Next());
            }

            Debug.WriteLine("r4 sequence:");
            for(int i = 0; i < 5; i++ ) {
                Debug.WriteLine(r3.Next());
            }
            #endregion
        }

        [TestMethod]
        public void HighSecurity() {
            var r = RandomNumberGenerator.Create();

            var randomBytes = new byte[4];// 4 bytes = 32 bit int
            r.GetBytes(randomBytes);
            int mdINt = BitConverter.ToInt32(randomBytes, 0);
            Debug.WriteLine(mdINt);
        }

        [TestMethod]
        public void ComparingReferences() {
            var a = new Uri("http://pluralsight.com");
            var b = new Uri("http://pluralsight.com");

            var isEqual = a == b;

            var falseIsSameReference = object.ReferenceEquals(a, b);

            b = a;

            var trueIsSameReferenceNow = object.ReferenceEquals(a, b);
        }
        
        [TestMethod]
        public void ComparingStringReferences() {
            //For strings, if is the same content, so the compiler uses the same reference
            var s1 = "Hello";
            var s2 = "Hello";

            var trueIsSameReferenceNow = object.ReferenceEquals(s1, s2);
        }

        [Flags]
        private enum Alignments {
            None = 0,
            Top = 1,
            Right = 2,
            Bottom = 3,
            Left = 4,
        }

        [TestMethod]
        public void TestingEnumFlagsAttribute() {
            //Setting and evaluating
            var topRightCombination = Alignments.Top | Alignments.Right;
            var bottomLeftCombination = Alignments.Bottom | Alignments.Left;

            var isTopIncluded = topRightCombination.HasFlag(Alignments.Top);

            var allAlignements = topRightCombination | bottomLeftCombination;

            //Removing top
            allAlignements ^= Alignments.Top;

            //Adding top again
            allAlignements ^= Alignments.Top;
        }

        [TestMethod]
        public void ThreePartFormatNumber() {

            const string threePartFormat = "(pos)#.##;(neg)#.##;(sorry nothing at all);";

            Debug.WriteLine(55.55.ToString(threePartFormat));
            Debug.WriteLine((-220.55).ToString(threePartFormat));
            Debug.WriteLine(0.ToString(threePartFormat));
        }

        [TestMethod]
        public void RedirectingOutputExamle() {
            var pi = new ProcessStartInfo {
                FileName = "cmd.exe",
                Arguments = "/C DATE /T",
                RedirectStandardOutput = true,
                UseShellExecute = false // Allows redirection of output
            };

            var p = Process.Start(pi);
            var dateFromCmd = p.StandardOutput.ReadToEnd();
        }

        [TestMethod]
        public void FindingItemsInArray() {

            var names = new[] { "Muilaerte", "Thais", "Mumu" };

            int thaisIndex = Array.BinarySearch(names, "Thais");

            int mumuIndex = Array.FindIndex(names, x => x.StartsWith("Mumu"));

            bool isThaisThere = Array.Exists(names, x => x == "Thais");
        }

        [TestMethod]
        public void ArrayFunctions() {
            var names = new[] { "Muilaerte", "Thais", "Mumu" };

            Array.ForEach(names, (x) => {
                Debug.WriteLine(x);
            });

            Array.Sort(names);

            bool allItemsStartsWithM = Array.TrueForAll(names, x => x.StartsWith("M"));
        }

        [TestMethod]
        public void CloneWithReferenceTypes() {
            //string = reference types
            var names = new[] { "Muilaerte", "Thais", "Mumu" };

            string[] shallowCopy = (string[]) names.Clone();

            var originalElementZero = names[0];
            var copyElementZero = shallowCopy[0];

            var isSameReference = object.ReferenceEquals(originalElementZero, copyElementZero);
        }

        [TestMethod]
        public void CloneWithValueTypes() {
            //int = value types
            var numbers = new[] { 1, 2, 3 };

            int[] shallowCopy = (int[]) numbers.Clone();
            var originalElementZero = numbers[0];
            var copyElementZero = shallowCopy[0];

            var isSameReference = object.ReferenceEquals(originalElementZero, copyElementZero);
        }

        
        [TestMethod]
        public void CopyToArrayStrings() {
            var names = new[] { "abc1", "abc2", "abc3" };

            string[] shallowCopy = (string[]) names.Clone();
            
            var originalElementZero = names[0];
            var copyElementZero = shallowCopy[0];

            var isSameReference = object.ReferenceEquals(originalElementZero, copyElementZero);
        }

        [TestMethod]
        public void WaysToInititalizeRectangularArrays() {
            char[,] boardGameLetters = new char[2, 2];

            boardGameLetters[0, 0] = 'A';
            boardGameLetters[0, 1] = 'A';
            boardGameLetters[1, 0] = 'A';
            boardGameLetters[1,1] = 'A';

            var boardGameLetters2 = new char[,] {

                {'a', 'b' },
                {'c', 'd' },
            };

            var boardGameLetters3 = new [,] {
                {'a', 'b' },
                {'c', 'd' },
            };
        }

        [TestMethod]
        public void WaysToInitializeJaggedArrays() {
            var boardGameLetters = new char[2][];

            //inner arrays starts as null

            boardGameLetters[0] = new char[3];
            boardGameLetters[0][0] = 'A';
            boardGameLetters[0][1] = 'B';
            boardGameLetters[0][2] = 'C';

            boardGameLetters[1] = new char[1];
            boardGameLetters[1][0] = 'D';

            var boardGameLetters2 = new[] {
                new [] {
                    'A', 'B', 'C'
                },
                new [] {'D'}
            };
        }

        [TestMethod]
        public void PreservingOriginalException() {
            try {
                throw new Exception("Testando!!!");
            } catch (Exception ex ) {
                //DONT USE 'THROW EX' because you will 
                //lose information about the original exception
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void NumberStylesEnumeration() {

            int iMinus24 = int.Parse("(24)", NumberStyles.AllowParentheses);

            double dMinus24 = Double.Parse("(24)", NumberStyles.AllowParentheses);

            decimal decMinus24 = Decimal.Parse("(24)", NumberStyles.AllowParentheses);


            //Numberstyles.None => only digits allowed
            float f = float.Parse("-24000", NumberStyles.None);
        }

        [TestMethod]
        public void NumberStylesCustomComposites() {
            double d1 = Double.Parse("(24,000)" , NumberStyles.AllowParentheses 
                                                | NumberStyles.AllowThousands);

            
            double d2 = Double.Parse("$24-" , NumberStyles.AllowCurrencySymbol 
                                            | NumberStyles.AllowThousands
                                            | NumberStyles.AllowTrailingSign);
        }

        [TestMethod]
        public void NumberStylesPremadeComposites() {
            double d1 = Double.Parse("$(24,000)", NumberStyles.Currency);
            int i1  = int.Parse("FF", NumberStyles.HexNumber);
        }

        [TestMethod]
        public void NumberStylesCustomCurrency() {
            var strangeCurrency = "J$123.45";

            var nfi = new NumberFormatInfo {
                CurrencySymbol = "J$"
            };

            double d = Double.Parse(strangeCurrency, NumberStyles.Currency, nfi);
        }

        [TestMethod]
        public void DateTimeAmbigousParseExact() {
            const string ambigousDateString = "01/12/2000";

            var d = DateTime.Parse(ambigousDateString);

            Debug.WriteLine(d.ToLongDateString());

            d = DateTime.ParseExact(ambigousDateString, "MM/dd/yyyy", null);

            Debug.WriteLine(d.ToLongDateString());
        }

        [TestMethod]
        public void DateTimeOffsetExample() {
            var original = new DateTimeOffset(2000, 12, 1, 12, 0, 0, TimeSpan.FromHours(-3));
            Debug.WriteLine(original.ToString());
        }

        [TestMethod]
        public void UsefulDateTimeStyles() {
            var data = "01/12/2000";
            var hora = "12:00:00";
            
            var dt1 = DateTime.Parse(data, null, DateTimeStyles.AssumeUniversal);

            var dt2 = DateTime.Parse(data, null, DateTimeStyles.AssumeLocal);

            var dt3 = DateTime.Parse(hora, null, DateTimeStyles.NoCurrentDateDefault);

            var dt4 = DateTime.Parse(hora, null, DateTimeStyles.None);
        }

        [TestMethod]
        public void UsingBitConverterForBasicTypes() {
            const float originalFloat = 25.56f;

            byte[] byteArray = BitConverter.GetBytes(originalFloat);

            float convertedBytes = BitConverter.ToSingle(byteArray, 0);
        }

        [TestMethod]
        public void BitConverterForDateTime() {
            var originalDate = DateTime.Now;

            long originallong = originalDate.ToBinary();

            byte[] byteArray = BitConverter.GetBytes(originallong);

            var convertedBack = DateTime.FromBinary(BitConverter.ToInt64(byteArray, 0));

            var isSameDate = originalDate == convertedBack;
        }

        [TestMethod]
        public void YieldExample() {
            var someNumbers = Enumerable.Range(1, 10);

            foreach ( var even in GetEvenNumbersUsingYield(someNumbers)) {
                Debug.WriteLine("Result: " + even);
            }
        }

        IEnumerable<int> GetEvenNumbersUsingYield(IEnumerable<int> numbers) {
            foreach ( var number in numbers ) {
                //Debug.WriteLine("GetEvenNumbersUsingYield processing input number: " + number);

                if ( number % 2 == 0 ) {
                    //Debug.WriteLine("Even number (yielding): " + number);
                    yield return number;
                }
            }
        }

        [TestMethod]
        public void AliasingTypes() {
            var usingAlias = new AliasForPersonWithDebuggerDisplay();
        }

        [TestMethod]
        public void BigIntegerExample() {
            BigInteger b = 25;
            b = BigInteger.Parse("99999999999999999999999999999999999999999999");
            var million = BigInteger.Pow(10, 3003);
            Debug.WriteLine(million);
        }

        [TestMethod]
        public void BigIntegerOperations() {
            BigInteger b1 = 1000;
            BigInteger b2 = 2000;

            var result = b1 * b2 + 45 / 2;

            result = result % 5;

            result = BigInteger.Negate(result);

            result = BigInteger.Max(b1, b2);
        }

        [TestMethod]
        public void BigIntegerLossOFPrecision() {
            BigInteger b = 9999999999999999999;
            double d =  (double) b;

            b = (BigInteger) d;
        }

        [TestMethod]
        public void NaughtyWordCensor() {
            string naughtyVersion = "Ele é um fdp!";

            var cleanVersion = string.Format(new NaughtyWordCensorFormatProvider(),
                "Clean version: {0}, {1}",
                naughtyVersion,
                "Other fdp string");
            
            var cleanVersion1 = string.Format(new NaughtyWordCensorFormatProvider(),
                "Clean version: {0:xxx}, {1}",
                naughtyVersion,
                "Other fdp string");
        }

        [TestMethod]
        public void ConditionalDirectives() {
            OutputlogUsingDirectives();
        }

        [Conditional("LOG")]
        private void OutputlogUsingDirectives() {
            Debug.WriteLine("Testando log!");
        }
        //TODO: read this: https://ayende.com/blog/3082/pipes-and-filters-the-ienumerable-appraoch


        [TestMethod]
        public void UsingPathClass() {
            var dirSeparatorChar = Path.DirectorySeparatorChar;

            var fullPath = Path.Combine(@"c:\", @"Temp\", "filaname.txt");

            var fullPath2 = Path.Combine(dirSeparatorChar + "temp" + dirSeparatorChar, 
                                        "filename.txt");

            //This will put ".." in the end of the directory
            var oneLevelUpFromCurrentDirWrong = Path.Combine(Environment.CurrentDirectory, "..");

            //This will work an goes to the right directory
            var oneLevelUpFromCurrentDirFullPath = Path.GetFullPath(oneLevelUpFromCurrentDirWrong);
            
        }

        [TestMethod]
        public void UsingOtherPathClassMethods() {
            var path = @"c:\temp\test.txt";

            path = Path.ChangeExtension(path, "cs");

            var dirName = Path.GetDirectoryName(path);

            var extension = Path.GetExtension(path);

            var file = Path.GetFileName(path);

            var fileNoExtension = Path.GetFileNameWithoutExtension(path);

            bool hasExstention = Path.HasExtension(path);

            //Other useful Methods
            char[] invalidaNameChars = Path.GetInvalidFileNameChars();

            string temporaryFileName = Path.GetTempFileName();

            string userTempPath = Path.GetTempPath();

            char defaultSeparatorChar = Path.DirectorySeparatorChar;
        }

        [TestMethod]
        public void UsingPaddingWithStrings() {
            string name = "Júnior", gender = "Masculino";
            int age = 28;
            var output = string.Format("Name {0,-20}Age: {1,10}Gender:{2,10}",
                          name, 
                          age, 
                          gender);

            Debug.WriteLine(output);
        }

        [TestMethod]
        public void CompactConstructor() {
            var p1 = new PersonWithDebuggerDisplay("Júnior");
            var p2 = new PersonWithDebuggerDisplay("Júnior", 28);
        }

        [TestMethod]
        public void SystemRelatedInfo() {
            var envVars = Environment.GetEnvironmentVariables();
            var envPathVar = envVars["Path"];

            var is64BitOs = Environment.Is64BitOperatingSystem;
            var is64BitProc = Environment.Is64BitProcess;
            var numberOfProcs = Environment.ProcessorCount;
            var pageSize = Environment.SystemPageSize;
            var clrRuntimeVersion = Environment.Version;
            var currEnvNewLineString = Environment.NewLine;

            var currentDir = Environment.CurrentDirectory;

            var desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            var myDocsDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var sysDir = Environment.SystemDirectory;
        }

        [TestMethod]
        public void UsingAnIndexer() {
            var bigFile = new DemoFileArray(@"c:\temp\largefile.bin");

            byte valueAsOffset = bigFile[20];

            valueAsOffset++; // Assumes value won't exceed byte.maxValue

            bigFile[10] = valueAsOffset;
        }
    }
}