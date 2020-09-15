namespace FoodApp.DataModels.Shared
{
    public enum OperationType
    {
        /// <summary>
        /// Default value
        /// </summary>
        None = 0,

        /// <summary>
        /// Merge
        /// </summary>
        Merge = 1,

        /// <summary>
        /// Delete
        /// </summary>
        Delete = 2,

        /// <summary>
        /// Create
        /// </summary>
        Create = 3,

        /// <summary>
        /// Update
        /// </summary>
        Update = 4,

        /// <summary>
        /// Change password
        /// </summary>
        ChangePassword = 5,

        /// <summary>
        /// Executes cart checkout
        /// </summary>
        CartCheckOut = 6
    }
}
