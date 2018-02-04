namespace OAuthConsole
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblAuthEndpoint = new System.Windows.Forms.Label();
            this.txtAuthEndpoint = new System.Windows.Forms.TextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cbxMethod = new System.Windows.Forms.ComboBox();
            this.dgParameters = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParameterType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cbxActions = new System.Windows.Forms.ComboBox();
            this.btnInvoke = new System.Windows.Forms.Button();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtInvokedEndpoint = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblContentType = new System.Windows.Forms.Label();
            this.tbResults = new System.Windows.Forms.TabControl();
            this.tbResultsPage1 = new System.Windows.Forms.TabPage();
            this.dgInvokeResults = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenuGridResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuBtnCopyContent = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuBtnCopyHeaders = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cMenuBtnCopyAuthCode = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuBtnCopyToken = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuBtnCopyRToken = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuBtnCopyIdToken = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cMenuBtnClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tbResultsPage2 = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnRefreshParams = new System.Windows.Forms.Button();
            this.chkRunWithoutCookies = new System.Windows.Forms.CheckBox();
            this.lblInvokedEndpoint = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.btnGetAuthHeader = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            this.cbxClients = new System.Windows.Forms.ComboBox();
            this.lblSpaceSep = new System.Windows.Forms.Label();
            this.txtScopes = new System.Windows.Forms.TextBox();
            this.lblScopes = new System.Windows.Forms.Label();
            this.txtRedirectURI = new System.Windows.Forms.TextBox();
            this.lblRedirectURI = new System.Windows.Forms.Label();
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.lblClientSecret = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.lblClientID = new System.Windows.Forms.Label();
            this.txtResourceEndpoint = new System.Windows.Forms.TextBox();
            this.lblResourceEndpoint = new System.Windows.Forms.Label();
            this.lblProvider = new System.Windows.Forms.Label();
            this.cbxProviders = new System.Windows.Forms.ComboBox();
            this.txtTokenEndpoint = new System.Windows.Forms.TextBox();
            this.lblTokenEndpoint = new System.Windows.Forms.Label();
            this.cbBrowse = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowserWinForm = new System.Windows.Forms.WebBrowser();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtAddressBar = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabJSONViewer = new System.Windows.Forms.TabControl();
            this.tabPageViwer = new System.Windows.Forms.TabPage();
            this.jsonTree = new System.Windows.Forms.TreeView();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.txtJsonString = new System.Windows.Forms.TextBox();
            this.panelTreeTextActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopyTreeText = new System.Windows.Forms.Button();
            this.btnPasteTreeText = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbxTokensFromURI = new System.Windows.Forms.GroupBox();
            this.btnClearQs = new System.Windows.Forms.Button();
            this.btnCopyIDTokenQS = new System.Windows.Forms.Button();
            this.txtIDTokenQs = new System.Windows.Forms.TextBox();
            this.lblIDTokenQs = new System.Windows.Forms.Label();
            this.btnCopyAccessTokenQs = new System.Windows.Forms.Button();
            this.txtAccessTokenQs = new System.Windows.Forms.TextBox();
            this.lblAccessTokenQs = new System.Windows.Forms.Label();
            this.txtQueryString = new System.Windows.Forms.TextBox();
            this.lblURI = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopyBase64 = new System.Windows.Forms.Button();
            this.btnFromBase64 = new System.Windows.Forms.Button();
            this.btnToBase64 = new System.Windows.Forms.Button();
            this.txtBase64Output = new System.Windows.Forms.TextBox();
            this.txtBase64Input = new System.Windows.Forms.TextBox();
            this.gbxBasicAuth = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopyBasicHeader = new System.Windows.Forms.Button();
            this.btnBasicDecrypt = new System.Windows.Forms.Button();
            this.btnBasicEncrypt = new System.Windows.Forms.Button();
            this.txtBasicHeader = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.txtStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cMenuJsonTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuJsonTreeCopyValue = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgParameters)).BeginInit();
            this.tbMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbResults.SuspendLayout();
            this.tbResultsPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvokeResults)).BeginInit();
            this.cMenuGridResults.SuspendLayout();
            this.tbResultsPage2.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabJSONViewer.SuspendLayout();
            this.tabPageViwer.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.panelTreeTextActions.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbxTokensFromURI.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxBasicAuth.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.cMenuJsonTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAuthEndpoint
            // 
            this.lblAuthEndpoint.AutoSize = true;
            this.lblAuthEndpoint.Location = new System.Drawing.Point(14, 76);
            this.lblAuthEndpoint.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAuthEndpoint.Name = "lblAuthEndpoint";
            this.lblAuthEndpoint.Size = new System.Drawing.Size(136, 24);
            this.lblAuthEndpoint.TabIndex = 3;
            this.lblAuthEndpoint.Text = "Auth endpoint";
            // 
            // txtAuthEndpoint
            // 
            this.txtAuthEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthEndpoint.Location = new System.Drawing.Point(229, 73);
            this.txtAuthEndpoint.Margin = new System.Windows.Forms.Padding(5);
            this.txtAuthEndpoint.Name = "txtAuthEndpoint";
            this.txtAuthEndpoint.Size = new System.Drawing.Size(1354, 32);
            this.txtAuthEndpoint.TabIndex = 2;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(809, 379);
            this.lblMethod.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(137, 24);
            this.lblMethod.TabIndex = 4;
            this.lblMethod.Text = "HTTP Method";
            // 
            // cbxMethod
            // 
            this.cbxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMethod.FormattingEnabled = true;
            this.cbxMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.cbxMethod.Location = new System.Drawing.Point(956, 376);
            this.cbxMethod.Margin = new System.Windows.Forms.Padding(5);
            this.cbxMethod.Name = "cbxMethod";
            this.cbxMethod.Size = new System.Drawing.Size(375, 32);
            this.cbxMethod.TabIndex = 5;
            // 
            // dgParameters
            // 
            this.dgParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgParameters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colValue,
            this.colParameterType});
            this.dgParameters.Location = new System.Drawing.Point(0, 12);
            this.dgParameters.Margin = new System.Windows.Forms.Padding(5);
            this.dgParameters.Name = "dgParameters";
            this.dgParameters.Size = new System.Drawing.Size(1366, 229);
            this.dgParameters.TabIndex = 6;
            this.dgParameters.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgParameters_EditingControlShowing);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 200;
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colValue.DataPropertyName = "Value";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colValue.DefaultCellStyle = dataGridViewCellStyle1;
            this.colValue.HeaderText = "Value";
            this.colValue.MaxInputLength = 10000000;
            this.colValue.Name = "colValue";
            // 
            // colParameterType
            // 
            this.colParameterType.AutoComplete = false;
            this.colParameterType.DataPropertyName = "ParameterType";
            this.colParameterType.HeaderText = "Parameter Type";
            this.colParameterType.Name = "colParameterType";
            this.colParameterType.Width = 200;
            // 
            // cbxActions
            // 
            this.cbxActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActions.FormattingEnabled = true;
            this.cbxActions.Location = new System.Drawing.Point(241, 376);
            this.cbxActions.Margin = new System.Windows.Forms.Padding(5);
            this.cbxActions.Name = "cbxActions";
            this.cbxActions.Size = new System.Drawing.Size(496, 32);
            this.cbxActions.TabIndex = 8;
            this.cbxActions.SelectedIndexChanged += new System.EventHandler(this.cbxActions_SelectedIndexChanged);
            // 
            // btnInvoke
            // 
            this.btnInvoke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoke.Location = new System.Drawing.Point(1042, 251);
            this.btnInvoke.Margin = new System.Windows.Forms.Padding(5);
            this.btnInvoke.Name = "btnInvoke";
            this.btnInvoke.Size = new System.Drawing.Size(324, 56);
            this.btnInvoke.TabIndex = 11;
            this.btnInvoke.Text = "INVOKE";
            this.btnInvoke.UseVisualStyleBackColor = true;
            this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tabPage1);
            this.tbMain.Controls.Add(this.tabPage2);
            this.tbMain.Controls.Add(this.tabPage4);
            this.tbMain.Controls.Add(this.tabPage3);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Margin = new System.Windows.Forms.Padding(5);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(1644, 906);
            this.tbMain.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtInvokedEndpoint);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.tbResults);
            this.tabPage1.Controls.Add(this.btnRefreshParams);
            this.tabPage1.Controls.Add(this.chkRunWithoutCookies);
            this.tabPage1.Controls.Add(this.lblInvokedEndpoint);
            this.tabPage1.Controls.Add(this.lblAction);
            this.tabPage1.Controls.Add(this.gbSettings);
            this.tabPage1.Controls.Add(this.cbxActions);
            this.tabPage1.Controls.Add(this.cbBrowse);
            this.tabPage1.Controls.Add(this.lblMethod);
            this.tabPage1.Controls.Add(this.cbxMethod);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage1.Size = new System.Drawing.Size(1636, 869);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Request builder";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtInvokedEndpoint
            // 
            this.txtInvokedEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvokedEndpoint.Location = new System.Drawing.Point(239, 418);
            this.txtInvokedEndpoint.Margin = new System.Windows.Forms.Padding(5);
            this.txtInvokedEndpoint.Name = "txtInvokedEndpoint";
            this.txtInvokedEndpoint.Size = new System.Drawing.Size(1367, 32);
            this.txtInvokedEndpoint.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblContentType);
            this.groupBox2.Controls.Add(this.btnInvoke);
            this.groupBox2.Controls.Add(this.dgParameters);
            this.groupBox2.Location = new System.Drawing.Point(239, 447);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1366, 326);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // lblContentType
            // 
            this.lblContentType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblContentType.AutoSize = true;
            this.lblContentType.Location = new System.Drawing.Point(7, 247);
            this.lblContentType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblContentType.Name = "lblContentType";
            this.lblContentType.Size = new System.Drawing.Size(999, 24);
            this.lblContentType.TabIndex = 41;
            this.lblContentType.Text = "When the parameter type is RequestBody, use the content type (e.g. application/js" +
    "on) as parameter name.";
            // 
            // tbResults
            // 
            this.tbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResults.Controls.Add(this.tbResultsPage1);
            this.tbResults.Controls.Add(this.tbResultsPage2);
            this.tbResults.Location = new System.Drawing.Point(12, 746);
            this.tbResults.Margin = new System.Windows.Forms.Padding(4);
            this.tbResults.Name = "tbResults";
            this.tbResults.SelectedIndex = 0;
            this.tbResults.Size = new System.Drawing.Size(1600, 123);
            this.tbResults.TabIndex = 42;
            // 
            // tbResultsPage1
            // 
            this.tbResultsPage1.Controls.Add(this.dgInvokeResults);
            this.tbResultsPage1.Location = new System.Drawing.Point(4, 33);
            this.tbResultsPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tbResultsPage1.Name = "tbResultsPage1";
            this.tbResultsPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tbResultsPage1.Size = new System.Drawing.Size(1592, 86);
            this.tbResultsPage1.TabIndex = 0;
            this.tbResultsPage1.Text = "Results";
            this.tbResultsPage1.UseVisualStyleBackColor = true;
            // 
            // dgInvokeResults
            // 
            this.dgInvokeResults.AllowUserToAddRows = false;
            this.dgInvokeResults.AllowUserToDeleteRows = false;
            this.dgInvokeResults.AllowUserToResizeRows = false;
            this.dgInvokeResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvokeResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colResult,
            this.colContent,
            this.colContentType});
            this.dgInvokeResults.ContextMenuStrip = this.cMenuGridResults;
            this.dgInvokeResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInvokeResults.Location = new System.Drawing.Point(4, 4);
            this.dgInvokeResults.Margin = new System.Windows.Forms.Padding(5);
            this.dgInvokeResults.MultiSelect = false;
            this.dgInvokeResults.Name = "dgInvokeResults";
            this.dgInvokeResults.ReadOnly = true;
            this.dgInvokeResults.RowHeadersVisible = false;
            this.dgInvokeResults.RowTemplate.Height = 30;
            this.dgInvokeResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInvokeResults.Size = new System.Drawing.Size(1584, 78);
            this.dgInvokeResults.TabIndex = 40;
            this.dgInvokeResults.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgInvokeResults_MouseDown);
            // 
            // colNumber
            // 
            this.colNumber.DataPropertyName = "Reference";
            this.colNumber.HeaderText = "#";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.Width = 30;
            // 
            // colResult
            // 
            this.colResult.DataPropertyName = "StatusCode";
            this.colResult.HeaderText = "Result";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            // 
            // colContent
            // 
            this.colContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContent.DataPropertyName = "Content";
            this.colContent.HeaderText = "Content";
            this.colContent.Name = "colContent";
            this.colContent.ReadOnly = true;
            // 
            // colContentType
            // 
            this.colContentType.DataPropertyName = "ExpectedContent";
            this.colContentType.HeaderText = "Content type";
            this.colContentType.Name = "colContentType";
            this.colContentType.ReadOnly = true;
            this.colContentType.Visible = false;
            this.colContentType.Width = 150;
            // 
            // cMenuGridResults
            // 
            this.cMenuGridResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuBtnCopyContent,
            this.cMenuBtnCopyHeaders,
            this.cMenuSeparator1,
            this.cMenuBtnCopyAuthCode,
            this.cMenuBtnCopyToken,
            this.cMenuBtnCopyRToken,
            this.cMenuBtnCopyIdToken,
            this.cMenuSeparator2,
            this.cMenuBtnClearAll});
            this.cMenuGridResults.Name = "cMenuGridResults";
            this.cMenuGridResults.Size = new System.Drawing.Size(205, 170);
            // 
            // cMenuBtnCopyContent
            // 
            this.cMenuBtnCopyContent.Name = "cMenuBtnCopyContent";
            this.cMenuBtnCopyContent.Size = new System.Drawing.Size(204, 22);
            this.cMenuBtnCopyContent.Text = "Copy content";
            this.cMenuBtnCopyContent.Click += new System.EventHandler(this.cMenuBtnCopyContent_Click);
            // 
            // cMenuBtnCopyHeaders
            // 
            this.cMenuBtnCopyHeaders.Name = "cMenuBtnCopyHeaders";
            this.cMenuBtnCopyHeaders.Size = new System.Drawing.Size(204, 22);
            this.cMenuBtnCopyHeaders.Text = "Copy headers";
            this.cMenuBtnCopyHeaders.Click += new System.EventHandler(this.cMenuBtnCopyHeaders_Click);
            // 
            // cMenuSeparator1
            // 
            this.cMenuSeparator1.Name = "cMenuSeparator1";
            this.cMenuSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // cMenuBtnCopyAuthCode
            // 
            this.cMenuBtnCopyAuthCode.Name = "cMenuBtnCopyAuthCode";
            this.cMenuBtnCopyAuthCode.Size = new System.Drawing.Size(204, 22);
            this.cMenuBtnCopyAuthCode.Text = "Copy authorization code";
            this.cMenuBtnCopyAuthCode.Click += new System.EventHandler(this.cMenuBtnCopyAuthCode_Click);
            // 
            // cMenuBtnCopyToken
            // 
            this.cMenuBtnCopyToken.Name = "cMenuBtnCopyToken";
            this.cMenuBtnCopyToken.Size = new System.Drawing.Size(204, 22);
            this.cMenuBtnCopyToken.Text = "Copy access token";
            this.cMenuBtnCopyToken.Click += new System.EventHandler(this.cMenuBtnCopyToken_Click);
            // 
            // cMenuBtnCopyRToken
            // 
            this.cMenuBtnCopyRToken.Name = "cMenuBtnCopyRToken";
            this.cMenuBtnCopyRToken.Size = new System.Drawing.Size(204, 22);
            this.cMenuBtnCopyRToken.Text = "Copy refresh token";
            this.cMenuBtnCopyRToken.Click += new System.EventHandler(this.cMenuBtnCopyRToken_Click);
            // 
            // cMenuBtnCopyIdToken
            // 
            this.cMenuBtnCopyIdToken.Name = "cMenuBtnCopyIdToken";
            this.cMenuBtnCopyIdToken.Size = new System.Drawing.Size(204, 22);
            this.cMenuBtnCopyIdToken.Text = "Copy ID Token";
            this.cMenuBtnCopyIdToken.Click += new System.EventHandler(this.cMenuBtnCopyIdToken_Click);
            // 
            // cMenuSeparator2
            // 
            this.cMenuSeparator2.Name = "cMenuSeparator2";
            this.cMenuSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // cMenuBtnClearAll
            // 
            this.cMenuBtnClearAll.Name = "cMenuBtnClearAll";
            this.cMenuBtnClearAll.Size = new System.Drawing.Size(204, 22);
            this.cMenuBtnClearAll.Text = "Clear all";
            this.cMenuBtnClearAll.Click += new System.EventHandler(this.cMenuBtnClearAll_Click);
            // 
            // tbResultsPage2
            // 
            this.tbResultsPage2.Controls.Add(this.txtLog);
            this.tbResultsPage2.Location = new System.Drawing.Point(4, 33);
            this.tbResultsPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tbResultsPage2.Name = "tbResultsPage2";
            this.tbResultsPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tbResultsPage2.Size = new System.Drawing.Size(1624, 86);
            this.tbResultsPage2.TabIndex = 1;
            this.tbResultsPage2.Text = "Log";
            this.tbResultsPage2.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(4, 4);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1616, 78);
            this.txtLog.TabIndex = 0;
            this.txtLog.WordWrap = false;
            // 
            // btnRefreshParams
            // 
            this.btnRefreshParams.Location = new System.Drawing.Point(30, 459);
            this.btnRefreshParams.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefreshParams.Name = "btnRefreshParams";
            this.btnRefreshParams.Size = new System.Drawing.Size(197, 48);
            this.btnRefreshParams.TabIndex = 22;
            this.btnRefreshParams.Text = "Refresh";
            this.btnRefreshParams.UseVisualStyleBackColor = true;
            this.btnRefreshParams.Click += new System.EventHandler(this.btnRefreshParams_Click);
            // 
            // chkRunWithoutCookies
            // 
            this.chkRunWithoutCookies.AutoSize = true;
            this.chkRunWithoutCookies.Location = new System.Drawing.Point(1466, 378);
            this.chkRunWithoutCookies.Margin = new System.Windows.Forms.Padding(5);
            this.chkRunWithoutCookies.Name = "chkRunWithoutCookies";
            this.chkRunWithoutCookies.Size = new System.Drawing.Size(178, 28);
            this.chkRunWithoutCookies.TabIndex = 38;
            this.chkRunWithoutCookies.Text = "Disable cookies";
            this.chkRunWithoutCookies.UseVisualStyleBackColor = true;
            // 
            // lblInvokedEndpoint
            // 
            this.lblInvokedEndpoint.AutoSize = true;
            this.lblInvokedEndpoint.Location = new System.Drawing.Point(26, 426);
            this.lblInvokedEndpoint.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInvokedEndpoint.Name = "lblInvokedEndpoint";
            this.lblInvokedEndpoint.Size = new System.Drawing.Size(168, 24);
            this.lblInvokedEndpoint.TabIndex = 34;
            this.lblInvokedEndpoint.Text = "Invoked endpoint";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(26, 381);
            this.lblAction.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(68, 24);
            this.lblAction.TabIndex = 21;
            this.lblAction.Text = "Action";
            // 
            // gbSettings
            // 
            this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbSettings.Controls.Add(this.btnGetAuthHeader);
            this.gbSettings.Controls.Add(this.lblClient);
            this.gbSettings.Controls.Add(this.cbxClients);
            this.gbSettings.Controls.Add(this.lblSpaceSep);
            this.gbSettings.Controls.Add(this.txtScopes);
            this.gbSettings.Controls.Add(this.lblScopes);
            this.gbSettings.Controls.Add(this.txtRedirectURI);
            this.gbSettings.Controls.Add(this.lblRedirectURI);
            this.gbSettings.Controls.Add(this.txtClientSecret);
            this.gbSettings.Controls.Add(this.lblClientSecret);
            this.gbSettings.Controls.Add(this.txtClientID);
            this.gbSettings.Controls.Add(this.lblClientID);
            this.gbSettings.Controls.Add(this.txtResourceEndpoint);
            this.gbSettings.Controls.Add(this.lblResourceEndpoint);
            this.gbSettings.Controls.Add(this.lblProvider);
            this.gbSettings.Controls.Add(this.cbxProviders);
            this.gbSettings.Controls.Add(this.txtTokenEndpoint);
            this.gbSettings.Controls.Add(this.lblAuthEndpoint);
            this.gbSettings.Controls.Add(this.lblTokenEndpoint);
            this.gbSettings.Controls.Add(this.txtAuthEndpoint);
            this.gbSettings.Location = new System.Drawing.Point(12, 14);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(5);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(5);
            this.gbSettings.Size = new System.Drawing.Size(1600, 352);
            this.gbSettings.TabIndex = 20;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Configuration";
            // 
            // btnGetAuthHeader
            // 
            this.btnGetAuthHeader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetAuthHeader.Location = new System.Drawing.Point(1407, 151);
            this.btnGetAuthHeader.Margin = new System.Windows.Forms.Padding(5);
            this.btnGetAuthHeader.Name = "btnGetAuthHeader";
            this.btnGetAuthHeader.Size = new System.Drawing.Size(177, 71);
            this.btnGetAuthHeader.TabIndex = 36;
            this.btnGetAuthHeader.Text = "Copy Auth Header";
            this.btnGetAuthHeader.UseVisualStyleBackColor = true;
            this.btnGetAuthHeader.Click += new System.EventHandler(this.btnGetAuthHeader_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(779, 35);
            this.lblClient.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(63, 24);
            this.lblClient.TabIndex = 35;
            this.lblClient.Text = "Client";
            // 
            // cbxClients
            // 
            this.cbxClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClients.FormattingEnabled = true;
            this.cbxClients.Location = new System.Drawing.Point(859, 32);
            this.cbxClients.Margin = new System.Windows.Forms.Padding(5);
            this.cbxClients.Name = "cbxClients";
            this.cbxClients.Size = new System.Drawing.Size(724, 32);
            this.cbxClients.TabIndex = 34;
            this.cbxClients.SelectedIndexChanged += new System.EventHandler(this.cbxClients_SelectedIndexChanged);
            // 
            // lblSpaceSep
            // 
            this.lblSpaceSep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpaceSep.AutoSize = true;
            this.lblSpaceSep.Location = new System.Drawing.Point(1413, 271);
            this.lblSpaceSep.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSpaceSep.Name = "lblSpaceSep";
            this.lblSpaceSep.Size = new System.Drawing.Size(169, 24);
            this.lblSpaceSep.TabIndex = 33;
            this.lblSpaceSep.Text = "(space delimited)";
            // 
            // txtScopes
            // 
            this.txtScopes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScopes.Location = new System.Drawing.Point(229, 268);
            this.txtScopes.Margin = new System.Windows.Forms.Padding(5);
            this.txtScopes.Name = "txtScopes";
            this.txtScopes.Size = new System.Drawing.Size(1168, 32);
            this.txtScopes.TabIndex = 31;
            // 
            // lblScopes
            // 
            this.lblScopes.AutoSize = true;
            this.lblScopes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblScopes.Location = new System.Drawing.Point(14, 271);
            this.lblScopes.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblScopes.Name = "lblScopes";
            this.lblScopes.Size = new System.Drawing.Size(81, 24);
            this.lblScopes.TabIndex = 32;
            this.lblScopes.Text = "Scopes";
            // 
            // txtRedirectURI
            // 
            this.txtRedirectURI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRedirectURI.Location = new System.Drawing.Point(229, 229);
            this.txtRedirectURI.Margin = new System.Windows.Forms.Padding(5);
            this.txtRedirectURI.Name = "txtRedirectURI";
            this.txtRedirectURI.Size = new System.Drawing.Size(1354, 32);
            this.txtRedirectURI.TabIndex = 29;
            // 
            // lblRedirectURI
            // 
            this.lblRedirectURI.AutoSize = true;
            this.lblRedirectURI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRedirectURI.Location = new System.Drawing.Point(14, 232);
            this.lblRedirectURI.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRedirectURI.Name = "lblRedirectURI";
            this.lblRedirectURI.Size = new System.Drawing.Size(130, 24);
            this.lblRedirectURI.TabIndex = 30;
            this.lblRedirectURI.Text = "Redirect URI";
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientSecret.Location = new System.Drawing.Point(229, 190);
            this.txtClientSecret.Margin = new System.Windows.Forms.Padding(5);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.Size = new System.Drawing.Size(1168, 32);
            this.txtClientSecret.TabIndex = 27;
            // 
            // lblClientSecret
            // 
            this.lblClientSecret.AutoSize = true;
            this.lblClientSecret.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClientSecret.Location = new System.Drawing.Point(14, 193);
            this.lblClientSecret.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblClientSecret.Name = "lblClientSecret";
            this.lblClientSecret.Size = new System.Drawing.Size(128, 24);
            this.lblClientSecret.TabIndex = 28;
            this.lblClientSecret.Text = "Client secret";
            // 
            // txtClientID
            // 
            this.txtClientID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientID.Location = new System.Drawing.Point(229, 151);
            this.txtClientID.Margin = new System.Windows.Forms.Padding(5);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(1168, 32);
            this.txtClientID.TabIndex = 25;
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClientID.Location = new System.Drawing.Point(14, 154);
            this.lblClientID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(90, 24);
            this.lblClientID.TabIndex = 26;
            this.lblClientID.Text = "Client ID";
            // 
            // txtResourceEndpoint
            // 
            this.txtResourceEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResourceEndpoint.Location = new System.Drawing.Point(228, 307);
            this.txtResourceEndpoint.Margin = new System.Windows.Forms.Padding(5);
            this.txtResourceEndpoint.Name = "txtResourceEndpoint";
            this.txtResourceEndpoint.Size = new System.Drawing.Size(1354, 32);
            this.txtResourceEndpoint.TabIndex = 22;
            // 
            // lblResourceEndpoint
            // 
            this.lblResourceEndpoint.AutoSize = true;
            this.lblResourceEndpoint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResourceEndpoint.Location = new System.Drawing.Point(14, 310);
            this.lblResourceEndpoint.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblResourceEndpoint.Name = "lblResourceEndpoint";
            this.lblResourceEndpoint.Size = new System.Drawing.Size(186, 24);
            this.lblResourceEndpoint.TabIndex = 23;
            this.lblResourceEndpoint.Text = "Resource endpoint";
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(14, 37);
            this.lblProvider.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(89, 24);
            this.lblProvider.TabIndex = 21;
            this.lblProvider.Text = "Provider";
            // 
            // cbxProviders
            // 
            this.cbxProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProviders.FormattingEnabled = true;
            this.cbxProviders.Location = new System.Drawing.Point(229, 32);
            this.cbxProviders.Margin = new System.Windows.Forms.Padding(5);
            this.cbxProviders.Name = "cbxProviders";
            this.cbxProviders.Size = new System.Drawing.Size(496, 32);
            this.cbxProviders.TabIndex = 20;
            this.cbxProviders.SelectedIndexChanged += new System.EventHandler(this.cbProvider_SelectedIndexChanged);
            // 
            // txtTokenEndpoint
            // 
            this.txtTokenEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTokenEndpoint.Location = new System.Drawing.Point(229, 112);
            this.txtTokenEndpoint.Margin = new System.Windows.Forms.Padding(5);
            this.txtTokenEndpoint.Name = "txtTokenEndpoint";
            this.txtTokenEndpoint.Size = new System.Drawing.Size(1354, 32);
            this.txtTokenEndpoint.TabIndex = 14;
            // 
            // lblTokenEndpoint
            // 
            this.lblTokenEndpoint.AutoSize = true;
            this.lblTokenEndpoint.Location = new System.Drawing.Point(14, 115);
            this.lblTokenEndpoint.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTokenEndpoint.Name = "lblTokenEndpoint";
            this.lblTokenEndpoint.Size = new System.Drawing.Size(150, 24);
            this.lblTokenEndpoint.TabIndex = 15;
            this.lblTokenEndpoint.Text = "Token endpoint";
            // 
            // cbBrowse
            // 
            this.cbBrowse.AutoSize = true;
            this.cbBrowse.Location = new System.Drawing.Point(1341, 378);
            this.cbBrowse.Margin = new System.Windows.Forms.Padding(5);
            this.cbBrowse.Name = "cbBrowse";
            this.cbBrowse.Size = new System.Drawing.Size(100, 28);
            this.cbBrowse.TabIndex = 13;
            this.cbBrowse.Text = "Browse";
            this.cbBrowse.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowserWinForm);
            this.tabPage2.Controls.Add(this.pbLoading);
            this.tabPage2.Controls.Add(this.btnGo);
            this.tabPage2.Controls.Add(this.txtAddressBar);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage2.Size = new System.Drawing.Size(1636, 869);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Browser";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowserWinForm
            // 
            this.webBrowserWinForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserWinForm.Location = new System.Drawing.Point(12, 70);
            this.webBrowserWinForm.Margin = new System.Windows.Forms.Padding(4);
            this.webBrowserWinForm.MinimumSize = new System.Drawing.Size(29, 29);
            this.webBrowserWinForm.Name = "webBrowserWinForm";
            this.webBrowserWinForm.Size = new System.Drawing.Size(1620, 795);
            this.webBrowserWinForm.TabIndex = 4;
            this.webBrowserWinForm.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowserWinForm_Navigated);
            this.webBrowserWinForm.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowserWinForm_Navigating);
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoading.Location = new System.Drawing.Point(12, 53);
            this.pbLoading.Margin = new System.Windows.Forms.Padding(5);
            this.pbLoading.MarqueeAnimationSpeed = 0;
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(1620, 10);
            this.pbLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbLoading.TabIndex = 3;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(1475, 10);
            this.btnGo.Margin = new System.Windows.Forms.Padding(5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(156, 34);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Browse";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtAddressBar
            // 
            this.txtAddressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddressBar.Location = new System.Drawing.Point(12, 11);
            this.txtAddressBar.Margin = new System.Windows.Forms.Padding(5);
            this.txtAddressBar.Name = "txtAddressBar";
            this.txtAddressBar.Size = new System.Drawing.Size(1462, 32);
            this.txtAddressBar.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabJSONViewer);
            this.tabPage4.Location = new System.Drawing.Point(4, 33);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1668, 869);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "JSON viewer";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabJSONViewer
            // 
            this.tabJSONViewer.Controls.Add(this.tabPageViwer);
            this.tabJSONViewer.Controls.Add(this.tabPageText);
            this.tabJSONViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabJSONViewer.Location = new System.Drawing.Point(0, 0);
            this.tabJSONViewer.Margin = new System.Windows.Forms.Padding(5);
            this.tabJSONViewer.Name = "tabJSONViewer";
            this.tabJSONViewer.SelectedIndex = 0;
            this.tabJSONViewer.Size = new System.Drawing.Size(1668, 869);
            this.tabJSONViewer.TabIndex = 3;
            this.tabJSONViewer.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabJSONViewer_Selected);
            // 
            // tabPageViwer
            // 
            this.tabPageViwer.Controls.Add(this.jsonTree);
            this.tabPageViwer.Location = new System.Drawing.Point(4, 33);
            this.tabPageViwer.Margin = new System.Windows.Forms.Padding(5);
            this.tabPageViwer.Name = "tabPageViwer";
            this.tabPageViwer.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageViwer.Size = new System.Drawing.Size(1660, 832);
            this.tabPageViwer.TabIndex = 0;
            this.tabPageViwer.Text = "Viewer";
            this.tabPageViwer.UseVisualStyleBackColor = true;
            // 
            // jsonTree
            // 
            this.jsonTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonTree.Location = new System.Drawing.Point(5, 5);
            this.jsonTree.Margin = new System.Windows.Forms.Padding(5);
            this.jsonTree.Name = "jsonTree";
            this.jsonTree.Size = new System.Drawing.Size(1650, 822);
            this.jsonTree.TabIndex = 0;
            this.jsonTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.jsonTree_MouseDown);
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.txtJsonString);
            this.tabPageText.Controls.Add(this.panelTreeTextActions);
            this.tabPageText.Location = new System.Drawing.Point(4, 33);
            this.tabPageText.Margin = new System.Windows.Forms.Padding(5);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageText.Size = new System.Drawing.Size(1660, 832);
            this.tabPageText.TabIndex = 1;
            this.tabPageText.Text = "Text";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // txtJsonString
            // 
            this.txtJsonString.AcceptsReturn = true;
            this.txtJsonString.AcceptsTab = true;
            this.txtJsonString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJsonString.Location = new System.Drawing.Point(5, 61);
            this.txtJsonString.Margin = new System.Windows.Forms.Padding(5);
            this.txtJsonString.MaxLength = 10000000;
            this.txtJsonString.Multiline = true;
            this.txtJsonString.Name = "txtJsonString";
            this.txtJsonString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJsonString.Size = new System.Drawing.Size(1650, 766);
            this.txtJsonString.TabIndex = 1;
            // 
            // panelTreeTextActions
            // 
            this.panelTreeTextActions.Controls.Add(this.btnClear);
            this.panelTreeTextActions.Controls.Add(this.btnCopyTreeText);
            this.panelTreeTextActions.Controls.Add(this.btnPasteTreeText);
            this.panelTreeTextActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTreeTextActions.Location = new System.Drawing.Point(5, 5);
            this.panelTreeTextActions.Margin = new System.Windows.Forms.Padding(5);
            this.panelTreeTextActions.Name = "panelTreeTextActions";
            this.panelTreeTextActions.Size = new System.Drawing.Size(1650, 56);
            this.panelTreeTextActions.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(5, 5);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(149, 43);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopyTreeText
            // 
            this.btnCopyTreeText.Location = new System.Drawing.Point(164, 5);
            this.btnCopyTreeText.Margin = new System.Windows.Forms.Padding(5);
            this.btnCopyTreeText.Name = "btnCopyTreeText";
            this.btnCopyTreeText.Size = new System.Drawing.Size(149, 43);
            this.btnCopyTreeText.TabIndex = 1;
            this.btnCopyTreeText.Text = "Copy";
            this.btnCopyTreeText.UseVisualStyleBackColor = true;
            this.btnCopyTreeText.Click += new System.EventHandler(this.btnCopyTreeText_Click);
            // 
            // btnPasteTreeText
            // 
            this.btnPasteTreeText.Location = new System.Drawing.Point(323, 5);
            this.btnPasteTreeText.Margin = new System.Windows.Forms.Padding(5);
            this.btnPasteTreeText.Name = "btnPasteTreeText";
            this.btnPasteTreeText.Size = new System.Drawing.Size(149, 43);
            this.btnPasteTreeText.TabIndex = 2;
            this.btnPasteTreeText.Text = "Paste";
            this.btnPasteTreeText.UseVisualStyleBackColor = true;
            this.btnPasteTreeText.Click += new System.EventHandler(this.btnPasteTreeText_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gbxTokensFromURI);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.gbxBasicAuth);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1636, 869);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Utilities";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gbxTokensFromURI
            // 
            this.gbxTokensFromURI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxTokensFromURI.Controls.Add(this.btnClearQs);
            this.gbxTokensFromURI.Controls.Add(this.btnCopyIDTokenQS);
            this.gbxTokensFromURI.Controls.Add(this.txtIDTokenQs);
            this.gbxTokensFromURI.Controls.Add(this.lblIDTokenQs);
            this.gbxTokensFromURI.Controls.Add(this.btnCopyAccessTokenQs);
            this.gbxTokensFromURI.Controls.Add(this.txtAccessTokenQs);
            this.gbxTokensFromURI.Controls.Add(this.lblAccessTokenQs);
            this.gbxTokensFromURI.Controls.Add(this.txtQueryString);
            this.gbxTokensFromURI.Controls.Add(this.lblURI);
            this.gbxTokensFromURI.Location = new System.Drawing.Point(5, 503);
            this.gbxTokensFromURI.Margin = new System.Windows.Forms.Padding(5);
            this.gbxTokensFromURI.Name = "gbxTokensFromURI";
            this.gbxTokensFromURI.Padding = new System.Windows.Forms.Padding(5);
            this.gbxTokensFromURI.Size = new System.Drawing.Size(1621, 361);
            this.gbxTokensFromURI.TabIndex = 10;
            this.gbxTokensFromURI.TabStop = false;
            this.gbxTokensFromURI.Text = "Tokens from Fragment";
            // 
            // btnClearQs
            // 
            this.btnClearQs.Location = new System.Drawing.Point(1486, 40);
            this.btnClearQs.Margin = new System.Windows.Forms.Padding(5);
            this.btnClearQs.Name = "btnClearQs";
            this.btnClearQs.Size = new System.Drawing.Size(149, 43);
            this.btnClearQs.TabIndex = 13;
            this.btnClearQs.Text = "Clear";
            this.btnClearQs.UseVisualStyleBackColor = true;
            this.btnClearQs.Click += new System.EventHandler(this.btnClearQs_Click);
            // 
            // btnCopyIDTokenQS
            // 
            this.btnCopyIDTokenQS.Location = new System.Drawing.Point(1488, 277);
            this.btnCopyIDTokenQS.Margin = new System.Windows.Forms.Padding(5);
            this.btnCopyIDTokenQS.Name = "btnCopyIDTokenQS";
            this.btnCopyIDTokenQS.Size = new System.Drawing.Size(149, 43);
            this.btnCopyIDTokenQS.TabIndex = 11;
            this.btnCopyIDTokenQS.Text = "Copy";
            this.btnCopyIDTokenQS.UseVisualStyleBackColor = true;
            this.btnCopyIDTokenQS.Click += new System.EventHandler(this.btnCopyIDTokenQS_Click);
            // 
            // txtIDTokenQs
            // 
            this.txtIDTokenQs.Location = new System.Drawing.Point(250, 283);
            this.txtIDTokenQs.Margin = new System.Windows.Forms.Padding(5);
            this.txtIDTokenQs.Name = "txtIDTokenQs";
            this.txtIDTokenQs.Size = new System.Drawing.Size(1226, 32);
            this.txtIDTokenQs.TabIndex = 12;
            // 
            // lblIDTokenQs
            // 
            this.lblIDTokenQs.AutoSize = true;
            this.lblIDTokenQs.Location = new System.Drawing.Point(15, 286);
            this.lblIDTokenQs.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIDTokenQs.Name = "lblIDTokenQs";
            this.lblIDTokenQs.Size = new System.Drawing.Size(92, 24);
            this.lblIDTokenQs.TabIndex = 10;
            this.lblIDTokenQs.Text = "ID Token";
            // 
            // btnCopyAccessTokenQs
            // 
            this.btnCopyAccessTokenQs.Location = new System.Drawing.Point(1488, 224);
            this.btnCopyAccessTokenQs.Margin = new System.Windows.Forms.Padding(5);
            this.btnCopyAccessTokenQs.Name = "btnCopyAccessTokenQs";
            this.btnCopyAccessTokenQs.Size = new System.Drawing.Size(149, 43);
            this.btnCopyAccessTokenQs.TabIndex = 8;
            this.btnCopyAccessTokenQs.Text = "Copy";
            this.btnCopyAccessTokenQs.UseVisualStyleBackColor = true;
            this.btnCopyAccessTokenQs.Click += new System.EventHandler(this.btnCopyAccessTokenQs_Click);
            // 
            // txtAccessTokenQs
            // 
            this.txtAccessTokenQs.Location = new System.Drawing.Point(250, 230);
            this.txtAccessTokenQs.Margin = new System.Windows.Forms.Padding(5);
            this.txtAccessTokenQs.Name = "txtAccessTokenQs";
            this.txtAccessTokenQs.Size = new System.Drawing.Size(1226, 32);
            this.txtAccessTokenQs.TabIndex = 9;
            // 
            // lblAccessTokenQs
            // 
            this.lblAccessTokenQs.AutoSize = true;
            this.lblAccessTokenQs.Location = new System.Drawing.Point(15, 233);
            this.lblAccessTokenQs.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAccessTokenQs.Name = "lblAccessTokenQs";
            this.lblAccessTokenQs.Size = new System.Drawing.Size(140, 24);
            this.lblAccessTokenQs.TabIndex = 5;
            this.lblAccessTokenQs.Text = "Access Token";
            // 
            // txtQueryString
            // 
            this.txtQueryString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueryString.Location = new System.Drawing.Point(250, 40);
            this.txtQueryString.Margin = new System.Windows.Forms.Padding(5);
            this.txtQueryString.Multiline = true;
            this.txtQueryString.Name = "txtQueryString";
            this.txtQueryString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQueryString.Size = new System.Drawing.Size(1194, 174);
            this.txtQueryString.TabIndex = 4;
            this.txtQueryString.TextChanged += new System.EventHandler(this.txtQueryString_TextChanged);
            // 
            // lblURI
            // 
            this.lblURI.AutoSize = true;
            this.lblURI.Location = new System.Drawing.Point(12, 40);
            this.lblURI.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblURI.Name = "lblURI";
            this.lblURI.Size = new System.Drawing.Size(45, 24);
            this.lblURI.TabIndex = 1;
            this.lblURI.Text = "URI";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCopyBase64);
            this.groupBox1.Controls.Add(this.btnFromBase64);
            this.groupBox1.Controls.Add(this.btnToBase64);
            this.groupBox1.Controls.Add(this.txtBase64Output);
            this.groupBox1.Controls.Add(this.txtBase64Input);
            this.groupBox1.Location = new System.Drawing.Point(5, 208);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1626, 285);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base64 encode/decode";
            // 
            // btnCopyBase64
            // 
            this.btnCopyBase64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyBase64.Location = new System.Drawing.Point(768, 223);
            this.btnCopyBase64.Margin = new System.Windows.Forms.Padding(5);
            this.btnCopyBase64.Name = "btnCopyBase64";
            this.btnCopyBase64.Size = new System.Drawing.Size(149, 43);
            this.btnCopyBase64.TabIndex = 7;
            this.btnCopyBase64.Text = "Copy";
            this.btnCopyBase64.UseVisualStyleBackColor = true;
            this.btnCopyBase64.Click += new System.EventHandler(this.btnCopyBase64_Click);
            // 
            // btnFromBase64
            // 
            this.btnFromBase64.Location = new System.Drawing.Point(647, 83);
            this.btnFromBase64.Margin = new System.Windows.Forms.Padding(5);
            this.btnFromBase64.Name = "btnFromBase64";
            this.btnFromBase64.Size = new System.Drawing.Size(109, 37);
            this.btnFromBase64.TabIndex = 6;
            this.btnFromBase64.Text = "<<";
            this.btnFromBase64.UseVisualStyleBackColor = true;
            this.btnFromBase64.Click += new System.EventHandler(this.btnFromBase64_Click);
            // 
            // btnToBase64
            // 
            this.btnToBase64.Location = new System.Drawing.Point(647, 35);
            this.btnToBase64.Margin = new System.Windows.Forms.Padding(5);
            this.btnToBase64.Name = "btnToBase64";
            this.btnToBase64.Size = new System.Drawing.Size(109, 37);
            this.btnToBase64.TabIndex = 5;
            this.btnToBase64.Text = ">>";
            this.btnToBase64.UseVisualStyleBackColor = true;
            this.btnToBase64.Click += new System.EventHandler(this.btnToBase64_Click);
            // 
            // txtBase64Output
            // 
            this.txtBase64Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBase64Output.Location = new System.Drawing.Point(768, 35);
            this.txtBase64Output.Margin = new System.Windows.Forms.Padding(5);
            this.txtBase64Output.Multiline = true;
            this.txtBase64Output.Name = "txtBase64Output";
            this.txtBase64Output.Size = new System.Drawing.Size(842, 178);
            this.txtBase64Output.TabIndex = 4;
            // 
            // txtBase64Input
            // 
            this.txtBase64Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBase64Input.Location = new System.Drawing.Point(19, 35);
            this.txtBase64Input.Margin = new System.Windows.Forms.Padding(5);
            this.txtBase64Input.Multiline = true;
            this.txtBase64Input.Name = "txtBase64Input";
            this.txtBase64Input.Size = new System.Drawing.Size(612, 178);
            this.txtBase64Input.TabIndex = 0;
            // 
            // gbxBasicAuth
            // 
            this.gbxBasicAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxBasicAuth.Controls.Add(this.label1);
            this.gbxBasicAuth.Controls.Add(this.btnCopyBasicHeader);
            this.gbxBasicAuth.Controls.Add(this.btnBasicDecrypt);
            this.gbxBasicAuth.Controls.Add(this.btnBasicEncrypt);
            this.gbxBasicAuth.Controls.Add(this.txtBasicHeader);
            this.gbxBasicAuth.Controls.Add(this.lblPassword);
            this.gbxBasicAuth.Controls.Add(this.txtPassword);
            this.gbxBasicAuth.Controls.Add(this.lblUserName);
            this.gbxBasicAuth.Controls.Add(this.txtUserName);
            this.gbxBasicAuth.Location = new System.Drawing.Point(5, 15);
            this.gbxBasicAuth.Margin = new System.Windows.Forms.Padding(5);
            this.gbxBasicAuth.Name = "gbxBasicAuth";
            this.gbxBasicAuth.Padding = new System.Windows.Forms.Padding(5);
            this.gbxBasicAuth.Size = new System.Drawing.Size(1621, 183);
            this.gbxBasicAuth.TabIndex = 0;
            this.gbxBasicAuth.TabStop = false;
            this.gbxBasicAuth.Text = "Basic Authentication header generator";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(931, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 48);
            this.label1.TabIndex = 8;
            this.label1.Text = "The header name must be set to \'Authorization\' \r\nand the value must be \'Basic [co" +
    "pied value]\'";
            // 
            // btnCopyBasicHeader
            // 
            this.btnCopyBasicHeader.Location = new System.Drawing.Point(768, 126);
            this.btnCopyBasicHeader.Margin = new System.Windows.Forms.Padding(5);
            this.btnCopyBasicHeader.Name = "btnCopyBasicHeader";
            this.btnCopyBasicHeader.Size = new System.Drawing.Size(149, 43);
            this.btnCopyBasicHeader.TabIndex = 7;
            this.btnCopyBasicHeader.Text = "Copy";
            this.btnCopyBasicHeader.UseVisualStyleBackColor = true;
            this.btnCopyBasicHeader.Click += new System.EventHandler(this.btnCopyBasicHeader_Click);
            // 
            // btnBasicDecrypt
            // 
            this.btnBasicDecrypt.Location = new System.Drawing.Point(647, 83);
            this.btnBasicDecrypt.Margin = new System.Windows.Forms.Padding(5);
            this.btnBasicDecrypt.Name = "btnBasicDecrypt";
            this.btnBasicDecrypt.Size = new System.Drawing.Size(109, 37);
            this.btnBasicDecrypt.TabIndex = 6;
            this.btnBasicDecrypt.Text = "<<";
            this.btnBasicDecrypt.UseVisualStyleBackColor = true;
            this.btnBasicDecrypt.Click += new System.EventHandler(this.btnBasicDecrypt_Click);
            // 
            // btnBasicEncrypt
            // 
            this.btnBasicEncrypt.Location = new System.Drawing.Point(647, 35);
            this.btnBasicEncrypt.Margin = new System.Windows.Forms.Padding(5);
            this.btnBasicEncrypt.Name = "btnBasicEncrypt";
            this.btnBasicEncrypt.Size = new System.Drawing.Size(109, 37);
            this.btnBasicEncrypt.TabIndex = 5;
            this.btnBasicEncrypt.Text = ">>";
            this.btnBasicEncrypt.UseVisualStyleBackColor = true;
            this.btnBasicEncrypt.Click += new System.EventHandler(this.btnBasicEncrypt_Click);
            // 
            // txtBasicHeader
            // 
            this.txtBasicHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBasicHeader.Location = new System.Drawing.Point(768, 35);
            this.txtBasicHeader.Margin = new System.Windows.Forms.Padding(5);
            this.txtBasicHeader.Multiline = true;
            this.txtBasicHeader.Name = "txtBasicHeader";
            this.txtBasicHeader.Size = new System.Drawing.Size(837, 81);
            this.txtBasicHeader.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 88);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(103, 24);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(133, 83);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(496, 32);
            this.txtPassword.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 40);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(105, 24);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Username";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(133, 35);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(496, 32);
            this.txtUserName.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 906);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 28, 0);
            this.statusStrip.Size = new System.Drawing.Size(1644, 22);
            this.statusStrip.TabIndex = 41;
            this.statusStrip.Text = "statusStrip1";
            // 
            // txtStatusLabel
            // 
            this.txtStatusLabel.Name = "txtStatusLabel";
            this.txtStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel1.Text = "© gianpo";
            // 
            // cMenuJsonTree
            // 
            this.cMenuJsonTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuJsonTreeCopyValue});
            this.cMenuJsonTree.Name = "cMenuJsonTree";
            this.cMenuJsonTree.Size = new System.Drawing.Size(134, 26);
            // 
            // cMenuJsonTreeCopyValue
            // 
            this.cMenuJsonTreeCopyValue.Name = "cMenuJsonTreeCopyValue";
            this.cMenuJsonTreeCopyValue.Size = new System.Drawing.Size(133, 22);
            this.cMenuJsonTreeCopyValue.Text = "Copy value";
            this.cMenuJsonTreeCopyValue.Click += new System.EventHandler(this.cMenuJsonTreeCopyValue_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1644, 928);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OAuth2 console";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgParameters)).EndInit();
            this.tbMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tbResults.ResumeLayout(false);
            this.tbResultsPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInvokeResults)).EndInit();
            this.cMenuGridResults.ResumeLayout(false);
            this.tbResultsPage2.ResumeLayout(false);
            this.tbResultsPage2.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabJSONViewer.ResumeLayout(false);
            this.tabPageViwer.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.tabPageText.PerformLayout();
            this.panelTreeTextActions.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.gbxTokensFromURI.ResumeLayout(false);
            this.gbxTokensFromURI.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxBasicAuth.ResumeLayout(false);
            this.gbxBasicAuth.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.cMenuJsonTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAuthEndpoint;
        private System.Windows.Forms.TextBox txtAuthEndpoint;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cbxMethod;
        private System.Windows.Forms.DataGridView dgParameters;
        private System.Windows.Forms.ComboBox cbxActions;
        private System.Windows.Forms.Button btnInvoke;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cbBrowse;
        private System.Windows.Forms.TextBox txtTokenEndpoint;
        private System.Windows.Forms.Label lblTokenEndpoint;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.ComboBox cbxProviders;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.TextBox txtResourceEndpoint;
        private System.Windows.Forms.Label lblResourceEndpoint;
        private System.Windows.Forms.TextBox txtAddressBar;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.Label lblClientSecret;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.TextBox txtScopes;
        private System.Windows.Forms.Label lblScopes;
        private System.Windows.Forms.TextBox txtRedirectURI;
        private System.Windows.Forms.Label lblRedirectURI;
        private System.Windows.Forms.Button btnRefreshParams;
        private System.Windows.Forms.TextBox txtInvokedEndpoint;
        private System.Windows.Forms.Label lblInvokedEndpoint;
        private System.Windows.Forms.Label lblSpaceSep;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckBox chkRunWithoutCookies;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gbxBasicAuth;
        private System.Windows.Forms.Button btnBasicDecrypt;
        private System.Windows.Forms.Button btnBasicEncrypt;
        private System.Windows.Forms.TextBox txtBasicHeader;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnCopyBasicHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgInvokeResults;
        private System.Windows.Forms.ContextMenuStrip cMenuGridResults;
        private System.Windows.Forms.ToolStripMenuItem cMenuBtnCopyHeaders;
        private System.Windows.Forms.ToolStripSeparator cMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cMenuBtnCopyAuthCode;
        private System.Windows.Forms.ToolStripMenuItem cMenuBtnCopyToken;
        private System.Windows.Forms.ToolStripMenuItem cMenuBtnCopyRToken;
        private System.Windows.Forms.ToolStripMenuItem cMenuBtnCopyContent;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel txtStatusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContentType;
        private System.Windows.Forms.ToolStripMenuItem cMenuBtnClearAll;
        private System.Windows.Forms.ProgressBar pbLoading;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cbxClients;
        private System.Windows.Forms.ToolStripSeparator cMenuSeparator2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCopyBase64;
        private System.Windows.Forms.Button btnFromBase64;
        private System.Windows.Forms.Button btnToBase64;
        private System.Windows.Forms.TextBox txtBase64Output;
        private System.Windows.Forms.TextBox txtBase64Input;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TreeView jsonTree;
        private System.Windows.Forms.TextBox txtJsonString;
        private System.Windows.Forms.TabControl tabJSONViewer;
        private System.Windows.Forms.TabPage tabPageViwer;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.FlowLayoutPanel panelTreeTextActions;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCopyTreeText;
        private System.Windows.Forms.Button btnPasteTreeText;
        private System.Windows.Forms.ContextMenuStrip cMenuJsonTree;
        private System.Windows.Forms.ToolStripMenuItem cMenuJsonTreeCopyValue;
        private System.Windows.Forms.Label lblContentType;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnGetAuthHeader;
        private System.Windows.Forms.TabControl tbResults;
        private System.Windows.Forms.TabPage tbResultsPage1;
        private System.Windows.Forms.TabPage tbResultsPage2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStripMenuItem cMenuBtnCopyIdToken;
        private System.Windows.Forms.WebBrowser webBrowserWinForm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn colParameterType;
        private System.Windows.Forms.GroupBox gbxTokensFromURI;
        private System.Windows.Forms.TextBox txtQueryString;
        private System.Windows.Forms.Label lblURI;
        private System.Windows.Forms.Button btnCopyIDTokenQS;
        private System.Windows.Forms.TextBox txtIDTokenQs;
        private System.Windows.Forms.Label lblIDTokenQs;
        private System.Windows.Forms.Button btnCopyAccessTokenQs;
        private System.Windows.Forms.TextBox txtAccessTokenQs;
        private System.Windows.Forms.Label lblAccessTokenQs;
        private System.Windows.Forms.Button btnClearQs;
    }
}

