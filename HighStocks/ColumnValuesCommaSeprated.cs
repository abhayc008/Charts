using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighStocks
{
    public class ColumnValuesCommaSeprated
    {       

        //--select    * from tblTest



        //DECLARE @tbl TABLE(col1 VARCHAR(100),col2 VARCHAR(100),col3 VARCHAR(100));
        //INSERT INTO @tbl VALUES('test1','abtes','test3');

        //SELECT 
        //STUFF(
        //(
        //    SELECT ',' + elmt.value('.','nvarchar(max)')
        //    FROM
        //    (
        //    SELECT
        //        (
        //    /*YOUR QUERY HERE*/
        //            SELECT TOP 1 * 
        //            FROM tblTest
        //    /*--------------------*/
        //            FOR XML AUTO ,ELEMENTS XSINIL,TYPE
        //        )
        //    ) AS A(t)
        //    CROSS APPLY t.nodes('/*/*') AS B(elmt)
        //    FOR XML PATH('')
        //),1,1,'')

    }
}