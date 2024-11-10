using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Task1
{
    public partial class Form2 : Form
    {
        private List<User> users = new List<User>();


        public Form2()
        {
            InitializeComponent();
        }

        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName} - {Email} - {Phone}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                FirstName = textBox1.Text,
                LastName = textBox2.Text,
                Email = textBox3.Text,
                Phone = textBox4.Text
            };

            users.Add(user);
            UpdateUserList();
            ClearInputFields();
        }
        private void UpdateUserList()
        {
            listBox1.Items.Clear();
            foreach (var user in users)
            {
                listBox1.Items.Add(user);
            }
        }

        private void ClearInputFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is User selectedUser)
            {
                textBox1.Text = selectedUser.FirstName;
                textBox2.Text = selectedUser.LastName;
                textBox3.Text = selectedUser.Email;
                textBox4.Text = selectedUser.Phone;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var writer = new StreamWriter("users.txt"))
            {
                foreach (var user in users)
                {
                    writer.WriteLine($"{user.FirstName};{user.LastName};{user.Email};{user.Phone}");
                }
            }
            MessageBox.Show("Дані успішно збережено у файл!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("users.txt"))
            {
                users.Clear();
                using (var reader = new StreamReader("users.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(';');
                        if (data.Length == 4)
                        {
                            var user = new User
                            {
                                FirstName = data[0],
                                LastName = data[1],
                                Email = data[2],
                                Phone = data[3]
                            };
                            users.Add(user);
                        }
                    }
                }
                UpdateUserList();
                MessageBox.Show("Дані успішно завантажено з файлу!");
            }
            else
            {
                MessageBox.Show("Файл не знайдено.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is User selectedUser)
            {
                selectedUser.FirstName = textBox1.Text;
                selectedUser.LastName = textBox2.Text;
                selectedUser.Email = textBox3.Text;
                selectedUser.Phone = textBox4.Text;
                UpdateUserList();
                ClearInputFields();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

