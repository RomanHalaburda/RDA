﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using RepublicDatabaseAutoservice.Logic;

namespace RepublicDatabaseAutoservice
{
    public partial class Search : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillFields.LoadBrands(ddlBrand);
                FillFields.LoadRegions(ddlRegion);
                FillFields.LoadCategories(ddlCategory);
                FillFields.LoadModels(ddlModel);
                FillFields.LoadCities(ddlCity);
                FillFields.LoadDistricts(ddlDistrict);
                FillFields.LoadCountries(ddlCountry);
            }
        }

        private void GenerateHTML(DataTable _dt)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<br><center><table border = '1'><tr>");
            foreach (DataColumn column in _dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");

            foreach (DataRow row in _dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in _dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }

            html.Append("</table></center>");

            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegion.SelectedIndex == 0)
            {
                ddlDistrict.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
            }
            else
            {
                FillFields.ReduceDistricts(ddlDistrict, ddlRegion.SelectedItem.Text);
                ddlDistrict.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistrict.SelectedIndex == 0)
            {
                ddlCity.SelectedIndex = 0;
            }
            else
            {
                FillFields.ReduceCities(ddlCity, ddlDistrict.SelectedItem.Text);
            }
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex == 0)
            {
                ddlModel.SelectedIndex = 0;
            }
            else
            {
                FillFields.ReduceModels(ddlModel, ddlBrand.SelectedItem.Text);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string region = ddlRegion.SelectedItem.Text;
            string district = ddlDistrict.SelectedItem.Text;
            string city = ddlCity.SelectedItem.Text;

            string brand = ddlBrand.SelectedItem.Text;
            string model = ddlModel.SelectedItem.Text;

            string category = ddlCategory.SelectedItem.Text;

            string age = tbAge.Text;
            string country = ddlCountry.SelectedItem.Text;

            DataTable dt = CallStoredProcedure.spGetSto(region, district, city, brand, model, category, age, country);
            GenerateHTML(dt);
        }
        /*
        protected void Button1_Click(object sender, EventArgs e) { }

        protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRegion = DropDownList2.Items[System.Convert.ToInt32(DropDownList2.SelectedValue)].Text;
            DataTable dt = CallStoredProcedure.spGetStoByRegion(DropDownList2.SelectedItem.Text);
            GenerateHTML(dt);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = CallStoredProcedure.spGetStoByDistrict(TextBox2.Text);
            GenerateHTML(dt);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataTable dt = CallStoredProcedure.spGetStoByCity(TextBox3.Text);
            GenerateHTML(dt);
        }

        protected void Button4_Click(object sender, EventArgs e) { }

        protected void ddl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCategory = DropDownList3.Items[System.Convert.ToInt32(DropDownList3.SelectedValue)].Text;
            DataTable dt = CallStoredProcedure.spGetStoByCategory(DropDownList3.SelectedItem.Text);
            GenerateHTML(dt);
        }
          
        protected void Button5_Click(object sender, EventArgs e)
        {
            DataTable dt = CallStoredProcedure.spGetStoByBrandAndModel(DropDownList4.SelectedItem.Text, DropDownList5.SelectedItem.Text);
            GenerateHTML(dt);
        }

        protected void Button6_Click(object sender, EventArgs e) { }

        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBrand = DropDownList1.Items[System.Convert.ToInt32(DropDownList1.SelectedValue)].Text;
            DataTable dt = CallStoredProcedure.spGetStoByBrand(DropDownList1.SelectedItem.Text);
            GenerateHTML(dt);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            DataTable dt = CallStoredProcedure.spGetStoByAgeAuto(TextBox8.Text);
            GenerateHTML(dt);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            DataTable dt = CallStoredProcedure.spGetStoByAgeAndMakerCountry(TextBox9.Text, TextBox10.Text);
            GenerateHTML(dt);
        }*/
    }
}