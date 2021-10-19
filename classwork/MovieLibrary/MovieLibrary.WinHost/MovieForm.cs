// ITSE 1430
// Movie Library

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        public Movie Movie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            //Always call base version first
            base.OnLoad(e);

            if (Movie != null)
                LoadMovie(Movie);
        }

        private void LoadMovie( Movie movie )
        {
            _txtTitle.Text = movie.Title;
            _txtDescription.Text = movie.Description;
            _cbRating.Text = movie.Rating;
            _txtRunLength.Text = movie.RunLength.ToString();
            _txtReleaseYear.Text = movie.ReleaseYear.ToString();
            _chkIsClassic.Checked = movie.IsClassic;
        }

        //Called when Save clicked
        private void OnSave ( object sender, EventArgs e )
        {
            //Build up a Movie
            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _cbRating.Text;
            movie.RunLength = GetInt32(_txtRunLength);
            movie.ReleaseYear = GetInt32(_txtReleaseYear);
            movie.IsClassic = _chkIsClassic.Checked;

            //TODO: Validate
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                DisplayError(error, "Error");
                DialogResult = DialogResult.None;
                return;
            }

            Movie = movie;

            //Close the form
            Close();
        }

        private int GetInt32 ( Control control)
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

        private void _txtTitle_KeyUp ( object sender, KeyEventArgs e )
        {
            var target = sender as TextBox;
            System.Diagnostics.Debug.WriteLine($"KeyUp: Text={target.Name} Key={e.KeyCode}");
        }
    }
}
