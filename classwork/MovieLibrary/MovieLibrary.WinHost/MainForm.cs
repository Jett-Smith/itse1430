// ITSE 1420
// Movie Library

using System;
using System.Linq;
using System.Windows.Forms;
using MovieLibrary.Memory;
using MovieLibrary.Sql;

namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        private IMovieDatabase _movies = new SqlMovieDatabase(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=MovieDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        public MainForm()
        {
            InitializeComponent();

            //Additional init here
            //Runs at design time as well - be careful
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI(true);
        }
        private void OnFileExit ( object sender, EventArgs e )
        {
            //Confirm exit?
            if (!Confirm("Do you want to quit?", "Confirm"))
                return;

            Close();
        }

        private  bool Confirm ( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dlg = new AboutBox();

            //Blocks until child form is closed
            dlg.ShowDialog();

            //Show displays modeless, not blocking
            //dlg.Show();
            //MessageBox.Show("After Show");
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var dlg = new MovieForm();
            dlg.StartPosition = FormStartPosition.CenterParent;

            do
            {
                //ShowDialog -> DialogResult
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                //Save movie
                try
                {
                    _movies.Add(dlg.Movie);
                    UpdateUI();
                    return;
                } catch (ArgumentException ex)
                {
                    DisplayError(ex.Message, "Programmer Error");
                } catch (InvalidOperationException ex)
                {
                    DisplayError(ex.Message, "Not now");
                } catch (NotSupportedException ex)
                {
                    DisplayError("Not supported", "Error");
                    //Do some logging
                    throw;
                } catch (System.IO.IOException ex)
                {
                    throw new Exception("IO failed", ex);
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Failed");
                }
            } while (true);
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var dlg = new MovieForm();
            dlg.Movie = movie;

            do
            {
                //ShowDialog -> DialogResult
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                //Error handling
                try
                {
                    _movies.Update(movie.Id, dlg.Movie);
                    UpdateUI();
                    return;
                } catch (ArgumentException ex)
                {
                    DisplayError(ex.Message, "Programmer Error");
                } catch (InvalidOperationException ex)
                {
                    DisplayError(ex.Message, "Not now");
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Failed");
                }
            } while (true);
        }

        private Movie GetSelectedMovie ()
        {
            return _listMovies.SelectedItem as Movie;
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //Confirmation
            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            //TODO: Delete
            try
            {
                _movies.Delete(movie.Id);
                UpdateUI();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Delete Failed");
            }
        }

        private void UpdateUI ( bool isFirstRun = false )
        {
            //Update movie list
            var movies = _movies.GetAll();
            if (isFirstRun && !movies.Any())
            {
                if(Confirm("Do you want to seed the database", "Seed"))
                {
                    _movies.Seed();
                    //SeedDatabase.Seed(_movies);
                    movies = _movies.GetAll();
                }
            }

            //LINQ Syntax
            movies = from x in movies
                     orderby x.Title, x.ReleaseYear
                     select x;

            var bindingSource = new BindingSource();
            //bindingSource.DataSource = movies.OrderBy(x => x.Title).ThenBy(x => x.ReleaseYear).ToArray();
            bindingSource.DataSource = movies.ToArray();

            //bind the movies to the listbox
            _listMovies.DataSource = bindingSource;
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
