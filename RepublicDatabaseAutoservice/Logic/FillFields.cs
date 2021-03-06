﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.UI.WebControls;

namespace RepublicDatabaseAutoservice.Logic
{
    public class FillFields
    {
        private static string connStr = "RDAConnection";

        public static void LoadBrands(DropDownList _ddl)
        {
            DataTable brands = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetAllBrands", conn);
                    adapter.Fill(brands);

                    _ddl.DataSource = brands;
                    _ddl.DataTextField = "brand_title";
                    _ddl.DataValueField = "brand_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите марку автомобиля>", "0"));
            _ddl.SelectedIndex = 0;
        }

        public static void LoadModels(DropDownList _ddl)
        {
            DataTable models = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetAllModels", conn);
                    adapter.Fill(models);

                    _ddl.DataSource = models;
                    _ddl.DataTextField = "model_title";
                    _ddl.DataValueField = "model_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите модель автомобиля>", "0"));
            _ddl.SelectedIndex = 0;
        }

        public static void LoadRegions(DropDownList _ddl)
        {
            DataTable regions = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetAllRegions", conn);
                    adapter.Fill(regions);

                    _ddl.DataSource = regions;
                    _ddl.DataTextField = "region_title";
                    _ddl.DataValueField = "region_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите область>", "0"));
            _ddl.SelectedIndex = 0;
        }

        public static void LoadDistricts(DropDownList _ddl)
        {
            DataTable regions = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetAllDistricts", conn);
                    adapter.Fill(regions);

                    _ddl.DataSource = regions;
                    _ddl.DataTextField = "district_title";
                    _ddl.DataValueField = "district_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите район>", "0"));
            _ddl.SelectedIndex = 0;
        }

        public static void LoadCities(DropDownList _ddl)
        {
            DataTable regions = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetAllCities", conn);
                    adapter.Fill(regions);

                    _ddl.DataSource = regions;
                    _ddl.DataTextField = "city_title";
                    _ddl.DataValueField = "city_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите город>", "0"));
            _ddl.SelectedIndex = 0;
        }

        public static void LoadCountries(DropDownList _ddl)
        {
            DataTable regions = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetAllCountries", conn);
                    adapter.Fill(regions);

                    _ddl.DataSource = regions;
                    _ddl.DataTextField = "bymaker_name";
                    _ddl.DataValueField = "bymaker_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите страну>", "0"));
            _ddl.SelectedIndex = 0;
        }

        public static void LoadCategories(DropDownList _ddl)
        {
            DataTable categories = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetAllCategories", conn);
                    adapter.Fill(categories);

                    _ddl.DataSource = categories;
                    _ddl.DataTextField = "category_name";
                    _ddl.DataValueField = "category_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите категорию работ>", "0"));
            _ddl.SelectedIndex = 0;
        }

        public static void ReduceDistricts(DropDownList _ddl, string _region)
        {
            DataTable categories = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetDistrictsByRegion '" + _region + "'", conn);
                    adapter.Fill(categories);

                    _ddl.DataSource = categories;
                    _ddl.DataTextField = "district_title";
                    _ddl.DataValueField = "district_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите район>", "0"));
            _ddl.SelectedIndex = 0;
        }

        public static void ReduceCities(DropDownList _ddl, string _district)
        {
            DataTable categories = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetCitiesByDistrict '" + _district + "'", conn);
                    adapter.Fill(categories);

                    _ddl.DataSource = categories;
                    _ddl.DataTextField = "city_title";
                    _ddl.DataValueField = "city_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите город>", "0"));
            _ddl.SelectedIndex = 0;
        }

        public static void ReduceModels(DropDownList _ddl, string _brand)
        {
            DataTable categories = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC GetModelsByBrand '" + _brand + "'", conn);
                    adapter.Fill(categories);

                    _ddl.DataSource = categories;
                    _ddl.DataTextField = "model_title";
                    _ddl.DataValueField = "model_id";
                    _ddl.DataBind();
                }
                catch (Exception) { }
            }

            _ddl.Items.Insert(0, new ListItem("<Выберите модель>", "0"));
            _ddl.SelectedIndex = 0;
        }
    }
}