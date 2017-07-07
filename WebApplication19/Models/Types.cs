using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class Types
    {
        public enum IMAGE
        {
            SLIDER = 1, PRODUCT = 2, ARTICLE = 3, LOGO = 4, BANER = 5
        }
        public enum Category
        {
            PRODUCT = 1, SEVICE = 2, ARTICLE = 3, NEWS = 4
        }
        public enum Status
        {
            DISPLAY = 1, HIDE = 0
        }
        public enum Article
        {
            ABOUT = 9, CUSTOMER = 10
        }
        public enum SystemConfig
        {
            LOGO = 1,
            ADDRESS = 2,
            CUSTOMIZE_SCRIPT = 3,
            EMAIL = 4,
            DESCRIPTION = 5,
            KEY_WORD = 6,
            IMAGE_PREVIEW = 7
        }

        public enum Support
        {
            TOP = 1,
            BOTTOM = 2
        }
    }
}