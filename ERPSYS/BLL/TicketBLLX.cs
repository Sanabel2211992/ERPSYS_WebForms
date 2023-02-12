using System.Data;
using ERPSYS.DAL;
using ERPSYS.Members;
using ERPSYS.Helpers.Ext;
using System.Collections.Generic;
using ERPSYS.Helpers;
using System;
using System.Drawing;

namespace ERPSYS.BLL
{
    public class TicketBLLx
    {
        private readonly TicketDBx _ticket = new TicketDBx();

        //**************************************************************************************************************************//SELECT

        public DataTable GetTicketList(DateTime startDate, DateTime endDate, string ticketNumber, int statusId)
        {
            return _ticket.GetTicketList(startDate, endDate, ticketNumber, statusId);
        }

        public Ticket GetTicket(int ticketId)
        {
            DataTable dtTicket = _ticket.GetTicket(ticketId);

            Ticket ticket = new Ticket();


            if (dtTicket.Rows.Count == 0)
            {
                ticket.TicketId = -1;
                return ticket;
            }

            DataRow dr = dtTicket.Rows[0];

            ticket.TicketId = dr["TicketId"].ToInt();
            ticket.TicketNumber = dr["TicketNumber"].ToString();
            ticket.TicketDate = dr["TicketDate"].ToDateTime();
            ticket.IssueDate = dr["IssueDate"].ToDateTime();
            ticket.PriorityId = dr["PriorityId"].ToInt();
            ticket.Priority = dr["TicketPriority"].ToString();
            ticket.TypeId = dr["TypeId"].ToInt();
            ticket.Type = dr["TicketType"].ToString();
            ticket.AssignedUserId = dr["AssignedUserId"].ToInt();
            ticket.AssignedUser = dr["AssignedUser"].ToString();
            ticket.ServiceId = dr["ServiceId"].ToInt();
            ticket.Service = dr["TicketService"].ToString();
            ticket.Issue = dr["TicketIssue"].ToString();
            ticket.IssueSource = dr["TicketIssueSource"].ToString();
            ticket.IssueStatusId = dr["IssueStatusId"].ToInt();
            ticket.IssueStatus = dr["IssueStatus"].ToString();
            ticket.Subject = dr["Subject"].ToString();
            ticket.UserId = dr["CreatedUserId"].ToInt();
            ticket.UserName = dr["CreatedUser"].ToString();
            ticket.AssignedTeamId = dr["AssignedTeamId"].ToInt();
            ticket.AssignedTeam = dr["AssignedTeam"].ToString();
            ticket.AssignedUserId = dr["AssignedUserId"].ToInt();
            ticket.AssignedUser = dr["AssignedUser"].ToString();
            ticket.AssignedUserEmail = dr["AssignedUserEmail"].ToString();

            ticket.CategoryId = dr["CategoryId"].ToInt();
            ticket.Category = dr["TicketCategory"].ToString();

            ticket.StatusId = dr["StatusId"].ToInt();
            ticket.Status = dr["TicketStatus"].ToString();

            return ticket;
        }

        public TicketThread GetTicketThread(int ticketId, int threadId)
        {
            DataSet dsThread = _ticket.GetTicketThread(ticketId, threadId);

            DataTable dtThread = dsThread.Tables[0];
            DataTable dtThreadAttachment = dsThread.Tables[1];

            TicketThread thread = new TicketThread();

            DataRow dr = dtThread.Rows[0];

            thread.ThreadId = dr["ThreadId"].ToInt();
            thread.TicketId = dr["TicketId"].ToInt();
            thread.UserId = dr["UserId"].ToInt();
            thread.UserName = dr["UserName"].ToString();
            thread.DisplayName = dr["DisplayName"].ToString();
            thread.ThreadDate = dr["ThreadDate"].ToDateTime();
            thread.UserIPAddress = dr["IPAddress"].ToString();
            thread.ThreadType = dr["ThreadType"].ToString();
            thread.ThreadLabel = dr["ThreadLabel"].ToString();
            thread.Body = dr["Body"].ToString();
            thread.HasAttachment = dr["HasAttachment"].ToBool();

            List<ThreadAttachment> lstAttachment = new List<ThreadAttachment>();

            foreach (DataRow drAttachment in dtThreadAttachment.Rows)
            {
                ThreadAttachment attachment = new ThreadAttachment();

                attachment.TicketId = drAttachment["TicketId"].ToInt();
                attachment.ThreadId = drAttachment["ThreadId"].ToInt();
                attachment.AttachmentName = drAttachment["AttachmentName"].ToString();
                attachment.AttachmentKey = drAttachment["AttachmentKey"].ToString();

                lstAttachment.Add(attachment);
            }

            thread.Attachment = lstAttachment;

            return thread;
        }

