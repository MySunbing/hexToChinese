using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hexToChinese
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

        }

        /// <summary>
        /// 16进制转gb2312
        /// </summary>
        /// <param name="hexcode"></param>
        /// <returns></returns>
        public static string hexTogb2312(string hexcode)
        {
            hexcode = hexcode.Replace("%", "");
            byte[] array = new byte[hexcode.Length / 2];
            for (int i = 0; i < hexcode.Length; i++)
            {
                try
                {
                    array[i] = byte.Parse(hexcode.Substring(i * 2, 2), NumberStyles.HexNumber);
                }
                catch
                {
                }
            }
            return Encoding.GetEncoding("gb2312").GetString(array);
        }
        /// <summary>
        /// 16进制转utf-8
        /// </summary>
        /// <param name="hexcode"></param>
        /// <returns></returns>
        public static string hexToutf_8(string hexcode)
        {
            hexcode = hexcode.Replace("%", "");
            byte[] array = new byte[hexcode.Length / 2];
            for (int i = 0; i < hexcode.Length; i++)
            {
                try
                {
                    array[i] = byte.Parse(hexcode.Substring(i * 2, 2), NumberStyles.HexNumber);
                }
                catch
                {
                }
            }
            return Encoding.GetEncoding("utf-8").GetString(array);
        }

        /// <summary>
        /// gb2312转16进制
        /// </summary>
        /// <param name="chinese"></param>
        /// <param name="select">是否增加%号</param>
        /// <returns></returns>
        public static string gb2312ToHex(string chinese,bool select = false)
        {
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(chinese);
            string text = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                if (select)
                {
                    text = text + "%" + string.Format("{0:X}", bytes[i]);
                }
                else
                {
                    text = text + string.Format("{0:X}", bytes[i]);
                }
                
            }
            return text;
        }
        /// <summary>
        /// utf-8转16进制
        /// </summary>
        /// <param name="chinese"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public static string utf_8ToHex(string chinese, bool select = false)
        {
            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(chinese);
            string text = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                if (select)
                {
                    text = text + "%" + string.Format("{0:X}", bytes[i]);
                }
                else
                {
                    text = text + string.Format("{0:X}", bytes[i]);
                }

            }
            return text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox2.Text = hexTogb2312(textBox1.Text);
            }
            else
            {
                textBox2.Text = hexToutf_8(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (checkBox1.Checked)
                {
                    textBox1.Text = gb2312ToHex(textBox2.Text, true);
                }
                else
                {
                    textBox1.Text = gb2312ToHex(textBox2.Text);
                }
            }
            else
            {
                if (checkBox1.Checked)
                {
                    textBox1.Text = utf_8ToHex(textBox2.Text, true);
                }
                else
                {
                    textBox1.Text = utf_8ToHex(textBox2.Text);
                }
            }
            
            
        }
    }
}
