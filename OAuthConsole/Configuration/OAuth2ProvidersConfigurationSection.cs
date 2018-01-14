using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthConsole.Configuration
{
    /// <summary>
    /// Represents the configuration element of an OAuth2 client.
    /// </summary>
    public class OAuth2ClientConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OAuth2ClientConfigurationElement()
        { }

        /// <summary>
        /// Gets the name of the OAuth2 client.
        /// </summary>
        /// <value>The name of the OAuth2 client.</value>
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
        }

        /// <summary>
        /// Gets the client identifier of the OAuth2 client.
        /// </summary>
        /// <value>The client identifier of the OAuth2 client.</value>
        [ConfigurationProperty("ClientId", IsRequired = true)]
        public string ClientId
        {
            get { return (string)this["ClientId"]; }
        }

        /// <summary>
        /// Gets the client secret of the OAuth2 client.
        /// </summary>
        /// <value>The client secret of the OAuth2 client.</value>
        [ConfigurationProperty("ClientSecret", IsRequired = true)]
        public string ClientSecret
        {
            get { return (string)this["ClientSecret"]; }
        }

        /// <summary>
        /// Gets the scopes of the OAuth2 client.
        /// </summary>
        /// <value>The scopes of the OAuth2 client.</value>
        [ConfigurationProperty("Scopes", IsRequired = true)]
        public string Scopes
        {
            get { return (string)this["Scopes"]; }
        }

        /// <summary>
        /// Gets the redirect URI of the OAuth2 client.
        /// </summary>
        /// <value>The redirect URI of the OAuth2 client.</value>
        [ConfigurationProperty("RedirectURI", IsRequired = true)]
        public string RedirectURI
        {
            get { return (string)this["RedirectURI"]; }
        }

        /// <summary>
        /// Gets the address of the resource endpoint.
        /// </summary>
        /// <value>The address of the resource endpoint.</value>
        [ConfigurationProperty("ResourceEndpoint", IsRequired = true)]
        public string ResourceEndpoint
        {
            get { return (string)this["ResourceEndpoint"]; }
        }
    }

    /// <summary>
    /// Represents a collection of OAuth2 client configuration elements.
    /// </summary>
    public class OAuth2ClientsConfigurationElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OAuth2ClientsConfigurationElementCollection()
        { }

        /// <summary>
        /// Creates a new configuration element.
        /// </summary>
        /// <returns>The new configuration element.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new OAuth2ClientConfigurationElement();
        }

        /// <summary>
        /// Gets the element key for a specific configuration element.
        /// </summary>
        /// <param name="element">The configuration element.</param>
        /// <returns>The element key.</returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((OAuth2ClientConfigurationElement)element).ClientId;
        }

        /// <summary>
        /// Gets a specific service host configuration element by key.
        /// </summary>
        /// <param name="keyName">The key.</param>
        /// <value>The service host configuration element.</value>
        public new OAuth2ClientConfigurationElement this[string keyName]
        {
            get { return (OAuth2ClientConfigurationElement)BaseGet((object)keyName); }
        }

        /// <summary>
        /// Gets a specific service host configuration element by index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <value>The service host configuration element.</value>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">The index is less than 0 or there is no element at the specified index.</exception>
        public OAuth2ClientConfigurationElement this[int index]
        {
            get { return (OAuth2ClientConfigurationElement)BaseGet(index); }
        }
    }


    /// <summary>
    /// Represents the configuration element of an OAuth2 provider.
    /// </summary>
    public class OAuth2ProviderConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OAuth2ProviderConfigurationElement()
        { }

        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        /// <value>The name of the provider.</value>
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
        }

        /// <summary>
        /// Gets the address of the authorization endpoint.
        /// </summary>
        /// <value>The address of the authorization endpoint.</value>
        [ConfigurationProperty("AuthorizationEndpoint", IsRequired = true)]
        public string AuthorizationEndpoint
        {
            get { return (string)this["AuthorizationEndpoint"]; }
        }

        /// <summary>
        /// Gets the address of the token endpoint.
        /// </summary>
        /// <value>The address of the token endpoint.</value>
        [ConfigurationProperty("TokenEndpoint", IsRequired = true)]
        public string TokenEndpoint
        {
            get { return (string)this["TokenEndpoint"]; }
        }

        /// <summary>
        /// Gets the OAuth2 clients configuration elements.
        /// </summary>
        /// <value>The OAuth2 clients configuration elements.</value>
        [ConfigurationProperty("OAuth2Clients")]
        public OAuth2ClientsConfigurationElementCollection OAuth2Clients
        {
            get { return (OAuth2ClientsConfigurationElementCollection)this["OAuth2Clients"]; }
        }
    }

    /// <summary>
    /// Represents a collection of OAuth2 provider configuration elements.
    /// </summary>
    public class OAuth2ProvidersConfigurationElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OAuth2ProvidersConfigurationElementCollection()
        { }

        /// <summary>
        /// Creates a new configuration element.
        /// </summary>
        /// <returns>The new configuration element.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new OAuth2ProviderConfigurationElement();
        }

        /// <summary>
        /// Gets the element key for a specific configuration element.
        /// </summary>
        /// <param name="element">The configuration element.</param>
        /// <returns>The element key.</returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((OAuth2ProviderConfigurationElement)element).Name;
        }

        /// <summary>
        /// Gets a specific service host configuration element by key.
        /// </summary>
        /// <param name="keyName">The key.</param>
        /// <value>The service host configuration element.</value>
        public new OAuth2ProviderConfigurationElement this[string keyName]
        {
            get { return (OAuth2ProviderConfigurationElement)BaseGet((object)keyName); }
        }

        /// <summary>
        /// Gets a specific service host configuration element by index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <value>The service host configuration element.</value>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">The index is less than 0 or there is no element at the specified index.</exception>
        public OAuth2ProviderConfigurationElement this[int index]
        {
            get { return (OAuth2ProviderConfigurationElement)BaseGet(index); }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "OAuth2Provider";
            }
        }
    }

    /// <summary>
    /// Represents the OAuth2 providers configuration section.
    /// </summary>
    public class OAuth2ProvidersConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the OAuth2 providers configuration elements.
        /// </summary>
        /// <value>The OAuth2 providers configuration elements.</value>
        [ConfigurationProperty("OAuth2Providers")]
        public OAuth2ProvidersConfigurationElementCollection OAuth2Providers
        {
            get { return (OAuth2ProvidersConfigurationElementCollection)this["OAuth2Providers"]; }
        }
    }
}
