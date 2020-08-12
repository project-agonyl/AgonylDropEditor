using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace AgonylDropEditor
{
    public partial class FormMain : Form
    {
        private BindingList<Monster> _a3MonsterData = new BindingList<Monster>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Utils.GetMyDirectory() + Path.DirectorySeparatorChar + "MON.txt"))
            {
                _ = MessageBox.Show("Please place MON.txt in same folder as this application", "Agonyl Drop Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (!File.Exists(Utils.GetMyDirectory() + Path.DirectorySeparatorChar + "IT0.txt"))
            {
                _ = MessageBox.Show("Please place IT0.txt in same folder as this application", "Agonyl Drop Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (!File.Exists(Utils.GetMyDirectory() + Path.DirectorySeparatorChar + "IT1.txt"))
            {
                _ = MessageBox.Show("Please place IT1.txt in same folder as this application", "Agonyl Drop Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (!File.Exists(Utils.GetMyDirectory() + Path.DirectorySeparatorChar + "IT2.txt"))
            {
                _ = MessageBox.Show("Please place IT2.txt in same folder as this application", "Agonyl Drop Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (!File.Exists(Utils.GetMyDirectory() + Path.DirectorySeparatorChar + "IT3.txt"))
            {
                _ = MessageBox.Show("Please place IT3.txt in same folder as this application", "Agonyl Drop Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            Utils.LoadMonsterData();
            Utils.LoadItemData();
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                Name = "Monster ID",
                Width = 150,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Name",
                Name = "Monster Name",
                Width = 150,
            });
            this.dataGridView.DataSource = this._a3MonsterData;
            this.ReloadDataButton.Enabled = false;
        }

        private void ChooseNPCFolderButton_Click(object sender, EventArgs e)
        {
            if (this.FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.CurrentMonsterFolderLabel.Text = this.FolderBrowser.SelectedPath;
                this.LoadMonsterDetails();
                this.ReloadDataButton.Enabled = true;
            }
        }

        private void ReloadDataButton_Click(object sender, EventArgs e)
        {
            this.LoadMonsterDetails();
        }

        private void LoadMonsterDetails()
        {
            if (!Directory.Exists(this.CurrentMonsterFolderLabel.Text))
            {
                return;
            }

            this._a3MonsterData.Clear();
            foreach (var file in Directory.GetFiles(this.CurrentMonsterFolderLabel.Text, "*.itm"))
            {
                try
                {
                    var id = Convert.ToUInt32(Path.GetFileNameWithoutExtension(file));

                    var monsterData = new Monster()
                    {
                        Id = id,
                        Name = Utils.MonsterList.ContainsKey(id) ? Utils.MonsterList[id].Name : "Unknown Monster",
                        File = file,
                    };
                    this._a3MonsterData.Add(monsterData);
                }
                catch { }
            }

            _ = MessageBox.Show("Loaded " + this._a3MonsterData.Count + "monster drop files", "Agonyl Drop Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the Data format of the file(s) can be accepted
            // (we only accept file drops from Windows Explorer, etc.)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // modify the drag drop effects to Move
                e.Effect = DragDropEffects.All;
            }
            else
            {
                // no need for any drag drop effect
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView_DragDrop(object sender, DragEventArgs e)
        {
            // still check if the associated data from the file(s) can be used for this purpose
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Fetch the file(s) names with full path here to be processed
                var fileList = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (Path.GetExtension(fileList[0]) == ".itm")
                {
                    var editorForm = new FormDropEditor();
                    editorForm.ItmFile = fileList[0];
                    editorForm.ShowDialog();
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = this.dataGridView.Rows[e.RowIndex].Index;
            var questEditorForm = new FormDropEditor();
            questEditorForm.ItmFile = this._a3MonsterData[dataIndexNo].File;
            questEditorForm.ShowDialog();
        }
    }
}
