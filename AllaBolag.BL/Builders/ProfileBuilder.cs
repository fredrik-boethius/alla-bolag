using AllaBolag.BL.CustomExceptions;
using AllaBolag.BL.Models;
using AllaBolag.BL.Services;
using AllaBolag.BL.Utils;
using AllaBolag.Common;
using HtmlAgilityPack;
using System;
using System.Diagnostics;
using System.Linq;

namespace AllaBolag.BL.Builders
{
    public class ProfileBuilder
    {
        public T Build<T>(IBuildStrategy<T> strategy) where T : class
        {
            return strategy.Build();
        }
    }
}
