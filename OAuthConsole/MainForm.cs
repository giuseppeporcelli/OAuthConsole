using mshtml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OAuthConsole.Configuration;
using RestSharp;
using RestSharp.Contrib;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAuthConsole
{

    public partial class MainForm : Form
    {
        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;
        private int _counter = 0;
        private BindingList<InvokeResultItem> _invokeResults = new BindingList<InvokeResultItem>();

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        private const string DefaultPageAddress = "http://www.amazon.com/";

        private BindingSource _parameters = new BindingSource();
        private OAuth2ProvidersConfigurationSection _providersConfigurationSection = null;
        private OAuth2ActionsConfigurationSection _actionsConfigurationSection = null;
        private OAuth2ProviderConfigurationElement _selectedProvider = null;
        private OAuth2ActionConfigurationElement _selectedAction = null;

        public MainForm()
        {
            InitializeComponent();

            //elementHost1.Child = new WPFWebBrowser();
            //((WPFWebBrowser)elementHost1.Child).wbMain.Navigated += wbMain_Navigated;
            //((WPFWebBrowser)elementHost1.Child).wbMain.Navigating += wbMain_Navigating;
            //((WPFWebBrowser)elementHost1.Child).wbMain.LoadCompleted += wbMain_LoadCompleted;

            dgInvokeResults.AutoGenerateColumns = false;
            dgInvokeResults.DataSource = _invokeResults;

            List<Tuple<string, ParameterType>> parameterTypes = new List<Tuple<string, ParameterType>>();
            parameterTypes.Add(new Tuple<string, ParameterType>(ParameterType.Cookie.ToString(), ParameterType.Cookie));
            parameterTypes.Add(new Tuple<string, ParameterType>(ParameterType.GetOrPost.ToString(), ParameterType.GetOrPost));
            parameterTypes.Add(new Tuple<string, ParameterType>(ParameterType.HttpHeader.ToString(), ParameterType.HttpHeader));
            parameterTypes.Add(new Tuple<string, ParameterType>(ParameterType.RequestBody.ToString(), ParameterType.RequestBody));
            parameterTypes.Add(new Tuple<string, ParameterType>(ParameterType.UrlSegment.ToString(), ParameterType.UrlSegment));

            colParameterType.DataSource = parameterTypes;
            colParameterType.DisplayMember = "Item1";
            colParameterType.ValueMember = "Item2";

            LoadConfiguration();

            webBrowserWinForm.Navigate(DefaultPageAddress);
        }

        private void LoadJsonInTree(string jsonString)
        {
            jsonTree.Nodes.Clear();

            var rootNode = new TreeNode("JSON");
            jsonTree.Nodes.Add(rootNode);

            jsonString = jsonString.Trim();
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                JObject myObject = null;
                
                try
                {
                    if (jsonString.StartsWith("["))
                    {
                        JArray myArray = JArray.Parse(jsonString);
                        myObject = new JObject();
                        myObject.Add("", myArray);
                    }
                    else
                    {   
                        myObject = JObject.Parse(jsonString);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (myObject != null)
                {
                    LoadObjectInTree(rootNode, myObject);
                }
            }
        }

        private void LoadObjectInTree(TreeNode parentNode, JObject sourceObject)
        {
            foreach (var property in sourceObject.Properties())
            {
                if (property.Value is JValue)
                {
                    JValue jValue = (JValue)property.Value;

                    string value = "";

                    if (jValue.Type == JTokenType.Null)
                    {
                        value = "null";
                    }
                    else
                    {
                        value = jValue.Value.ToString();
                    }

                    TreeNode node = new TreeNode(property.Name + " : " + value);
                    node.Tag = value;
                    node.ContextMenuStrip = cMenuJsonTree;

                    parentNode.Nodes.Add(node);
                }
                else if (property.Value is JArray)
                {
                    TreeNode arrayNode = new TreeNode("[ ] " + property.Name);
                    parentNode.Nodes.Add(arrayNode);

                    JArray array = (JArray)property.Value;
                    LoadArrayInTree(arrayNode, array);
                }
                else if (property.Value is JObject)
                {
                    TreeNode objectNode = new TreeNode("{ } " + property.Name);
                    parentNode.Nodes.Add(objectNode);

                    LoadObjectInTree(objectNode, (JObject)property.Value);
                }
            }
        }

        private void LoadArrayInTree(TreeNode parentNode, JArray sourceObject)
        {
            for (int i = 0; i < sourceObject.Count; ++i)
            {
                JToken token = sourceObject[i];

                if (token is JValue)
                {
                    JValue jValue = (JValue)token;

                    string value = "";

                    if (jValue.Type == JTokenType.Null)
                    {
                        value = "null";
                    }
                    else
                    {
                        value = jValue.Value.ToString();
                    }

                    TreeNode node = new TreeNode(value);
                    node.Tag = value;
                    node.ContextMenuStrip = cMenuJsonTree;

                    parentNode.Nodes.Add(node);
                }
                else if (token is JArray)
                {
                    TreeNode arrayNode = new TreeNode("[ ] " + i);
                    parentNode.Nodes.Add(arrayNode);

                    JArray array = (JArray)token;
                    LoadArrayInTree(arrayNode, array);
                }
                else if (token is JObject)
                {
                    TreeNode objectNode = new TreeNode("{ } " + i);
                    parentNode.Nodes.Add(objectNode);

                    LoadObjectInTree(objectNode, (JObject)token);
                }
            }
        }


        void wbMain_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            pbLoading.MarqueeAnimationSpeed = 0;
            pbLoading.Refresh();
        }

        void wbMain_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            pbLoading.MarqueeAnimationSpeed = 30;

            try
            {
                string redirectURIParameter = GetCurrentRedirectUriParameter();

                if (!string.IsNullOrWhiteSpace(redirectURIParameter))
                {
                    Uri redirectUri = new Uri(redirectURIParameter);

                    if (e.Uri.Host == redirectUri.Host && e.Uri.LocalPath == redirectUri.LocalPath && e.Uri.Scheme == "x-cez")
                    {
                        tbMain.SelectedTab = tbMain.TabPages[0];

                        InvokeResultItem item = new InvokeResultItem();
                        item.Reference = ++_counter;
                        item.StatusCode = null;
                        item.Content = HttpUtility.UrlDecode(e.Uri.ToString());

                        if (string.IsNullOrWhiteSpace(e.Uri.Fragment))
                        {
                            item.ExpectedContent = InvokeResultExpectedContent.AuthorizationCodeInQueryString;
                        }
                        else
                        {
                            item.ExpectedContent = InvokeResultExpectedContent.TokenInFragment;
                        }

                        _invokeResults.Insert(0, item);
                        dgInvokeResults.Rows[0].Selected = true;

                        pbLoading.MarqueeAnimationSpeed = 0;
                        pbLoading.Refresh();
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void wbMain_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Cursor.Current = Cursors.Default;

            txtAddressBar.Text = e.Uri.ToString();

            try
            {
                string redirectURIParameter = GetCurrentRedirectUriParameter();

                if (!string.IsNullOrWhiteSpace(redirectURIParameter))
                {
                    Uri redirectUri = new Uri(redirectURIParameter);

                    if (e.Uri.Host == redirectUri.Host && e.Uri.LocalPath == redirectUri.LocalPath)
                    {
                        tbMain.SelectedTab = tbMain.TabPages[0];

                        InvokeResultItem item = new InvokeResultItem();
                        item.Reference = ++_counter;
                        item.StatusCode = null;
                        item.Content = HttpUtility.UrlDecode(e.Uri.ToString());

                        if (string.IsNullOrWhiteSpace(e.Uri.Fragment))
                        {
                            item.ExpectedContent = InvokeResultExpectedContent.AuthorizationCodeInQueryString;
                        }
                        else
                        {
                            item.ExpectedContent = InvokeResultExpectedContent.TokenInFragment;
                        }

                        _invokeResults.Insert(0, item);
                        dgInvokeResults.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCurrentRedirectUriParameter()
        {
            string redirectURI = "";

            foreach (RestParameter parameter in _parameters)
            {
                if (parameter.Name == "redirect_uri")
                {
                    redirectURI = parameter.Value;
                    break;
                }
            }

            return redirectURI;
        }

        private void LoadConfiguration()
        {
            cbxMethod.SelectedIndex = 0;

            _parameters.Add(new RestParameter());

            dgParameters.AutoGenerateColumns = false;
            dgParameters.DataSource = _parameters;

            _providersConfigurationSection = (OAuth2ProvidersConfigurationSection)ConfigurationManager.GetSection("OAuth2ProvidersConfigurationSection");
            _actionsConfigurationSection = (OAuth2ActionsConfigurationSection)ConfigurationManager.GetSection("OAuth2ActionsConfigurationSection");

            // Loading providers.
            List<string> providerNames = new List<string>();
            foreach (OAuth2ProviderConfigurationElement element in _providersConfigurationSection.OAuth2Providers)
            {
                providerNames.Add(element.Name);
            }
            cbxProviders.DataSource = providerNames;

            // Loading actions.
            List<OAuth2ActionConfigurationElement> actions = new List<OAuth2ActionConfigurationElement>();
            actions.Add(new OAuth2ActionConfigurationElement());
            foreach (OAuth2ActionConfigurationElement element in _actionsConfigurationSection.OAuth2Actions)
            {
                actions.Add(element);
            }
            cbxActions.DataSource = actions;
            cbxActions.DisplayMember = "Name";
        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            if (chkRunWithoutCookies.Checked)
            {
                InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
            }

            string endpointToInvoke = txtInvokedEndpoint.Text;

            if (!string.IsNullOrWhiteSpace(endpointToInvoke))
            {
                string method = (string)cbxMethod.SelectedItem;

                RestClient client = new RestClient();
                RestRequest request = new RestRequest(endpointToInvoke, method == "GET" ? Method.GET : Method.POST);

                StringBuilder additionalHeaders = new StringBuilder();

                foreach (RestParameter parameter in _parameters)
                {
                    if (!string.IsNullOrWhiteSpace(parameter.Name))
                    {
                        if (parameter.Value == null)
                        {
                            parameter.Value = "";
                        }

                        if (parameter.ParameterType == ParameterType.HttpHeader)
                        {
                            additionalHeaders.Append(parameter.Name + ": " + parameter.Value + Environment.NewLine);
                        }

                        var parValue = parameter.Value.Trim();
                        
                        request.AddParameter(parameter.Name, parValue, parameter.ParameterType);
                    }
                }

                if (cbBrowse.Checked)
                {
                    var uri = client.BuildUri(request);
                    txtLog.AppendText(uri.ToString() + Environment.NewLine);

                    if (_selectedAction.Name.Contains("Implicit"))
                    {
                        System.Diagnostics.Process.Start(uri.ToString());
                    }
                    else
                    {
                        tbMain.SelectedTab = tbMain.TabPages[1];
                        webBrowserWinForm.Navigate(uri);
                        //((WPFWebBrowser)elementHost1.Child).wbMain.Navigate(uri, "", null, additionalHeaders.ToString());
                    }
                }
                else
                {
                    var response = client.Execute(request);

                    StringBuilder sbHeaders = new StringBuilder();
                    foreach (var header in response.Headers)
                    {
                        sbHeaders.AppendLine(header.Name + ": " + header.Value);
                    }

                    InvokeResultItem item = new InvokeResultItem();
                    item.Reference = ++_counter;
                    item.StatusCode = (int)response.StatusCode;
                    item.Content = response.Content;
                    item.Headers = sbHeaders.ToString();
                    item.ExpectedContent = InvokeResultExpectedContent.Unknown;

                    OAuth2ActionConfigurationElement action = cbxActions.SelectedItem as OAuth2ActionConfigurationElement;

                    if (action != null)
                    {
                        if (action.Endpoint == "Token")
                        {
                            item.ExpectedContent = InvokeResultExpectedContent.TokenInBody;
                        }
                    }

                    _invokeResults.Insert(0, item);
                    dgInvokeResults.Rows[0].Selected = true;
                }
            }
        }

        private void cbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            string providerName = cbxProviders.SelectedValue != null ? cbxProviders.SelectedValue.ToString() : "";

            OAuth2ProviderConfigurationElement configurationElement = _providersConfigurationSection.OAuth2Providers[providerName];
            txtAuthEndpoint.Text = configurationElement.AuthorizationEndpoint;
            txtTokenEndpoint.Text = configurationElement.TokenEndpoint;

            // Loading clients.
            List<OAuth2ClientConfigurationElement> clients = new List<OAuth2ClientConfigurationElement>();
            foreach (OAuth2ClientConfigurationElement element in configurationElement.OAuth2Clients)
            {
                clients.Add(element);
            }
            cbxClients.DataSource = clients;
            cbxClients.DisplayMember = "Name";

            if (clients.Count > 0)
            {
                cbxClients.SelectedIndex = 0;
            }

            _selectedProvider = configurationElement;

            if (cbxActions.Items.Count > 0)
            {
                cbxActions.SelectedIndex = 0;
            }

            txtInvokedEndpoint.Text = "";
        }

        private void cbxActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clientId = "";
            string clientSecret = "";
            string redirectUri = "";
            string scope = "";

            if (_selectedProvider != null)
            {
                clientId = txtClientID.Text;
                clientSecret = txtClientSecret.Text;
                redirectUri = txtRedirectURI.Text;
                scope = txtScopes.Text;
            }

            _selectedAction = null;
            _parameters.Clear();

            cbxMethod.SelectedItem = "GET";
            cbBrowse.Checked = false;

            _selectedAction = (OAuth2ActionConfigurationElement)cbxActions.SelectedItem;

            if (_selectedAction != null)
            {
                cbxMethod.SelectedItem = _selectedAction.Method;
                cbBrowse.Checked = false;

                switch (_selectedAction.Endpoint)
                {
                    case "Authorize":
                        txtInvokedEndpoint.Text = txtAuthEndpoint.Text;
                        cbBrowse.Checked = true;
                        break;
                    case "Token":
                        txtInvokedEndpoint.Text = txtTokenEndpoint.Text;
                        break;
                    case "Resource":
                        txtInvokedEndpoint.Text = txtResourceEndpoint.Text;
                        break;
                    default:
                        txtInvokedEndpoint.Text = "";
                        break;
                }

                if (_selectedAction.OAuth2ActionParameters != null && _selectedAction.OAuth2ActionParameters.Count > 0)
                {
                    foreach (OAuth2ParameterConfigurationElement parameter in _selectedAction.OAuth2ActionParameters)
                    {
                        string value = parameter.Value;

                        switch (parameter.Name)
                        {
                            case "client_id":
                                value = clientId;
                                break;
                            case "client_secret":
                                value = clientSecret;
                                break;
                            case "redirect_uri":
                                value = redirectUri;
                                break;
                            case "scope":
                                value = scope;
                                break;
                        }

                        var restParameter = new RestParameter();
                        restParameter.Name = parameter.Name;
                        restParameter.Value = value;
                        restParameter.ParameterType = (ParameterType)Enum.Parse(typeof(ParameterType), parameter.ParameterType);

                        _parameters.Add(restParameter);
                    }
                }
            }
        }

        private class RestParameter
        {
            public RestParameter()
            {
                Name = "";
                Value = "";
                ParameterType = ParameterType.GetOrPost;
            }

            public string Name { get; set; }
            public string Value { get; set; }
            public ParameterType ParameterType { get; set; }
        }

        private void btnRefreshParams_Click(object sender, EventArgs e)
        {
            cbxActions_SelectedIndexChanged(this, new EventArgs());
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAddressBar.Text))
            {
                string location = txtAddressBar.Text;

                if (location != "about:blank" && !location.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase)
                    && !location.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
                {
                    location = "http://" + location;
                }

                if (Uri.IsWellFormedUriString(location, UriKind.Absolute) || location == "about:blank")
                {
                    webBrowserWinForm.Navigate(location);
                }
                else
                {
                    MessageBox.Show("The provided address is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBasicEncrypt_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            txtBasicHeader.Text = "";

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    string formattedHeader = string.Format("{0}:{1}", userName, password);
                    byte[] buffer = Encoding.UTF8.GetBytes(formattedHeader);

                    txtBasicHeader.Text = Convert.ToBase64String(buffer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Plase specify a valid (non empty) username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBasicDecrypt_Click(object sender, EventArgs e)
        {
            string header = txtBasicHeader.Text;

            txtUserName.Text = "";
            txtPassword.Text = "";

            if (!string.IsNullOrEmpty(header))
            {
                try
                {
                    byte[] buffer = Convert.FromBase64String(header);
                    string formattedHeader = Encoding.UTF8.GetString(buffer);

                    string[] splitValues = formattedHeader.Split(new char[] { ':' });

                    if (splitValues.Length == 2)
                    {
                        txtUserName.Text = splitValues[0];
                        txtPassword.Text = splitValues[1];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Plase specify a valid (non empty) header.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyBasicHeader_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBasicHeader.Text))
            {
                Clipboard.SetText(txtBasicHeader.Text);
                MessageBox.Show("Header copied to clipboard", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cMenuBtnCopyAuthCode_Click(object sender, EventArgs e)
        {
            if (dgInvokeResults.SelectedRows != null && dgInvokeResults.SelectedRows.Count > 0)
            {
                var row = dgInvokeResults.SelectedRows[0];
                var resultItem = row.DataBoundItem as InvokeResultItem;
                string clipboardValue = "";

                if (resultItem != null)
                {
                    if (resultItem.ExpectedContent == InvokeResultExpectedContent.AuthorizationCodeInQueryString)
                    {
                        try
                        {
                            Uri uri = new Uri(resultItem.Content);
                            var collection = HttpUtility.ParseQueryString(uri.Query);

                            if (collection.AllKeys.Contains("code"))
                            {
                                clipboardValue = collection["code"];
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(clipboardValue))
                {
                    MessageBox.Show("Authorization code not found in the result content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Clipboard.SetText(clipboardValue);
                    txtStatusLabel.Text = "Authorization code copied to clipboard.";
                }
            }
        }

        private void cMenuBtnCopyContent_Click(object sender, EventArgs e)
        {
            if (dgInvokeResults.SelectedRows != null && dgInvokeResults.SelectedRows.Count > 0)
            {
                var row = dgInvokeResults.SelectedRows[0];
                var resultItem = row.DataBoundItem as InvokeResultItem;
                string clipboardValue = "";

                if (resultItem != null)
                {
                    clipboardValue = resultItem.Content;
                }

                if (string.IsNullOrWhiteSpace(clipboardValue))
                {
                    MessageBox.Show("Content not found in the result.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Clipboard.SetText(clipboardValue);
                    txtStatusLabel.Text = "Content copied to clipboard.";
                }
            }
        }

        private void cMenuBtnCopyHeaders_Click(object sender, EventArgs e)
        {
            if (dgInvokeResults.SelectedRows != null && dgInvokeResults.SelectedRows.Count > 0)
            {
                var row = dgInvokeResults.SelectedRows[0];
                var resultItem = row.DataBoundItem as InvokeResultItem;
                string clipboardValue = "";

                if (resultItem != null)
                {
                    clipboardValue = resultItem.Headers;
                }

                if (string.IsNullOrWhiteSpace(clipboardValue))
                {
                    MessageBox.Show("Headers not found in the result.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Clipboard.SetText(clipboardValue);
                    txtStatusLabel.Text = "Headers copied to clipboard.";
                }
            }
        }

        private void cMenuBtnCopyRToken_Click(object sender, EventArgs e)
        {
            if (dgInvokeResults.SelectedRows != null && dgInvokeResults.SelectedRows.Count > 0)
            {
                var row = dgInvokeResults.SelectedRows[0];
                var resultItem = row.DataBoundItem as InvokeResultItem;
                string clipboardValue = "";

                if (resultItem != null)
                {
                    if (resultItem.ExpectedContent == InvokeResultExpectedContent.TokenInBody)
                    {
                        try
                        {
                            IDictionary<string, JToken> jsonTokens = (IDictionary<string, JToken>)JsonConvert.DeserializeObject(resultItem.Content);

                            if (jsonTokens != null)
                            {
                                if (jsonTokens.ContainsKey("refresh_token"))
                                {
                                    clipboardValue = jsonTokens["refresh_token"].ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(clipboardValue))
                {
                    MessageBox.Show("Refresh token not found in the result content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Clipboard.SetText(clipboardValue);
                    txtStatusLabel.Text = "Refresh token copied to clipboard.";
                }
            }
        }

        private void cMenuBtnCopyToken_Click(object sender, EventArgs e)
        {
            if (dgInvokeResults.SelectedRows != null && dgInvokeResults.SelectedRows.Count > 0)
            {
                var row = dgInvokeResults.SelectedRows[0];
                var resultItem = row.DataBoundItem as InvokeResultItem;
                string clipboardValue = "";

                if (resultItem != null)
                {
                    if (resultItem.ExpectedContent == InvokeResultExpectedContent.TokenInBody)
                    {
                        try
                        {
                            IDictionary<string, JToken> jsonTokens = (IDictionary<string, JToken>)JsonConvert.DeserializeObject(resultItem.Content);

                            if (jsonTokens != null)
                            {
                                if (jsonTokens.ContainsKey("access_token"))
                                {
                                    clipboardValue = jsonTokens["access_token"].ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (resultItem.ExpectedContent == InvokeResultExpectedContent.TokenInFragment)
                    {
                        Uri uri = new Uri(resultItem.Content);

                        if (!string.IsNullOrWhiteSpace(uri.Fragment))
                        {
                            string fragmentValue = uri.Fragment.Substring(1);
                            var collection = HttpUtility.ParseQueryString(fragmentValue);

                            if (collection.AllKeys.Contains("access_token"))
                            {
                                clipboardValue = collection["access_token"];
                            }
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(clipboardValue))
                {
                    MessageBox.Show("Access token not found in the result content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Clipboard.SetText(clipboardValue);
                    txtStatusLabel.Text = "Access token copied to clipboard.";
                }
            }
        }

        private void dgInvokeResults_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRowIndex = dgInvokeResults.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRowIndex >= 0)
                {
                    dgInvokeResults.Rows[currentMouseOverRowIndex].Selected = true;
                }
            }
        }

        private void cMenuBtnClearAll_Click(object sender, EventArgs e)
        {
            if (_invokeResults != null && _invokeResults.Count > 0)
            {
                _invokeResults.Clear();
                _counter = 0;
            }
        }

        private void cbxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            OAuth2ClientConfigurationElement element = cbxClients.SelectedItem as OAuth2ClientConfigurationElement;

            if (element != null)
            {
                txtClientID.Text = element.ClientId;
                txtClientSecret.Text = element.ClientSecret;
                txtRedirectURI.Text = element.RedirectURI;
                txtScopes.Text = element.Scopes;
                txtResourceEndpoint.Text = element.ResourceEndpoint;
            }
        }

        private void btnToBase64_Click(object sender, EventArgs e)
        {
            string text = txtBase64Input.Text;

            if (!string.IsNullOrEmpty(text))
            {
                try
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(text);
                    string decodedText = Convert.ToBase64String(buffer);

                    txtBase64Output.Text = decodedText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFromBase64_Click(object sender, EventArgs e)
        {
            string text = txtBase64Output.Text;

            if (!string.IsNullOrEmpty(text))
            {
                try
                {
                    byte[] buffer = Convert.FromBase64String(text);
                    string decodedText = Encoding.UTF8.GetString(buffer);

                    txtBase64Input.Text = decodedText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCopyBase64_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBase64Output.Text))
            {
                Clipboard.SetText(txtBase64Output.Text);
                MessageBox.Show("Base64 string copied to clipboard", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabJSONViewer_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                this.LoadJsonInTree(txtJsonString.Text);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtJsonString.Text = "";
        }

        private void btnCopyTreeText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtJsonString.Text))
            {
                Clipboard.SetText(txtJsonString.Text);
            }
        }

        private void btnPasteTreeText_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtJsonString.Text = Clipboard.GetText();
            }
        }

        private void cMenuJsonTreeCopyValue_Click(object sender, EventArgs e)
        {
            if (jsonTree != null && jsonTree.SelectedNode != null)
            {
                if (jsonTree.SelectedNode.Tag is string)
                {
                    string value = (string)jsonTree.SelectedNode.Tag;

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        Clipboard.SetText(value);
                    }
                }
            }
        }

        private void jsonTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var node = jsonTree.HitTest(e.X, e.Y).Node;
                jsonTree.SelectedNode = node;
            }
        }

        private void dgParameters_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                TextBox tbx = e.Control as TextBox;
                tbx.Multiline = true;
            }
        }

        private void btnGetAuthHeader_Click(object sender, EventArgs e)
        {
            string clientId = txtClientID.Text;
            string clientSecret = txtClientSecret.Text;

            string header = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                clientId + ":" + clientSecret));
            Clipboard.SetText(header);
        }

        private void cMenuBtnCopyIdToken_Click(object sender, EventArgs e)
        {
            if (dgInvokeResults.SelectedRows != null && dgInvokeResults.SelectedRows.Count > 0)
            {
                var row = dgInvokeResults.SelectedRows[0];
                var resultItem = row.DataBoundItem as InvokeResultItem;
                string clipboardValue = "";

                if (resultItem != null)
                {
                    if (resultItem.ExpectedContent == InvokeResultExpectedContent.TokenInBody)
                    {
                        try
                        {
                            IDictionary<string, JToken> jsonTokens = (IDictionary<string, JToken>)JsonConvert.DeserializeObject(resultItem.Content);

                            if (jsonTokens != null)
                            {
                                if (jsonTokens.ContainsKey("id_token"))
                                {
                                    clipboardValue = jsonTokens["id_token"].ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (resultItem.ExpectedContent == InvokeResultExpectedContent.TokenInFragment)
                    {
                        Uri uri = new Uri(resultItem.Content);

                        if (!string.IsNullOrWhiteSpace(uri.Fragment))
                        {
                            string fragmentValue = uri.Fragment.Substring(1);
                            var collection = HttpUtility.ParseQueryString(fragmentValue);

                            if (collection.AllKeys.Contains("id_token"))
                            {
                                clipboardValue = collection["id_token"];
                            }
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(clipboardValue))
                {
                    MessageBox.Show("ID token not found in the result content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Clipboard.SetText(clipboardValue);
                    txtStatusLabel.Text = "ID token copied to clipboard.";
                }
            }
        }

        private void webBrowserWinForm_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Cursor.Current = Cursors.Default;

            txtAddressBar.Text = e.Url.ToString();

            try
            {
                string redirectURIParameter = GetCurrentRedirectUriParameter();

                if (!string.IsNullOrWhiteSpace(redirectURIParameter))
                {
                    Uri redirectUri = new Uri(redirectURIParameter);

                    if (e.Url.Host == redirectUri.Host && e.Url.LocalPath == redirectUri.LocalPath)
                    {
                        tbMain.SelectedTab = tbMain.TabPages[0];

                        InvokeResultItem item = new InvokeResultItem();
                        item.Reference = ++_counter;
                        item.StatusCode = null;
                        item.Content = HttpUtility.UrlDecode(e.Url.ToString());

                        if (string.IsNullOrWhiteSpace(e.Url.Fragment))
                        {
                            item.ExpectedContent = InvokeResultExpectedContent.AuthorizationCodeInQueryString;
                        }
                        else
                        {
                            item.ExpectedContent = InvokeResultExpectedContent.TokenInFragment;
                        }

                        _invokeResults.Insert(0, item);
                        dgInvokeResults.Rows[0].Selected = true;
                    }
                }

                pbLoading.MarqueeAnimationSpeed = 0;
                pbLoading.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void webBrowserWinForm_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            pbLoading.MarqueeAnimationSpeed = 30;

            try
            {
                string redirectURIParameter = GetCurrentRedirectUriParameter();

                if (!string.IsNullOrWhiteSpace(redirectURIParameter))
                {
                    Uri redirectUri = new Uri(redirectURIParameter);

                    if (e.Url.Host == redirectUri.Host && e.Url.LocalPath == redirectUri.LocalPath && e.Url.Scheme == "x-cez")
                    {
                        tbMain.SelectedTab = tbMain.TabPages[0];

                        InvokeResultItem item = new InvokeResultItem();
                        item.Reference = ++_counter;
                        item.StatusCode = null;
                        item.Content = HttpUtility.UrlDecode(e.Url.ToString());

                        if (string.IsNullOrWhiteSpace(e.Url.Fragment))
                        {
                            item.ExpectedContent = InvokeResultExpectedContent.AuthorizationCodeInQueryString;
                        }
                        else
                        {
                            item.ExpectedContent = InvokeResultExpectedContent.TokenInFragment;
                        }

                        _invokeResults.Insert(0, item);
                        dgInvokeResults.Rows[0].Selected = true;

                        pbLoading.MarqueeAnimationSpeed = 0;
                        pbLoading.Refresh();
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyAccessTokenQs_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAccessTokenQs.Text.Trim()))
            {
                Clipboard.SetText(txtAccessTokenQs.Text.Trim());
            }
        }

        private void btnCopyIDTokenQS_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIDTokenQs.Text.Trim()))
            {
                Clipboard.SetText(txtIDTokenQs.Text.Trim());
            }
        }

        private void txtQueryString_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQueryString.Text))
            {
                try
                {
                    Uri uri = new Uri(txtQueryString.Text);

                    if (!string.IsNullOrWhiteSpace(uri.Fragment))
                    {
                        string fragmentValue = uri.Fragment.Substring(1);
                        var collection = HttpUtility.ParseQueryString(fragmentValue);

                        if (collection.AllKeys.Contains("id_token"))
                        {
                            txtIDTokenQs.Text = collection["id_token"];
                        }

                        if (collection.AllKeys.Contains("access_token"))
                        {
                            txtAccessTokenQs.Text = collection["access_token"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearQs_Click(object sender, EventArgs e)
        {
            txtQueryString.Text = "";
            txtAccessTokenQs.Text = "";
            txtIDTokenQs.Text = "";
        }
    }

    public class InvokeResultItem
    {
        public int Reference { get; set; }
        public int? StatusCode { get; set; }
        public string Content { get; set; }
        public string Headers { get; set; }
        public InvokeResultExpectedContent ExpectedContent { get; set; }
    }

    public enum InvokeResultExpectedContent
    {
        Unknown = 0,
        AuthorizationCodeInQueryString = 1,
        TokenInBody = 2,
        TokenInFragment = 3
    }
}
