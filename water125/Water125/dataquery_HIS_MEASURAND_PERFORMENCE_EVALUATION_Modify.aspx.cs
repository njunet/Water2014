using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Water125
{
    public partial class dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION_Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string id = Request.Params["id"];
                    ShowInfo(int.Parse(id));
                }
                else
                {
                    Response.Redirect("dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION.aspx");
                    Response.End();
                }
            }
        }

        private void ShowInfo(int id)
        {
            Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION bll = new Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION();
            Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION model = bll.GetModel(id);
            Record_id.Text = model.id.ToString();
            Year.Text = model.year.ToString();
            COD.Text = model.COD.ToString();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Record_id.Text);
           

            Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION bll = new Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION();
            Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION model = bll.GetModel(id);
            model.year = int.Parse(this.Year.Text);
            model.COD = decimal.Parse(this.COD.Text);
            model.NH3N=decimal.Parse(this.NH3N.Text);
            model.TN=decimal.Parse(this.TN.Text);
            model.TP=decimal.Parse(this.TP.Text);
            model.CDO_density=decimal.Parse(this.CDO_density.Text);
            model.TN_density=decimal.Parse(this.TN_density.Text);
            model.TP_density=decimal.Parse(this.TP_density.Text);
            model.Nutrition_indicators=decimal.Parse(this.Nutrition_indicators.Text);
             model.near_COD_density=decimal.Parse(this.near_COD_density.Text);
             model.near_TP_density=decimal.Parse(this.near_TP_density.Text);
             model.near_TN_density=decimal.Parse(this.near_TN_density.Text);
             model.near_NH3N_density=decimal.Parse(this.near_NH3N_density.Text);
             model.Grade3_water_percent=decimal.Parse(this.Grade3_water_percent.Text);
             model.Grade5_water_percent=decimal.Parse(this.Grade5_water_percent.Text);
             model.COD_GDP=decimal.Parse(this.COD_GDP.Text);
             model.NH3N_GDP=decimal.Parse(this.NH3N_GDP.Text);
             model.Sewage_Treatment_Rate=decimal.Parse(this.Sewage_Treatment_Rate.Text);
             model.Fertilizer_intensity=decimal.Parse(this.Fertilizer_intensity.Text);
             model.Environmental_investment_GDP=decimal.Parse(this.Environmental_investment_GDP.Text);
             model.Public_satisfaction=decimal.Parse(this.Public_satisfaction.Text);
             model.Water_consumption_GDP=decimal.Parse(this.Water_consumption_GDP.Text);
             model.GDP_Increment=decimal.Parse(this.GDP_Increment.Text);
             model.GDP_per_capita=decimal.Parse(this.GDP_per_capita.Text);
             model.Primary_Industry_GDP=decimal.Parse(this.Primary_Industry_GDP.Text);
             model.Secondary_industry_GDP=decimal.Parse(this.Secondary_industry_GDP.Text);
             model.Tertiary_Industry_GDP=decimal.Parse(this.Tertiary_Industry_GDP.Text);
             model.population_density=decimal.Parse(this.population_density.Text);
             model.Urbanization_rate=decimal.Parse(this.Urbanization_rate.Text);
            bll.Update(model);
            Response.Redirect("dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION.aspx");
        }
    }
    
}