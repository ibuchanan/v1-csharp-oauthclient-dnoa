using System.Collections.Generic;

namespace VersionOne.OAuthClient_DNOA
{
    internal interface IClientSecrets
    {
        string ClientId { get; }
        string ClientName { get; }
        string ClientSecret { get; }
        string AuthUri { get; }
        string TokenUri { get; }
        string ServerBaseUri { get; }
        string ExpiresOn { get; }
        List<string> RedirectUris { get; }
    }
}