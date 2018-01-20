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
 
namespace SubtitleBulkRenamer 
{ 
    public partial class MainForm : Form 
    { 
        public MainForm() 
        { 
            InitializeComponent(); 
        } 
 
        private void RenameSubtitles( List< string > subtitleFilenames ) 
        { 
            // Get directory path and subtitle extension type. 
            FileInfo fileInfo  = new FileInfo( subtitleFilenames.First() ); 
            string   filePath  = fileInfo.FullName; 
            string   extension = fileInfo.Extension; 
            string   directory = filePath.Substring( 0, filePath.LastIndexOf( "\\" ) ); 
 
            // Set the directory and get all video files from it so we can iterate through them. 
            Directory.SetCurrentDirectory( directory ); 
            List< string > videoFileNames = new List< string >( Directory.GetFiles( directory, "*.mkv" ) ); 
            if( videoFileNames.Count <= 0 ) // If the video file format is not mkv then it must be mp4. 
			{
                videoFileNames = new List< string >( Directory.GetFiles( directory, "*.mp4" ) );
				if( videoFileNames.Count <= 0 ) // If the video file format is not mkv OR mp4 then signal error and quit.
				{
					MessageBox.Show( "No .mkv or .mp4 files found in directory!", "Error Encountered" );
					Application.Exit();
				}
			}
            
            // Search through video files and sort them based on episode number. 
            Dictionary< int, string > videoFiles = new Dictionary< int, string >(); 
            foreach( string fileName in videoFileNames ) 
            { 
                string sxxexx =  
                    System.Text.RegularExpressions.Regex.Match( fileName.ToLower(), "s\\d\\de\\d\\d" ).Value; 
                if( sxxexx.Length == 0 ) 
                { 
                    MessageBox.Show( "Video file didn't have \"SXXEXX\" format!", "Error Encountered" ); 
                    Application.Exit(); 
                } 
                int episodeNo = ( int )Char.GetNumericValue( sxxexx.ElementAt( 4 ) ) * 10 + 
                                ( int )Char.GetNumericValue( sxxexx.ElementAt( 5 ) ); 
                videoFiles[ episodeNo ] = fileName; 
            } 
 
            // Search through subtitles and sort them based on episode number. 
            Dictionary< int, string > subtitleFiles = new Dictionary< int, string >(); 
            foreach( string fileName in subtitleFilenames ) 
            { 
                string sxxexx =  
                    System.Text.RegularExpressions.Regex.Match( fileName.ToLower(), "s\\d\\de\\d\\d" ).Value; 
                if( sxxexx.Length == 0 ) 
                { 
                    MessageBox.Show( "Subtitle file didn't have \"SXXEXX\" format!", "Error Encountered" ); 
                    Application.Exit(); 
                } 
                int episodeNo = ( int )Char.GetNumericValue( sxxexx.ElementAt( 4 ) ) * 10 + 
                                ( int )Char.GetNumericValue( sxxexx.ElementAt( 5 ) ); 
                subtitleFiles[ episodeNo ] = fileName; 
            } 
 
            int renamedCount = 0, notRenamedCount = 0; 
            // Rename the subtitles based on video file names. 
            foreach( var subtitleFile in subtitleFiles ) 
            { 
                int    episodeNo		   = subtitleFile.Key; 
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
 
            // If execution reached here, no errors so far. Print success message and quit. 
            string successPrompt = "";

			if( renamedCount > 0 )
			{
				successPrompt += renamedCount.ToString() +
								 ( renamedCount > 1 ? " files were renamed!" : " file was renamed!" );
			}
			else
			{
				successPrompt += "No files were renamed!";
			}
			if( notRenamedCount > 0 )
			{
				successPrompt += "\n" + notRenamedCount.ToString() +
								 ( notRenamedCount > 1 ? " files already had correct names!"
													   : " file already had the correct name!" );
			}

            MessageBox.Show( successPrompt, "Renaming Finished Successfully" ); 
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