using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace LayeredMvcProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var adminUserInfo = adminManager.GetAdminList()
                .FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                //Response.Write("<script language='javascript'>alert(\"Hatalı Kullanıcı Adı veya Şifre Girdiniz\")</script>");
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var WriterUserInfo = writerLoginManager.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (WriterUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(WriterUserInfo.WriterMail, false);
                Session["WriterMail"] = WriterUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                //Response.Write("<script language='javascript'>alert(\"Hatalı Kullanıcı Adı veya Şifre Girdiniz\")</script>");
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}