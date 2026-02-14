using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LibrarySystem.Services
{
    public class Library
    {
        private BookCatalog bookcatalog;
        private MemberRegistry memberRegistry;
        private LoanManager loanManager;
        public Library() 
        {
            bookcatalog = new BookCatalog();
            memberRegistry = new MemberRegistry();
            loanManager = new LoanManager();
        }

    }
}
