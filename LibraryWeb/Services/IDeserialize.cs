using LibraryWeb.Models;
using System.Collections.Generic;

namespace LibraryWeb.Services
{
    public interface IDeserialize
    {
        List<book> GetDeserialize();
    }
}
