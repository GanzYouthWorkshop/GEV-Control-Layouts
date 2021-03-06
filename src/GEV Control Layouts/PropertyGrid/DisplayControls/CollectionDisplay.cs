﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

namespace GEV.Layouts.PropertyGrid.DisplayControls
{
    public partial class CollectionDisplay : UserControl, IDisplayControl
    {
        public CollectionDisplay()
        {
            InitializeComponent();
        }

        public event EventHandler Selected;

        public void ForceValidate()
        {
        }

        public void Setup(object dataSource, PropertyInfo info, object value)
        {
            if(value is ICollection)
            {
                this.label1.Text = (value as ICollection).Count.ToString();
            }
            else
            {
                this.label1.Text = "-";
            }
        }
    }
}
