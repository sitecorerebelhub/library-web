using LibraryWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWeb.Services
{
    public interface ISerialize
    {
        void GetSerialize(List<book> ObjectToXml);
    }
}
