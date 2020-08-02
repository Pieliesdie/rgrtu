using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Курсовая.GIS.Tests
{
    [TestClass]
    public class RSAExtensionTest
    {
        private const string publickeypem = @"RSAKeys\public.pem";
        private const string privatekeypem = @"RSAKeys\private.pem";

        private const string publickey = "MEgCQQDG/Na7kYQC9jch2+ScvVEPV/vQMOeig5pqVwbXJqZI3l1+D2fiZLsOTEzO/+8fSF0eF+S2PvVmvS8I3gKDkQT/AgMBAAE=";
        private const string privatekey = "MIIBOgIBAAJBAMb81ruRhAL2NyHb5Jy9UQ9X+9Aw56KDmmpXBtcmpkjeXX4PZ+Jkuw5MTM7/" +
            "7x9IXR4X5LY+9Wa9LwjeAoORBP8CAwEAAQJAEC1eB8G8ycDampYV7+g0PtsYTcSsEDpCw4Jvu+4YdrP4kHqmLoFKgKRB/RqViohgCZd59" +
            "oAu9xbu20OQklQDAQIhAOcJyqX60EjpkSP26f64nrBI/Y5IqFzzvDIgClF5amGpAiEA3HySFUK0TS" +
            "ZUBKWC+iYvs6gnPGMbVHK4cB6GPvqOKmcCIQCx9g/bc+vWDdtXmYy6QRky7rYoT/0nxDK1ZYqtIVn5KQIfPEnTp/yVUIM" +
            "qdhrLtZq7cGSKVfjDgFPeGso96vqX5QIhALFc8mzAtipsoZkaGehkCEncCCHKm5EUMOxeAbO3OKZ+";
        private const string SourceMessage = "Hello World!";

        [TestMethod]
        public void EncryptionTest()
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privatekey), out _);
            var encrmessage = rsa.PrivareEncryption(Encoding.UTF8.GetBytes(SourceMessage));
            rsa.ImportRSAPublicKey(Convert.FromBase64String(publickey),out _);
            var message = Encoding.UTF8.GetString(rsa.PublicDecryption(encrmessage));
            Assert.AreEqual(message, SourceMessage);
        }

        [TestMethod]
        public void ImportPublicKeyTest()
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportPublicKey(publickeypem);
            var key = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            Assert.AreEqual(key, publickey);
        }

        [TestMethod]
        public void ImportPrivateKeyTest()
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportPrivateKey(privatekeypem);
            var key = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            Assert.AreEqual(key, privatekey);
        }

        [TestMethod]
        public void ExportPublicKeyTest()
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportPrivateKey(privatekeypem);
            rsa.ExportPublicKey(@"RSAKeys\GeneratedPublic.pem");
            var generated =File.ReadAllText(@"RSAKeys\GeneratedPublic.pem");
            generated = Regex.Replace(generated, "\r", "");
            generated = Regex.Replace(generated, "\n", "");
            var source = File.ReadAllText(@"RSAKeys\public.pem");
            source = Regex.Replace(source, "\r", "");
            source = Regex.Replace(source, "\n", "");
            Assert.AreEqual(generated, source);
        }

        [TestMethod]
        public void EncryptionStringRSATest()
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privatekey), out _);
            var encrmessage = rsa.EncryptStringRSA(SourceMessage);
            rsa.ImportRSAPublicKey(Convert.FromBase64String(publickey), out _);
            var message = rsa.DecryptStringRSA(encrmessage);
            Assert.AreEqual(message, SourceMessage);
        }
    }
}
