using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace AgonylDropEditor
{
    public partial class FormDropEditor : Form
    {
        public string ItmFile;

        private byte[] _fileData;
        private BindingList<A3Drop> _a3Drops = new BindingList<A3Drop>();

        public FormDropEditor()
        {
            InitializeComponent();
        }

        private void FormDropEditor_Load(object sender, EventArgs e)
        {
            var monsterName = "Unknown Monster";
            if (ushort.TryParse(Path.GetFileNameWithoutExtension(this.ItmFile), out _))
            {
                var monsterId = Convert.ToUInt16(Path.GetFileNameWithoutExtension(this.ItmFile));
                monsterName = Utils.MonsterList.ContainsKey(monsterId) ? Utils.MonsterList[monsterId].Name : "Unknown Monster";
            }

            this.Text = "Drop Editor - " + Path.GetFileName(this.ItmFile) + " (" + monsterName + ")";
            this._fileData = File.ReadAllBytes(this.ItmFile);
            this.SaveFileDialog.FileName = Path.GetFileName(this.ItmFile);
            this.SaveFileDialog.InitialDirectory = new FileInfo(this.ItmFile).Directory.Name;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemId",
                Name = "Item ID",
                Width = 100,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName",
                Name = "Item Name",
                Width = 150,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DropRate",
                Name = "Drop Rate",
                Width = 150,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DropGroup",
                Name = "Drop Group",
                Width = 100,
            });
            this.dataGridView.DataSource = this._a3Drops;
            this._fileData = File.ReadAllBytes(this.ItmFile);
            for (var i = 0; i < this._fileData.Length; i += 6)
            {
                var itemId = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref this._fileData, 2, i));
                string itemName;
                if (itemId == 0xFFFF)
                {
                    itemName = "Empty drop slot";
                }
                else
                {
                    var smallItemId = (ushort)(itemId & 0x3FFF);
                    itemName = Utils.ItemList.ContainsKey(smallItemId) ? Utils.ItemList[smallItemId].Name : "Unknown Item";
                }

                this._a3Drops.Add(new A3Drop()
                {
                    ItemId = itemId,
                    ItemName = itemName,
                    DropRate = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref this._fileData, 2, i + 2)),
                    DropGroup = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref this._fileData, 2, i + 4)),
                });
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this._a3Drops.Count == 0)
            {
                _ = MessageBox.Show("Drop list is empty", "Agonyl Drop Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.SaveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                var dataBuilder = new BinaryDataBuilder();
                foreach (var item in this._a3Drops)
                {
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.ItemId));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.DropRate));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.DropGroup));
                }

                File.WriteAllBytes(this.SaveFileDialog.FileName, dataBuilder.GetBuffer());
                _ = MessageBox.Show("Saved the file " + Path.GetFileName(this.SaveFileDialog.FileName), "Agonyl Drop Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
