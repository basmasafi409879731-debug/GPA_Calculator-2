using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPA_Calculator_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            System.Windows.Forms.TextBox[] gradeBoxes = { textBox1, textBox3, textBox5, textBox7, textBox9 };
            System.Windows.Forms.TextBox[] hourBoxes = { textBox2, textBox4, textBox6, textBox8, textBox10 };

            double totalPoints = 0; // مجموع (الدرجة * الساعات)
            int totalHours = 0;     // مجموع الساعات الكلي

            for (int i = 0; i < 5; i++)
            {
                double grade;
                int hours;

                // التحقق من صحة إدخال الدرجة (بين 0 و 100)
                if (!double.TryParse(gradeBoxes[i].Text, out grade) || grade < 0 || grade > 100)
                {
                    MessageBox.Show($"عذراً، يرجى إدخال درجة صحيحة (بين 0 و 100) للمساق رقم {i + 1}.",
                                    "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gradeBoxes[i].Focus();
                    return;
                }

                // التحقق من صحة إدخال عدد الساعات (أكبر من 0)
                if (!int.TryParse(hourBoxes[i].Text, out hours) || hours <= 0)
                {
                    MessageBox.Show($"عذراً، يرجى إدخال عدد ساعات صحيح (أكبر من 0) للمساق رقم {i + 1}.",
                                    "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hourBoxes[i].Focus();
                    return;
                }

                totalPoints += (grade * hours);
                totalHours += hours;
            }

            // حساب المعدل الفصلي النهائي
            double gpa = totalPoints / totalHours;

            // عرض النتيجة مقربة لمنزلتين عشريتين
            lblResult.Text = $"المعدل الفصلي: {gpa:F2}%";
        }
    }
}
