using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTS_Web_App
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usr = TextBox1.Text.Trim().ToUpper();
            string psswrd = TextBox2.Text;

            //Verify the credentials against database. Here I hard coded for simplicity.
            if (usr == "123" && psswrd == "123")
            {
                FormsAuthentication.SetAuthCookie(usr, true);
                string retrnUrl = Request.QueryString["returnUrl"];
                if (!string.IsNullOrEmpty(retrnUrl))
                {
                    //Redirect to Original requested page
                    FormsAuthentication.RedirectFromLoginPage(usr, Persist.Checked);
                }
                else
                {
                    //If user directly opened login page, always show him Homepage.
                    Response.Redirect("/Default.aspx");
                }
            }
            else
            {
                //If Credentials are wrong, show him error message.
                Label1.Text = "User name or password is wrong";
                Label1.ForeColor = Color.Red;
            }

        }
    }
}