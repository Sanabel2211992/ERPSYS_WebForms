using System.Collections;
using System.Web;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class UserSession
    {
        public static object SessionId
        {
            get { return HttpContext.Current.Session.Contents["UserSessionData"]; }
        }
        public static int UserId
        {
            get { return HttpContext.Current.Session.Contents["UserSessionData"] != null ? ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).UserId : -1; }
        }

        public static string UserDisplayName
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).DisplayName; }
        }

        public static string UserName
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).UserName; }
        }

        public static bool HasProfilePicture
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).HasProfilePicture; }
        }

        public static int RoleId
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).RoleId; }
        }

        public static string Role
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).Role; }
        }

        public static int DepartmentId
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).DepartmentId; }
        }
        public static int LocationId
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).LocationId; }
        }

        public static string Department
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).Department; }
        }

        public static string EmailAddress
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).EmailAddress; }
        }

        public static string UserTitle
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).UserTitle; }
        }

        public static int CompanyId
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).CompanyId; }
        }

        public static string CompanyName
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).CompanyName; }
        }

        public static int CurrencyId
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).CurrencyId; }
        }

        public static string Currency
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).Currency; }
        }

        public static string CurrencyCode
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).CurrencyCode; }
        }

        public static bool HasSalesTax
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).HasSalesTax; }
        }

        public static decimal SalesTaxValue
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).SalesTaxValue; }
        }

        public static int RoundDigit
        {
            get { return 2; }
        }

        public static bool HasCostView
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).HasCostView; }
        }

        public static ArrayList AuthorizePages
        {
            get { return ((SessionValues)HttpContext.Current.Session.Contents["UserSessionData"]).AuthorizePages; }
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

        public static void SetUserSessionFields(int userId, string username, string displayName, bool hasProfilePic, int roleId, string role, int departmentId, string department, int locationId, string emailAddress, string userTitle, bool hasCostView, ArrayList alAuthorizePages, int companyId, string compnayName, int currencyId, string currency, string currencyCode, bool hasSalesTax, decimal salesTaxValue)
        {
            SessionValues sessionValues = new SessionValues();

            sessionValues.UserId = userId;
            sessionValues.UserName = username;
            sessionValues.DisplayName = displayName;
            sessionValues.HasProfilePicture = hasProfilePic;
            sessionValues.RoleId = roleId;
            sessionValues.Role = role;
            sessionValues.DepartmentId = departmentId;
            sessionValues.Department = department;
            sessionValues.LocationId = locationId;
            sessionValues.EmailAddress = emailAddress;
            sessionValues.UserTitle = userTitle;
            sessionValues.HasCostView = hasCostView;
            sessionValues.AuthorizePages = alAuthorizePages;
            sessionValues.CompanyId = companyId;
            sessionValues.CompanyName = compnayName;
            sessionValues.CurrencyId = currencyId;
            sessionValues.Currency = currency;
            sessionValues.CurrencyCode = currencyCode;
            sessionValues.HasSalesTax = hasSalesTax;
            sessionValues.SalesTaxValue = salesTaxValue;

            HttpContext.Current.Session.Add("UserSessionData", sessionValues);
        }

        public static void UpdateProfileHasPictureSession(bool value)
        {
            SessionValues sessionValues = (SessionValues)HttpContext.Current.Session.Contents["UserSessionData"];
            sessionValues.HasProfilePicture = value;
            HttpContext.Current.Session.Add("UserSessionData", sessionValues);
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}