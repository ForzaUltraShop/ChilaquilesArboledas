namespace ChilaquilesArboledas.Forms.Admin
{
    using FoodApp.BusinessLayer;
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    public partial class CategoryEdit : Page
    {
        public readonly CategoriesLogic categoriesLogic = new CategoriesLogic();
        
        private string ActionType
        {
            get
            {
                return ViewState["CategoryEditAction"].ToString();
            }
            set
            {
                ViewState["CategoryEditAction"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Request.QueryString["CategoryIdentifier"] != null)
                {
                    loadCategoryControls();
                    ActionType = "update";
                }
                else
                {
                    txtCategoryName.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    ActionType = "create";
                }
            }
        }

        private void loadCategoryControls()
        {
            int.TryParse(Request.QueryString["CategoryIdentifier"].ToString(), out int categoryIdentifier);
            if(categoryIdentifier > default(int))
            {
                var categoriesResponse = categoriesLogic.CategoriesGetFilteredList(new RequestDTO<CategoriesDTO>
                {
                    Item = new CategoriesDTO
                    {
                        CategoryIdentifier = categoryIdentifier
                    },
                    WordFilter = string.Empty
                });

                if (categoriesResponse.Success)
                {
                    var categoryItem = categoriesResponse.Result.FirstOrDefault();
                    txtCategoryName.Text = categoryItem.CategoryName.Trim();
                    txtDescription.Text = categoryItem.CategoryDescription.Trim();
                    chkIsActive.Checked = categoryItem.IsActive;

                    if (!string.IsNullOrEmpty(categoryItem.CategoryImagePath))
                    {
                        divCategoryImage.Visible = true;
                        imgCategory.Visible = true;
                        imgCategory.ImageUrl = Path.Combine(imgCategory.ImageUrl, categoryItem.CategoryImagePath);
                        hdfCategoryImage.Value = categoryItem.CategoryImagePath;
                    }
                    else
                    {
                        divCategoryImage.Visible = default;
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("~/Forms/Admin/Categories.aspx"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            categoryMerge();
        }

        private void categoryMerge()
        {
            int.TryParse(Request.QueryString["CategoryIdentifier"], out int categoryIdentifier);
            bool successResponse = categoriesLogic.CategoriesExecute(new RequestDTO<CategoriesDTO>
            {
                Item = new CategoriesDTO
                {
                    CategoryIdentifier = (ActionType == "create" ? default : categoryIdentifier),
                    CategoryName = txtCategoryName.Text,
                    CategoryDescription = txtDescription.Text,
                    CategoryImagePath = (ActionType == "create" ? hdfCategoryImage.Value : fuCategoryImage.PostedFile.FileName),
                    IsActive = (ActionType == "create" ? true : chkIsActive.Checked)
                },
                OperationType = (ActionType == "create" ? OperationType.Create :  OperationType.Update)
            }).Success;

            if (successResponse)
            {
                if (ActionType == "create")
                {
                    fuCategoryImage.SaveAs(Server.MapPath(string.Format("~/assets/images/{0}", fuCategoryImage.PostedFile.FileName)));
                }

                showUserMessage("La información se guardo correctamente", "success");
                loadCategoryControls();
            }
            else
            {
                showUserMessage("No fue posible guardar la información", "error");
            }
        } 

        private void showUserMessage(string message, string alertType)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            //string script = string.Format("alert('{0}')", message);

            string script = string.Format("swal('{0}','{1}','{2}')", "Admin", message, alertType);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("swal"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "swal", script, true);
            }
        }
    }
}