using AlbumPhoto.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumPhoto.Graphique
{
    public partial class SuperTagsForm : Form
    {
        protected Donnees donnees;

        public SuperTagsForm(Donnees dnn)
        {
            InitializeComponent();
            donnees = dnn;

            try
            {
                if (!donnees.path_folder.Equals("") && File.Exists(donnees.path_folder + "//tags.txt"))
                {
                    using (StreamReader reader = new StreamReader(donnees.path_folder + "//tags.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Length > 1)
                            {

                                int index = line.IndexOf('|');
                                SuperTag newSt = new SuperTag(line.Substring(0, index).Trim());
                                Console.WriteLine(newSt);

                                if (line.Length > index + 1)
                                {
                                    List<string> listetags = line.Substring(index + 1, (line.Length - 1) - (index + 1)).Split(';').ToList();
                                    foreach (string s in listetags)
                                    {
                                        if (!s.Trim().Equals(""))
                                            newSt.addTag(s.Trim());
                                    }
                                }
                                donnees.addSuperTag(newSt);
                            }

                        }
                    }
                }
            }
            catch { }
           

            foreach (SuperTag st in donnees.listeSuperTags)
            {
                treeViewTags.Nodes.Add(st.nomSuperTag);
                foreach (string tag in st.ListeSousTags)
                    treeViewTags.Nodes[treeViewTags.Nodes.Count - 1].Nodes.Add(tag);
            }
        }

        private void buttonAddSuperTag_Click(object sender, EventArgs e)
        {
            if (textBoxSuperTag.Text.Trim() == "" || donnees.getSuperTag(textBoxSuperTag.Text.Trim()) != null)
                return;
            treeViewTags.Nodes.Add(textBoxSuperTag.Text.Trim());
            donnees.addSuperTag(new SuperTag(textBoxSuperTag.Text.Trim()));

        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            if (textBoxTag.Text.Trim() == "" || treeViewTags.SelectedNode == null || (treeViewTags.SelectedNode != null  && donnees.getSuperTag(treeViewTags.SelectedNode.Text).ListeSousTags.Contains(textBoxTag.Text.Trim())))
                return;
            treeViewTags.SelectedNode.Nodes.Add(textBoxTag.Text.Trim());
            donnees.getSuperTag(treeViewTags.SelectedNode.Text).addTag(textBoxTag.Text.Trim());
        }

        private void textBoxSuperTag_Click(object sender, EventArgs e)
        {
            if(textBoxSuperTag.Text.Equals("Ajouter un super tag..."))
                textBoxSuperTag.Text = "";
        }

        private void textBoxTag_Click(object sender, EventArgs e)
        {
            if (textBoxTag.Text.Equals("Assigner un tag à un super tag..."))
                textBoxTag.Text = "";
        }

        private void buttonDelSuperTag_Click(object sender, EventArgs e)
        {
            if (treeViewTags.SelectedNode == null || !treeViewTags.Nodes.Contains(treeViewTags.SelectedNode))
                return;

            donnees.listeSuperTags.Remove( donnees.getSuperTag(treeViewTags.SelectedNode.Text) );
            treeViewTags.SelectedNode.Remove();
        }

        private void buttonDelTag_Click(object sender, EventArgs e)
        {
            if (treeViewTags.SelectedNode == null || !treeViewTags.Nodes.Contains(treeViewTags.SelectedNode.Parent))
                return;

            donnees.getSuperTag(treeViewTags.SelectedNode.Parent.Text).removeTag(treeViewTags.SelectedNode.Text);
            treeViewTags.SelectedNode.Remove();
        }

        private void SuperTagsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!donnees.path_folder.Equals("") && donnees.listeSuperTags.Count>0)
            {
                if (File.Exists(donnees.path_folder + "//tags.txt"))
                {
                    File.Delete(donnees.path_folder + "//tags.txt");
                }
                using (StreamWriter writer = new StreamWriter(donnees.path_folder + "//tags.txt"))
                {
                    
                    foreach (SuperTag st in donnees.listeSuperTags)
                    {
                        writer.Write(st.nomSuperTag.Trim() + "|");
                        foreach (string t in st.ListeSousTags)
                        {
                            writer.Write(t.Trim() + ";");
                        }
                        writer.WriteLine();
                    }
                }
            }
            
        }
    }
}
