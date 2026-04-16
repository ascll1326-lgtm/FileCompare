using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace FileCompare
{
    public partial class fmApp : Form
    {
        public fmApp()
        {
            InitializeComponent();
        }

 
        private void PopulateListView(ListView lv, string folderPath, string otherFolderPath)
        {
            lv.BeginUpdate();
            lv.Items.Clear();
            try
            {
                // 폴더(디렉터리) 먼저 추가
                var dirs = Directory.EnumerateDirectories(folderPath)
                    .Select(p => new DirectoryInfo(p))
                    .OrderBy(d => d.Name);

                foreach (var d in dirs)
                {
                    var item = new ListViewItem(d.Name);
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(d.LastWriteTime.ToString("g"));
                    lv.Items.Add(item);
                }
                // 파일 추가
                var files = Directory.EnumerateFiles(folderPath)
                    .Select(p => new FileInfo(p))
                    .OrderBy(f => f.Name);
                foreach (var f in files)
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.Length.ToString("N0") + " 바이트");
                    item.SubItems.Add(f.LastWriteTime.ToString("g"));

                    // 다른 폴더가 비어있지 않은 경우에만 참조 파일 검사
                    FileInfo rf = null;
                    if (!string.IsNullOrEmpty(otherFolderPath))
                    {
                        string refPath = Path.Combine(otherFolderPath, f.Name);
                        rf = File.Exists(refPath) ? new FileInfo(refPath) : null;
                    }

                    // 상태 판별
                    if (rf == null)
                    {
                        // 단독 파일
                        item.ForeColor = Color.Purple;
                    }
                    else
                    {
                        int result = DateTime.Compare(f.LastWriteTime, rf.LastWriteTime);

                        if (result == 0)
                        {
                            // 동일
                            item.ForeColor = Color.Black;
                        }
                        else if (result > 0)
                        {
                            // 내가 더 최신 → New
                            item.ForeColor = Color.Red;
                        }
                        else
                        {
                            // 내가 더 오래됨 → Old
                            item.ForeColor = Color.Gray;
                        }
                    }
                    lv.Items.Add(item);
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show(this, "폴더를 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "입출력 오류: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lv.EndUpdate();
            }
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {

        }

        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를 선택하세요.";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    // 항상 선택한 쪽은 ListView를 채운다. 반대쪽 폴더가 설정되어 있으면 그 쪽도 갱신한다.
                    PopulateListView(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
                    if (!string.IsNullOrEmpty(txtRightDir.Text))
                    {
                        PopulateListView(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
                    }


                }
            }
        }

        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를 선택하세요.";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    // 항상 선택한 쪽은 ListView를 채운다. 반대쪽 폴더가 설정되어 있으면 그 쪽도 갱신한다.
                    PopulateListView(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
                    if (!string.IsNullOrEmpty(txtLeftDir.Text))
                    {
                        PopulateListView(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
                    }

                }
            }
        }
    }
}
