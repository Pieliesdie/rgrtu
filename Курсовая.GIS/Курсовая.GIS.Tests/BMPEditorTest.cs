using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace Курсовая.GIS.Tests
{
    [TestClass]
    public class BMPEditorTest
    {
        private const string ModifiedBmp1bitPath = @"ModifiedBMPs\2color.bmp";
        private const string ModifiedBmp4bitPath = @"ModifiedBMPs\16color.bmp";
        private const string ModifiedBmp8bitPath = @"ModifiedBMPs\256color.bmp";
        private const string ModifiedBmp24bitPath = @"ModifiedBMPs\24bit.bmp";

        private const string OriginalBmp1bitPath = @"OriginalBMPs\2color.bmp";
        private const string OriginalBmp4bitPath = @"OriginalBMPs\16color.bmp";
        private const string OriginalBmp8bitPath = @"OriginalBMPs\256color.bmp";
        private const string OriginalBmp24bitPath = @"OriginalBMPs\24bit.bmp";
        private const string message = "Hello world!";
        private static byte[] secret => Encoding.Unicode.GetBytes(message);

        public static IEnumerable<object[]> GetDataForPathTest()
        {
            yield return new object[] { OriginalBmp1bitPath, secret };
            yield return new object[] { OriginalBmp4bitPath, secret };
            yield return new object[] { OriginalBmp8bitPath, secret };
            yield return new object[] { OriginalBmp24bitPath, secret };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForPathTest), DynamicDataSourceType.Method)]
        public void AddSecretToBmpTest(string path, byte[] secret)
        {
            var BeforeAdding = Encoding.Unicode.GetString(File.ReadAllBytes(path)).Contains(message);
            Assert.IsFalse(BeforeAdding);
            BMPEditor.AddSecretToBmp(path, secret);
            var AfterAdding = Encoding.Unicode.GetString(File.ReadAllBytes(path)).Contains(message);
            Assert.IsTrue(AfterAdding);
            Assert.IsNotNull(new BitmapImage(new System.Uri(path,System.UriKind.Relative)));
        }

        [TestMethod]
        [DataRow(ModifiedBmp1bitPath)]
        [DataRow(ModifiedBmp4bitPath)]
        [DataRow(ModifiedBmp8bitPath)]
        [DataRow(ModifiedBmp24bitPath)]
        public void ReadSecretFromBmpTest(string path)
        {
            var _message = BMPEditor.ReadSecretFromBmp(path);
            Assert.AreEqual(message, Encoding.Unicode.GetString(_message));
        }
    }
}
