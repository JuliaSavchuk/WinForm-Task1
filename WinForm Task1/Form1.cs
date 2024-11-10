using System.Text;

namespace WinForm_Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\p22\\Desktop\\Task1.txt";

            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    progressBar1.Maximum = (int)fs.Length;
                    progressBar1.Value = 0;

                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    StringBuilder fileContent = new StringBuilder();

                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileContent.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                        progressBar1.Value += bytesRead;

                        // Оновлення прогресу
                        Application.DoEvents();
                    }

                    label1.Text = $"Зміст файлу: {fileContent.ToString()}";
                }
            }
            else
            {
                MessageBox.Show("Файл не знайдено!");
            }
        }
    }
}
