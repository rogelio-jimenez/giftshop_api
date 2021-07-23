using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application
{
    public static class AppConstants
    {
        public const int EmailLength = 100;
        public const int StandardValueLength = 100;
        public const int PostalCodeLength = 10;
        public const int CountryCodeLength = 3;
        public const int MaxLength = 4000;
        public const int StandardDecimalValueLength = 20;

        public const string AssetsFolderName = "assets";
        public const string ProductImagesFolderName = "product-images";

        public const int QrCodeLength = 1024;

        public const long ProductImageMaxLength = 5000000; //bytes -> 5 mb
    }
}
