using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighStocks
{
    public class TEST2BAL
    {
        public static int AddProgram(TEST2 objTEST2)
        {
            TESTDataContext objTESTDataContext = new TESTDataContext();

            objTESTDataContext.TEST2s.InsertOnSubmit(objTEST2);
            objTESTDataContext.SubmitChanges();

            return 0;
        }
    }    
}