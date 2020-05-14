namespace ISFileAndContent
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_openkey = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_contentkey = new System.Windows.Forms.TextBox();
            this.dt_end = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_start = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_fileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_openFolder = new System.Windows.Forms.Button();
            this.tb_folderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dg_pageData = new System.Windows.Forms.DataGridView();
            this.cb_fileOn = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_home = new System.Windows.Forms.Button();
            this.btn_prePage = new System.Windows.Forms.Button();
            this.btn_nextPage = new System.Windows.Forms.Button();
            this.btn_lastPage = new System.Windows.Forms.Button();
            this.lb_page = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bizNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileOnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileModelDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_pageData)).BeginInit();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileModelDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(563, 132);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb_fileOn);
            this.panel1.Controls.Add(this.cb_openkey);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tb_contentkey);
            this.panel1.Controls.Add(this.dt_end);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dt_start);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tb_fileName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_openFolder);
            this.panel1.Controls.Add(this.tb_folderPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_clear);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 162);
            this.panel1.TabIndex = 1;
            // 
            // cb_openkey
            // 
            this.cb_openkey.AutoSize = true;
            this.cb_openkey.Location = new System.Drawing.Point(247, 95);
            this.cb_openkey.Name = "cb_openkey";
            this.cb_openkey.Size = new System.Drawing.Size(120, 16);
            this.cb_openkey.TabIndex = 15;
            this.cb_openkey.Text = "是否开启内容搜索";
            this.cb_openkey.UseVisualStyleBackColor = true;
            this.cb_openkey.CheckedChanged += new System.EventHandler(this.cb_openkey_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "搜索内容：";
            // 
            // tb_contentkey
            // 
            this.tb_contentkey.Enabled = false;
            this.tb_contentkey.Location = new System.Drawing.Point(470, 90);
            this.tb_contentkey.Name = "tb_contentkey";
            this.tb_contentkey.Size = new System.Drawing.Size(168, 21);
            this.tb_contentkey.TabIndex = 13;
            // 
            // dt_end
            // 
            this.dt_end.Enabled = false;
            this.dt_end.Location = new System.Drawing.Point(637, 51);
            this.dt_end.Name = "dt_end";
            this.dt_end.Size = new System.Drawing.Size(135, 21);
            this.dt_end.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "文件结束创建时间：";
            // 
            // dt_start
            // 
            this.dt_start.Enabled = false;
            this.dt_start.Location = new System.Drawing.Point(364, 50);
            this.dt_start.Name = "dt_start";
            this.dt_start.Size = new System.Drawing.Size(133, 21);
            this.dt_start.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "文件开始创建时间：";
            // 
            // tb_fileName
            // 
            this.tb_fileName.Location = new System.Drawing.Point(94, 50);
            this.tb_fileName.Name = "tb_fileName";
            this.tb_fileName.Size = new System.Drawing.Size(133, 21);
            this.tb_fileName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "文件名：";
            // 
            // btn_openFolder
            // 
            this.btn_openFolder.Location = new System.Drawing.Point(469, 12);
            this.btn_openFolder.Name = "btn_openFolder";
            this.btn_openFolder.Size = new System.Drawing.Size(46, 23);
            this.btn_openFolder.TabIndex = 4;
            this.btn_openFolder.Text = "...";
            this.btn_openFolder.UseVisualStyleBackColor = true;
            this.btn_openFolder.Click += new System.EventHandler(this.btn_openFolder_Click);
            // 
            // tb_folderPath
            // 
            this.tb_folderPath.Location = new System.Drawing.Point(94, 14);
            this.tb_folderPath.Name = "tb_folderPath";
            this.tb_folderPath.Size = new System.Drawing.Size(357, 21);
            this.tb_folderPath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "搜索路径：";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(671, 131);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dg_pageData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 396);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 162);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(810, 34);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "查询结果如下";
            // 
            // dg_pageData
            // 
            this.dg_pageData.AutoGenerateColumns = false;
            this.dg_pageData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_pageData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bizNameDataGridViewTextBoxColumn,
            this.Column1,
            this.fileNameDataGridViewTextBoxColumn,
            this.fileOnDataGridViewTextBoxColumn,
            this.filePathDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.fileSizeDataGridViewTextBoxColumn,
            this.msgDataGridViewTextBoxColumn});
            this.dg_pageData.DataSource = this.fileModelDtoBindingSource;
            this.dg_pageData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dg_pageData.Location = new System.Drawing.Point(0, 40);
            this.dg_pageData.Name = "dg_pageData";
            this.dg_pageData.RowTemplate.Height = 23;
            this.dg_pageData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_pageData.Size = new System.Drawing.Size(810, 356);
            this.dg_pageData.TabIndex = 0;
            this.dg_pageData.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_pageData_CellMouseDown);
            // 
            // cb_fileOn
            // 
            this.cb_fileOn.AutoSize = true;
            this.cb_fileOn.Location = new System.Drawing.Point(107, 95);
            this.cb_fileOn.Name = "cb_fileOn";
            this.cb_fileOn.Size = new System.Drawing.Size(120, 16);
            this.cb_fileOn.TabIndex = 16;
            this.cb_fileOn.Text = "是否开启日期搜索";
            this.cb_fileOn.UseVisualStyleBackColor = true;
            this.cb_fileOn.CheckedChanged += new System.EventHandler(this.cb_fileOn_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lb_page);
            this.panel4.Controls.Add(this.btn_lastPage);
            this.panel4.Controls.Add(this.btn_nextPage);
            this.panel4.Controls.Add(this.btn_prePage);
            this.panel4.Controls.Add(this.btn_home);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 514);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(810, 44);
            this.panel4.TabIndex = 1;
            // 
            // btn_home
            // 
            this.btn_home.Location = new System.Drawing.Point(281, 13);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(75, 23);
            this.btn_home.TabIndex = 0;
            this.btn_home.Text = "首页";
            this.btn_home.UseVisualStyleBackColor = true;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // btn_prePage
            // 
            this.btn_prePage.Location = new System.Drawing.Point(374, 13);
            this.btn_prePage.Name = "btn_prePage";
            this.btn_prePage.Size = new System.Drawing.Size(75, 23);
            this.btn_prePage.TabIndex = 1;
            this.btn_prePage.Text = "上一页";
            this.btn_prePage.UseVisualStyleBackColor = true;
            this.btn_prePage.Click += new System.EventHandler(this.btn_prePage_Click);
            // 
            // btn_nextPage
            // 
            this.btn_nextPage.Location = new System.Drawing.Point(467, 13);
            this.btn_nextPage.Name = "btn_nextPage";
            this.btn_nextPage.Size = new System.Drawing.Size(75, 23);
            this.btn_nextPage.TabIndex = 2;
            this.btn_nextPage.Text = "下一页";
            this.btn_nextPage.UseVisualStyleBackColor = true;
            this.btn_nextPage.Click += new System.EventHandler(this.btn_nextPage_Click);
            // 
            // btn_lastPage
            // 
            this.btn_lastPage.Location = new System.Drawing.Point(561, 13);
            this.btn_lastPage.Name = "btn_lastPage";
            this.btn_lastPage.Size = new System.Drawing.Size(75, 23);
            this.btn_lastPage.TabIndex = 3;
            this.btn_lastPage.Text = "末页";
            this.btn_lastPage.UseVisualStyleBackColor = true;
            this.btn_lastPage.Click += new System.EventHandler(this.btn_lastPage_Click);
            // 
            // lb_page
            // 
            this.lb_page.AutoSize = true;
            this.lb_page.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_page.Location = new System.Drawing.Point(26, 18);
            this.lb_page.Name = "lb_page";
            this.lb_page.Size = new System.Drawing.Size(0, 14);
            this.lb_page.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DirectoryName";
            this.Column1.HeaderText = "目录";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem1.Text = "打开所在的文件夹";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem2.Text = "打开文件";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // bizNameDataGridViewTextBoxColumn
            // 
            this.bizNameDataGridViewTextBoxColumn.DataPropertyName = "BizName";
            this.bizNameDataGridViewTextBoxColumn.HeaderText = "BizName";
            this.bizNameDataGridViewTextBoxColumn.Name = "bizNameDataGridViewTextBoxColumn";
            this.bizNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "ShowName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "文件名";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            // 
            // fileOnDataGridViewTextBoxColumn
            // 
            this.fileOnDataGridViewTextBoxColumn.DataPropertyName = "FileOn";
            this.fileOnDataGridViewTextBoxColumn.HeaderText = "创建日期";
            this.fileOnDataGridViewTextBoxColumn.Name = "fileOnDataGridViewTextBoxColumn";
            // 
            // filePathDataGridViewTextBoxColumn
            // 
            this.filePathDataGridViewTextBoxColumn.DataPropertyName = "FilePath";
            this.filePathDataGridViewTextBoxColumn.HeaderText = "文件路径";
            this.filePathDataGridViewTextBoxColumn.Name = "filePathDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "状态";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // fileSizeDataGridViewTextBoxColumn
            // 
            this.fileSizeDataGridViewTextBoxColumn.DataPropertyName = "FileSize";
            this.fileSizeDataGridViewTextBoxColumn.HeaderText = "文件大小";
            this.fileSizeDataGridViewTextBoxColumn.Name = "fileSizeDataGridViewTextBoxColumn";
            // 
            // msgDataGridViewTextBoxColumn
            // 
            this.msgDataGridViewTextBoxColumn.DataPropertyName = "Msg";
            this.msgDataGridViewTextBoxColumn.HeaderText = "Msg";
            this.msgDataGridViewTextBoxColumn.Name = "msgDataGridViewTextBoxColumn";
            // 
            // fileModelDtoBindingSource
            // 
            this.fileModelDtoBindingSource.DataSource = typeof(ISFileAndContent.Model.FileModelDto);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 558);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "智能文档搜索";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_pageData)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileModelDtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_openFolder;
        private System.Windows.Forms.TextBox tb_folderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_fileName;
        private System.Windows.Forms.DateTimePicker dt_end;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dt_start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_contentkey;
        private System.Windows.Forms.CheckBox cb_openkey;
        private System.Windows.Forms.DataGridView dg_pageData;
        private System.Windows.Forms.BindingSource fileModelDtoBindingSource;
        private System.Windows.Forms.CheckBox cb_fileOn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lb_page;
        private System.Windows.Forms.Button btn_lastPage;
        private System.Windows.Forms.Button btn_nextPage;
        private System.Windows.Forms.Button btn_prePage;
        private System.Windows.Forms.Button btn_home;
        private System.Windows.Forms.DataGridViewTextBoxColumn bizNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileOnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

