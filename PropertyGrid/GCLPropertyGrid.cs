using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Text;
using System.Collections;

namespace GEV.Layouts.PropertyGrid
{
    public partial class GCLPropertyGrid : UserControl
    {
        protected object m_DataSource;
        public object DataSource
        {
            get
            {
                return this.m_DataSource;
            }

            set
            {
                this.m_DataSource = value;

                if (this.m_DataSource != null)
                {
                    this.BuildGUI();
                }
            }
        }

        private Bitmap m_Bitmap;
        private List<PropertyCategory> m_InternalPropertyData;

        public GCLPropertyGrid()
        {
            InitializeComponent();
        }

        protected void BuildGUI()
        {
            PropertyInfo[] properties = this.m_DataSource.GetType().GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Public);

            var propertyData = properties.GroupBy(prop => prop.GetCustomAttribute<CategoryAttribute>(true))
                                         .Select(group => new { Category = group.First().GetCustomAttribute<CategoryAttribute>(true), Items = group.ToList() })
                                         .ToList();

            this.m_InternalPropertyData = new List<PropertyCategory>();
            foreach(var pd in propertyData)
            {
                string cat = pd.Category != null ? pd.Category.Category : "Egyéb";

                this.m_InternalPropertyData.Add(new PropertyCategory()
                {
                    Name = cat,
                    Collapsed = false,
                    Properties = pd.Items
                });
            }

            this.DrawGUI();
        }

        protected void DrawGUI()
        {
            int height = 0;

            foreach(PropertyCategory pc in this.m_InternalPropertyData)
            {
                height += 31; //Fejlléc

                if(!pc.Collapsed)
                {
                    height += pc.Properties.Count * 30;
                }
            }

            this.m_Bitmap = new Bitmap(this.panel1.Width, height);
            using (Graphics g = Graphics.FromImage(this.m_Bitmap))
            {
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                height = 0;

                StringFormat format = new StringFormat()
                {
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.LineLimit
                };

                foreach (PropertyCategory pc in this.m_InternalPropertyData)
                {
                    this.panel1.Controls.Add(new GCLPropertyGridCategoryPresenter()
                    {
                        Dock = DockStyle.Top,
                        DataSource = this.m_DataSource,
                        Category = pc
                    });

                    //    string collapseChara = pc.Collapsed ? "" : "";
                    //    g.DrawString(collapseChara + "  " + pc.Name.ToUpper(), this.Font, Brushes.Black, new RectangleF(0, height, this.panel1.Width, 30), format);
                    //    height += 30;
                    //    g.DrawLine(Pens.Black, 30, height, this.panel1.Width - 30, height);
                    //    height += 1;

                    //    if (!pc.Collapsed)
                    //    {
                    //        foreach(PropertyInfo property in pc.Properties)
                    //        {
                    //            object obj = property.GetValue(this.m_DataSource);
                    //            g.DrawString(property.Name, this.Font, Brushes.Black, new RectangleF(0, height, this.panel1.Width / 2, 30), format);
                    //            this.DrawPropertyValue(property, g, new RectangleF(this.panel1.Width / 2, height, this.panel1.Width / 2 - 10, 30));
                    //            height += 30;
                    //        }
                    //    }
                    //}
                    //this.pictureBox1.Image = this.m_Bitmap;
                }
            }

        }

        protected void DrawPropertyValue(PropertyInfo prop, Graphics g, RectangleF rect)
        {
            object value = prop.GetValue(this.m_DataSource);
            using (Brush greenBrush = new SolidBrush(Color.FromArgb(0, 170, 70)))
            {
                if (value is ICollection)
                {
                    StringFormat format = new StringFormat()
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Far,
                    };

                    int count = (value as ICollection).Count;

                    SizeF area = g.MeasureString(count.ToString(), this.Font);
                    float w = area.Width + 6;
                    float h = area.Height + 4;
                    RectangleF background = new RectangleF(this.panel1.Width - w - 8, 15 - (h / 2) + rect.Y, w, h);

                    g.DrawString("Collection  " + count, this.Font, Brushes.Black, rect, format);
                    g.FillRectangle(greenBrush, background);
                    g.DrawString(count.ToString(), this.Font, Brushes.White, rect, format);
                }
                else
                {
                    g.DrawString("---", this.Font, Brushes.White, rect);
                }
            }
        }
    }
}
