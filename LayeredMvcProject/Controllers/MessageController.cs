using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox(string p)
        {
            var messageList = messageManager.GetMessagesListInbox(p);
            return View(messageList);
        }

        public ActionResult Sendbox(string p)
        {
            var messageList = messageManager.GetMessagesListSendbox(p);
            return View(messageList);
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var messageValues = messageManager.GetMessageById(id);
            return View(messageValues);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var messageValues = messageManager.GetMessageById(id);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = "admin@admin.com";
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.AddMessage(message);
                return RedirectToAction("SendBox", "Message");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}