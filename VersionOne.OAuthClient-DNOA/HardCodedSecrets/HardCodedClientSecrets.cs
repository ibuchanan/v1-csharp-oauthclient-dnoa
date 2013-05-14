using System.Collections.Generic;

namespace VersionOne.OAuthClient_DNOA.HardCodedSecrets
{
    class HardCodedClientSecrets : IClientSecrets
    {
        private const string CLIENT_ID = "client_kyjmamaf";
	    private const string CLIENT_NAME = "CSharp Example with DotNetOpenAuth lib";
	    private const string CLIENT_SECRET = "ybydeqg3vnjhnou5s5po";
        private static readonly List<string> REDIRECT_URIS = new List<string>() {"urn:ietf:wg:oauth:2.0:oob"};
        private const string AUTH_URI = "https://www14.v1host.com//v1sdktesting/oauth.mvc/auth";
	    private const string TOKEN_URI = "https://www14.v1host.com//v1sdktesting/oauth.mvc/token";
	    private const string SERVER_BASE_URI = "https://www14.v1host.com/v1sdktesting";
	    private const string EXPIRES_ON = "9999-12-31T23:59:59.9999999";

        public string ClientId { get { return CLIENT_ID; } }
        public string ClientName { get { return CLIENT_NAME; } }
        public string ClientSecret { get { return CLIENT_SECRET; } }
        public string AuthUri { get { return AUTH_URI;  }  }
        public string TokenUri { get { return TOKEN_URI; } }
        public string ServerBaseUri { get { return SERVER_BASE_URI; } }
        public string ExpiresOn { get { return EXPIRES_ON; } }
        public List<string> RedirectUris { get { return REDIRECT_URIS; } }
    }
}
