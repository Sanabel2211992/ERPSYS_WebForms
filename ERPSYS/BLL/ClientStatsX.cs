using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ERPSYS.BLL
{
    public class ClientStats : IHttpModule
    {
        public void Dispose()
        {
            // Nothing to dispose
        }

        public void Init(HttpApplication context)
        {
            context.PostAcquireRequestState += new EventHandler(context_PostAcquireRequestState);
        }

        private void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (!context.Request.PhysicalPath.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase))
                return;

            if (context.Session["client_width"] == null && context.Request.QueryString["sw"] == null)
            {
                context.Response.Filter = new ClientStatsFilter(context.Response.Filter);
            }
        }

        /// <summary>
        /// Gets the width of the requesting browser's window.
        /// Returns 0 if no information was retrieved from the browser.
        /// </summary>
        public static int WindowWidth
        {
            get
            {
                string width = HttpContext.Current.Session["client_width"] as string;
                int value;
                int.TryParse(width, out value);
                return value;
            }
        }

        /// <summary>
        /// Gets the height of the requesting browser's window
        /// Returns 0 if no information was retrieved from the browser.
        /// </summary>
        public static int WindowHeight
        {
            get
            {
                string height = HttpContext.Current.Session["client_height"] as string;
                int value;
                int.TryParse(height, out value);
                return value;
            }
        }

        /// <summary>
        /// Gets the width of the requesting client's screen resolution.
        /// Returns 0 if no information was retrieved from the client.
        /// </summary>
        public static int ScreenWidth
        {
            get
            {
                string width = HttpContext.Current.Session["screen_width"] as string;
                int value;
                int.TryParse(width, out value);
                return value;
            }
        }

        /// <summary>
        /// Gets the height of the requesting client's screen resolution.
        /// Returns 0 if no information was retrieved from the client.
        /// </summary>
        public static int ScreenHeight
        {
            get
            {
                string height = HttpContext.Current.Session["screen_height"] as string;
                int value;
                int.TryParse(height, out value);
                return value;
            }
        }

        /// <summary>
        /// Gets the color depth of the requesting client's screen.
        /// Returns null if no information was retrieved from the client.
        /// </summary>
        public static int ColorDepth
        {
            get
            {
                string colors = HttpContext.Current.Session["screen_color"] as string;
                int value;
                int.TryParse(colors, out value);
                return value;
            }
        }

        /// <summary>
        /// Gets whether or not any client informations is retrieved.
        /// </summary>
        public static bool IsInformationAvailable
        {
            get { return WindowHeight + WindowWidth + ScreenHeight + ScreenWidth + ColorDepth > 0; }
        }

        private class ClientStatsFilter : Stream
        {

            public ClientStatsFilter(Stream sink)
            {
                _sink = sink;
            }

            private Stream _sink;

            #region Properites

            public override bool CanRead
            {
                get { return true; }
            }

            public override bool CanSeek
            {
                get { return true; }
            }

            public override bool CanWrite
            {
                get { return true; }
            }

            public override void Flush()
            {
                _sink.Flush();
            }

            public override long Length
            {
                get { return 0; }
            }

            private long _position;
            public override long Position
            {
                get { return _position; }
                set { _position = value; }
            }

            #endregion

            #region Methods

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _sink.Read(buffer, offset, count);
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _sink.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _sink.SetLength(value);
            }

            public override void Close()
            {
                _sink.Close();
            }

            private static Regex _RegexHead = new Regex("</head>", RegexOptions.IgnoreCase);
            private static Regex _RegexBody = new Regex("<body", RegexOptions.IgnoreCase);
            private static string _JavaScript = GetJavaScript();

            /// <summary>
            /// Inserts the JavaScript to the head element of the HTML document.
            /// </summary>
            public override void Write(byte[] buffer, int offset, int count)
            {
                byte[] data = new byte[count];
                Buffer.BlockCopy(buffer, offset, data, 0, count);
                string html = System.Text.Encoding.Default.GetString(buffer);

                html = _RegexHead.Replace(html, _JavaScript);
                html = _RegexBody.Replace(html, "<body onload=\"ClientStatCheck()\" ");

                byte[] outdata = System.Text.Encoding.Default.GetBytes(html);
                _sink.Write(outdata, 0, outdata.GetLength(0));
            }

            /// <summary>
            /// Generates the JavaScript that is used to retrieve
            /// information about the client.
            /// <remarks>
            /// It currently retrieves the width and height of the window and screen,
            /// but it can easily be expanded to retrieve other information 
            /// as well. Everything that is possible to retrieve through JavaScript
            /// is also possible to expose as properties in the ClientStats class.
            /// 
            /// If you add other information to the script, remember 
            /// to update the ClientHandler and add the properties accordingly.
            /// </remarks>
            /// </summary>
            private static string GetJavaScript()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("<script type=\"text/javascript\">");
                sb.AppendLine("function ClientStatCheck(){");
                sb.AppendLine("var cw = document.body.clientWidth;");
                sb.AppendLine("var ch = document.body.clientHeight;");
                sb.AppendLine("var sw = screen.width;");
                sb.AppendLine("var sh = screen.height;");
                sb.AppendLine("var color = screen.colorDepth;");
                sb.AppendLine("location.replace('clientstats.aspx?cw='+cw+'&ch='+ch+'&sw='+sw+'&sh='+sh+'&color='+color+'&ref='+escape(top.location.href));");
                sb.AppendLine("}");
                sb.AppendLine("</script>");
                sb.AppendLine("</head>");
                return sb.ToString();
            }

            #endregion
       }

    }

    #region HttpHandler

    public class ClientHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        /// <summary>
        /// Registers the client info in session variables and redirects 
        /// the browser back to the original requested web page.
        /// <para>
        /// If this handler doesn't execute, it will not be possible to 
        /// retrieve the client information from the browser.
        /// </para>
        /// </summary>
        public void ProcessRequest(HttpContext context)
        {
            context.Session["client_width"] = context.Request.QueryString["cw"];
            context.Session["client_height"] = context.Request.QueryString["ch"];
            context.Session["screen_width"] = context.Request.QueryString["sw"];
            context.Session["screen_height"] = context.Request.QueryString["sh"];
            context.Session["screen_color"] = context.Request.QueryString["color"];

            context.Response.Redirect(context.Request.QueryString["ref"], true);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }

    #endregion
}