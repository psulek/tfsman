namespace TFSManager.Core
{
    /// <summary>
    /// LoginInfo
    /// </summary>
    public struct LoginInfo
    {
        private string domain;
        private string password;
        private string serverName;
        private string userName;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginInfo"/> class.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="serverName">Name of the server.</param>
        public LoginInfo(string domain, string userName, string password, string serverName)
        {
            this.domain = domain;
            this.userName = userName;
            this.password = password;
            this.serverName = serverName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginInfo"/> class.
        /// </summary>
        public LoginInfo(string serverName)
        {
            this.domain = null;
            this.userName = null;
            this.password = null;
            this.serverName = serverName;
        }

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        /// <value>The domain.</value>
        public string Domain
        {
            get
            {
                return this.domain;
            }
            set
            {
                this.domain = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        /// <value>The name of the server.</value>
        public string ServerName
        {
            get
            {
                return this.serverName;
            }
            set
            {
                this.serverName = value;
            }
        }

        /// <summary>
        /// Creates the using logged user.
        /// </summary>
        /// <returns></returns>
        public static LoginInfo CreateUsingLoggedUser(string serverName)
        {
            return new LoginInfo(null, null, null, serverName);
        }
    }
}