using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MiniCAD.Components
{
    public interface IEditableComponent : IComponent
    {
        event EventHandler Click;
        event EventHandler MouseDown;
        event EventHandler MouseUp;
        event EventHandler MouseMove;

        List<SnapPoint> SnapPoints { get; }
        bool Selected { get; set; }
        bool IsEdited { get; set; }
        int EditState { get; set; }

        void Clicked();
        void MousePressedDown();
        void MousePressedUp();
        void MouseMoved();
    }
}
