
namespace FO2Dat
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            ListViewGroup listViewGroup3 = new ListViewGroup("Klasörler", HorizontalAlignment.Left);
            ListViewGroup listViewGroup4 = new ListViewGroup("Dosyalar", HorizontalAlignment.Left);
            stbStatus = new StatusStrip();
            prbProgress = new ToolStripProgressBar();
            lblFileSize = new ToolStripStatusLabel();
            lblRealSize = new ToolStripStatusLabel();
            lblCount = new ToolStripStatusLabel();
            lblItems = new ToolStripStatusLabel();
            lblSelected = new ToolStripStatusLabel();
            dlgOpen = new OpenFileDialog();
            dlgSave = new SaveFileDialog();
            imlSmallIcons = new ImageList(components);
            imlTreeIcons = new ImageList(components);
            imlLargeIcons = new ImageList(components);
            mnuStrip = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuFileNew = new ToolStripMenuItem();
            mnuFileOpen = new ToolStripMenuItem();
            mnuFileClose = new ToolStripMenuItem();
            mnuFileLine1 = new ToolStripSeparator();
            mnuFileCompress = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            mnuFileExtractAll = new ToolStripMenuItem();
            mnuFileExtractSelection = new ToolStripMenuItem();
            mnuFileLine2 = new ToolStripSeparator();
            mnuFileQuit = new ToolStripMenuItem();
            mnuView = new ToolStripMenuItem();
            mnuViewLargeIcon = new ToolStripMenuItem();
            mnuViewSmallIcon = new ToolStripMenuItem();
            mnuViewList = new ToolStripMenuItem();
            mnuViewDetails = new ToolStripMenuItem();
            mnuViewTile = new ToolStripMenuItem();
            mnuViewShowGroups = new ToolStripMenuItem();
            splContainer = new SplitContainer();
            trvTree = new TreeView();
            lstFiles = new ListView();
            fldBrowse = new FolderBrowserDialog();
            wrkNew = new System.ComponentModel.BackgroundWorker();
            wrkCompress = new System.ComponentModel.BackgroundWorker();
            tlbTools = new ToolStrip();
            btnNew = new ToolStripButton();
            btnOpen = new ToolStripButton();
            btnClose = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnCompress = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnViewLargeIcons = new ToolStripButton();
            btnViewSmallIcons = new ToolStripButton();
            btnViewList = new ToolStripButton();
            btnViewDetails = new ToolStripButton();
            btnViewTile = new ToolStripButton();
            btnViewGroups = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnExtractAll = new ToolStripButton();
            btnExtractSelection = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnUpOneLevel = new ToolStripButton();
            mnuLanguage = new ToolStripDropDownButton();
            mnuLanguageTurkish = new ToolStripMenuItem();
            mnuLanguageEnglish = new ToolStripMenuItem();
            wrkExtract = new System.ComponentModel.BackgroundWorker();
            stbStatus.SuspendLayout();
            mnuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splContainer).BeginInit();
            splContainer.Panel1.SuspendLayout();
            splContainer.Panel2.SuspendLayout();
            splContainer.SuspendLayout();
            tlbTools.SuspendLayout();
            SuspendLayout();
            // 
            // stbStatus
            // 
            stbStatus.GripStyle = ToolStripGripStyle.Visible;
            stbStatus.ImageScalingSize = new Size(24, 24);
            stbStatus.Items.AddRange(new ToolStripItem[] { prbProgress, lblFileSize, lblRealSize, lblCount, lblItems, lblSelected });
            stbStatus.Location = new Point(0, 639);
            stbStatus.Name = "stbStatus";
            stbStatus.Padding = new Padding(1, 0, 16, 0);
            stbStatus.Size = new Size(1057, 22);
            stbStatus.TabIndex = 2;
            stbStatus.Resize += stbStatus_Resize;
            // 
            // prbProgress
            // 
            prbProgress.AutoSize = false;
            prbProgress.Name = "prbProgress";
            prbProgress.Size = new Size(832, 16);
            prbProgress.Visible = false;
            // 
            // lblFileSize
            // 
            lblFileSize.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(4, 17);
            // 
            // lblRealSize
            // 
            lblRealSize.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblRealSize.Name = "lblRealSize";
            lblRealSize.Size = new Size(4, 17);
            // 
            // lblCount
            // 
            lblCount.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(4, 17);
            // 
            // lblItems
            // 
            lblItems.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblItems.Name = "lblItems";
            lblItems.Size = new Size(4, 17);
            // 
            // lblSelected
            // 
            lblSelected.Name = "lblSelected";
            lblSelected.Size = new Size(0, 17);
            // 
            // dlgOpen
            // 
            dlgOpen.DefaultExt = "dat";
            dlgOpen.Filter = "Fallout 2 DAT Files|*.dat";
            // 
            // dlgSave
            // 
            dlgSave.Filter = "Fallout 2 DAT Files|*.dat";
            // 
            // imlSmallIcons
            // 
            imlSmallIcons.ColorDepth = ColorDepth.Depth8Bit;
            imlSmallIcons.ImageStream = (ImageListStreamer)resources.GetObject("imlSmallIcons.ImageStream");
            imlSmallIcons.TransparentColor = Color.Transparent;
            imlSmallIcons.Images.SetKeyName(0, "SCLSFOLD.png");
            imlSmallIcons.Images.SetKeyName(1, "SFILE.png");
            // 
            // imlTreeIcons
            // 
            imlTreeIcons.ColorDepth = ColorDepth.Depth8Bit;
            imlTreeIcons.ImageStream = (ImageListStreamer)resources.GetObject("imlTreeIcons.ImageStream");
            imlTreeIcons.TransparentColor = Color.Transparent;
            imlTreeIcons.Images.SetKeyName(0, "SCLSFOLD.png");
            imlTreeIcons.Images.SetKeyName(1, "SOPNFOLD.png");
            // 
            // imlLargeIcons
            // 
            imlLargeIcons.ColorDepth = ColorDepth.Depth8Bit;
            imlLargeIcons.ImageStream = (ImageListStreamer)resources.GetObject("imlLargeIcons.ImageStream");
            imlLargeIcons.TransparentColor = Color.Transparent;
            imlLargeIcons.Images.SetKeyName(0, "CLSDFOLD.png");
            imlLargeIcons.Images.SetKeyName(1, "FILE.png");
            // 
            // mnuStrip
            // 
            mnuStrip.GripStyle = ToolStripGripStyle.Visible;
            mnuStrip.ImageScalingSize = new Size(24, 24);
            mnuStrip.Items.AddRange(new ToolStripItem[] { mnuFile, mnuView });
            mnuStrip.Location = new Point(0, 0);
            mnuStrip.Name = "mnuStrip";
            mnuStrip.Padding = new Padding(2, 1, 0, 1);
            mnuStrip.Size = new Size(1057, 24);
            mnuStrip.TabIndex = 5;
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileNew, mnuFileOpen, mnuFileClose, mnuFileLine1, mnuFileCompress, toolStripSeparator5, mnuFileExtractAll, mnuFileExtractSelection, mnuFileLine2, mnuFileQuit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(51, 22);
            mnuFile.Tag = "3";
            mnuFile.Text = "Dosya";
            // 
            // mnuFileNew
            // 
            mnuFileNew.Image = Properties.Resources.mnuFileNew_Image;
            mnuFileNew.ImageScaling = ToolStripItemImageScaling.None;
            mnuFileNew.ImageTransparentColor = Color.Silver;
            mnuFileNew.Name = "mnuFileNew";
            mnuFileNew.ShortcutKeyDisplayString = "";
            mnuFileNew.ShortcutKeys = Keys.Control | Keys.N;
            mnuFileNew.Size = new Size(195, 22);
            mnuFileNew.Tag = "1";
            mnuFileNew.Text = "Yeni...";
            mnuFileNew.Click += mnuFileNew_Click;
            // 
            // mnuFileOpen
            // 
            mnuFileOpen.Image = Properties.Resources.mnuFileOpen_Image;
            mnuFileOpen.ImageScaling = ToolStripItemImageScaling.None;
            mnuFileOpen.ImageTransparentColor = Color.Silver;
            mnuFileOpen.Name = "mnuFileOpen";
            mnuFileOpen.ShortcutKeys = Keys.Control | Keys.O;
            mnuFileOpen.Size = new Size(195, 22);
            mnuFileOpen.Tag = "1";
            mnuFileOpen.Text = "Aç...";
            mnuFileOpen.Click += mnuFileOpen_Click;
            // 
            // mnuFileClose
            // 
            mnuFileClose.Image = Properties.Resources.mnuFileClose_Image;
            mnuFileClose.ImageScaling = ToolStripItemImageScaling.None;
            mnuFileClose.ImageTransparentColor = Color.Silver;
            mnuFileClose.Name = "mnuFileClose";
            mnuFileClose.Size = new Size(195, 22);
            mnuFileClose.Tag = "1";
            mnuFileClose.Text = "Kapat";
            mnuFileClose.Click += mnuFileClose_Click;
            // 
            // mnuFileLine1
            // 
            mnuFileLine1.Name = "mnuFileLine1";
            mnuFileLine1.Size = new Size(192, 6);
            // 
            // mnuFileCompress
            // 
            mnuFileCompress.Enabled = false;
            mnuFileCompress.Image = Properties.Resources.mnuFileCompress_Image;
            mnuFileCompress.ImageScaling = ToolStripItemImageScaling.None;
            mnuFileCompress.Name = "mnuFileCompress";
            mnuFileCompress.ShortcutKeys = Keys.Control | Keys.S;
            mnuFileCompress.Size = new Size(195, 22);
            mnuFileCompress.Tag = "1";
            mnuFileCompress.Text = "Sıkıştır...";
            mnuFileCompress.Click += mnuFileCompress_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(192, 6);
            // 
            // mnuFileExtractAll
            // 
            mnuFileExtractAll.Enabled = false;
            mnuFileExtractAll.Image = Properties.Resources.mnuFileExtractAll_Image;
            mnuFileExtractAll.ImageScaling = ToolStripItemImageScaling.None;
            mnuFileExtractAll.ImageTransparentColor = Color.Transparent;
            mnuFileExtractAll.Name = "mnuFileExtractAll";
            mnuFileExtractAll.ShortcutKeys = Keys.Control | Keys.Shift | Keys.E;
            mnuFileExtractAll.Size = new Size(195, 22);
            mnuFileExtractAll.Tag = "1";
            mnuFileExtractAll.Text = "Hepsini...";
            mnuFileExtractAll.Click += mnuExtractAll_Click;
            // 
            // mnuFileExtractSelection
            // 
            mnuFileExtractSelection.Enabled = false;
            mnuFileExtractSelection.Image = Properties.Resources.mnuFileExtractSelection_Image;
            mnuFileExtractSelection.ImageScaling = ToolStripItemImageScaling.None;
            mnuFileExtractSelection.ImageTransparentColor = Color.Transparent;
            mnuFileExtractSelection.Name = "mnuFileExtractSelection";
            mnuFileExtractSelection.ShortcutKeys = Keys.Control | Keys.E;
            mnuFileExtractSelection.Size = new Size(195, 22);
            mnuFileExtractSelection.Tag = "1";
            mnuFileExtractSelection.Text = "Seçimi...";
            mnuFileExtractSelection.Click += mnuExtractSelection_Click;
            // 
            // mnuFileLine2
            // 
            mnuFileLine2.Name = "mnuFileLine2";
            mnuFileLine2.Size = new Size(192, 6);
            // 
            // mnuFileQuit
            // 
            mnuFileQuit.Name = "mnuFileQuit";
            mnuFileQuit.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuFileQuit.Size = new Size(195, 22);
            mnuFileQuit.Tag = "1";
            mnuFileQuit.Text = "Çıkış";
            mnuFileQuit.Click += mnuFileQuit_Click;
            // 
            // mnuView
            // 
            mnuView.DropDownItems.AddRange(new ToolStripItem[] { mnuViewLargeIcon, mnuViewSmallIcon, mnuViewList, mnuViewDetails, mnuViewTile, mnuViewShowGroups });
            mnuView.Name = "mnuView";
            mnuView.Size = new Size(70, 22);
            mnuView.Tag = "1";
            mnuView.Text = "Görünüm";
            // 
            // mnuViewLargeIcon
            // 
            mnuViewLargeIcon.Image = Properties.Resources.mnuViewLargeIcon_Image;
            mnuViewLargeIcon.ImageScaling = ToolStripItemImageScaling.None;
            mnuViewLargeIcon.ImageTransparentColor = Color.Silver;
            mnuViewLargeIcon.Name = "mnuViewLargeIcon";
            mnuViewLargeIcon.Size = new Size(180, 22);
            mnuViewLargeIcon.Tag = "1";
            mnuViewLargeIcon.Text = "Büyük Simge";
            mnuViewLargeIcon.Click += mnuViewLargeIcon_Click;
            // 
            // mnuViewSmallIcon
            // 
            mnuViewSmallIcon.Image = Properties.Resources.mnuViewSmallIcon_Image;
            mnuViewSmallIcon.ImageScaling = ToolStripItemImageScaling.None;
            mnuViewSmallIcon.ImageTransparentColor = Color.Silver;
            mnuViewSmallIcon.Name = "mnuViewSmallIcon";
            mnuViewSmallIcon.Size = new Size(180, 22);
            mnuViewSmallIcon.Tag = "1";
            mnuViewSmallIcon.Text = "Küçük Simge";
            mnuViewSmallIcon.Click += mnuViewSmallIcon_Click;
            // 
            // mnuViewList
            // 
            mnuViewList.Image = Properties.Resources.btnViewList_Image;
            mnuViewList.ImageScaling = ToolStripItemImageScaling.None;
            mnuViewList.ImageTransparentColor = Color.Silver;
            mnuViewList.Name = "mnuViewList";
            mnuViewList.Size = new Size(180, 22);
            mnuViewList.Tag = "1";
            mnuViewList.Text = "Liste";
            mnuViewList.Click += mnuViewList_Click;
            // 
            // mnuViewDetails
            // 
            mnuViewDetails.Checked = true;
            mnuViewDetails.CheckState = CheckState.Checked;
            mnuViewDetails.Image = Properties.Resources.mnuViewDetails_Image;
            mnuViewDetails.ImageScaling = ToolStripItemImageScaling.None;
            mnuViewDetails.ImageTransparentColor = Color.Silver;
            mnuViewDetails.Name = "mnuViewDetails";
            mnuViewDetails.Size = new Size(180, 22);
            mnuViewDetails.Tag = "1";
            mnuViewDetails.Text = "Ayrıntılar";
            mnuViewDetails.Click += mnuViewDetails_Click;
            // 
            // mnuViewTile
            // 
            mnuViewTile.Image = Properties.Resources.mnuViewTile_Image;
            mnuViewTile.ImageScaling = ToolStripItemImageScaling.None;
            mnuViewTile.ImageTransparentColor = Color.Silver;
            mnuViewTile.Name = "mnuViewTile";
            mnuViewTile.Size = new Size(180, 22);
            mnuViewTile.Tag = "1";
            mnuViewTile.Text = "Döşeme";
            mnuViewTile.Click += mnuViewTile_Click;
            // 
            // mnuViewShowGroups
            // 
            mnuViewShowGroups.Image = Properties.Resources.mnuViewShowGroups_Image;
            mnuViewShowGroups.ImageScaling = ToolStripItemImageScaling.None;
            mnuViewShowGroups.ImageTransparentColor = Color.Silver;
            mnuViewShowGroups.Name = "mnuViewShowGroups";
            mnuViewShowGroups.Size = new Size(180, 22);
            mnuViewShowGroups.Tag = "1";
            mnuViewShowGroups.Text = "Grupları Göster";
            mnuViewShowGroups.Click += mnuViewShowGroups_Click;
            // 
            // splContainer
            // 
            splContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splContainer.FixedPanel = FixedPanel.Panel1;
            splContainer.Location = new Point(14, 60);
            splContainer.Margin = new Padding(4, 3, 4, 3);
            splContainer.Name = "splContainer";
            // 
            // splContainer.Panel1
            // 
            splContainer.Panel1.Controls.Add(trvTree);
            // 
            // splContainer.Panel2
            // 
            splContainer.Panel2.Controls.Add(lstFiles);
            splContainer.Size = new Size(1029, 572);
            splContainer.SplitterDistance = 300;
            splContainer.SplitterWidth = 5;
            splContainer.TabIndex = 4;
            // 
            // trvTree
            // 
            trvTree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            trvTree.HideSelection = false;
            trvTree.ImageIndex = 0;
            trvTree.ImageList = imlTreeIcons;
            trvTree.Location = new Point(4, 3);
            trvTree.Margin = new Padding(4, 3, 4, 3);
            trvTree.Name = "trvTree";
            trvTree.SelectedImageKey = "SOPNFOLD.png";
            trvTree.Size = new Size(292, 565);
            trvTree.TabIndex = 1;
            trvTree.AfterCollapse += trvTree_AfterCollapse;
            trvTree.BeforeExpand += trvTree_BeforeExpand;
            trvTree.AfterSelect += trvTree_AfterSelect;
            // 
            // lstFiles
            // 
            lstFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstFiles.FullRowSelect = true;
            listViewGroup3.Header = "Klasörler";
            listViewGroup3.Name = "grpFolders";
            listViewGroup4.Header = "Dosyalar";
            listViewGroup4.Name = "grpFiles";
            lstFiles.Groups.AddRange(new ListViewGroup[] { listViewGroup3, listViewGroup4 });
            lstFiles.LargeImageList = imlLargeIcons;
            lstFiles.Location = new Point(4, 3);
            lstFiles.Margin = new Padding(4, 3, 4, 3);
            lstFiles.Name = "lstFiles";
            lstFiles.ShowGroups = false;
            lstFiles.Size = new Size(716, 565);
            lstFiles.SmallImageList = imlSmallIcons;
            lstFiles.TabIndex = 4;
            lstFiles.UseCompatibleStateImageBehavior = false;
            lstFiles.View = View.Details;
            lstFiles.ItemSelectionChanged += lstFiles_ItemSelectionChanged;
            lstFiles.DoubleClick += lstFiles_DoubleClick;
            lstFiles.KeyDown += lstFiles_KeyDown;
            // 
            // wrkNew
            // 
            wrkNew.DoWork += wrkNew_DoWork;
            wrkNew.RunWorkerCompleted += wrkNew_RunWorkerCompleted;
            // 
            // wrkCompress
            // 
            wrkCompress.WorkerReportsProgress = true;
            wrkCompress.DoWork += wrkCompress_DoWork;
            wrkCompress.ProgressChanged += wrkCompress_ProgressChanged;
            wrkCompress.RunWorkerCompleted += wrkCompress_RunWorkerCompleted;
            // 
            // tlbTools
            // 
            tlbTools.ImageScalingSize = new Size(24, 24);
            tlbTools.Items.AddRange(new ToolStripItem[] { btnNew, btnOpen, btnClose, toolStripSeparator1, btnCompress, toolStripSeparator2, btnViewLargeIcons, btnViewSmallIcons, btnViewList, btnViewDetails, btnViewTile, btnViewGroups, toolStripSeparator3, btnExtractAll, btnExtractSelection, toolStripSeparator4, btnUpOneLevel, mnuLanguage });
            tlbTools.Location = new Point(0, 24);
            tlbTools.Name = "tlbTools";
            tlbTools.Padding = new Padding(0, 0, 2, 0);
            tlbTools.Size = new Size(1057, 25);
            tlbTools.TabIndex = 6;
            tlbTools.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNew.Image = Properties.Resources.btnNew_Image;
            btnNew.ImageScaling = ToolStripItemImageScaling.None;
            btnNew.ImageTransparentColor = Color.Silver;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(23, 22);
            btnNew.Tag = "btnNew";
            btnNew.Click += mnuFileNew_Click;
            // 
            // btnOpen
            // 
            btnOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpen.Image = Properties.Resources.btnOpen_Image;
            btnOpen.ImageScaling = ToolStripItemImageScaling.None;
            btnOpen.ImageTransparentColor = Color.Silver;
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(23, 22);
            btnOpen.Tag = "btnOpen";
            btnOpen.Click += mnuFileOpen_Click;
            // 
            // btnClose
            // 
            btnClose.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnClose.Image = Properties.Resources.btnClose_Image;
            btnClose.ImageScaling = ToolStripItemImageScaling.None;
            btnClose.ImageTransparentColor = Color.Silver;
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(23, 22);
            btnClose.Tag = "btnClose";
            btnClose.Click += mnuFileClose_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // btnCompress
            // 
            btnCompress.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCompress.Enabled = false;
            btnCompress.Image = Properties.Resources.btnCompress_Image;
            btnCompress.ImageScaling = ToolStripItemImageScaling.None;
            btnCompress.ImageTransparentColor = Color.Transparent;
            btnCompress.Name = "btnCompress";
            btnCompress.Size = new Size(23, 22);
            btnCompress.Tag = "btnCompress";
            btnCompress.Click += mnuFileCompress_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // btnViewLargeIcons
            // 
            btnViewLargeIcons.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnViewLargeIcons.Image = Properties.Resources.btnViewLargeIcons_Image;
            btnViewLargeIcons.ImageScaling = ToolStripItemImageScaling.None;
            btnViewLargeIcons.ImageTransparentColor = Color.Silver;
            btnViewLargeIcons.Name = "btnViewLargeIcons";
            btnViewLargeIcons.Size = new Size(23, 22);
            btnViewLargeIcons.Tag = "btnViewLargeIcons";
            btnViewLargeIcons.Click += mnuViewLargeIcon_Click;
            // 
            // btnViewSmallIcons
            // 
            btnViewSmallIcons.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnViewSmallIcons.Image = Properties.Resources.btnViewSmallIcons_Image;
            btnViewSmallIcons.ImageScaling = ToolStripItemImageScaling.None;
            btnViewSmallIcons.ImageTransparentColor = Color.Silver;
            btnViewSmallIcons.Name = "btnViewSmallIcons";
            btnViewSmallIcons.Size = new Size(23, 22);
            btnViewSmallIcons.Tag = "btnViewSmallIcons";
            btnViewSmallIcons.Click += mnuViewSmallIcon_Click;
            // 
            // btnViewList
            // 
            btnViewList.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnViewList.Image = Properties.Resources.btnViewList_Image;
            btnViewList.ImageScaling = ToolStripItemImageScaling.None;
            btnViewList.ImageTransparentColor = Color.Silver;
            btnViewList.Name = "btnViewList";
            btnViewList.Size = new Size(23, 22);
            btnViewList.Tag = "btnViewList";
            btnViewList.Click += mnuViewList_Click;
            // 
            // btnViewDetails
            // 
            btnViewDetails.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnViewDetails.Image = Properties.Resources.btnViewDetails_Image;
            btnViewDetails.ImageScaling = ToolStripItemImageScaling.None;
            btnViewDetails.ImageTransparentColor = Color.Silver;
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(23, 22);
            btnViewDetails.Tag = "btnViewDetails";
            btnViewDetails.Click += mnuViewDetails_Click;
            // 
            // btnViewTile
            // 
            btnViewTile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnViewTile.Image = Properties.Resources.btnViewTile_Image;
            btnViewTile.ImageScaling = ToolStripItemImageScaling.None;
            btnViewTile.ImageTransparentColor = Color.Silver;
            btnViewTile.Name = "btnViewTile";
            btnViewTile.Size = new Size(23, 22);
            btnViewTile.Tag = "btnViewTile";
            btnViewTile.Click += mnuViewTile_Click;
            // 
            // btnViewGroups
            // 
            btnViewGroups.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnViewGroups.Image = Properties.Resources.btnViewGroups_Image;
            btnViewGroups.ImageScaling = ToolStripItemImageScaling.None;
            btnViewGroups.ImageTransparentColor = Color.Silver;
            btnViewGroups.Name = "btnViewGroups";
            btnViewGroups.Size = new Size(23, 22);
            btnViewGroups.Tag = "btnViewGroups";
            btnViewGroups.Click += mnuViewShowGroups_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // btnExtractAll
            // 
            btnExtractAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExtractAll.Enabled = false;
            btnExtractAll.Image = Properties.Resources.btnExtractAll_Image;
            btnExtractAll.ImageScaling = ToolStripItemImageScaling.None;
            btnExtractAll.ImageTransparentColor = Color.Magenta;
            btnExtractAll.Name = "btnExtractAll";
            btnExtractAll.Size = new Size(23, 22);
            btnExtractAll.Tag = "btnExtractAll";
            btnExtractAll.Click += mnuExtractAll_Click;
            // 
            // btnExtractSelection
            // 
            btnExtractSelection.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExtractSelection.Enabled = false;
            btnExtractSelection.Image = Properties.Resources.btnExtractSelection_Image;
            btnExtractSelection.ImageScaling = ToolStripItemImageScaling.None;
            btnExtractSelection.ImageTransparentColor = Color.Magenta;
            btnExtractSelection.Name = "btnExtractSelection";
            btnExtractSelection.Size = new Size(23, 22);
            btnExtractSelection.Tag = "btnExtractSelection";
            btnExtractSelection.Click += mnuExtractSelection_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // btnUpOneLevel
            // 
            btnUpOneLevel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnUpOneLevel.Image = Properties.Resources.btnUpOneLevel_Image;
            btnUpOneLevel.ImageScaling = ToolStripItemImageScaling.None;
            btnUpOneLevel.ImageTransparentColor = Color.Silver;
            btnUpOneLevel.Name = "btnUpOneLevel";
            btnUpOneLevel.Size = new Size(23, 22);
            btnUpOneLevel.Tag = "btnUpOneLevel";
            btnUpOneLevel.Click += btnUpOneLevel_Click;
            // 
            // mnuLanguage
            // 
            mnuLanguage.Alignment = ToolStripItemAlignment.Right;
            mnuLanguage.DisplayStyle = ToolStripItemDisplayStyle.Image;
            mnuLanguage.DropDownItems.AddRange(new ToolStripItem[] { mnuLanguageTurkish, mnuLanguageEnglish });
            mnuLanguage.Image = Properties.Resources.mnuLanguage_Image;
            mnuLanguage.ImageScaling = ToolStripItemImageScaling.None;
            mnuLanguage.ImageTransparentColor = Color.Magenta;
            mnuLanguage.Name = "mnuLanguage";
            mnuLanguage.Size = new Size(29, 22);
            mnuLanguage.Tag = "mnuLanguage";
            // 
            // mnuLanguageTurkish
            // 
            mnuLanguageTurkish.Image = Properties.Resources.mnuLanguageTurkish_Image;
            mnuLanguageTurkish.ImageScaling = ToolStripItemImageScaling.None;
            mnuLanguageTurkish.Name = "mnuLanguageTurkish";
            mnuLanguageTurkish.Size = new Size(188, 30);
            mnuLanguageTurkish.Tag = "";
            mnuLanguageTurkish.Text = "Türkçe";
            mnuLanguageTurkish.Click += mnuLanguageTurkish_Click;
            // 
            // mnuLanguageEnglish
            // 
            mnuLanguageEnglish.Image = Properties.Resources.mnuLanguageEnglish_Image;
            mnuLanguageEnglish.ImageScaling = ToolStripItemImageScaling.None;
            mnuLanguageEnglish.Name = "mnuLanguageEnglish";
            mnuLanguageEnglish.Size = new Size(112, 22);
            mnuLanguageEnglish.Tag = "";
            mnuLanguageEnglish.Text = "English";
            mnuLanguageEnglish.Click += mnuLanguageEnglish_Click;
            // 
            // wrkExtract
            // 
            wrkExtract.WorkerReportsProgress = true;
            wrkExtract.DoWork += wrkExtract_DoWork;
            wrkExtract.ProgressChanged += wrkExtract_ProgressChanged;
            wrkExtract.RunWorkerCompleted += wrkExtract_RunWorkerCompleted;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 661);
            Controls.Add(tlbTools);
            Controls.Add(splContainer);
            Controls.Add(stbStatus);
            Controls.Add(mnuStrip);
            MainMenuStrip = mnuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormMain";
            StartPosition = FormStartPosition.Manual;
            Text = "FO2Dat";
            FormClosing += formMain_FormClosing;
            stbStatus.ResumeLayout(false);
            stbStatus.PerformLayout();
            mnuStrip.ResumeLayout(false);
            mnuStrip.PerformLayout();
            splContainer.Panel1.ResumeLayout(false);
            splContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splContainer).EndInit();
            splContainer.ResumeLayout(false);
            tlbTools.ResumeLayout(false);
            tlbTools.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip stbStatus;
        private OpenFileDialog dlgOpen;
        private SaveFileDialog dlgSave;
        private ImageList imlSmallIcons;
        private SplitContainer splContainer;
        private TreeView trvTree;
        private ListView lstFiles;
        private MenuStrip mnuStrip;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuFileNew;
        private ToolStripMenuItem mnuFileOpen;
        private ToolStripSeparator mnuFileLine1;
        private ToolStripMenuItem mnuFileCompress;
        private ToolStripSeparator mnuFileLine2;
        private ToolStripMenuItem mnuFileQuit;
        private ToolStripMenuItem mnuView;
        private ToolStripMenuItem mnuViewLargeIcon;
        private ToolStripMenuItem mnuViewSmallIcon;
        private ToolStripMenuItem mnuViewList;
        private ToolStripMenuItem mnuViewDetails;
        private ToolStripMenuItem mnuViewTile;
        private ToolStripProgressBar prbProgress;
        private ToolStripMenuItem mnuFileClose;
        private ImageList imlTreeIcons;
        private ImageList imlLargeIcons;
        private ToolStripStatusLabel lblFileSize;
        private ToolStripStatusLabel lblCount;
        private ToolStripMenuItem mnuViewShowGroups;
        private ToolStripStatusLabel lblRealSize;
        private FolderBrowserDialog fldBrowse;
        private System.ComponentModel.BackgroundWorker wrkNew;
        private System.ComponentModel.BackgroundWorker wrkCompress;
        private ToolStrip tlbTools;
        private ToolStripButton btnNew;
        private ToolStripButton btnOpen;
        private ToolStripButton btnClose;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnCompress;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnViewLargeIcons;
        private ToolStripButton btnViewSmallIcons;
        private ToolStripButton btnViewList;
        private ToolStripButton btnViewDetails;
        private ToolStripButton btnViewTile;
        private ToolStripButton btnViewGroups;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnExtractAll;
        private ToolStripButton btnExtractSelection;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnUpOneLevel;
        private ToolStripDropDownButton mnuLanguage;
        private ToolStripMenuItem mnuLanguageTurkish;
        private ToolStripMenuItem mnuLanguageEnglish;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem mnuFileExtractAll;
        private ToolStripMenuItem mnuFileExtractSelection;
        private ToolStripStatusLabel lblItems;
        private ToolStripStatusLabel lblSelected;
        private System.ComponentModel.BackgroundWorker wrkExtract;
    }
}

