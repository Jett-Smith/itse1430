/*
 *  Jett Smith
 *  ITSE 1430 - Fall 2021
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JettSmith.AdventureGame.WinHost
{
    public partial class MainForm : Form
    {
        private Character _character;
        private World _world;
        private Player _player;
        private bool _showInventory = false;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            _world = new World();
            _world.Seed();
            DisablePlay();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            if (!Confirm("Do you want to quit?", "Confirm"))
                return;

            Close();
        }

        private bool Confirm ( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dlg = new AboutBox();
            dlg.ShowDialog();
        }

        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var dlg = new CharacterForm();
            dlg.StartPosition = FormStartPosition.CenterParent;

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            MessageBox.Show("Character Saved");
            _character = dlg.Character;
            UpdateUI();
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            var dlg = new CharacterForm();
            dlg.Character = _character;

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            MessageBox.Show("Character Saved");
            _character = dlg.Character;
            UpdateUI();
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{_character.Name}'?", "Delete"))
                return;

            _character = null;
            UpdateUI();
        }

        private void OnGameStart ( object sender, EventArgs e )
        {
            if(_character == null)
            {
                DisplayError("You need to make a character to proceed", "No Character Created");
                return;
            }

            stopToolStripMenuItem.Enabled = true;
            characterToolStripMenuItem.Enabled = false;

            _player = new Player() {
                PlayerCharacter = _character,
                CurrentArea = _world.StartingArea,
            };

            _btnInventory.Enabled = true;
            UpdateUI();
        }

        public void UpdateUI ()
        {
            var characters = (_character != null) ? new Character[1] : new Character[0];
            if (_character != null)
                characters[0] = _character;

            var bindingSource = new BindingSource();
            bindingSource.DataSource = characters;

            _listCharacters.DataSource = bindingSource;

            if (_showInventory)
            {
                _btnInventory.Text = "Hide Inventory";
                _lblGoldCostAndWeight.Text = $"Worth {_player.inventory.GetTotalGoldCost()} gp  {_player.inventory.GetTotalWeight()} lbs.";

                var inventory = (_player.inventory != null) ? _player.inventory.GetAll().ToArray() : new Item[0];

                var bindingSource2 = new BindingSource();
                bindingSource2.DataSource = inventory;

                _listInventory.DataSource = bindingSource2;
            } 
            else
            {
                _btnInventory.Text = "Show Inventory";
                _lblGoldCostAndWeight.Text = "";

                var bindingSource2 = new BindingSource();
                bindingSource2.DataSource = new Item[0];

                _listInventory.DataSource = bindingSource2;
            }

            if (_player != null)
            {
                Area currentArea = _world.FindById(_player.CurrentArea);

                if (currentArea.AreaItem == null)
                {
                    _lblDescription.Text = currentArea.Description;
                    _btnPickUp.Enabled = false;
                }
                else
                {
                    _lblDescription.Text = currentArea.Description + "\n\n" + currentArea.ItemDescription;
                    _btnPickUp.Enabled = true;
                }

                _btnNorth.Enabled = !(currentArea.NorthArea == -1);
                _btnSouth.Enabled = !(currentArea.SouthArea == -1);
                _btnEast.Enabled = !(currentArea.EastArea == -1);
                _btnWest.Enabled = !(currentArea.WestArea == -1);
            }
            else
            {
                DisablePlay();
            }
        }
        
        private void OnGameStop ( object sender, EventArgs e )
        {
            characterToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
            _player = null;
            UpdateUI();
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnNorth ( object sender, EventArgs e )
        {
            _player.CurrentArea = _world.FindById(_player.CurrentArea).NorthArea;
            UpdateUI();
        }
        private void OnSouth ( object sender, EventArgs e )
        {
            _player.CurrentArea = _world.FindById(_player.CurrentArea).SouthArea;
            UpdateUI();
        }
        private void OnEast ( object sender, EventArgs e )
        {
            _player.CurrentArea = _world.FindById(_player.CurrentArea).EastArea;
            UpdateUI(); ;
        }
        private void OnWest ( object sender, EventArgs e )
        {
            _player.CurrentArea = _world.FindById(_player.CurrentArea).WestArea;
            UpdateUI();
        }

        private void OnPickUp ( object sender, EventArgs e )
        {
            _player.inventory.Add(_world.FindById(_player.CurrentArea).AreaItem.Clone());
            _world.FindById(_player.CurrentArea).AreaItem = null;
            UpdateUI();
        }

        private void OnInventory ( object sender, EventArgs e )
        {
            _showInventory = !_showInventory;
            UpdateUI();
        }

        private void DisablePlay ()
        {
            _lblDescription.Text = "";
            _btnNorth.Enabled = false;
            _btnSouth.Enabled = false;
            _btnEast.Enabled = false;
            _btnWest.Enabled = false;
            _btnInventory.Enabled = false;
            _btnPickUp.Enabled = false;
        }
    }
}
