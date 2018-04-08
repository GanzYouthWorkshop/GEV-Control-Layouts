using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GEV.Layouts.DataGrid
{
    public class GCLDataGrid : DataGridView
    {
        public GCLDataGrid() : base()
        {
            this.BackgroundColor = GCLColors.Shadow;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = GCLColors.SoftBorder;
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RowHeadersVisible = false;
            this.RowTemplate.Height = 24;

            this.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(51, 51, 51),
                Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = GCLColors.PrimaryText,
                Padding = new Padding(3),
                SelectionBackColor = GCLColors.AccentColor1,
                SelectionForeColor = GCLColors.PrimaryText,
                WrapMode = DataGridViewTriState.True,
            };

            this.DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = GCLColors.Button,
                Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = GCLColors.PrimaryText,
                SelectionBackColor = GCLColors.AccentColor1,
                SelectionForeColor = GCLColors.PrimaryText,
                WrapMode = DataGridViewTriState.False,
            };

            this.RowHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(51, 51, 51),
                Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = GCLColors.PrimaryText,
                SelectionBackColor = GCLColors.AccentColor1,
                SelectionForeColor = GCLColors.PrimaryText,
                WrapMode = DataGridViewTriState.True,
            };
        }
    }
}
