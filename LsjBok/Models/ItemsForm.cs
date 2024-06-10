using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQAccounting.Models
{
    public partial class ItemsForm : Form
    {
        private readonly InvoicingContext _context;

        //private static readonly ArticlesForm instance = new ArticlesForm();
        //static ArticlesForm() { }
        //public static ArticlesForm Instance
        //{
        //    get {  return instance; }
        //}
        //private ArticlesForm()
        public ItemsForm()
        {
            InitializeComponent();
            _context = new InvoicingContext();
        }

        private void btnNewArticle_Click(object sender, EventArgs e)
        {
            var form = new AddEditItemForm();
            form.ShowDialog();
        }

        private void btnEditArticle_Click(object sender, EventArgs e)
        {
            if (1 == listView1.SelectedItems.Count)
            {
                var form = new AddEditItemForm((Item)listView1.SelectedItems[0].Tag);
                form.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (1 == listView1.SelectedItems.Count)
            {
                _context.Items.Remove((Item)listView1.SelectedItems[0].Tag);
                _context.SaveChanges();
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void showArticles()
        {
            listView1.Items.Clear();

            foreach (var article in _context.Items)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = article;
                item.Text = article.ItemId.ToString();
                item.SubItems.Add(article.ItemName);
                item.SubItems.Add(article.VAT.ToString() + " %");
                item.SubItems.Add(article.ItemType);
                item.SubItems.Add(article.Unit);
                item.SubItems.Add(article.NetAmount.ToString());
                listView1.Items.Add(item);
            }
        }

        private void ArticlesForm_Activated(object sender, EventArgs e)
        {
            showArticles();

        }

        private void ArticlesForm_Load(object sender, EventArgs e)
        {
            showArticles();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = new AddEditItemForm((Item)listView1.SelectedItems[0].Tag);
            form.ShowDialog();
        }
    }
}
