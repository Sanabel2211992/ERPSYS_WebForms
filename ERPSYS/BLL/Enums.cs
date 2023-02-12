namespace ERPSYS.BLL
{
    //public enum MessageBoxTypes
    //{
    //    Error = 0,
    //    Warning = 1,
    //    Success = 2,
    //    Info = 3,
    //    Delete = 4,
    //    None = 5
    //}

    public enum MessageBoxTypes
    {
        None = 0,
        Info = 1,
        Success = 2,
        Warning = 3,
        Error = 4,
        Deny = 5,
        Edit = 6,
        Delete = 7
    }

    public enum FileAttachmentTypes
    {
        Image = 1,
        PDF = 2,
        Excel = 3
    }

    public enum FileAttachmentLocationTypes
    {
        System
    }

    public enum SalesInvoiceRefundTypes
    {
        Whole = 1,
        Individual = 2
    }

    public enum MailMessagePriority
    {
        Normal = 0,
        Low = 1,
        High = 2
    }

    public enum ExcelType
    {
        Xls = 1,
        Xlsx = 2
    }
}