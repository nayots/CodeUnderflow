using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Common.AutoMapper
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}