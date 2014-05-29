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

        private const string DefaultPageAddress = "http://localhost/";

        private BindingSource _parameters = new BindingSource();
        private OAuth2ProvidersConfigurationSection _providersConfigurationSection = null;
        private OAuth2ActionsConfigurationSection _actionsConfigurationSection = null;
        private OAuth2ProviderConfigurationElement _selectedProvider = null;
        private OAuth2ActionConfigurationElement _selectedAction = null;

        public MainForm()
        {
            InitializeComponent();

            elementHost1.Child = new WPFWebBrowser();
            ((WPFWebBrowser)elementHost1.Child).wbMain.Navigated += wbMain_Navigated;
            ((WPFWebBrowser)elementHost1.Child).wbMain.Navigating += wbMain_Navigating;
            ((WPFWebBrowser)elementHost1.Child).wbMain.LoadCompleted += wbMain_LoadCompleted;

            dgInvokeResults.AutoGenerateColumns = false;
            dgInvokeResults.DataSource = _invokeResults;

            LoadConfiguration();

            ((WPFWebBrowser)elementHost1.Child).wbMain.Navigate(DefaultPageAddress);
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

                        if (parameter.InjectInHeader)
                        {
                            request.AddHeader(parameter.Name, parameter.Value);
                            additionalHeaders.Append(parameter.Name + ": " + parameter.Value + Environment.NewLine);
                        }
                        else
                        {
                            request.AddParameter(parameter.Name, parameter.Value);
                        }
                    }
                }

                if (cbBrowse.Checked)
                {
                    tbMain.SelectedTab = tbMain.TabPages[1];
                    var uri = client.BuildUri(request);

                    ((WPFWebBrowser)elementHost1.Child).wbMain.Navigate(uri, "", null, additionalHeaders.ToString());
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
            cbxClients.DisplayMember = "ClientId";

            if (clients.Count > 0)
            {
                cbxClients.SelectedIndex = 0;
            }
            
            _selectedProvider = configurationElement;

            cbxActions.SelectedIndex = 0;
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
                        cbBrowse.Checked = true;
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
                        restParameter.InjectInHeader = parameter.AsHeader;

                        _parameters.Add(restParameter);
                    }
                }
            }
        }

        private class RestParameter
        {
            public RestParameter()
            {
                InjectInHeader = false;
                Name = "";
                Value = "";
            }

            public string Name { get; set; }
            public string Value { get; set; }
            public bool InjectInHeader { get; set; }
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
                    ((WPFWebBrowser)elementHost1.Child).wbMain.Navigate(location);
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
