/*
 * Felis Consulting ©
 * Created by: Peter Šulek
 * Created: 27.03.2007
 */

using System.Net;

using Microsoft.TeamFoundation.Client;

namespace TFSManager.Core
{
    /// <summary>
    /// Team foundation utils.
    /// </summary>
    public class TFSUtils
    {
        private static TeamFoundationServer lastConnectedServer;

        /// <summary>
        /// Gets the last connected server.
        /// </summary>
        /// <value>The last connected server.</value>
        public static TeamFoundationServer LastConnectedServer
        {
            get
            {
                return lastConnectedServer;
            }
        }

        private static TeamFoundationServer CreateServer(LoginInfo info)
        {
            NetworkCredential credential;

            if (info.UserName == null)
            {
                credential = CredentialCache.DefaultNetworkCredentials;
            }
            else
            {
                credential = new NetworkCredential(info.UserName, info.Password, info.Domain);
            }

            return new TeamFoundationServer(info.ServerName, credential);
        }

        /// <summary>
        /// Tests the tfs connection.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        /// <returns></returns>
        public static bool TestConnection(string serverName)
        {
            return TestConnection(LoginInfo.CreateUsingLoggedUser(serverName));
        }

        /// <summary>
        /// Tests the tfs connection.
        /// </summary>
        /// <returns></returns>
        public static bool TestConnection(LoginInfo info)
        {
            TeamFoundationServer tfs = CreateServer(info);
            bool result = (tfs != null);

            if (result)
            {
                try
                {
                    tfs.Authenticate();
                }
                catch {}

                result = tfs.HasAuthenticated;

                if (result)
                {
                    lastConnectedServer = tfs;
                }
            }

            return result;
        }
    }
}