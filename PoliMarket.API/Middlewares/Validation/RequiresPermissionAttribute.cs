using PoliMarket.Models.Enums;

namespace PoliMarket.API.Middlewares.Validation
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class RequiresPermissionAttribute : Attribute
    {
        public SistemaEnum Permission { get; }

        public RequiresPermissionAttribute(SistemaEnum permission)
        {
            Permission = permission;
        }
    }

}
