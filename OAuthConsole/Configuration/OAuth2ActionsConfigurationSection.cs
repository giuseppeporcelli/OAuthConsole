using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthConsole.Configuration
{
    /// <summary>
    /// Represents the configuration element of an OAuth2 action.
    /// </summary>
    public class OAuth2ActionConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OAuth2ActionConfigurationElement()
        { }

        /// <summary>
        /// Gets the name of the action.
        /// </summary>
        /// <value>The name of the action.</value>
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
        }

        /// <summary>
        /// Gets the method of the action.
        /// </summary>
        /// <value>The method of the action.</value>
        [ConfigurationProperty("Method", IsRequired = true)]
        public string Method
        {
            get { return (string)this["Method"]; }
        }

        /// <summary>
        /// Gets the endpoint of the action.
        /// </summary>
        /// <value>The endpoint of the action.</value>
        [ConfigurationProperty("Endpoint", IsRequired = false)]
        public string Endpoint
        {
            get { return (string)this["Endpoint"]; }
        }

        /// <summary>
        /// Gets the OAuth2 parameters configuration elements.
        /// </summary>
        /// <value>The OAuth2 parameters configuration elements.</value>
        [ConfigurationProperty("OAuth2ActionParameters")]
        public OAuth2ParametersConfigurationElementCollection OAuth2ActionParameters
        {
            get { return (OAuth2ParametersConfigurationElementCollection)this["OAuth2ActionParameters"]; }
        }
    }

    /// <summary>
    /// Represents the configuration element of an OAuth2 action parameter.
    /// </summary>
    public class OAuth2ParameterConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OAuth2ParameterConfigurationElement()
        { }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        /// <value>The name of the parameter.</value>
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
        }

        /// <summary>
        /// Gets the value of the parameter.
        /// </summary>
        /// <value>The value of the parameter.</value>
        [ConfigurationProperty("Value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["Value"]; }
        }

        /// <summary>
        /// Gets a boolean value specifying whether the parameter has to be injected as header.
        /// </summary>
        /// <value>A boolean value specifying whether the parameter has to be injected as header</value>
        [ConfigurationProperty("ParameterType", IsRequired = false, DefaultValue = "GetOrPost")]
        public string ParameterType
        {
            get { return (string)this["ParameterType"]; }
        }
    }

    /// <summary>
    /// Represents a collection of OAuth2 action configuration elements.
    /// </summary>
    public class OAuth2ActionsConfigurationElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OAuth2ActionsConfigurationElementCollection()
        { }

        /// <summary>
        /// Creates a new configuration element.
        /// </summary>
        /// <returns>The new configuration element.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new OAuth2ActionConfigurationElement();
        }

        /// <summary>
        /// Gets the element key for a specific configuration element.
        /// </summary>
        /// <param name="element">The configuration element.</param>
        /// <returns>The element key.</returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((OAuth2ActionConfigurationElement)element).Name;
        }

        /// <summary>
        /// Gets a specific service host configuration element by key.
        /// </summary>
        /// <param name="keyName">The key.</param>
        /// <value>The service host configuration element.</value>
        public new OAuth2ActionConfigurationElement this[string keyName]
        {
            get { return (OAuth2ActionConfigurationElement)BaseGet((object)keyName); }
        }

        /// <summary>
        /// Gets a specific service host configuration element by index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <value>The service host configuration element.</value>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">The index is less than 0 or there is no element at the specified index.</exception>
        public OAuth2ActionConfigurationElement this[int index]
        {
            get { return (OAuth2ActionConfigurationElement)BaseGet(index); }
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
                return "OAuth2Action";
            }
        }
    }

    /// <summary>
    /// Represents a collection of OAuth2 parameter configuration elements.
    /// </summary>
    public class OAuth2ParametersConfigurationElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OAuth2ParametersConfigurationElementCollection()
        { }

        /// <summary>
        /// Creates a new configuration element.
        /// </summary>
        /// <returns>The new configuration element.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new OAuth2ParameterConfigurationElement();
        }

        /// <summary>
        /// Gets the element key for a specific configuration element.
        /// </summary>
        /// <param name="element">The configuration element.</param>
        /// <returns>The element key.</returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((OAuth2ParameterConfigurationElement)element).Name;
        }

        /// <summary>
        /// Gets a specific service host configuration element by key.
        /// </summary>
        /// <param name="keyName">The key.</param>
        /// <value>The service host configuration element.</value>
        public new OAuth2ParameterConfigurationElement this[string keyName]
        {
            get { return (OAuth2ParameterConfigurationElement)BaseGet((object)keyName); }
        }

        /// <summary>
        /// Gets a specific service host configuration element by index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <value>The service host configuration element.</value>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">The index is less than 0 or there is no element at the specified index.</exception>
        public OAuth2ParameterConfigurationElement this[int index]
        {
            get { return (OAuth2ParameterConfigurationElement)BaseGet(index); }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName == "OAuth2Action";
        }

        public bool Contains(string keyName)
        {
            bool result = false;

            foreach (OAuth2ParameterConfigurationElement item in this)
            {
                if (string.Compare(item.Name, keyName, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }

    /// <summary>
    /// Represents the OAuth2 actions configuration section.
    /// </summary>
    public class OAuth2ActionsConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the OAuth2 actions configuration elements.
        /// </summary>
        /// <value>The OAuth2 actions configuration elements.</value>
        [ConfigurationProperty("OAuth2Actions", IsDefaultCollection = true)]
        public OAuth2ActionsConfigurationElementCollection OAuth2Actions
        {
            get { return (OAuth2ActionsConfigurationElementCollection)this["OAuth2Actions"]; }
        }
    }
}
