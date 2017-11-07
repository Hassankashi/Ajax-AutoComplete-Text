//' (c) Copyright Microsoft Corporation.
//' This source is subject to the Microsoft Public License.
//' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
//' All other rights reserved.
//'*-------------------------------*
//'*                               *
//'*      Mahsa Hassankashi        *
//'*     info@mahsakashi.com       *
//'*   http://www.mahsakashi.com   * 
//'*     kashi_mahsa@yahoo.com     * 
//'*                               *
//'*                               *
//'*-------------------------------*
//' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AutoComplete
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService {

    public AutoComplete () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
     

    public string[] GetCompletionList(string prefixText, int count)
    {

         //ADO.Net
         SqlConnection cn =new SqlConnection();
         DataSet ds = new DataSet();
         DataTable  dt = new DataTable();
         String strCn = "data source=.;Initial Catalog=MyDB;Integrated Security=True";
         cn.ConnectionString = strCn;
         SqlCommand cmd = new SqlCommand();
         cmd.Connection = cn;
         cmd.CommandType = CommandType.Text;
        //Compare String From Textbox(prefixText) AND String From Column in DataBase(CompanyName)
        //If String from DataBase is equal to String from TextBox(prefixText) then add it to return ItemList
        //-----I Defined a parameter instead of passing value directly to prevent sql injection--------//
        cmd.CommandText = "select * from tblCustomer Where CompanyName like @myParameter";
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%");
        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        catch
        {
        }
        finally
        {
            cn.Close();
        }
        dt = ds.Tables[0];

       //Then return List of string(txtItems) as result
       List<string> txtItems =new List<string>();
       String  dbValues;

        foreach (DataRow row  in dt.Rows)
        {
            //String From DataBase(dbValues)
            dbValues = row["CompanyName"].ToString();
            dbValues = dbValues.ToLower();
            txtItems.Add(dbValues);
            
          }

        return txtItems.ToArray();
      
    }
   
}

