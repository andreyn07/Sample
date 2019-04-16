using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DogAndPuppy
{
    public partial class DogMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                LoadDropDowns();
            }
        }

        private void LoadDropDowns()
        {
            var db = new DBAccess();
            DataTable dt = db.GetDog();
            ddlDog.DataSource = dt;
            ddlDog.DataValueField = "DogID";
            ddlDog.DataTextField = "Name";
            ddlDog.DataBind();
            ddlDog.Items.Insert(0, "Please Select Dog Name");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // ViewState["DogVS"] = ddlDog.SelectedValue.ToString();
            Session["DogID"] = ddlDog.SelectedValue.ToString(); 
            Session["DogName"] = ddlDog.SelectedItem;
            Response.Redirect("~/DogUpdate.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void ddlDog_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            {
                dvButton.Visible = ddlDog.SelectedIndex > 0 ? true : false;
                
               

            }
            if (ddlDog.SelectedIndex > 0)
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            
        }
    }
}