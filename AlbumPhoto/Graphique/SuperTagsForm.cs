using AlbumPhoto.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
