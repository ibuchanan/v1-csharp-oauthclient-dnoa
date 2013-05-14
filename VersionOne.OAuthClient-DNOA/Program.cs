using System;
using System.Diagnostics;
using DotNetOpenAuth.OAuth2;
using VersionOne.OAuthClient_DNOA.HardCodedSecrets;

namespace VersionOne.OAuthClient_DNOA
{
    public class Program
    {
	    // Currently VersionOne only has a single OAuth security scope.
	    private const string Scope = "apiv1";

	    // Client secrets from the VersionOne application instance
	    private static IClientSecrets _secrets;

	    // User ID is a key for getting storing and retrieving credentials
	    private const string UserId = "self";

        public static void Main(string[] args)
        {
            Console.WriteLine("\n[STEP] Load Client Secrets");
            _secrets = new HardCodedClientSecrets();
            // Quit if the secrets could not be loaded
            if (null == _secrets) Environment.Exit(1);
            Console.WriteLine("  Client ID: {0}", _secrets.ClientId);
            Console.WriteLine("  Client Name: {0}", _secrets.ClientName);
            Console.WriteLine("  Client Secret: {0}", _secrets.ClientSecret);
            if (_secrets.RedirectUris != null)
                Console.WriteLine("  Redirect URIs: {0}", _secrets.RedirectUris.ToArray());
            Console.WriteLine("  Auth URI: {0}", _secrets.AuthUri);
            Console.WriteLine("  Token URI: {0}", _secrets.TokenUri);
            Console.WriteLine("  Server Base URI: {0}", _secrets.ServerBaseUri);
            Console.WriteLine("  Expires On: {0}", _secrets.ExpiresOn);

            var client = InitializeAuthorizationFlow();
            ObtainCredentials(client);

            Console.ReadLine();
        }

        private static UserAgentClient InitializeAuthorizationFlow()
        {
            Console.WriteLine("\n[STEP] Initialize Authorization Flow");
            var client = new UserAgentClient(new Uri(_secrets.AuthUri), new Uri(_secrets.TokenUri), _secrets.ClientId, _secrets.ClientSecret);
            return client;
        }

        private static void ObtainCredentials(UserAgentClient client)
        {
            Console.WriteLine("\n[STEP] Obtain Credentials");
            RequestAuthorization(client);
            var code = ReceiveAuthorizationCode();
            return;
        }

        private static void RequestAuthorization(UserAgentClient client)
        {
            Console.WriteLine("\n[STEP] Request Authorization");
            var codeUrl = client.RequestUserAuthorization(new[] { Scope }, null, new Uri(_secrets.RedirectUris[0]));
            Console.WriteLine("  Navigate to:");
            Console.WriteLine(codeUrl);
            Process.Start(codeUrl.ToString());
            return;
        }

        private static string ReceiveAuthorizationCode()
        {
            Console.WriteLine("\n[STEP] Receive Authorization Code");
            Console.WriteLine("  Paste authorization code:");
            var code = Console.ReadLine();
            return code;
        }

        private static void RequestAccessToken()
        {
            Console.WriteLine("\n[STEP] Request Access Token");
            return;
        }

        private static void RequestResource()
        {
            Console.WriteLine("\n[STEP] Request Resource");
            return;
        }
    }
}
