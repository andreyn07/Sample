using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DogAndPuppy
{
    public partial class DogUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                hdDogID.Value = Session["DogID"].ToString();
                txtName.Text = Session["DogName"].ToString();
                LoadDropDowns();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string stateID = ddlState.SelectedValue.ToString();
            string zipcode = txtZip.Text;
            int countryID = Convert.ToInt32(ddlCountry.SelectedValue);
            int breedID = Convert.ToInt32(ddlBreed.SelectedValue);
            int colorID = Convert.ToInt32(ddlColor.SelectedValue);
            int sizeID = Convert.ToInt32(ddlSize.SelectedValue);
            int genderID = Convert.ToInt32(ddlGender.SelectedValue);
            int dogId = 0;
            var db = new DBAccess();
            db.SetDog(name, address, city, stateID, zipcode, countryID, breedID,
                colorID, sizeID, genderID, ref dogId);
            if (dogId > 0)
            {
                lblMessage.Text = "Dog was inserted succesfully with DogID = " + dogId;
                CLearScreen();
            }

        }

        private void CLearScreen()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtZip.Text = "";
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

            int dogId = Convert.ToInt32(hdDogID.Value);
            dt = db.GetDog(null, dogId);
            DataRow dr = dt.Rows[0];
            txtAddress.Text = dr["Address"].ToString();
            txtCity.Text = dr["City"].ToString();
            txtZip.Text = dr["Zipcode"].ToString();
            ddlSize.SelectedValue = dr["SizeID"].ToString();
            ddlColor.SelectedValue = dr["ColorID"].ToString();
            ddlGender.SelectedValue = dr["GenderID"].ToString();
            ddlBreed.SelectedValue = dr["BreedID"].ToString();
            ddlState.SelectedValue = dr["StateID"].ToString();
            ddlCountry.SelectedValue = dr["CountryID"].ToString();



        }


    
    }
}