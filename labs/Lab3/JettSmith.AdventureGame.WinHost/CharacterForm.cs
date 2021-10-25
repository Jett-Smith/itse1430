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
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
                LoadCharacter(Character);
            else
                LoadNewCharacter();

            ValidateChildren();
        }

        private void LoadCharacter ( Character character )
        {
            _txtName.Text = character.Name;
            _cbClass.Text = character.Class;
            _cbRace.Text = character.Race;
            _txtStength.Text = character.Strength.ToString();
            _txtIntelligence.Text = character.Intelligence.ToString();
            _txtAgility.Text = character.Agility.ToString();
            _txtConstitution.Text = character.Constitution.ToString();
            _txtCharisma.Text = character.Charisma.ToString();
            _txtBiography.Text = character.Biography;
        }

        private void LoadNewCharacter ()
        {
            _txtStength.Text = "50";
            _txtIntelligence.Text = "50";
            _txtAgility.Text = "50";
            _txtConstitution.Text = "50";
            _txtCharisma.Text = "50";
        }

        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            }

            var character = new Character();
            character.Name = _txtName.Text;
            character.Class = _cbClass.Text;
            character.Race = _cbRace.Text;
            character.Strength = GetInt32(_txtStength);
            character.Intelligence = GetInt32(_txtIntelligence);
            character.Agility = GetInt32(_txtAgility);
            character.Constitution = GetInt32(_txtConstitution);
            character.Charisma = GetInt32(_txtCharisma);
            character.Biography = _txtBiography.Text;

            var error = character.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                DisplayError(error, "Error");
                DialogResult = DialogResult.None;
                return;
            }

            Character = character;

            Close();
        }

        private void OnValidatingName ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            if (control.Text.Length > 0)
            {
                _errors.SetError(control, "");
                return;
            }

            _errors.SetError(control, "Name is required");
            e.Cancel = true;
        }

        private void OnValidatingClass ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            if (control.Text.Length > 0)
            {
                _errors.SetError(control, "");
                return;
            }

            _errors.SetError(control, "Class is required");
            e.Cancel = true;
        }

        private void OnValidatingRace ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            if (control.Text.Length > 0)
            {
                _errors.SetError(control, "");
                return;
            }

            _errors.SetError(control, "Race is required");
            e.Cancel = true;
        }

        private void OnValidatingStrength ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetInt32(control);
            if (value >= 1 && value <= 100)
            {
                _errors.SetError(control, "");
                return;
            }

            _errors.SetError(control, "Strength must be between 1 and 100");
            e.Cancel = true;
        }

        private void OnValidatingIntelligence ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetInt32(control);
            if (value >= 1 && value <= 100)
            {
                _errors.SetError(control, "");
                return;
            }

            _errors.SetError(control, "Intelligence must be between 1 and 100");
            e.Cancel = true;
        }

        private void OnValidatingAgility ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetInt32(control);
            if (value >= 1 && value <= 100)
            {
                _errors.SetError(control, "");
                return;
            }

            _errors.SetError(control, "Agility must be between 1 and 100");
            e.Cancel = true;
        }

        private void OnValidatingConstitution ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetInt32(control);
            if (value >= 1 && value <= 100)
            {
                _errors.SetError(control, "");
                return;
            }

            _errors.SetError(control, "Constitution must be between 1 and 100");
            e.Cancel = true;
        }

        private void OnValidatingCharisma ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetInt32(control);
            if (value >= 1 && value <= 100)
            {
                _errors.SetError(control, "");
                return;
            }

            _errors.SetError(control, "Charisma must be between 1 and 100");
            e.Cancel = true;
        }

        private int GetInt32 ( Control control )
        {
            var text = control.Text;
            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Confirm ( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
