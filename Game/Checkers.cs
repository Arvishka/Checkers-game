using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Checkers : Form
    {
        private BoardView m_view;
        public Checkers()
        {
            InitializeComponent();
            m_view = new BoardView(this);
            m_view.Location = new Point(0, 0);
            m_view.Size = ClientSize;
            Controls.Add(m_view);
        }
        //Exit button for exit from program. 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //About window
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
            about = null;
        }
        //Rules window
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rules rules = new Rules();
            rules.ShowDialog();
            rules = null;
        }
        //Save the checkers game file
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.InitialDirectory = Directory.GetCurrentDirectory();
            SaveDialog.Filter = "Checkers file (*.sav|*.sav| All files (*.*)|(*,*)";
            SaveDialog.FilterIndex = 1;
            SaveDialog.RestoreDirectory = true;

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream FileVarStream = new FileStream(SaveDialog.FileName, FileMode.Create);
                StreamWriter myStream = new StreamWriter(FileVarStream);
                if ((myStream != null))
                {
                    m_view.saveBoard(FileVarStream);
                    myStream.Close();
                }
            }
        }
        //Load file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            OpenDialog.InitialDirectory = Directory.GetCurrentDirectory();
            OpenDialog.Filter = "Файл Шашек (*.sav)|*.sav|Все файлы (*.*)|*.*";
            OpenDialog.FilterIndex = 1;
            OpenDialog.RestoreDirectory = true;

            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream FileVar = new FileStream(OpenDialog.FileName, FileMode.Open);
                if ((FileVar != null))
                {
                    m_view.loadBoard(FileVar);
                    FileVar.Close();
                }
            }
        }
        //new game with human
        private void newGameWithHumanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int level = m_view.depth;
            m_view.newGame();
            m_view.depth = level;
        }
        //New game wing AI
        private void newGameWithAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nothing. Don't touch this!
        }

        private void Checkers_Load(object sender, EventArgs e)
        {
            //Nothing. Don't touch this!
        }

        private void lowLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int level = m_view.depth;
            m_view.newGameAI();
            m_view.depth = 1;
        }

        private void mediumLevelAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int level = m_view.depth;
            m_view.newGameAI();
            m_view.depth = 3;
        }

        private void hardLevelAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int level = m_view.depth;
            m_view.newGameAI();
            m_view.depth = 5;
        }
    }
    //protected override void OnSizeChanged(EventArgs e)
    //{
    //    base.OnSizeChanged(e);
    //    if (m_view != null)
    //    {
    //        m_view.Size = ClientSize;
    //        m_view.Invalidate();
    //    }
    //}

}