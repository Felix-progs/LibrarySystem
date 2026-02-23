using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Interfaces
{
    public interface ISearchable
    {
        bool Matches(string searchTerm);
    }
}
