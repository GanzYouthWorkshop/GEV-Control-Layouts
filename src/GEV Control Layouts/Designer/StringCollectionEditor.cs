using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Designer
{
    public class StringCollectionEditor : CollectionEditor
    {
        public StringCollectionEditor(Type type) : base(type)
        {
        }

        protected override string HelpTopic { get; } = "";

        protected override CollectionForm CreateCollectionForm()
        {
            return new StringCollectionEditorForm(this);
        }

        protected class StringCollectionEditorForm : CollectionForm
        {
            StringCollectionEditorControls controls;

            public StringCollectionEditorForm(CollectionEditor editor) : base(editor)
            {
                this.controls = new StringCollectionEditorControls()
                {
                    Dock = System.Windows.Forms.DockStyle.Fill
                };
                this.Controls.Add(controls);
            }

            protected override void OnEditValueChanged()
            {
                this.Items = this.controls.textBox1.Text.Split('\n');
            }
        }
    }
}
