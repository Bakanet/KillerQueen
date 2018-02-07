namespace Brainfuck
{
    partial class IDE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.interpret = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.check = new System.Windows.Forms.Button();
            this.before = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.original_text = new System.Windows.Forms.TextBox();
            this.after1_text = new System.Windows.Forms.TextBox();
            this.after2_text = new System.Windows.Forms.TextBox();
            this.bool_text = new System.Windows.Forms.TextBox();
            this.generate = new System.Windows.Forms.Button();
            this.shorten = new System.Windows.Forms.Button();
            this.brainfuck_load = new System.Windows.Forms.Button();
            
            this.label_json1 = new System.Windows.Forms.Label();
            this.label_json2 = new System.Windows.Forms.Label();
            this.jsonbutton = new System.Windows.Forms.Button();
            this.jsonfile = new System.Windows.Forms.OpenFileDialog();
            this.json_button_search = new System.Windows.Forms.Button();
            this.json_text_search = new System.Windows.Forms.TextBox();
            


            this.SuspendLayout();
            
            
            
            
            // 
            // interpret
            // 
            this.interpret.Location = new System.Drawing.Point(13, 23);
            this.interpret.Name = "interpret";
            this.interpret.Size = new System.Drawing.Size(90, 23);
            this.interpret.TabIndex = 0;
            this.interpret.Text = "Interpret";
            this.interpret.UseVisualStyleBackColor = true;
            this.interpret.Click += new System.EventHandler(this.interpret_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 11);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 225);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(109, 242);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(372, 123);
            this.textBox2.TabIndex = 3;
            this.textBox2.ReadOnly = true;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(13, 152);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(90, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(13, 181);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(90, 23);
            this.import.TabIndex = 5;
            this.import.Text = "Import file";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(13, 210);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(90, 23);
            this.clear.TabIndex = 0;
            this.clear.Text = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(592, 13);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(75, 23);
            this.check.TabIndex = 10;
            this.check.Text = "Check";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // before
            // 
            this.before.AutoSize = true;
            this.before.Location = new System.Drawing.Point(488, 53);
            this.before.Name = "before";
            this.before.Size = new System.Drawing.Size(42, 13);
            this.before.TabIndex = 11;
            this.before.Text = "Original";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "After shorten_code";
            // 
            // original_text
            // 
            this.original_text.Location = new System.Drawing.Point(592, 46);
            this.original_text.Name = "original_text";
            this.original_text.Size = new System.Drawing.Size(100, 20);
            this.original_text.TabIndex = 14;
            // 
            // after1_text
            // 
            this.after1_text.Location = new System.Drawing.Point(592, 70);
            this.after1_text.Name = "after1_text";
            this.after1_text.Size = new System.Drawing.Size(100, 20);
            this.after1_text.TabIndex = 15;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(13, 52);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(90, 23);
            this.generate.TabIndex = 18;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // shorten
            // 
            this.shorten.Location = new System.Drawing.Point(13, 123);
            this.shorten.Name = "shorten";
            this.shorten.Size = new System.Drawing.Size(90, 23);
            this.shorten.TabIndex = 19;
            this.shorten.Text = "Shorten";
            this.shorten.UseVisualStyleBackColor = true;
            this.shorten.Click += new System.EventHandler(this.shorten_Click);
             // 
            // shorten
            // 
            this.brainfuck_load.Location = new System.Drawing.Point(488, 290);
            this.brainfuck_load.Name = "brainfuck_load";
            this.brainfuck_load.Size = new System.Drawing.Size(90, 23);
            this.brainfuck_load.TabIndex = 19;
            this.brainfuck_load.Text = "Load brainfuck";
            this.brainfuck_load.UseVisualStyleBackColor = true;
            this.brainfuck_load.Click += new System.EventHandler(this.brainfuck_load_Click);           
            
            
            this.jsonbutton.Location = new System.Drawing.Point(488, 120);
            this.jsonbutton.Size = new System.Drawing.Size(100, 23);
            this.jsonbutton.Click += new System.EventHandler(this.json_Click);
            this.jsonbutton.Text = "Load JSON file";
            this.jsonfile.Title = "JSON FILE";
            
            this.label_json1.AutoSize = true;
            this.label_json1.Location = new System.Drawing.Point(488, 160);
            this.label_json1.Name = "json_1";
            this.label_json1.Size = new System.Drawing.Size(100, 23);
            this.label_json1.TabIndex = 20;
            this.label_json1.Text = "JSON state : no file yet";

            
            this.label_json2.AutoSize = true;
            this.label_json2.Location = new System.Drawing.Point(488, 250);
            this.label_json2.Name = "json_2";
            this.label_json2.Size = new System.Drawing.Size(100, 23);
            this.label_json2.TabIndex = 21;
            this.label_json2.Text = "";
            
            this.json_button_search.Location = new System.Drawing.Point(600, 190);
            this.json_button_search.Size = new System.Drawing.Size(90, 23);
            this.json_button_search.Click += new System.EventHandler(this.json_search_Click);
            this.json_button_search.Text = "Search in JSON";
            this.json_button_search.TabIndex = 23;
            
            this.json_text_search.Location = new System.Drawing.Point(488, 190);
            this.json_text_search.Name = "search";
            this.json_text_search.Size = new System.Drawing.Size(100, 20);
            this.json_text_search.TabIndex = 22;
            
            this.interpret.UseVisualStyleBackColor = true;
            //
            // IDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 377);
            this.Controls.Add(this.shorten);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.after1_text);
            this.Controls.Add(this.original_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.before);
            this.Controls.Add(this.check);
            this.Controls.Add(this.import);
            this.Controls.Add(this.save);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.interpret);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.jsonbutton);
            this.Controls.Add(this.label_json1);
            this.Controls.Add(this.label_json2);
            this.Controls.Add(this.json_button_search);
            this.Controls.Add(this.json_text_search);
            this.Controls.Add(this.brainfuck_load);
            this.Name = "IDE";
            this.Text = "IDE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button interpret;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Label before;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox original_text;
        private System.Windows.Forms.TextBox after1_text;
        private System.Windows.Forms.TextBox after2_text;
        private System.Windows.Forms.TextBox bool_text;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Button shorten;
        private System.Windows.Forms.Button brainfuck_load;
        
        private System.Windows.Forms.Button jsonbutton;
        private System.Windows.Forms.Label label_json1;
        private System.Windows.Forms.Label label_json2;
        private System.Windows.Forms.FileDialog jsonfile;
        private System.Windows.Forms.TextBox json_text_search;
        private System.Windows.Forms.Button json_button_search;
    }
}