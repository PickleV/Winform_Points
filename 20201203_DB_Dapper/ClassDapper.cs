using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Windows.Forms;

namespace _20201203_DB_Dapper
{
    public class DB
    {
        //If on git hub, no password will be uploaded
        public static string GetConStr(string Name)
        {
            return ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }

        //Use sql
        public static List<Person> GetPerson(string FirstName)
        {
            using (IDbConnection connection=new SqlConnection(GetConStr("Con01")))
            {
                //Wrong Practice, no sqlstring is not good
              var output=connection.Query<Person>($"select * from person where firstname='{FirstName}'").ToList();
              return output;
            }
        }

        //use stored procedure
        public static List<Person> GetPerson1(string FirstName)
        {
            using (IDbConnection connection = new SqlConnection(GetConStr("Con01")))
            {
                //Wrong Practice, no sqlstring is not good
                var output = connection.Query<Person>("dbo.People_GetByLastName @FirstName",new {FirstName=FirstName}).ToList();
                return output;
            }
        }


        //Insert use sql command
        internal static int InsertPerson(Person person)
        {
            using (IDbConnection connection = new SqlConnection(GetConStr("Con01")))
            {

                return connection.Execute("insert into person(FirstName,LastName,[EmailAddress],Phone) Values(@FirstName,@LastName,@EmailAddress,@Phone)", person);
                //@FirstName表示自动把person中的FirstName的值给入进去
               
            }
        }

  

        //Insert use stored procedure
        internal static void InsertPerson1(Person person)
        {
            using (IDbConnection connection = new SqlConnection(GetConStr("Con01")))
            {

                connection.Execute("dbo.people_insert @FirstName,@LastName,@Email,@Phone", person);
                //@FirstName表示自动把person中的FirstName的值给入进去
                return;
                
            }
        }

        internal static int InsertPeople(List<Person> people)
        {
            using (IDbConnection connection = new SqlConnection(GetConStr("Con01")))
            {
                return connection.Execute("insert into person(FirstName,LastName,Email,Phone) @FirstName,@LastName,@Email,@Phone", people);
                //connection.Execute("dbo.people_insert @FirstName,@LastName,@Email,@Phone", people); //一次进行多行插入
            }
        }

        internal static int DelPerson(List<Person> people)
        {
            using (IDbConnection connection = new SqlConnection(GetConStr("Con01")))
            {

                //connection.Execute("dbo.people_insert @FirstName,@LastName,@Email,@Phone", people); //一次进行多行插入
                return connection.Execute("delete from person where FirstName=@FirstName", people);
            }
        }



    }


    //name perperty name must match
    // Not case sensitive
   public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }


        public string FullInfo
        {
            //"FistName LastName (Email)"
            get { return $"{FirstName}{LastName}({EmailAddress})"; }
        }


    }
}
