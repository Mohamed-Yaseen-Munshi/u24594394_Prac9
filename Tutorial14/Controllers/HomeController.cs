using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Tutorial14.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection myConnection = new SqlConnection(Globals.ConnectionString);

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoInsert(FormCollection form)
        {
            int Age = Convert.ToInt32(form["Age"]);
            string Name = form["Name"];
            string club = form["Club"];
            decimal Fee = Convert.ToDecimal(form["Fee"]);

            try
            {
                string insertQuery = "INSERT INTO Student (Name, Age, Fee, Club) VALUES (@Name, @Age, @Fee, @Club)";

                using (myConnection)
                {
                    SqlCommand myInsertCommand = new SqlCommand(insertQuery, myConnection);
                    myInsertCommand.Parameters.AddWithValue("@Name", Name);
                    myInsertCommand.Parameters.AddWithValue("@Age", Age);
                    myInsertCommand.Parameters.AddWithValue("@Fee", Fee);
                    myInsertCommand.Parameters.AddWithValue("@Club", club);

                    myConnection.Open();

                    int rowsAffected = myInsertCommand.ExecuteNonQuery();

                    ViewBag.Message = "Success: " + rowsAffected + " rows added.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
            finally
            {
                myConnection.Close();
            }
            return View("Index");
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoUpdate(int id, string name)
        {
            try
            {
                string updateQuery = "UPDATE Student SET Name = @Name WHERE ID = @ID";
                SqlCommand myUpdateCommand = new SqlCommand(updateQuery, myConnection);
                myUpdateCommand.Parameters.AddWithValue("@Name", name);
                myUpdateCommand.Parameters.AddWithValue("@ID", id);

                myConnection.Open();
                int rowsAffected = myUpdateCommand.ExecuteNonQuery();
                ViewBag.Message = "Success: " + rowsAffected + " rows updated.";
            }
            catch (Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally
            {
                myConnection.Close();
            }
            return View("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            try
            {
                string deleteQuery = "DELETE FROM Student WHERE ID = @ID";
                SqlCommand myDeleteCommand = new SqlCommand(deleteQuery, myConnection);
                myDeleteCommand.Parameters.AddWithValue("@ID", id);

                myConnection.Open();
                int rowsAffected = myDeleteCommand.ExecuteNonQuery();
                ViewBag.Message = "Success: " + rowsAffected + " rows deleted.";
            }
            catch (Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally
            {
                myConnection.Close();
            }
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
