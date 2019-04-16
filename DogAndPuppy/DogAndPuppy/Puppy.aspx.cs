using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DogAndPuppy
{
    public partial class Puppy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dvDogName.Visible = false;
                pnMain.Visible = false;
                LoadDropDowns();
            }
            
        }

        protected void ddlBreed_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvDogName.Visible = false;
            pnMain.Visible = false;
            if (ddlBreed.SelectedIndex > 0)
            {
                dvDogName.Visible = false;
                var db = new DBAccess();
                int breedId = Convert.ToInt32(ddlBreed.SelectedValue);
                DataTable dt = db.GetDog(breedId);
                if (dt != null)
                {
                    dvDogName.Visible = true;
                    ddlDog.DataSource = dt;
                    ddlDog.DataValueField = "DogId";
                    ddlDog.DataTextField = "Name";
                    ddlDog.DataBind();
                    ddlDog.Items.Insert(0, "Please Select Dog Name");
                }
                else
                {
                    lblMessage.Text = "There is no dogs with this breedId";
                }
                
            }
        }

        protected void ddlDog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDog.SelectedIndex > 0)
            {
                 pnMain.Visible = true;
            }
            else pnMain.Visible = false;
        }

        private void LoadDropDowns()
        {
            var db = new DBAccess();
            DataSet ds = db.GetLookup();
            DataTable dt = ds.Tables[0];
            ddlSize.DataSource = dt;
            ddlSize.DataValueField = "SizeID";
            ddlSize.DataTextField = "Size";
            ddlSize.DataBind();
            ddlSize.Items.Insert(0, "Please Select Size");

            dt = ds.Tables[1];
            ddlColor.DataSource = dt;
            ddlColor.DataValueField = "ColorID";
            ddlColor.DataTextField = "Color";
            ddlColor.DataBind();
            ddlColor.Items.Insert(0, "Please Select Color");

            dt = ds.Tables[2];
            ddlGender.DataSource = dt;
            ddlGender.DataValueField = "GenderID";
            ddlGender.DataTextField = "Gender";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, "Please Select Gender");

            dt = ds.Tables[3];
            ddlBreed.DataSource = dt;
            ddlBreed.DataValueField = "BreedID";
            ddlBreed.DataTextField = "Breed";
            ddlBreed.DataBind();
            ddlBreed.Items.Insert(0, "Please Select Breed");

            dt = ds.Tables[4];
            ddlState.DataSource = dt;
            ddlState.DataValueField = "StateID";
            ddlState.DataTextField = "State";
            ddlState.DataBind();
            ddlState.Items.Insert(0, "Please Select State");

            dt = ds.Tables[5];
            ddlCountry.DataSource = dt;
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataTextField = "Country";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, "Please Select Country");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            string name = txtName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string stateID = ddlState.SelectedValue.ToString();
            string zipcode = txtZip.Text;
            int countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            int colorId = Convert.ToInt32(ddlColor.SelectedValue);
            int sizeId = Convert.ToInt32(ddlSize.SelectedValue);
            int genderId = Convert.ToInt32(ddlGender.SelectedValue);
            int dogId = Convert.ToInt32(ddlDog.SelectedValue);
            decimal price = Convert.ToDecimal(txtPrice.Text);
            string val = txtDOB.Text;
            string dob = val.Substring(4, 4) + "-" +
                         val.Substring(0, 2) + "-" +
                         val.Substring(2, 2);
            string firstname = txtFirstname.Text;
            string lastname = txtLastName.Text;
            string msg = "";
            var db = new DBAccess();
            int puppyId = db.SetPuppy(name, address, city, stateID, zipcode,
                countryId, colorId, sizeId, genderId, dogId, price, dob,
                firstname, lastname, ref msg);
            if (puppyId > 0)
            {
                lblMessage.Text = "New Puppy was succesfully added  = " + puppyId;
                ClearScreen();
            }
            else
                lblMessage.Text = msg;
        }

        private void ClearScreen()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtZip.Text = "";
            txtPrice.Text = "";
            txtDOB.Text = "";
            ddlState.SelectedIndex = 0;
            ddlColor.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            ddlSize.SelectedIndex = 0;
        }
    }
}