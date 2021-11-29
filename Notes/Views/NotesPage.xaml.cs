using System;
using System.IO;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class NotesPage : ContentPage
    {
        // Path.Combine(string[]) 將一個字串陣列合併為單一路徑
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public NotesPage()
        {
            // 初始化
            InitializeComponent();

            // 檢查檔案是否存在
            if (File.Exists(_fileName))
            {
                // 若存在，則將檔案內容呈現在文字框
                editor.Text = File.ReadAllText(_fileName);
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // 寫入檔案並儲存，然後關閉檔案
            File.WriteAllText(_fileName, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            // 檢查檔案是否存在
            if (File.Exists(_fileName))
            {
                // 若存在則刪除
                File.Delete(_fileName);
            }
            // 刪除後文字輸入框設定為空
            editor.Text = string.Empty;
        }
    }
}
