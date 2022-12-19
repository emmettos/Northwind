namespace EoSoftware.Northwind.WebApi;

public static class AppRole
{
    public const string ApplicationAdmin = "Application.Admin";
    public const string SupplierAdmin = "Supplier.Admin";

    public const string SupplierSpecialist = "Supplier.Specialist";
}

public static class AuthorizationPolicies
{
    public const string AssignmentToApplicationAdminRoleRequired = "AssignmentToApplicationAdminRoleRequired";
    public const string AssignmentToSupplierAdminRoleRequired = "AssignmentToSupplierAdminRoleRequired";
}
