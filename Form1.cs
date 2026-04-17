using System;
using System.IO;
using System.Linq;
using System.Drawing;
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

        // 디렉터리와 그 하위 항목들에서 가장 최근 수정시간을 구한다.
        private DateTime GetDirectoryLastWriteTime(string dirPath)
        {
            try
            {
                DateTime last = Directory.GetLastWriteTime(dirPath);

                foreach (var f in Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories))
                {
                    DateTime ft = File.GetLastWriteTime(f);
                    if (ft > last) last = ft;
                }

                foreach (var d in Directory.GetDirectories(dirPath, "*", SearchOption.AllDirectories))
                {
                    DateTime dt = Directory.GetLastWriteTime(d);
                    if (dt > last) last = dt;
                }

                return last;
            }
            catch
            {
                return Directory.GetLastWriteTime(dirPath);
            }
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

                    // 디렉터리를 하나의 항목처럼 다루기 위해 하위 항목을 포함한 최근 수정일을 계산
                    DateTime dirLast = GetDirectoryLastWriteTime(d.FullName);
                    item.SubItems.Add(dirLast.ToString("g"));

                    // 다른 폴더가 설정되어 있으면 참조 디렉터리의 최근 수정일을 얻어서 상태 판별
                    if (!string.IsNullOrEmpty(otherFolderPath))
                    {
                        string refDir = Path.Combine(otherFolderPath, d.Name);
                        if (Directory.Exists(refDir))
                        {
                            DateTime refDirLast = GetDirectoryLastWriteTime(refDir);
                            int cmp = DateTime.Compare(dirLast, refDirLast);
                            if (cmp == 0)
                                item.ForeColor = Color.Black;
                            else if (cmp > 0)
                                item.ForeColor = Color.Red; // 내가 더 최신
                            else
                                item.ForeColor = Color.Gray; // 내가 더 오래됨
                        }
                        else
                        {
                            // 상대에 동일한 폴더가 없음
                            item.ForeColor = Color.Purple;
                        }
                    }
                    else
                    {
                        // 비교 대상이 없으면 단독 폴더
                        item.ForeColor = Color.Purple;
                    }

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
            CopySelectedFiles(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            CopySelectedFiles(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
        }

        private void CopySelectedFiles(ListView sourceLv, string sourceDir, string destDir)
        {
            if (string.IsNullOrEmpty(sourceDir))
            {
                MessageBox.Show(this, "복사할 폴더가 선택되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(destDir))
            {
                MessageBox.Show(this, "대상 폴더가 선택되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sourceLv.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "복사할 파일을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (ListViewItem item in sourceLv.SelectedItems)
            {
                string name = item.Text;
                string srcPath = Path.Combine(sourceDir, name);
                string dstPath = Path.Combine(destDir, name);

                // 디렉터리이면 재귀적으로 복사 (파일 복사와 동일한 덮어쓰기 정책 적용)
                if (item.SubItems.Count > 1 && item.SubItems[1].Text == "<DIR>")
                {
                    if (!Directory.Exists(srcPath))
                        continue;

                    // 대상 디렉터리의 최근 수정시간과 비교하여 덮어쓰기 여부 결정
                    if (Directory.Exists(dstPath))
                    {
                        DateTime srcDirLast = GetDirectoryLastWriteTime(srcPath);
                        DateTime dstDirLast = GetDirectoryLastWriteTime(dstPath);

                        if (dstDirLast > srcDirLast)
                        {
                            string srcName = Path.GetFileName(srcPath);
                            string dstName = Path.GetFileName(dstPath);
                            var dr = MessageBox.Show(this,
                                $"원본 폴더: {srcName}\n대상 폴더: {dstName}\n\n대상 폴더가 더 오래되었습니다. 덮어쓰시겠습니까?",
                                "덮어쓰기 확인",
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);

                            if (dr == DialogResult.Cancel)
                                break; // 전체 작업 취소
                            if (dr == DialogResult.No)
                                continue; // 이 항목 건너뜀
                            // Yes -> 진행
                        }
                    }

                    // 복사: 내부에서 추가 확인창을 띄우지 않음(파일 복사 정책과 동일하게 동작)
                    bool cont = CopyDirectoryRecursive(srcPath, dstPath, promptPerFile: false);
                    if (!cont)
                        break; // 사용자가 취소하면 전체 작업 중단

                    continue;
                }

                // 파일 처리
                if (!File.Exists(srcPath))
                    continue;

                bool doCopy = true;
                if (File.Exists(dstPath))
                {
                    var srcInfo = new FileInfo(srcPath);
                    var dstInfo = new FileInfo(dstPath);

                    // 대상 파일이 더 오래되어 소스로 덮어쓰는 경우 확인
                    if (dstInfo.LastWriteTime > srcInfo.LastWriteTime)
                    {
                        string srcName = Path.GetFileName(srcPath);
                        string dstName = Path.GetFileName(dstPath);
                        var dr = MessageBox.Show(this,
                            $"원본 파일: {srcName}\n대상 파일: {dstName}\n\n대상 파일이 더 오래되었습니다. 덮어쓰시겠습니까?",
                            "덮어쓰기 확인",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question);

                        if (dr == DialogResult.Cancel)
                        {
                            // 전체 작업 취소
                            break;
                        }

                        if (dr == DialogResult.No)
                        {
                            doCopy = false;
                        }
                    }
                }

                if (!doCopy)
                    continue;

                try
                {
                    // ensure destination folder exists
                    var parent = Path.GetDirectoryName(dstPath);
                    if (!string.IsNullOrEmpty(parent) && !Directory.Exists(parent))
                        Directory.CreateDirectory(parent);

                    File.Copy(srcPath, dstPath, true);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, "파일 복사 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 복사 후 목록 갱신
            if (!string.IsNullOrEmpty(txtLeftDir.Text))
                PopulateListView(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
            if (!string.IsNullOrEmpty(txtRightDir.Text))
                PopulateListView(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
        }

        // 디렉터리 재귀 복사. 취소 시 false 반환
        // promptPerFile: true이면 각 파일별로 덮어쓰기 확인을 수행한다.
        private bool CopyDirectoryRecursive(string srcDir, string dstDir, bool promptPerFile = true)
        {
            try
            {
                // 만들기 전에 대상 경로가 파일인지 확인
                if (File.Exists(dstDir))
                {
                    MessageBox.Show(this, $"대상 경로에 동일한 이름의 파일이 있어 폴더를 생성할 수 없습니다: {dstDir}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!Directory.Exists(dstDir))
                    Directory.CreateDirectory(dstDir);

                // 파일 복사 (현재 디렉터리의 파일들)
                foreach (var file in Directory.GetFiles(srcDir))
                {
                    try
                    {
                        string fileName = Path.GetFileName(file);
                        string dstPath = Path.Combine(dstDir, fileName);

                        // ensure parent exists (dstDir already exists)
                        if (!Directory.Exists(dstDir))
                            Directory.CreateDirectory(dstDir);

                        bool doCopy = true;
                        if (File.Exists(dstPath))
                        {
                            var srcInfo = new FileInfo(file);
                            var dstInfo = new FileInfo(dstPath);
                            // 덮어쓰기 기준: 대상이 더 오래된 경우 (dst < src)
                            if (dstInfo.LastWriteTime < srcInfo.LastWriteTime)
                            {
                                if (promptPerFile)
                                {
                                    var dr = MessageBox.Show(this,
                                        $"원본 파일: {fileName}\n대상 파일: {fileName}\n\n대상 파일이 더 오래되었습니다. 덮어쓰시겠습니까?",
                                        "덮어쓰기 확인",
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question);

                                    if (dr == DialogResult.Cancel)
                                        return false; // 전체 작업 취소
                                    if (dr == DialogResult.No)
                                        doCopy = false;
                                }
                                else
                                {
                                    // promptPerFile == false: 자동으로 덮어쓰기 진행
                                    doCopy = true;
                                }
                            }
                        }

                        if (doCopy)
                        {
                            // ensure parent directory exists
                            var p = Path.GetDirectoryName(dstPath);
                            if (!string.IsNullOrEmpty(p) && !Directory.Exists(p))
                                Directory.CreateDirectory(p);

                            File.Copy(file, dstPath, true);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(this, "파일 복사 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // 하위 디렉터리 재귀
                foreach (var dir in Directory.GetDirectories(srcDir))
                {
                    string dirName = Path.GetFileName(dir);
                    string targetSubDir = Path.Combine(dstDir, dirName);
                    bool cont = CopyDirectoryRecursive(dir, targetSubDir);
                    if (!cont)
                        return false;
                }
                Directory.SetLastWriteTime(dstDir, Directory.GetLastWriteTime(srcDir));
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(this, "권한 오류: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "디렉터리 복사 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