        public List<TicketThread> GetTicketThreads(int ticketId)
        {
            DataSet dsThread = _ticket.GetTicketThreads(ticketId);

            DataTable dtThread = dsThread.Tables[0];
            DataTable dtThreadAttachment = dsThread.Tables[1];

            List<TicketThread> lstThread = new List<TicketThread>();

            foreach (DataRow dr in dtThread.Rows)
            {
                var thread = new TicketThread();

                thread.ThreadId = dr["ThreadId"].ToInt();
                thread.TicketId = dr["TicketId"].ToInt();
                thread.UserId = dr["UserId"].ToInt();
                thread.UserName = dr["UserName"].ToString();
                thread.DisplayName = dr["DisplayName"].ToString();
                thread.ThreadDate = dr["ThreadDate"].ToDateTime();
                thread.UserIPAddress = dr["IPAddress"].ToString();
                thread.ThreadType = dr["ThreadType"].ToString();
                thread.ThreadLabel = dr["ThreadLabel"].ToString();
                thread.Body = dr["Body"].ToString();
                thread.HasAttachment = dr["HasAttachment"].ToBool();

                List<ThreadAttachment> lstAttachment = new List<ThreadAttachment>();

                foreach (DataRow drAttachment in dtThreadAttachment.Rows)
                {
                    if (dr["ThreadId"].ToInt() == drAttachment["ThreadId"].ToInt())
                    {
                        ThreadAttachment attachment = new ThreadAttachment();

                        attachment.TicketId = drAttachment["TicketId"].ToInt();
                        attachment.ThreadId = drAttachment["ThreadId"].ToInt();
                        attachment.AttachmentName = drAttachment["AttachmentName"].ToString();
                        attachment.AttachmentKey = drAttachment["AttachmentKey"].ToString();

                        lstAttachment.Add(attachment);
                    }
                }

                thread.Attachment = lstAttachment;
                lstThread.Add(thread);
            }

            return lstThread;
        }

        //**************************************************************************************************************************//INSERT


        //**************************************************************************************************************************//UPDATE

        
        //**************************************************************************************************************************//DELETE


        //**************************************************************************************************************************//SETTING SELECT

        public TicketSettings GetTicketSettings()
        {
            DataTable dt = _ticket.GetTicketSettings();

            TicketSettings settings = new TicketSettings();

            if (dt.Rows.Count == 0)
            {
                return settings;
            }

            DataRow dr = dt.Rows[0];
            settings.URL = dr["URL"].ToString();
            settings.SiteName = dr["Title"].ToString();
            settings.EmailId = dr["EmailId"].ToInt();
            settings.ToMail = dr["ToMail"].ToString();
            settings.CcMail = dr["CcMail"].ToString();
            settings.BccMail = dr["BccMail"].ToString();

            return settings;
        }

        public DataTable GetTicketCategoryList()
        {
            return _ticket.GetTicketCategoryList();
        }

        public TicketCategory GetCategoryDetails(int categoryId)
        {
            DataTable dt = _ticket.GetCategoryDetails(categoryId);

            TicketCategory category = new TicketCategory();

            if (dt.Rows.Count == 0)
            {
                category.CategoryId = -1;
                return category;
            }

            DataRow dr = dt.Rows[0];

            category.CategoryId = categoryId;
            category.Name = dr["Name"].ToString();
            category.Description = dr["Description"].ToString();
            category.IsActive = dr["IsActive"].ToBool();

            return category;
        }

        public DataTable GetTicketDepartmentList()
        {
            return _ticket.GetTicketDepartmentList();
        }

        public TicketDepartment GetDepartmentDetails(int departmentId)
        {
            DataTable dt = _ticket.GetDepartmentDetails(departmentId);

            TicketDepartment department = new TicketDepartment();

            if (dt.Rows.Count == 0)
            {
                department.DepartmentId = -1;
                return department;
            }

            DataRow dr = dt.Rows[0];

            department.DepartmentId = departmentId;
            department.Name = dr["Name"].ToString();
            department.Description = dr["Description"].ToString();
            department.IsActive = dr["IsActive"].ToBool();

            return department;
        }
        //**************************************************************************************************************************//SETTING INSERT

        public int AddCategory(TicketCategory category, out string rMsg)
        {
            return _ticket.AddCategory(category, out rMsg);
        }

        public int AddDepartment(TicketDepartment department, out string rMsg)
        {
            return _ticket.AddDepartment(department, out rMsg);
        }
        //**************************************************************************************************************************//SETTING UPDATE

        public int UpdateTicketSettings(TicketSettings settings, out string rMsg)
        {
            return _ticket.UpdateTicketSettings(settings, out rMsg);
        }

        public void UpdateCategory(TicketCategory category, out string rMessage)
        {
            _ticket.UpdateCategory(category, out rMessage);
        }

        public void UpdateDepartment(TicketDepartment department, out string rMessage)
        {
            _ticket.UpdateDepartment(department, out rMessage);
        }

        //**************************************************************************************************************************//SETTING DELETE


        //**************************************************************************************************************************//STATIC

        public static Color PriorityColor(int priorityId)
        {
            switch (priorityId)
            {
                case 1:
                    return Color.SkyBlue;
                case 2:
                    return Color.Black;
                case 3:
                    return Color.Red;
                case 4:
                    return Color.Red;
                default:
                    return Color.Blue;
            }
        }

        public static Color StatusColor(int statusId)
        {
            switch (statusId)
            {
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Black;
                case 4:
                    return Color.Black;
                default:
                    return Color.Blue;
            }
        }
    }
}