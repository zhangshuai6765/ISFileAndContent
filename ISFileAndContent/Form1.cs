using ISFileAndContent.FolderUtil;
using ISFileAndContent.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISFileAndContent
{
    /// <summary>
    /// 1.支持文件与文件内容搜索
    /// 2.支持排序
    /// 3.支持分页
    /// 4.支持定位到当前文件夹或打开文件
    /// 5.通用泛型扩展
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PageDto pageDto = new PageDto();

        /// <summary>
        /// key：排序字段；value：false为正序，true为倒序
        /// </summary>
        Dictionary<string, bool> orderbyDic = new Dictionary<string, bool>();

        private void btn_search_Click(object sender, EventArgs e)
        {
            string folderPath = @"D:\timingtask\dksource\";
            //string folderPath = tb_folderPath.Text;
            QueryDto queryDto = GetSearchConditon(folderPath);
            if (queryDto != null)
                PageData(folderPath, queryDto);
        }

        private QueryDto GetSearchConditon(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("不是有效的目录", "提示");
                return null;
            }

            //查询条件
            QueryDto queryDto = new QueryDto();
            queryDto.FileName = this.tb_fileName.Text;
            if (cb_openkey.Checked)
            {
                queryDto.OpenKey = true;
                queryDto.ContentKey = tb_contentkey.Text;
            }
            else
            {
                queryDto.OpenKey = false;
                queryDto.ContentKey = "";
            }

            if (cb_fileOn.Checked)
            {
                queryDto.StartFileOn = dt_start.Value;
                queryDto.EndFileOn = dt_end.Value;
            }

            return queryDto;
        }

        /// <summary>
        /// 添加排序方式
        /// </summary>
        /// <returns></returns>
        private List<OrderByDto> AddOrderbyCondition()
        {
            List<OrderByDto> orderbyList = new List<OrderByDto>();
            OrderByDto dto = new OrderByDto();

            dto.SortName = "FileOn";
            dto.Desc = true;
            dto.t = typeof(DateTime);
            orderbyList.Add(dto);

            dto = new OrderByDto();
            dto.SortName = "Status";
            dto.Desc = false;
            dto.t = typeof(int);
            orderbyList.Add(dto);

            //dto = new OrderByDto();
            //dto.SortName = "FileName";
            //dto.Desc = false;
            //dto.t = typeof(string);
            //orderbyList.Add(dto);

            return orderbyList;
        }

        public void PageData(string folderPath, QueryDto queryCondition)
        {
            string[] supportSuffix = { ".txt", ".xml", ".cs" };
            List<FileModelDto> fmList = new List<FileModelDto>();
            List<FileInfo> fileList = FolderUtil.FileHelper.GetAllFiles(folderPath);

            foreach (var fi in fileList)
            {
                //如果开启了内容搜索，则需要筛选文件的后缀
                if (queryCondition.OpenKey && supportSuffix.Contains(fi.Extension.ToLower()))
                {
                    FileModelDto fm = new FileModelDto();
                    fm.FileName = fi.Name.ToLower();
                    fm.ShowName = fi.Name;
                    fm.BizName = fi.Directory.Name;
                    fm.DirectoryName = fi.DirectoryName;
                    fm.FilePath = fi.FullName;
                    fm.Status = (int)Model.TaskStatus.Watting;
                    fm.FileOn = fi.CreationTime;
                    fm.FileSize = System.Math.Ceiling(fi.Length / 1024.0) + " KB";
                    fm.Msg = "等待中…";

                    string content = FolderUtil.FileHelper.ReadTxtFile(fi.FullName);
                    if (content.Contains(queryCondition.ContentKey))
                        fmList.Add(fm);
                }
                else
                {
                    FileModelDto fm = new FileModelDto();
                    fm.FileName = fi.Name.ToLower();
                    fm.ShowName = fi.Name;
                    fm.BizName = fi.Directory.Name;
                    fm.DirectoryName = fi.DirectoryName;
                    fm.FilePath = fi.FullName;
                    fm.Status = (int)Model.TaskStatus.Watting;
                    fm.FileOn = fi.CreationTime;
                    fm.FileSize = System.Math.Ceiling(fi.Length / 1024.0) + " KB";
                    fm.Msg = "等待中…";

                    fmList.Add(fm);
                }
                
            }

            List<OrderByDto> orderbyItem = AddOrderbyCondition();
            //List<OrderByDto> orderbyItem = new List<OrderByDto>();
           DataCollection <FileModelDto> dc = FolderUtil.FileHelper.FileIntelligentSearch<FileModelDto, QueryDto>(fmList.AsQueryable<FileModelDto>(), queryCondition, orderbyItem.ToArray());
            this.dg_pageData.DataSource = dc.data as List<FileModelDto>;//pagelist
           
            pageDto.Page = dc.Page;
            pageDto.PageSize = dc.PageSize;
            pageDto.PageCount = dc.PageCount;
            pageDto.TotalCount = dc.TotalCount;

            if (dc.data.Count > 0)
                this.lb_page.Text = "第" + pageDto.Page + "页，共" + pageDto.PageCount + "页，记录总数为:" + pageDto.TotalCount;
            else
                this.lb_page.Text = "共有0条记录";

            //按钮可用逻辑
            if (pageDto.PageCount == 0)
            {
                this.btn_home.Enabled = false;
                this.btn_prePage.Enabled = false;
                this.btn_nextPage.Enabled = false;
                this.btn_lastPage.Enabled = false;
            }
            else
            {
                if (pageDto.PageCount == pageDto.Page)
                {
                    if(pageDto.Page == 1)
                    {
                        this.btn_home.Enabled = false;
                        this.btn_nextPage.Enabled = false;
                        this.btn_prePage.Enabled = false;
                        this.btn_lastPage.Enabled = false;
                    }
                    else
                    {
                        this.btn_home.Enabled = true;
                        this.btn_nextPage.Enabled = false;
                        this.btn_prePage.Enabled = true;
                        this.btn_lastPage.Enabled = false;
                    }
                    
                }
                else if (pageDto.PageCount > pageDto.Page)
                {
                    this.btn_nextPage.Enabled = true;
                    this.btn_lastPage.Enabled = true;
                    if (pageDto.Page == 1)
                    {
                        this.btn_prePage.Enabled = false;
                        this.btn_home.Enabled = false;
                    }
                    else
                    {
                        this.btn_prePage.Enabled = true;
                        this.btn_home.Enabled = true;
                    }

                }
                else
                {
                    this.btn_home.Enabled = false;
                    this.btn_nextPage.Enabled = false;
                    this.btn_prePage.Enabled = false;
                    this.btn_lastPage.Enabled = false;
                }
            }
        }

        private void btn_openFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.folderBrowserDialog1.SelectedPath.Trim() != "")
                    this.tb_folderPath.Text = this.folderBrowserDialog1.SelectedPath.Trim();
            }
        }

        private void cb_openkey_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox cb = sender as CheckBox;
            if (cb_openkey.Checked)
                tb_contentkey.Enabled = true;
            else
                tb_contentkey.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dt_start.Value = DateTime.Now.AddDays(-7);
        }

        private void cb_fileOn_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_fileOn.Checked)
            {
                dt_start.Enabled = true;
                dt_end.Enabled = true;
            }
            else
            {
                dt_start.Enabled = false;
                dt_end.Enabled = false;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.tb_folderPath.Text = "";
            this.tb_fileName.Text = "";
            this.cb_fileOn.Checked = false;
            this.cb_openkey.Checked = false;
            this.tb_contentkey.Text = "";
            
            if(dg_pageData.DataSource!=null)
            {
                List<FileModelDto> fileList = (List<FileModelDto>)dg_pageData.DataSource;
                fileList = new List<FileModelDto>();
                dg_pageData.DataSource = fileList;
            }
            else
            {
                dg_pageData.Rows.Clear();
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            string folderPath = tb_folderPath.Text;
            QueryDto queryDto = GetSearchConditon(folderPath);
            queryDto.Page = 1;
            queryDto.PageSize = 10;
            if (queryDto != null)
                PageData(folderPath, queryDto);
        }

        private void btn_prePage_Click(object sender, EventArgs e)
        {
            string folderPath = tb_folderPath.Text;
            QueryDto queryDto = GetSearchConditon(folderPath);
            queryDto.Page = pageDto.Page - 1;
            if (queryDto != null)
                PageData(folderPath, queryDto);
        }

        private void btn_nextPage_Click(object sender, EventArgs e)
        {
            string folderPath = tb_folderPath.Text;
            QueryDto queryDto = GetSearchConditon(folderPath);
            queryDto.Page = pageDto.Page + 1;
            if (queryDto != null)
                PageData(folderPath, queryDto);
        }

        private void btn_lastPage_Click(object sender, EventArgs e)
        {
            string folderPath = tb_folderPath.Text;
            QueryDto queryDto = GetSearchConditon(folderPath);
            queryDto.Page = pageDto.PageCount;
            if (queryDto != null)
                PageData(folderPath, queryDto);
        }

        private void dg_pageData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                if(e.RowIndex>=0)
                {
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        /// <summary>
        /// 打开文件所在的文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dg_pageData.SelectedRows[0] as DataGridViewRow;
            FileModelDto dto = row.DataBoundItem as FileModelDto;

            if (dto != null)
            {
                System.Diagnostics.Process.Start("explorer.exe", dto.DirectoryName);
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dg_pageData.SelectedRows[0] as DataGridViewRow;
            FileModelDto dto = row.DataBoundItem as FileModelDto;

            if (dto != null)
            {
                try
                {
                    System.Diagnostics.Process.Start(dto.FilePath);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("暂不支持此文件格式", "提示");
                }
               
            }
        }
    }
}
