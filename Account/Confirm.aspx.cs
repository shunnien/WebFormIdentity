﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormIdentity;
using WebFormIdentity.Helper;

public partial class Account_Confirm : System.Web.UI.Page
{
    protected string StatusMessage
    {
        get;
        private set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string code = IdentityHelper.GetCodeFromRequest(Request);
        string userId = IdentityHelper.GetUserIdFromRequest(Request);
        if (code != null && userId != null)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var result = manager.ConfirmEmail(userId, code);
            if (result.Succeeded)
            {
                successPanel.Visible = true;
                return;
            }
        }
        successPanel.Visible = false;
        errorPanel.Visible = true;
    }
}