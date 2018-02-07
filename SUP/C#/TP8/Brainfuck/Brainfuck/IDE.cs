using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brainfuck
{
    public partial class IDE : Form
    {
        private Dictionary<char, char> brainfuck = Program.classicBrainfuck();
        private JSONElement jsone = null;
        
        public IDE()
        {
            InitializeComponent();
        }

        private void interpret_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = Brainfuck.Interpret(textBox1.Text, brainfuck);
            }
            catch (Exception ex)
            {
                textBox2.Text = "Brainfuck failed: " + ex.Message;
            }
            
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, textBox1.Text);
            }
        }

        private void import_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(op.FileName);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void print_code_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void check_Click(object sender, EventArgs e)
        {
            try
            {
            string code;
            if (textBox1.Text.Length == 0)
                code = Brainfuck.GenerateCodeFromText("Coucou les sups c'est vos ACDC qui vous parlent!", brainfuck);
            else
                code = textBox1.Text;
            original_text.Clear();
            original_text.Text = code.Length + "char";

            string code2 = Brainfuck.ShortenCode(code, brainfuck);
            after1_text.Clear();
            after1_text.Text = code2.Length + "char";
            }
            catch (Exception ex)
            {
                after1_text.Text = "Brainfuck failed: " + ex.Message;
            }
        }

        private void json_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo File = null;
            bool con = true;
            do
            {
                if (jsonfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    File = new System.IO.FileInfo(jsonfile.FileName);
                    Console.WriteLine("File to be loaded : " + File.FullName);
                    if (File.Extension == ".json")
                    {
                        this.jsone = JSON.ParseJSONFile(File.FullName);
                        label_json1.Text = "JSON state : Parsed";
                        con = false;
                        try
                        {
                            JSON.PrintJSON(this.jsone);            
                            label_json1.Text = "JSON state : Parsed and printed in console";
                        }
                        catch (Exception exception)
                        {
                            label_json1.Text = "JSON state : Parsed and not printed, see console";
                            Console.WriteLine("PrintJSON error : " + exception);
                        }
                    }
                    else
                        label_json1.Text = "JSON state : invalid JSON file";
                }
                else
                    con = false;
            } while (con && File != null && File.Extension != ".json");
        }

        private void json_search_Click(object sender, EventArgs e)
        {
            if (this.jsone == null)
            {
                label_json2.Text = "JSON file not loaded";
                return;
            }
            JSONElement tmp = JSON.SearchJSON(this.jsone, json_text_search.Text);
            if (tmp == null)
                label_json2.Text = "Not found";
            else if (tmp.Type == JSONElement.JSONType.STR)
                label_json2.Text = tmp.string_value;
            else if (tmp.Type == JSONElement.JSONType.BOOL)
                label_json2.Text = tmp.bool_value.ToString();
            else if (tmp.Type == JSONElement.JSONType.NB)
                label_json2.Text = tmp.int_value.ToString();
            else if (tmp.Type == JSONElement.JSONType.NULL)
                label_json2.Text = "null";
            else if (tmp.Type == JSONElement.JSONType.DIC)
            {
                label_json2.Text = "Dic/list. Printed in Console";
                try
                {
                    JSON.PrintJSON(tmp);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("JSON printing error : " + exception);
                }
            }
        }

        private void brainfuck_load_Click(object sender, EventArgs e)
        {
            if (this.jsone == null)
            {
                label_json2.Text = "JSON file not loaded";
                return;
            }

            foreach (KeyValuePair<char, char> kvp in brainfuck)
            {
                JSONElement tmp =  JSON.SearchJSON(this.jsone, kvp.Key + "");
                if (tmp == null || tmp.Type != JSONElement.JSONType.STR)
                {
                    label_json2.Text = "Invalid JSON";
                    brainfuck = Program.classicBrainfuck();
                    return;
                }

                brainfuck[kvp.Key] = tmp.string_value[0];
            }
        }

        private void generate_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Brainfuck.GenerateCodeFromText(textBox1.Text, brainfuck);
            }
            catch (Exception ex)
            {
                textBox1.Text = "Brainfuck failed: "  + ex.Message;
            }
        }

        private void shorten_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Brainfuck.ShortenCode(textBox1.Text, brainfuck);
            }
            catch (Exception ex)
            {
                textBox1.Text = "Brainfuck failed: " + ex.Message;
            }
        }
    }
}
