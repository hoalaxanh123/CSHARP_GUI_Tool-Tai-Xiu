using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XT_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.richTextBox_Input.Text = "X\nX\nT\nX\nX\nT\nT\nX\nX\nX\nT\nT";
            //MessageBox.Show(this.richTextBox_Input.Text.Replace("\n",string.Empty));

            //DemX_T();
        }
        void DemX_T()
        {
            int row_count = 0;
            try
            {
                //Đếm ký tự
                string input = this.richTextBox_Input.Text.Replace("\n", string.Empty);
                for (int i = 0; i < input.Length; i++)
                {
                    int count = 1;
                    this.richTextBox_Output1.Text += (input[i]);

                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[i].CompareTo(input[j]) == 0)
                        {
                            count++;
                            i++;
                        }
                        else
                            break;
                    }

                    if (count > 1)
                    {
                        this.richTextBox_Output1.Text += "(" + count + ")";
                    }
                    if (count > row_count)
                        row_count = count;
                }

                //Nạp kết quả vào mảng 2 chiều
                string[,] Array = new string[row_count, input.Length];
                int column_current = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    int count = 1;
                    Array[row_count - 1, column_current] = input[i].ToString();
                    if (i + 1 >= input.Length)
                        break;
                    for (int j = i + 1; j <= input.Length; j++)
                    {
                        if (i + 1 >= input.Length)
                            break;
                        if (input[i].CompareTo(input[j]) == 0)
                        {
                            int index = row_count - count - 1;
                            if (index < 0)
                                index = 0;
                            Array[index, column_current] = input[i].ToString();
                            count++;
                            i++;
                        }
                        else
                            break;
                    }
                    column_current++;
                }

                //In ra kết quả
                for (int i = 0; i < row_count; i++)
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (Array[i, j] != null)
                        {
                            this.richTextBox_OutPut2.Text += Array[i, j] + "\t";
                        }
                            
                        else
                        {
                            this.richTextBox_OutPut2.Text += "\t";
                        }

                    }
                    this.richTextBox_OutPut2.Text += "\n";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void richTextBox_Input_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox_Output1.Text = "";
            this.richTextBox_OutPut2.Text = "";
            this.richTextBox_Input.Text = this.richTextBox_Input.Text.ToUpper();
            DemX_T();
        }
    }
}
