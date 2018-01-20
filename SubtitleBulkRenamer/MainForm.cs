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
using System.Text.RegularExpressions;


namespace SubtitleBulkRenamer 
{ 
    public partial class MainForm : Form 
    {
		public int userSelection;
		private delegate bool EpisodeNoParser( string fileName, out int episodeNo );

		public MainForm() 
        { 
            InitializeComponent(); 
        } 
 
        private void RenameSubtitles( List< string > subtitleFilenamesList )
		{
			// Get directory path and subtitle extension type. 
			FileInfo fileInfo  = new FileInfo( subtitleFilenamesList.First() );
			string	 filePath  = fileInfo.FullName;
			string	 extension = fileInfo.Extension;
			string	 directory = filePath.Substring( 0, filePath.LastIndexOf( "\\" ) );

			// Set the directory and get all video files from it so we can iterate through them. 
			Directory.SetCurrentDirectory( directory );
			List<string> videoFileNamesList = new List<string>( Directory.GetFiles( directory, "*.mkv" ) );
			if( videoFileNamesList.Count <= 0 ) // If the video file format is not mkv then it must be mp4. 
			{
				videoFileNamesList = new List<string>( Directory.GetFiles( directory, "*.mp4" ) );
				if( videoFileNamesList.Count <= 0 ) // If the video file format is not mkv OR mp4 then signal error and quit.
				{
					MessageBox.Show( "No .mkv or .mp4 files found in directory!", "Error Encountered" );
					Application.Exit();
				}
			}

			// Sort video files based on episode number.
			Dictionary< int, string > videoFilesDict = new Dictionary< int, string >();
			SortFiles( videoFilesDict, videoFileNamesList );

			// Sort subtitle files based on episode number.
			Dictionary< int, string > subtitleFilesDict = new Dictionary< int, string >();
			SortFiles( subtitleFilesDict, subtitleFilenamesList );

			// Rename subtitle files.
			int renamedCount, notRenamedCount;
			Rename( videoFilesDict, subtitleFilesDict, extension, out renamedCount, out notRenamedCount );

			// If execution reached here, no errors so far. Print success message and quit. 
			string successPrompt = "";

			if( renamedCount > 0 )
			{
				successPrompt =  renamedCount.ToString();
				successPrompt += ( renamedCount > 1 ? " files were renamed!" : " file was renamed!" );
			}
			else
			{
				successPrompt = "No files were renamed!";
			}

			if( notRenamedCount > 0 )
			{
				successPrompt += "\n" + notRenamedCount.ToString();
				successPrompt += ( notRenamedCount > 1 ? " files already had correct names!"
													   : " file already had the correct name!" );
			}

			MessageBox.Show( successPrompt, "Renaming Finished Successfully" );
		}

		// Sorts files based on episode number, into a dictionary. 
		private void SortFiles( Dictionary< int, string > filesDict, List< string > fileNamesList )
		{
			// Test parse. If SxxExx method succeeds, it will be used. If it fails, 
			int episodeNo;
			EpisodeNoParser episodeNoParser = new EpisodeNoParser( ParseEpNo_SxxExxMethod );
			if( !episodeNoParser( fileNamesList.First().Substring( fileNamesList.First().LastIndexOf( "\\" ) + 1 ),
								  out episodeNo ) )
			{
				episodeNoParser = ParseEpNo_TryhardMethod;
			}
			
			foreach( string fileName in fileNamesList )
			{
				if( !episodeNoParser( fileName.Substring( fileName.LastIndexOf( "\\" ) + 1 ), out episodeNo ) )
				{
					MessageBox.Show( "Episode number of " + fileName + " could not be parsed!", "Error Encountered" );
					Application.Exit();
				}
				filesDict[ episodeNo ] = fileName; // Put this episode in its correct place using episodeNo.
			}
		}

		// Uses the "SxxExx" pattern in the filename to parse the episode number.
		// Example file name: "Vikings.S04E09.1080p.WEB-DL.x265-StackHD.mkv".
		private bool ParseEpNo_SxxExxMethod( string fileName, out int episodeNo )
		{
			episodeNo = -1;
			string SxxExx = Regex.Match( fileName.ToLower(), "s\\d\\de\\d\\d" ).Value;
			if( SxxExx.Length == 0 ) // If the string is empty that means SxxExx patternt could not be found.
			{
				return false;
			}
			episodeNo = ( int )Char.GetNumericValue( SxxExx.ElementAt( 4 ) ) * 10 +
						( int )Char.GetNumericValue( SxxExx.ElementAt( 5 ) );
			return true;
		}

