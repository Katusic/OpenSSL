using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace openSSL
{
    class Program
    {
        static void Main(string[] args)
        {

            var body = "test body";
            var YourPrivateRSA = UtilLib.PemKey.GetRSAProviderFromPemFileName("../../priv/private.pem");
            var signedBody = YourPrivateRSA.SignData(Encoding.UTF8.GetBytes(body), CryptoConfig.MapNameToOID("SHA256"));
            var signature = System.Convert.ToBase64String(signedBody);
            Console.WriteLine($"The signature done with Your private key is:\n\r{signature}.");

            var YourPublicRSA = UtilLib.PemKey.GetRSAProviderFromPemFileName("../../priv/public.pem");

            var decoded_signature = System.Convert.FromBase64String(signature);
            var valid = YourPublicRSA.VerifyData(Encoding.UTF8.GetBytes(body), CryptoConfig.MapNameToOID("SHA256"), decoded_signature);
            Console.WriteLine($"signature is valid: \r{valid}");


            //var YourPublicRSA = UtilLib.PemKey.GetRSAProviderFromPemFileName(@"D:\keys\public.pem"); //file provided by Hub88
            ////signature comes in header X-Hub88-Signature
            //var codedSignature = "ABz2LrDYMVJ4zYyBZ+j9jO8ZcTFjWofeVmk1cmiFciC2QWoKUyUJUs+Com5io96KqVqWC5sabsLj/qGm0iDsAzPKiPOPEPrTFx3rH+Pl4rNL1T7Puz9xdlILbppJUo+ptx2GsNVQWeJXhfVRGc8wY+amElz3sc5EWX3c+k+h+nchMWRlBgnhZw3QqCSGaJ1M1tMXhdyAdtwioqG0rcPogO4Shp5oPb3+kNlruCVRErULSuONghuLKM3k2BECV6fD1v8flacSq+zjM+ytcfsTz9o7stsUwkcJAMqWB+4LG5nw5gxgqvA+Bc+wwOisimsLOVI7gWV17Jg/n24PZDJHyg==";
            //var decoded_signature = System.Convert.FromBase64String(codedSignature);
            //var valid = YourPublicRSA.VerifyData(Encoding.UTF8.GetBytes(body), CryptoConfig.MapNameToOID("SHA256"), decoded_signature);
            //Console.WriteLine(valid);
        }
    }
}
