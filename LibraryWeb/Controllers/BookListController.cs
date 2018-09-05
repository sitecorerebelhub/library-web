using LibraryWeb.Models;
using LibraryWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class BookListController : Controller
    {
        #region Variables
        private IDeserialize _deserializeServiceProvider;
        private ISerialize _serializeServiceProvider;
        private const string returnColorStyle = "style=background-color:#cee0dc";
        private const string borrowColorStyle = "style=background-color:#F2F2F2";
        private const string naColorStyle = "style=background-color:#e8e4c0";
        #endregion

        #region Default Constructor
        public BookListController() { }
        public BookListController(IDeserialize desrializeServiceProvider, ISerialize serializeServiceProvider)
        {
            _deserializeServiceProvider = desrializeServiceProvider;
            _serializeServiceProvider = serializeServiceProvider;
        }
        #endregion

        #region Book Operations
        // GET: BookList
        public ActionResult Index()
        {
            try
            {
                if (IsValidUser())
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    List<book> books = _deserializeServiceProvider.GetDeserialize();

                    //Update book object values
                    foreach (var book in books)
                    {
                        if (book.Borrowed == "True")
                        {
                            if (User != null && User.Identity.Name.ToLower() == book.user.ToLower())
                            {
                                book.colorstyle = returnColorStyle;
                                book.baText = "Return";
                                book.baParam = "return";
                                book.baClass = "NA";
                            }
                            else
                            {
                                book.colorstyle = naColorStyle;
                                book.baText = "Not Available";
                                book.baParam = "na";
                                book.baClass = "linkdisabled";
                            }
                        }
                        else
                        {
                            book.colorstyle = borrowColorStyle;
                            book.baText = "Borrow";
                            book.baParam = "borrow";
                            book.baClass = "NA";
                        }
                    }
                    return View(books);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Perform BookAction
        public ActionResult BookAction(string id, string isreturn)
        {
            try
            {
                // Call funtion to convert XML to Books object
                List<book> books = _deserializeServiceProvider.GetDeserialize();

                //Update object values
                books.First(b => b.id.ToString() == id).user = (isreturn == "return") ? "N/A" : User.Identity.Name.ToLower();
                books.First(b => b.id.ToString() == id).Borrowed = (isreturn == "return") ? "False" : "True";

                //Call function to convert object to XML
                _serializeServiceProvider.GetSerialize(books);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Reusable Methods
        private bool IsValidUser()
        {
            return User != null && string.IsNullOrWhiteSpace(User.Identity.Name);
        }
        #endregion
    }
}