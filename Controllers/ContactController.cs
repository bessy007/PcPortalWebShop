using Microsoft.AspNetCore.Mvc;
using PCPortal.Data;
using PCPortal.Models;

namespace PCPortal.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ContactController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Contact> objContactList = _db.Contacts;
            return View(objContactList);
        }
        [Route("Contact/ContactIndex/{contactId}")]
        public IActionResult ContactIndex(int? contactId)
        {
            var contact = _db.Contacts.Find(contactId);

            if (contact == null)
            {
                return NotFound();
            }

            return View("ContactIndex", contact);
        }
        public IActionResult ViewContact(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contactFromDb = _db.Contacts.Find(id);

            if (contactFromDb == null)
            {
                return NotFound();
            }
            return View(contactFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Contacts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Contacts.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Message deleted successfully!";
            return RedirectToAction("Index");
        }
        //GET
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        //POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Contact(Contact model)
        {
            // Validate the model
            if (ModelState.IsValid)
            {
                // Save the data to the database or perform other actions
                // For simplicity, let's assume you have a database context called _dbContext

                // Example: Saving to a database
                var contactEntity = new Contact
                {
                    FullName = model.FullName,
                    EmailAddress = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber,
                    Message = model.Message
                };

                _db.Contacts.Add(contactEntity);
                _db.SaveChanges();

                // Redirect to a thank-you page or wherever you want
                return RedirectToAction("ThankYou");
            }

            // If the model is not valid, redisplay the form with validation errors
            return View("Contact", model);
        }
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
