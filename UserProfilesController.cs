using system;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace guybbb
{
  public class UserProfilesController{

    public string GetUserProfile(string userName){

    string conStr = "Data Source=billbeez.test.server.com;Initial Catalog=billbeez-main;User id=billbeez-applicany;Password=123456";
    string CommandText = "SELECT Id, Username , firstname,lastname,Age,Active FROM user_profiles WHERE (Username= @username)";
    var cmd = new SqlCommand(CommandText);  

    cmd.Connection = new sqlConnection(conStr);
    cmd.Parameters.Add(new SqlParameter("@Username", System.Data.SqlDbType.NVarChar,20,"Username"));  
    cmd.Parameters["@Username"].Value = userName;

    var rdr = cmd.ExecuteReader();
    rdr.Read();
    var userProfile = new UserProfile(){
                      Id = Convert.ToInt16(rdr["Id"]), 
                      Username = rdr["Username"].ToString(), 
                      Firstname = rdr["firstname"].ToString(), 
                      Lastname = rdr["lastname"].ToString(),
	  	              Age = Convert.ToInt16(rdr["Age"]), 
		              Active = Convert.ToInt16(rdr["Active"])
		            } 
                
    userProfileJsonStr = new JavaScriptSerializer().Serialize(userProfile); 
    return userProfileJsonStr;
  }
 }
}