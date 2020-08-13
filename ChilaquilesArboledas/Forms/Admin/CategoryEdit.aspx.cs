namespace ChilaquilesArboledas.Forms.Admin
{
    using FoodApp.BusinnessLayer.Interface;
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Permissions;
    using System.Web.UI;

    public partial class CategoryEdit : Page
    {
        public ICategoriesLogic categoriesLogic { get; set; }
        
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

                    if (!string.IsNullOrEmpty(categoryItem.CategoryImagePath))
                    {
                        divCategoryImage.Visible = true;
                        divImageFileUpload.Visible = default;
                        imgCategory.ImageUrl = Path.Combine(imgCategory.ImageUrl, categoryItem.CategoryImagePath);
                    }
                    else
                    {
                        divCategoryImage.Visible = default;
                        divImageFileUpload.Visible = true;
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
                    CategoryImagePath = fuCategoryImage.PostedFile.FileName,
                    IsActive = (ActionType == "create" ? true : chkIsActive.Checked)
                },
                OperationType = (ActionType == "create" ? OperationType.Create :  OperationType.Update)
            }).Success;

            if (successResponse)
            {
                //TODO:Mostrar alerta
                fuCategoryImage.SaveAs(Server.MapPath(string.Format("~/assets/images/{0}", fuCategoryImage.PostedFile.FileName)));
            }
            else
            {

            }
        } 
    }
}