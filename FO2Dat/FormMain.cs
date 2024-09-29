using FO2Dat.Properties;
using System.ComponentModel;
using System.Globalization;

namespace FO2Dat
{
    public partial class FormMain : Form
    {
        private DatFile? datFile;
        //private readonly DatReader datReader = new();
        //private readonly DatWriter datWriter = new();
        //private readonly StringHelper stringHelper = new();
        private readonly string? newFileText;
        private Strings str = new();
        private int LCID;

        public FormMain()
        {
            InitializeComponent();
            loadSettings();
            prbProgress.Width = stbStatus.Width - 20;
            #region UILanguageTexts
            loadLanguageStrings(Controls);
            loadMenuStrings(mnuStrip.Items);
            loadToolBarToolTips();
            newFileText = str.newFile;
            lstFiles.Groups[0].Header = str.folder + str.sLer;
            lstFiles.Groups[1].Header = str.file + str.sLar;
            #endregion UILanguageTexts
        }

        #region FormEvents
        #region FileMenu
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            if (fldBrowse.ShowDialog(this) == DialogResult.Cancel) return;
            datFile = new DatFile
            {
                fileName = StringHelper.addSlash(fldBrowse.SelectedPath) + $"({newFileText})"
            };
            Enabled = false;
            wrkNew.RunWorkerAsync();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog(this) == DialogResult.Cancel) return;
            openFile(dlgOpen.FileName);
        }

        private void mnuFileClose_Click(object sender, EventArgs? e)
        {
            datFile = null;
            updateUIStatus(false, false);
        }

        private void mnuFileCompress_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog(this) == DialogResult.Cancel) return;
            Enabled = false;
            prbProgress.Value = 0;
            prbProgress.Visible = true;
            wrkCompress.RunWorkerAsync();
        }
        #endregion FileMenu

        #region ExtractMenu
        private void mnuExtractAll_Click(object sender, EventArgs e)
        {
            if (datFile == null) return;
            if (fldBrowse.ShowDialog(this) == DialogResult.Cancel) return;
            prbProgress.Value = 0;
            prbProgress.Visible = true;
            Enabled = false;
            wrkExtract.RunWorkerAsync(new List<object>() { datFile.dirTree, "" });
        }

        private void mnuExtractSelection_Click(object sender, EventArgs e)
        {
            if (datFile == null) return;
            if (lstFiles.SelectedItems.Count == 0) return;
            if (fldBrowse.ShowDialog(this) == DialogResult.Cancel) return;
            prbProgress.Value = 0;
            prbProgress.Visible = true;
            Enabled = false;
            List<DirEntry> entries = [];
            string fullPath = StringHelper.removePath(StringHelper.addSlash(trvTree.SelectedNode.FullPath), StringHelper.addSlash(datFile.fileTitle));
            foreach (ListViewItem listItem in lstFiles.Items)
            {
                if (listItem.Selected)
                {
                    if (listItem.Group == lstFiles.Groups["grpFiles"])
                    {
                        var tItem = datFile.dirTree.Find(x => x.fileName == fullPath + listItem.Text);
                        if (tItem != null) entries.Add(tItem);
                    }
                    else if (listItem.Group == lstFiles.Groups["grpFolders"]) entries.AddRange(datFile.dirTree.FindAll(x => x.fileName.StartsWith(fullPath + listItem.Text + "\\")));
                }
            }
            if (entries.Count > 0) wrkExtract.RunWorkerAsync(new List<object>() { entries, fullPath });
        }
        #endregion ExtractMenu

        #region UIRelated
        private void trvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (datFile == null) return;
            if (e.Node == null) return;
            lstFiles.Items.Clear();
            string fullPath = StringHelper.removePath(StringHelper.addSlash(e.Node.FullPath), StringHelper.addSlash(datFile.fileTitle));
            List<DirEntry> files = datFile.dirTree.FindAll(x => x.fileName.StartsWith(fullPath));
            List<ListViewItem> fileList = [];
            List<ListViewItem> folderList = [];
            foreach (DirEntry dirEntry in files)
            {
                string[] path = StringHelper.splitPath(StringHelper.removePath(dirEntry.fileName, fullPath));
                if (path.Length > 1)
                {
                    string subDirName = path[0];
                    if (folderList.Find(x => x.Name == subDirName) == null)
                        folderList.Add(new ListViewItem(new string[] { subDirName, str.folder ?? "" }, 0, lstFiles.Groups["grpFolders"]) { Name = subDirName });
                }
                else
                {
                    string fileTitle = path[0];
                    ListViewItem newFile = new(new string[] {
                        fileTitle,
                        (dirEntry.type == 1 ? str.compressed : str.uncompressed)??"",
                        StringHelper.formatSizeString(dirEntry.realSize),
                        StringHelper.formatSizeString(dirEntry.packedSize),
                        Convert.ToString(dirEntry.offset, 16).PadLeft(8, '0')
                    }, 1, lstFiles.Groups["grpFiles"])
                    {
                        Name = fileTitle,
                        UseItemStyleForSubItems = false,
                    };
                    newFile.SubItems[4].Font = new System.Drawing.Font("Courier New", 8.25f);
                    fileList.Add(newFile);
                }
            }
            lstFiles.Items.AddRange([.. folderList]);
            lstFiles.Items.AddRange([.. fileList]);
            updateTexts();
        }

        private void lstFiles_DoubleClick(object sender, EventArgs? e)
        {
            if (lstFiles.SelectedItems.Count != 1) return;
            var slGrp = lstFiles.SelectedItems[0].Group;
            if (slGrp == null) return;
            if (slGrp.Name != "grpFolders") return;
            var found = trvTree.SelectedNode.Nodes.Find(lstFiles.SelectedItems[0].Text, false);
            if (found.Length != 0) trvTree.SelectedNode = found[0];
        }

        private void stbStatus_Resize(object sender, EventArgs e) => prbProgress.Width = stbStatus.Width - 20;

        private void trvTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node == null) return;
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        private void trvTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void mnuViewLargeIcon_Click(object sender, EventArgs e) => lstFilesViewUpdate(View.LargeIcon);

        private void mnuViewSmallIcon_Click(object sender, EventArgs e) => lstFilesViewUpdate(View.SmallIcon);

        private void mnuViewList_Click(object sender, EventArgs e) => lstFilesViewUpdate(View.List);

        private void mnuViewDetails_Click(object sender, EventArgs e) => lstFilesViewUpdate(View.Details);

        private void mnuViewTile_Click(object sender, EventArgs e) => lstFilesViewUpdate(View.Tile);

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datFile != null)
                if (e.CloseReason == CloseReason.UserClosing && datFile.fileName.Contains($"({newFileText})"))
                    if (MessageBox.Show(this, str.applicationExitPrompt, str.warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
            foreach (ColumnHeader column in lstFiles.Columns) Settings.Default[column.Name + "Width"] = column.Width;

            Settings.Default.splContainerSplit = splContainer.SplitterDistance;

            Settings.Default.lstFilesView = lstFiles.View;

            Settings.Default.lstFilesShowGroups = lstFiles.ShowGroups;

            Settings.Default.FormState = WindowState;
            if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.FormSize = Size;
                Settings.Default.FormLocation = Location;
            }

            Settings.Default.Save();
        }

        private void mnuViewShowGroups_Click(object sender, EventArgs e)
        {
            lstFilesGroupsUpdate(!mnuViewShowGroups.Checked);
            #region FixingTheBug
            foreach (ListViewItem item in lstFiles.Items)
            {
                ListViewGroup group = item.Group ?? new ListViewGroup();
                item.Group = null;
                item.Group = group;
            }
            #endregion FixingTheBug
        }

        private void mnuFileQuit_Click(object sender, EventArgs e) => Close();

        private void btnUpOneLevel_Click(object sender, EventArgs? e)
        {
            if (trvTree.SelectedNode == null) return;
            if (trvTree.SelectedNode.Parent == null) return;
            string previousSelected = trvTree.SelectedNode.Name;
            trvTree.SelectedNode = trvTree.SelectedNode.Parent;
            try
            {
                ListViewItem item = lstFiles.Items.Find(previousSelected, false)[0];
                item.Selected = true;
                lstFiles.FocusedItem = item;
            }
            catch (Exception) { }
        }

        private void lstFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) lstFiles_DoubleClick(sender, null);
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.BrowserBack) btnUpOneLevel_Click(sender, null);
        }

        private void mnuLanguageTurkish_Click(object sender, EventArgs e) => changeLanguage(Strings.turkish);

        private void mnuLanguageEnglish_Click(object sender, EventArgs e) => changeLanguage(Strings.english);

        private void lstFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) => updateTexts();
        #endregion UIRelated

        #region BackgroundWorkers
        private void wrkExtract_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null) return;
            List<object> arguments = (List<object>)e.Argument;
            List<DirEntry> entries = (List<DirEntry>)arguments[0];
            string pathFilter = (string)arguments[1];
            string path = fldBrowse.SelectedPath;
            if (datFile == null || sender is not BackgroundWorker worker) return;
            DatReader.extractAll(datFile, path, entries, worker, pathFilter);
        }

        private void wrkExtract_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prbProgress.Value = e.ProgressPercentage;
        }

        private void wrkExtract_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Enabled = true;
            prbProgress.Visible = false;
        }

        private void wrkNew_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                if (datFile == null) return;
                DatWriter.createDatHeader(datFile, new DirectoryInfo(fldBrowse.SelectedPath));
                e.Result = true;
            }
            catch (Exception)
            {
                e.Result = false;
            }
        }

        private void wrkNew_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null) return;
            if ((bool)e.Result) updateUIStatus(true, false);
            else
            {
                MessageBox.Show(this, str.fileNewErrorMessage, str.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                mnuFileClose_Click(sender, null);
            }
            Enabled = true;
        }

        private void wrkCompress_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            prbProgress.Value = e.ProgressPercentage;
        }

        private void wrkCompress_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            openFile();
            prbProgress.Visible = false;
            Enabled = true;
        }

        private void wrkCompress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (datFile == null || sender is not BackgroundWorker worker) return;
            DatWriter.createDatFile(datFile, dlgSave.FileName, worker);
        }
        #endregion BackgroundWorkers
        #endregion FormEvents

        #region HelperMethods
        #region FormHelpers
        private void loadLanguageStrings(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren) loadLanguageStrings(control.Controls);
                if (control.Tag != null) control.Text = str[control.Name];
            }
        }

        private void loadToolBarToolTips()
        {
            foreach (ToolStripItem item in tlbTools.Items)
            {
                if (item.Tag != null) item.ToolTipText = str[item.Name ?? ""];
            }
        }

        private void loadMenuStrings(ToolStripItemCollection menuItems)
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (menuItems[i].GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)menuItems[i];
                    if (menuItem.HasDropDownItems) loadMenuStrings(menuItem.DropDownItems);
                    if (menuItem.Tag != null) menuItem.Text = str[menuItem.Name ?? ""];
                }
            }
        }

        private void clearLists()
        {
            lstFiles.Items.Clear();
            trvTree.Nodes.Clear();
        }

        private void updateTexts()
        {
            lblFileSize.Text = (datFile == null) ? "" : str.fileSize + ": " + StringHelper.formatSizeString(datFile.fileSize);
            lblRealSize.Text = (datFile == null) ? "" : str.realSize + ": " + StringHelper.formatSizeString(datFile.realSize);
            lblCount.Text = (datFile == null) ? "" : $"{str.total} {datFile.filesTotal:#,##0} {(str.file ?? "").ToLower() + ((LCID == Strings.english && datFile.filesTotal > 1) ? "s" : "")}";
            lblItems.Text = (datFile == null) ? "" : $"{lstFiles.Items.Count:#,##0} {str.item + ((LCID == Strings.english && lstFiles.Items.Count > 1) ? "s" : "")} {str.shown}";
            lblSelected.Text = (datFile == null) ? "" : $"{lstFiles.SelectedItems.Count:#,##0} {str.item + ((LCID == Strings.english && lstFiles.SelectedItems.Count > 1) ? "s" : "")} {str.selected}";
            string formText = (datFile == null) ? "" : datFile.fileName.Contains($"({newFileText})") ? $"({newFileText})" : datFile.fileName;
            Text = "FO2Dat" + ((formText == "") ? "" : " - ") + formText;
        }

        private void compressButton(bool state)
        {
            mnuFileCompress.Enabled = state;
            btnCompress.Enabled = state;
        }

        private void extractButton(bool state)
        {
            mnuFileExtractAll.Enabled = state;
            mnuFileExtractSelection.Enabled = state;
            btnExtractAll.Enabled = state;
            btnExtractSelection.Enabled = state;
        }

        private void lstFilesViewUpdate(View view)
        {
            lstFiles.View = view;
            mnuViewLargeIcon.Checked = view == View.LargeIcon;
            btnViewLargeIcons.Checked = view == View.LargeIcon;
            mnuViewDetails.Checked = view == View.Details;
            btnViewDetails.Checked = view == View.Details;
            mnuViewList.Checked = view == View.List;
            btnViewList.Checked = view == View.List;
            mnuViewSmallIcon.Checked = view == View.SmallIcon;
            btnViewSmallIcons.Checked = view == View.SmallIcon;
            mnuViewTile.Checked = view == View.Tile;
            btnViewTile.Checked = view == View.Tile;
        }

        private void lstFilesGroupsUpdate(bool show)
        {
            mnuViewShowGroups.Checked = show;
            btnViewGroups.Checked = mnuViewShowGroups.Checked;
            lstFiles.ShowGroups = mnuViewShowGroups.Checked;
        }

        private void mnuLanguageCheck()
        {
            mnuLanguageTurkish.Checked = LCID == Strings.turkish;
            mnuLanguageEnglish.Checked = LCID == Strings.english;
        }

        private void updateUIStatus(bool compressButtons, bool extractButtons)
        {
            compressButton(compressButtons);
            extractButton(extractButtons);
            buildTree();
            updateTexts();
        }

        private void loadSettings()
        {
            Size = Settings.Default.FormSize;
            Location = Settings.Default.FormLocation;
            WindowState = Settings.Default.FormState;

            if (Settings.Default.languageLCID == 0) Settings.Default.languageLCID = CultureInfo.InstalledUICulture.LCID;
            LCID = Settings.Default.languageLCID;
            str = new Strings();
            mnuLanguageCheck();

            lstFiles.Columns.Add("hdrName", str.name, Settings.Default.hdrNameWidth);
            lstFiles.Columns.Add("hdrIsCompressed", str.type, Settings.Default.hdrIsCompressedWidth);
            lstFiles.Columns.Add("hdrSize", str.realSize, Settings.Default.hdrSizeWidth)
                .TextAlign = HorizontalAlignment.Right;
            lstFiles.Columns.Add("hdrPackedSize", str.packedSize, Settings.Default.hdrPackedSizeWidth)
                .TextAlign = HorizontalAlignment.Right;
            lstFiles.Columns.Add("hdrOffset", str.offset, Settings.Default.hdrOffsetWidth);

            splContainer.SplitterDistance = Settings.Default.splContainerSplit;

            lstFilesViewUpdate(Settings.Default.lstFilesView);

            lstFilesGroupsUpdate(Settings.Default.lstFilesShowGroups);
        }

        private void changeLanguage(int language, bool askRestart = true)
        {
            if (LCID == language) return;
            Settings.Default.languageLCID = language;
            //LCID = language;
            //str.switchTo(LCID);
            mnuLanguageCheck();
            if (askRestart)
                if (MessageBox.Show(this, str.changeLanguageRestartPrompt, str.warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    Application.Restart();
        }
        #endregion FormHelpers

        private void openFile(string file = "")
        {
            if (file != "") datFile = DatReader.load(file);
            if (datFile == null)
            {
                MessageBox.Show(this, str.fileOpenErrorMessage, str.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            updateUIStatus(compressButtons: false, extractButtons: true);
        }

        private void buildTree()
        {
            clearLists();
            if (datFile == null) return;
            TreeNode root = new(datFile.fileTitle);
            trvTree.Nodes.Add(root);
            foreach (DirEntry dirEntry in datFile.dirTree)
            {
                string[] path = StringHelper.splitPath(dirEntry.fileName);
                TreeNode parentNode = root;
                for (int i = 0; i < path.Length - 1; i++)
                    parentNode = parentNode.Nodes.ContainsKey(path[i]) ? parentNode.Nodes.Find(path[i], false)[0] : parentNode.Nodes.Add(path[i], path[i]);
            }
        }
        #endregion HelperMethods
    }
}
