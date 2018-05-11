using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Docking
{
    public partial class GCLDockingContainer : GCLPanel
    {
        private Control m_dockHost;
        internal DockOverlay Overlay = new DockOverlay();
        public FloatCollection Floaters { get; private set; } = new FloatCollection();

        private void GCLDockingContainer_ControlAdded(object sender, ControlEventArgs e)
        {
            if(e.Control is GCLDockablePanel)
            {
                GCLDockablePanel dp = (GCLDockablePanel)e.Control;

                this.Attach(dp, dp.Header);
            }
        }

        private void GCLDockingContainer_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                this.m_dockHost = this.Parent;
            }
        }


        public GCLDockingContainer(IContainer container)
        {
            container.Add(this);

            this.ControlAdded += GCLDockingContainer_ControlAdded;
            this.ParentChanged += GCLDockingContainer_ParentChanged;

            InitializeComponent();
            this.Padding = new Padding(0);
        }


        /// <summary>
        /// display the container control that is either floating or docked
        /// </summary>
        /// <param name="container"></param>
        public void Show(Control container)
        {
            IFloatingWindow f = this.Floaters.Find(container);
            if (f != null) f.Show();
        }

        /// <summary>
        /// this will gracefully hide the container control
        /// making sure that the floating window is also closed
        /// </summary>
        /// <param name="container"></param>
        public void Hide(Control container)
        {
            IFloatingWindow f = this.Floaters.Find(container);
            if (f != null) f.Hide();
        }

        /// <summary>
        /// Attach a container control and use it as a grip hande. The container must support mouse move events.
        /// </summary>
        /// <param name="container">container to make dockable/floatable</param>
        /// <returns>the floaty that manages the container's behaviour</returns>
        public IFloatingWindow Attach(ScrollableControl container)
        {
            return Attach(container, container, null);
        }

        /// <summary>
        /// Attach a container and a grip handle. The handle must support mouse move events.
        /// </summary>
        /// <param name="container">container to make dockable/floatable</param>
        /// <param name="handle">grip handle used to drag the container</param>
        /// <returns>the floaty that manages the container's behaviour</returns>
        public IFloatingWindow Attach(ScrollableControl container, Control handle)
        {
            return Attach(container, handle, null);
        }

        /// <summary>
        /// attach this class to any dockable type of container control 
        /// to make it dockable.
        /// Attach a container control and use it as a grip hande. The handle must support mouse move events.
        /// Supply a splitter control to allow resizing of the docked container
        /// </summary>
        /// <param name="container">control to be dockable</param>
        /// <param name="handle">handle to be used to track the mouse movement (e.g. caption of the container)</param>
        /// <param name="splitter">splitter to resize the docked container (optional)</param>
        public IFloatingWindow Attach(ScrollableControl container, Control handle, Splitter splitter)
        {
            if (container == null) throw new ArgumentException("container cannot be null");
            if (handle == null) throw new ArgumentException("handle cannot be null");

            DockState dockState = new DockState();
            dockState.Container = container;
            dockState.Handle = handle;
            dockState.OriginalDockHost = m_dockHost;
            dockState.Splitter = splitter;

            FloatingWindow floaty = new FloatingWindow(this);
            floaty.Attach(dockState);
            this.Floaters.Add(floaty);
            return floaty;
        }

        // finds the potential dockhost control at the specified location
        internal Control FindDockHost(FloatingWindow window, Point pt)
        {
            Control c = null;
            if (FormIsHit(window.DockState.OriginalDockHost, pt))
            {
                c = window.DockState.OriginalDockHost; //assume toplevel control
            }
                

            if (window.DockOnHostOnly)
            {
                return c;
            }
                
            foreach (FloatingWindow f in Floaters)
            {
                if (f.DockState.Container.Visible && FormIsHit(f.DockState.Container, pt) && window.Controls[1] != f.DockState.Container)
                {
                    return f.DockState.Container;
                }
            }
            return c;
        }

        // finds the potential dockhost control at the specified location
        internal bool FormIsHit(Control c, Point pt)
        {
            if (c == null) return false;

            Point pc = c.PointToClient(pt);
            bool hit = c.ClientRectangle.IntersectsWith(new Rectangle(pc, new Size(3, 3))); //.TopLevelControl; // this is tricky
            return hit;
        }
    }
}
