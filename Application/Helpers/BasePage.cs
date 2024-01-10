using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class BasePage
    {
        public double TotalItems { get; set; }
        public double PageSize { get; set; } = 100;
        public int TotalPages
        {
            get
            {
                return 
                 (int)Math.Ceiling(TotalItems / PageSize);
            }
        }
        public int CurrentPage { get; set; }
        public int StartPage
        {
            get
            {
                var pageNumber = CurrentPage + 1;
                if (pageNumber == 1)
                    return CurrentPage;
                if (pageNumber == 2)
                    return CurrentPage - 1;
                if (pageNumber == TotalPages)
                    if (CurrentPage < 5)
                        return 0;
                    else if (pageNumber >= 5)
                        return CurrentPage - 4;
                if (pageNumber > 2)
                    if (TotalPages > 5)
                        return CurrentPage - 2;
                    else
                        return 0;

                return 0;
            }
        }
        public int EndPage
        {
            get
            {

                var pageNumber = CurrentPage + 1;
                if (pageNumber == TotalPages)
                    return CurrentPage;
                if (pageNumber == TotalPages - 1)
                    return CurrentPage + 1;
                if (pageNumber < TotalPages - 1)
                    if (TotalPages >= 5)
                        if (pageNumber == 1)
                            return CurrentPage + 4;
                        else if (pageNumber == 2)
                            return CurrentPage + 3;
                        else
                            return CurrentPage + 2;
                    else
                        return CurrentPage + 2;
                return 0;
            }
        }
    }
}