		private bool ParseEpNo_TryhardMethod( string fileName, out int episodeNo )
		{
			episodeNo = -1;
			string fileNameLowerCopy = string.Copy( fileName.ToLower() );

			// Filter out known phrases with numbers in them.
			string[] knownPhrasesWithNumbers = { "480p", "720p", "1080p", "x264", "x265" };

			var wordsInFileNameLowerCopy = 
				Regex.Matches( fileNameLowerCopy, "\\w+" ).Cast< Match >().OrderByDescending( m => m.Index );

			foreach( var wordMatch in wordsInFileNameLowerCopy )
			{
				if( knownPhrasesWithNumbers.Contains( wordMatch.Value ) )
				{
					fileNameLowerCopy = fileNameLowerCopy.Remove( wordMatch.Index, wordMatch.Length );
				}
			}

			// Find the remaining digits in the now filtered lowercase file name.
			var matches = Regex.Matches( fileNameLowerCopy, "\\d*\\d" );

			if( matches.Count > 1 ) // Multiple matches found, let the user decide for this one.
			{
				List< string > matchesList = new List< string >();
				matchesList = matches.OfType< Match >().Select( m => m.Groups[ 0 ].Value ).ToArray().ToList();

				// Create an EpisodeNoSelectionForm and let the user manually choose the episode number.
				new EpisodeNoSelectionForm( this, fileName, matchesList ).ShowDialog();
				episodeNo = userSelection;
				return true;
			}
			else if( matches.Count == 1 ) // Found it!
			{
				List< string > matchesList = new List< string >();
				matchesList = matches.OfType< Match >().Select( m => m.Groups[ 0 ].Value ).ToArray().ToList();
				if( !Int32.TryParse( matchesList.First(), out episodeNo ) ) // Attempt to convert string to int.
				{
					return false;
				}
				return true;
			}
			else // We failed spectacularly!
			{
				return false;
			}
		}
		
		private void Rename( Dictionary< int, string > videoFiles, Dictionary< int, string > subtitleFiles,
							 string extension, out int renamedCount, out int notRenamedCount )
		{
			renamedCount = notRenamedCount = 0;
			// Rename the subtitles based on video file names. 
			foreach( var subtitleFile in subtitleFiles )
			{
				int	   episodeNo           = subtitleFile.Key;
				string oldSubtitleFileName = subtitleFile.Value;
				string videoFilename       = videoFiles[ episodeNo ];
				string newSubtitleFileName = videoFilename.Substring( 0, videoFilename.LastIndexOf( '.' ) ) +
											 extension;
				if( oldSubtitleFileName.Equals( newSubtitleFileName ) )
				{
					notRenamedCount++; // Count the number of subtitles with already correct names. 
				}
				else // Rename. 
				{
					System.IO.File.Move( oldSubtitleFileName, newSubtitleFileName );
					renamedCount++;
				}
			}
		}

		private void OnBrowseButtonClicked( object sender, EventArgs e ) 
        { 
            if( OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ) 
            { 
                RenameSubtitles( new List< string >( OpenFileDialog.FileNames ) ); 
            } 
        } 
 
        private void OnDragDrop( object sender, DragEventArgs e ) 
        { 
            int x = this.PointToClient( new Point( e.X, e.Y ) ).X; 
            int y = this.PointToClient( new Point( e.X, e.Y ) ).Y; 
 
            if( x >= DragFileLabel.Location.X && ( x <= DragFileLabel.Location.X + DragFileLabel.Width ) && 
                y >= DragFileLabel.Location.Y && ( y <= DragFileLabel.Location.Y + DragFileLabel.Height ) ) 
            { 
                List< string > fileNames = new List< string >( ( string[] )e.Data.GetData( DataFormats.FileDrop ) ); 
                // Only subtitles are allowed. Delete other files from the List. 
                for( int i = 0 ; i < fileNames.Count ; i++ ) 
                { 
                    string filenameLowercase = fileNames.ElementAt( i ).ToLower();
					if( filenameLowercase.IndexOf( ".srt" ) == -1 && filenameLowercase.IndexOf( ".sub" ) == -1 )
					{
						fileNames.RemoveAt( i );
					}
                }

				if( fileNames.Count <= 0 )
				{
					MessageBox.Show( "No subtitles were selected! Please choose only subtitle (.srt & .sub) files.",
									 "Error Encountered" );
				}
				else
				{
					RenameSubtitles( fileNames );
				}
            } 
        } 
 
        private void OnDragEnter( object sender, DragEventArgs e ) 
        { 
            e.Effect = DragDropEffects.Move; 
        } 
    } 
} 