using System;
using System.Collections;
using System.Data;
using System.Web;
using ERPSYS.DAL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.BLL
{
    public class AuthenticationBLL
    {
        public bool AuthenticateUser(string userLoginName, string userPassword, bool isRememberMe)
        {
            try
            {
                AuthenticationDB accountDB = new AuthenticationDB();
                DataTable authenticationDt = accountDB.CheckUserAuthentication(userLoginName, userPassword);

                if (authenticationDt.Rows.Count > 0)
                {
                    int userId = authenticationDt.Rows[0][0].ToInt();

                    if (userId > 0)
                    {
                        DataSet ds = accountDB.GetLoginUserSetting(userId);

                        DataTable userDt = ds.Tables[0];
                        DataTable compnayDt = ds.Tables[1];
                        DataTable companyPreferencesDt = ds.Tables[2];

                        if (userDt.Rows.Count > 0 && compnayDt.Rows.Count > 0 && companyPreferencesDt.Rows.Count > 0)
                        {
                            DataRow userDr = userDt.Rows[0];
                            DataRow compnayDr = compnayDt.Rows[0];
                            DataRow companyPreferencesDr = companyPreferencesDt.Rows[0];

                            string displayName = userDr["DisplayName"].ToString();
                            string userName = userDr["UserName"].ToString();
                            int roleId = userDr["RoleId"].ToInt();
                            string role = userDr["Role"].ToString();
                            int departmentId = userDr["DepartmentId"].ToInt();
                            string department = userDr["Department"].ToString();
                            int locationId = userDr["LocationId"].ToInt();
                            string emailAddress = userDr["EmailAddress"].ToString();
                            string userTitle = userDr["UserTitle"].ToString();
                            bool hasCostView = userDr["HasCostView"].ToBool();
                            ArrayList alAuthorizePages = new ArrayList();
                            alAuthorizePages.AddRange(userDr["AuthorizePage"].ToString().Split(Convert.ToChar(",")));
                            int companyId = compnayDr["CompanyId"].ToInt();
                            string companyName = compnayDr["CompanyName"].ToString();
                            int currencyId = companyPreferencesDr["CurrencyId"].ToInt();
                            string currency = companyPreferencesDr["CurrencyDescription"].ToString();
                            string currencyCode = companyPreferencesDr["CurrencyCode"].ToString();
                            bool hasSalesTax = companyPreferencesDr["EnableSalesTax"].ToBool();
                            decimal salesTaxValue = companyPreferencesDr["SalesTaxValue"].ToDecimal();
                            bool hasProfilePic = userDr["UserImage"] != DBNull.Value && userDr["UserImageType"] != DBNull.Value;

                            UserSession.SetUserSessionFields(userId, userName, displayName, hasProfilePic, roleId, role, departmentId, department, locationId, emailAddress, userTitle, hasCostView, alAuthorizePages, companyId, companyName, currencyId, currency, currencyCode, hasSalesTax, salesTaxValue);

                            if (hasProfilePic && !RegisteredUser.HasProfilePictureCache)
                            {
                                UserProfileBLL.UpdateProfilePictureToCache((byte[])userDr["UserImage"], userId.ToString());
                                UserProfileBLL.UpdateProfileSmallPictureToCache(userId.ToString(), 35, 35);
                            }

                            ClsLogging.WriteInfoMessage("User LogIn");

                            if (isRememberMe)
                            {
                                HttpCookie myCookie = new HttpCookie("FTMERPX");
                                HttpContext.Current.Response.Cookies.Remove("FTMERPX");
                                HttpContext.Current.Response.Cookies.Add(myCookie);
                                myCookie.Values.Add("username", userLoginName);
                                myCookie.Values.Add("password", userPassword);
                                DateTime dtExpiry = DateTime.Now.AddDays(30);
                                var httpCookie = HttpContext.Current.Response.Cookies["FTMERPX"];
                                if (httpCookie != null)
                                    httpCookie.Expires = dtExpiry;
                            }
                            else
                            {
                                var httpCookie = HttpContext.Current.Response.Cookies["FTMERPX"];
                                if (httpCookie != null)
                                    httpCookie.Expires = DateTime.Now.AddDays(-1);
                            }

                            return true;
                        }
                    }
                    return false;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}