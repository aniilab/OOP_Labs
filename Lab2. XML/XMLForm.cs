using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace LabXML
{
    public partial class XMLForm : Form
    {
        string HelpFilePath = "D:\\c#\\LabXML\\LabXML\\help.txt";
        string XMLPath ="D:\\c#\\LabXML\\LabXML\\TopMovies.xml";
        string XSLPath = "D:\\c#\\LabXML\\LabXML\\bin\\Debug\\XMLtoHTML.xsl";
        public XMLForm()
        {
            InitializeComponent();
            SetComboBox(XMLPath);
            WindowState = FormWindowState.Maximized;
            nameComboBox.Enabled = false;
            dateComboBox.Enabled = false;
            BudgetComboBox.Enabled = false;
            CountryComboBox.Enabled = false;
            TimeComboBox.Enabled = false;
            WatchedComboBox.Enabled = false;
            ProductionComboBox.Enabled = false;
            GenreComboBox.Enabled = false;
            LINQtoXMLradioButton.Checked = true;
        }

        public void SetComboBox(string path)
        {
            IStrategy p = new LINQtoXML();
            List<Movie> res = p.AnalyzeFile(new Movie(), path);
            List<string> name = new List<string>();
            List<string> date = new List<string>();
            List<string> budget = new List<string>();
            List<string> production = new List<string>();
            List<string> genre = new List<string>();
            List<string> time = new List<string>();

            foreach (Movie movie in res)
            {
                if (!name.Contains(movie.Name))
                {
                    name.Add(movie.Name);
                }
                if (!date.Contains(movie.ReleaseDate))
                {
                    date.Add(movie.ReleaseDate);
                }
                if (!budget.Contains(movie.Budget))
                {
                    budget.Add(movie.Budget);
                }
                if (!production.Contains(movie.Production))
                {
                    production.Add(movie.Production);
                }
                if (!genre.Contains(movie.Genre))
                {
                    genre.Add(movie.Genre);
                }
                if (!time.Contains(movie.RunningTime))
                {
                    time.Add(movie.RunningTime);
                }
            }
            name = name.OrderBy(x => x).ToList();
            date = date.OrderBy(x => x).ToList();
            budget = budget.OrderBy(x => x).ToList();
            production = production.OrderBy(x => x).ToList();
            genre = genre.OrderBy(x => x).ToList();
            time = time.OrderBy(x => x).ToList();

            string yes = "Yes";
            string no = "No";
            string USA = "United States";
            string UK = "United Kingdom";

            nameComboBox.Items.AddRange(name.ToArray());
            dateComboBox.Items.AddRange(date.ToArray());
            BudgetComboBox.Items.AddRange(budget.ToArray());
            ProductionComboBox.Items.AddRange(production.ToArray());
            GenreComboBox.Items.AddRange(genre.ToArray());
            TimeComboBox.Items.AddRange(time.ToArray());
            WatchedComboBox.Items.Add(yes);
            WatchedComboBox.Items.Add(no);
            CountryComboBox.Items.Add(USA);
            CountryComboBox.Items.Add(UK);
            
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {
            string message = File.ReadAllText(HelpFilePath);
            MessageBox.Show(message, "Help Info");
        }

        private void Author_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author of this laboratory work says hi!\nAuthor: Alina Bedenko from K-27.", "Author Info");
        }

        private void XMLForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitDialogResult = MessageBox.Show("Are you sure you want to exit?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (exitDialogResult == DialogResult.Yes)
            {
                return;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void XMLForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            nameComboBox.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void transformButton_Click(object sender, EventArgs e)
        {
            XslCompiledTransform xsl = new XslCompiledTransform();

            xsl.Load(XSLPath);
            string input = XMLPath;
            string result = @"HTMLOutput.html";
            xsl.Transform(input, result);
            MessageBox.Show("Success!");
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            List<Movie> res = new List<Movie>();
            Movie movie = WantedMovie();
            IStrategy parser = new LINQtoXML();
            if (LINQtoXMLradioButton.Checked)
            {
                parser = new LINQtoXML();
            }
            else if (SAXradioButton.Checked)
            {
                parser = new SAX();                
            }
            else if (DOMradioButton.Checked)
            {
                parser = new DOM();
            }
            res = parser.AnalyzeFile(movie, XMLPath);
            Output(res);
        }

        private Movie WantedMovie()
        {
            string[] data = new string[8];
            if (nameCheckBox.Checked)
            {
                data[0] = Convert.ToString(nameComboBox.Text);
            }
            if (realeseDateCheckBox.Checked)
            {
                data[1] = Convert.ToString(dateComboBox.Text);
            }
            if (genreCheckBox.Checked)
            {
                data[2] = Convert.ToString(GenreComboBox.Text);
            }
            if (timeCheckBox.Checked)
            {
                data[3] = Convert.ToString(TimeComboBox.Text);
            }
            if (budgetCheckBox.Checked)
            {
                data[4] = Convert.ToString(BudgetComboBox.Text);
            }
            if (productionCheckBox.Checked)
            {
                data[5] = Convert.ToString(ProductionComboBox.Text);
            }
            if (countryCheckBox.Checked)
            {
                data[6] = Convert.ToString(CountryComboBox.Text);
            }
            if (watchedCheckBox.Checked)
            {
                data[7] = Convert.ToString(WatchedComboBox.Text);
            }
            Movie wanted = new Movie(data);
            return wanted;
        }

        private void Output(List<Movie> outputMaterial)
        {
            int i = 1;
            richTextBox1.Clear();
            if (outputMaterial.Count == 0)
            {
                richTextBox1.AppendText("Nothing was found! \n");
                return;
            }
            foreach (Movie movie in outputMaterial)
            {
                richTextBox1.AppendText(i++ + "." + "\n");
                richTextBox1.AppendText("Name: " + movie.Name + "\n");
                richTextBox1.AppendText("Release date: " + movie.ReleaseDate + "\n");
                richTextBox1.AppendText("Genre: " + movie.Genre + "\n");
                richTextBox1.AppendText("Running time: " + movie.RunningTime + "\n");
                richTextBox1.AppendText("Budget: " + movie.Budget + "\n");
                richTextBox1.AppendText("Production: " + movie.Production + "\n");
                richTextBox1.AppendText("Country: " + movie.Country + "\n");
                richTextBox1.AppendText("Have you watched it: " + movie.Watched + "\n");
                richTextBox1.AppendText("🎞🎞🎞🎞🎞🎞🎞🎞🎞🎞🎞🎞🎞🎞🎞 \n");
            }
        }

        private void realeseDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dateComboBox.Enabled = true;
        }

        private void genreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenreComboBox.Enabled = true;
        }

        private void timeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TimeComboBox.Enabled = true;
        }

        private void budgetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BudgetComboBox.Enabled = true;
        }

        private void productionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ProductionComboBox.Enabled = true;
        }

        private void countryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CountryComboBox.Enabled = true;
        }

        private void watchedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WatchedComboBox.Enabled = true;
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }

            try
            {
                ClearComboBox();
                ClearForm();
                SetComboBox(path);
                XMLPath = path;
                MessageBox.Show("Done!");
            }
            catch
            {
                MessageBox.Show("Wrong file!");
                SetComboBox(XMLPath);
            }
        }

        private void ClearComboBox()
        {
            nameComboBox.Items.Clear();
            dateComboBox.Items.Clear();
            BudgetComboBox.Items.Clear();
            CountryComboBox.Items.Clear();
            TimeComboBox.Items.Clear();
            WatchedComboBox.Items.Clear();
            ProductionComboBox.Items.Clear();
            GenreComboBox.Items.Clear();

        }

        private void ClearForm()
        {
            richTextBox1.Clear();
            nameCheckBox.Checked = false;
            realeseDateCheckBox.Checked = false;
            budgetCheckBox.Checked = false;
            countryCheckBox.Checked = false;
            timeCheckBox.Checked = false;
            watchedCheckBox.Checked = false;
            productionCheckBox.Checked = false;
            genreCheckBox.Checked = false;
            DOMradioButton.Checked = false;
            SAXradioButton.Checked = false;
            LINQtoXMLradioButton.Checked = false;
            nameComboBox.Text = null;
            dateComboBox.Text = null;
            BudgetComboBox.Text = null;
            CountryComboBox.Text = null;
            TimeComboBox.Text = null;
            WatchedComboBox.Text = null;
            ProductionComboBox.Text = null;
            GenreComboBox.Text = null;
            nameComboBox.Enabled = false;
            dateComboBox.Enabled = false;
            BudgetComboBox.Enabled = false;
            CountryComboBox.Enabled = false;
            TimeComboBox.Enabled = false;
            WatchedComboBox.Enabled = false;
            ProductionComboBox.Enabled = false;
            GenreComboBox.Enabled = false;
        }
    }
}
