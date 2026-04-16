# (C# 코딩) 
## 개요
- C# 프로그래밍 학습
- 1줄 소개: 
- 사용한 플랫폼:
- C#, .NET Windows Forms, Visual Studio, GitHub
- 사용한 컨트롤:
- Label, TextBox, ListBox, Button
- 사용한 기술과 구현한 기능:




## 실행 화면 (과제1)
- 코드의 실행 스크린샷과 구현 내용 설명
![실행화면](img/screenshot-1.png)
- 구현한 내용 (위 그림 참조)
- 필요한 컨트롤들을 적절하게 배치하여 기본적인 UI를 구성하였다.
- Anchor 속성을 활용하여 폼의 크기가 변경되어도 컨트롤들이 적절하게 위치하도록 설정하였다.
- 오른쪽, 왼쪽에 폴더 선택 버튼을 만들어서 버튼을 누르면 폴더 선택 기능이 실행되도록 구현하였다.
- 폴더를 선택하면 텍스트 박스에 선택한 폴더의 경로가 표시되도록 구현하였다.
- 코드는 다음과 같다.
-  private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를 선택하세요.";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
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
                }
                    



## 실행 화면 (과제2)
- 코드의 실행 스크린샷과 구현 내용 설명
![실행화면](img/screenshot-2.png)
- 구현한 내용 (위 그림 참조)



## 실행 화면 (과제3)
- 코드의 실행 스크린샷과 구현 내용 설명
![실행화면](img/screenshot-3.png)
- 구현한 내용 (위 그림 참조)
- 




## 실행 화면 (과제4)
- 코드의 실행 스크린샷과 구현 내용 설명
![실행화면](img/screenshot-4.png)
- 구현한 내용 (위 그림 참조)

